using System.Collections.Generic;
using UnityEngine;
using BM.Core;
using BM.Gatherer;

namespace BM.Shaft
{
    public sealed class ShaftManager : MonoBehaviour
    {
        [SerializeField] private Transform _rowParent;
        [SerializeField] private float _rowSpacing = 3f;
        [SerializeField] private PipeNetwork _pipeNetwork;
        [SerializeField] private BodyPool _bodyPool;
        [SerializeField] private GameObject _pipeVisualPrefab;
        [SerializeField] private Ghoul _ghoul;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private BloodManager _bloodManager;
        [SerializeField] private GathererManager _gathererManager;
        [SerializeField] private Transform _surfaceRoot;

        [Header("Minion Visuals")]
        [SerializeField] private GameObject _minionModelPrefab;
        [SerializeField] private RuntimeAnimatorController _minionAnimCtrl;
        [SerializeField] private Material _minionMaterial;

        [Header("Row Backdrops")]
        [SerializeField] private GameObject[] _backdropBlocks;
        [SerializeField] private int _backdropTilesX = 10;
        [SerializeField] private int _backdropTilesY = 3;
        [SerializeField] private int _rowsPerBackdropVariant = 2;
        [SerializeField] private Vector3 _backdropLocalCenter = new Vector3(1f, 0f, -2f);

        [Header("Row Pipe Sides (per row, locked/unlocked)")]
        [SerializeField] private GameObject _pipesSidesLockedPrefab;
        [SerializeField] private GameObject _pipesSidesUnlockedPrefab;
        [SerializeField] private Vector3 _pipesSidesLocalPos = new Vector3(-1.21f, 1.94f, -0.05f);
        [SerializeField] private Vector3 _pipesSidesLocalRot = new Vector3(0f, 90f, 90f);
        [SerializeField] private Vector3 _pipesSidesLocalScale = new Vector3(3f, 3f, 3f);

        [Header("Surface Pipe Connection")]
        [SerializeField] private GameObject _pipesSurfacePrefab;
        [SerializeField] private Vector3 _pipesSurfaceLocalPos = new Vector3(-1.21f, 0.51f, -0.17f);
        [SerializeField] private Vector3 _pipesSurfaceLocalRot = new Vector3(0f, 90f, 90f);
        [SerializeField] private Vector3 _pipesSurfaceLocalScale = new Vector3(3f, 3f, 3f);

        [Header("Balance")]
        [Tooltip("How many rows unlocked per gatherer slot earned (e.g. 5 = slot at rows 5, 10, 15...).")]
        [SerializeField] private int _rowsPerGathererSlot = 5;

        private readonly List<Row> _rows = new List<Row>();
        private int _ghoulRowIndex;
        private int _viewedRowIndex;
        private bool _nextRowUnlocked;
        private int _gathererSlotsAvailable;

        public int GhoulRowIndex => _ghoulRowIndex;
        public int ViewedRowIndex => _viewedRowIndex;
        public int RowCount => _rows.Count;
        public BloodManager BloodManager => _bloodManager;
        public bool CanDescend => _ghoulRowIndex + 1 < _rows.Count;

        public Row ActiveRow => GetRow(_ghoulRowIndex);
        public Row ViewedRow => GetRow(_viewedRowIndex);

        private double GetRowDepthMultiplier(Row row)
        {
            return System.Math.Pow(1.2, row.RowIndex);
        }

        public double GetOutletCost(Row row)
        {
            int purchased = Mathf.Max(0, row.OutletCount - 1);
            return 100 * System.Math.Pow(2, purchased) * GetRowDepthMultiplier(row);
        }

        public double GetMinionCost(Row row)
        {
            return 60 * System.Math.Pow(1.8, row.ChopMinionCount) * GetRowDepthMultiplier(row);
        }

        public bool TryBuyOutlet()
        {
            Row row = ActiveRow;
            if (row == null || row.OutletCount >= row.MaxOutlets) return false;
            double cost = GetOutletCost(row);
            if (_bloodManager == null || !_bloodManager.TrySpend(cost)) return false;
            return row.BuyOutlet();
        }

        public bool TryBuyMinion()
        {
            Row row = ActiveRow;
            if (row == null || row.GetNextUnminionedOutlet() == null) return false;
            double cost = GetMinionCost(row);
            if (_bloodManager == null || !_bloodManager.TrySpend(cost)) return false;
            return row.BuyMinion();
        }

        public double GetAutoButtonCost(Row row)
        {
            return 1600 * GetRowDepthMultiplier(row);
        }

        public bool TryBuyAutoButton()
        {
            Row row = ActiveRow;
            if (row == null || row.HasAutoButton || row.ToolUpgrade == null) return false;
            double cost = GetAutoButtonCost(row);
            if (_bloodManager == null || !_bloodManager.TrySpend(cost)) return false;
            return row.BuyAutoButton();
        }

        public GathererManager GathererMgr => _gathererManager;

        public double GetGathererSpeedCost()
        {
            if (_gathererManager == null) return 0;
            return 500 * System.Math.Pow(4, _gathererManager.SpeedTier - 1);
        }

        public int GathererSlotsAvailable => _gathererSlotsAvailable;
        public bool CanBuyGatherer => _gathererManager != null && _gathererSlotsAvailable > 0 && _gathererManager.Count < 10;

        public double GetGathererCountCost()
        {
            if (_gathererManager == null) return 0;
            return 500 * System.Math.Pow(3, _gathererManager.Count - 1);
        }

        public bool TryBuyGathererSpeed()
        {
            if (_gathererManager == null || _gathererManager.SpeedTier >= 5) return false;
            double cost = GetGathererSpeedCost();
            if (_bloodManager == null || !_bloodManager.TrySpend(cost)) return false;
            _gathererManager.SetSpeedTier(_gathererManager.SpeedTier + 1);
            return true;
        }

        public bool TryBuyGathererCount()
        {
            if (!CanBuyGatherer) return false;
            double cost = GetGathererCountCost();
            if (_bloodManager == null || !_bloodManager.TrySpend(cost)) return false;
            _gathererManager.SetCount(_gathererManager.Count + 1);
            _gathererSlotsAvailable--;
            return true;
        }

        private void Awake()
        {
            _rows.Clear();
            if (_rowParent == null) return;
            _rowParent.GetComponentsInChildren<Row>(true, _rows);
            if (_mainCamera == null) _mainCamera = Camera.main;
            CreateSurfaceMask();
            CreateSurfacePipes();
            // Add backdrop + pipe sides + auto-upgrade button to Row 0 (scene-placed row doesn't go through CreateUpgradeButtonForRow)
            if (_rows.Count > 0)
            {
                Row row0 = _rows[0];
                CreateRowBackdrop(row0);
                CreateRowPipesSides(row0, unlocked: true); // Row 0 is the deepest at start -> end cap visible
                if (row0.ToolUpgrade != null)
                    CreateAutoUpgradeButtonForRow(row0.ToolUpgrade.gameObject, row0);
                CreateEmptyRowBelow(row0);
            }
        }

        private void CreateSurfacePipes()
        {
            if (_surfaceRoot == null || _pipesSurfacePrefab == null) return;
            if (_surfaceRoot.Find("Surface_Pipe_Connection") != null) return;

            GameObject go = Instantiate(_pipesSurfacePrefab, _surfaceRoot);
            go.name = "Surface_Pipe_Connection";
            go.transform.localPosition = _pipesSurfaceLocalPos;
            go.transform.localRotation = Quaternion.Euler(_pipesSurfaceLocalRot);
            go.transform.localScale = _pipesSurfaceLocalScale;
            SetLayerRecursive(go, _surfaceRoot.gameObject.layer);
            foreach (var col in go.GetComponentsInChildren<Collider>())
                Destroy(col);
        }

        private static void SetLayerRecursive(GameObject go, int layer)
        {
            go.layer = layer;
            for (int i = 0; i < go.transform.childCount; i++)
                SetLayerRecursive(go.transform.GetChild(i).gameObject, layer);
        }

        private void CreateSurfaceMask()
        {
            if (_surfaceRoot == null) return;
            if (_surfaceRoot.Find("SurfaceMask") != null) return;

            Color bgColor = _mainCamera != null ? _mainCamera.backgroundColor : new Color(0.07f, 0.05f, 0.07f);
            Material mat = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
            mat.SetColor("_BaseColor", bgColor);

            // Camera at Z=16 looking -Z. Rows at Z=0.
            // Mask at Z=0.5: between camera and rows, occludes rows behind it.
            // Surface content pushed to Z=1: between camera and mask, visible.
            // Quad faces +Z by default (toward camera) -- no rotation needed.
            //
            // Covers local Y=-1.5 to Y=29.5 (from just above active row outlets upward).
            GameObject mask = GameObject.CreatePrimitive(PrimitiveType.Quad);
            mask.name = "SurfaceMask";
            mask.transform.SetParent(_surfaceRoot, false);
            mask.transform.localPosition = new Vector3(1.5f, 19f, 2f);
            mask.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            mask.transform.localScale = new Vector3(40f, 31f, 1f);
            Collider col = mask.GetComponent<Collider>();
            if (col != null) Object.Destroy(col);
            Renderer rend = mask.GetComponent<Renderer>();
            if (rend != null) rend.sharedMaterial = mat;

            // Push all visible surface children in front of the mask (Z=3, closer to camera)
            foreach (Transform child in _surfaceRoot)
            {
                if (child == mask.transform) continue;
                Vector3 pos = child.localPosition;
                pos.z = 3f;
                child.localPosition = pos;
            }
        }

        public Row GetRow(int index)
        {
            if (index < 0 || index >= _rows.Count) return null;
            return _rows[index];
        }

        private void Update()
        {
            if (_rows.Count == 0) return;
            Row activeRow = GetRow(_ghoulRowIndex);
            if (activeRow == null) return;

            if (!_nextRowUnlocked && activeRow.IsFullyBuilt)
            {
                UnlockNextRow();
                _nextRowUnlocked = true;
            }

            var kb = UnityEngine.InputSystem.Keyboard.current;
            if (kb != null)
            {
                if (kb.dKey.wasPressedThisFrame) Descend();
                if (kb.upArrowKey.wasPressedThisFrame) ScrollView(-1);
                if (kb.downArrowKey.wasPressedThisFrame) ScrollView(1);
            }
        }

        public void ScrollView(int direction)
        {
            int target = _viewedRowIndex + direction;
            if (target < 0 || target > _ghoulRowIndex) return;
            _viewedRowIndex = target;

            if (_rowParent != null)
                _rowParent.position = new Vector3(_rowParent.position.x, _viewedRowIndex * _rowSpacing, _rowParent.position.z);

            // Move ghoul to the viewed row so player can interact
            Row viewedRow = GetRow(_viewedRowIndex);
            if (_ghoul != null && viewedRow != null)
            {
                _ghoul.MoveToRow(_viewedRowIndex);
                _ghoul.transform.SetParent(viewedRow.transform, false);
                _ghoul.transform.localPosition = new Vector3(0.24f, 0f, 0f);
            }

            CreateEmptyRowBelow(viewedRow);
        }

        public void UnlockNextRow()
        {
            // Safeguard: don't unlock if we'd end up with more than one row below the ghoul.
            // The only row that should exist beyond the active row is the one just unlocked.
            if (_rows.Count > _ghoulRowIndex + 1)
            {
                Debug.LogWarning("[BM] ShaftManager: UnlockNextRow skipped -- already have row below active (rows=" + _rows.Count + " ghoul=" + _ghoulRowIndex + ")");
                return;
            }
            int newIndex = _rows.Count;
            float yPos = -newIndex * _rowSpacing;

            GameObject rowGO = new GameObject("Row_" + newIndex);
            rowGO.transform.SetParent(_rowParent, false);
            rowGO.transform.localPosition = new Vector3(0f, yPos, 0f);

            Row row = rowGO.AddComponent<Row>();
            row.Init(newIndex, _pipeNetwork, _bodyPool, _pipeVisualPrefab, _bloodManager, 1.39f,
                _minionModelPrefab, _minionAnimCtrl, _minionMaterial);

            CreateRowBackdrop(row);
            CreateRowPipesSides(row, unlocked: true); // new row is now the deepest -> end cap visible
            LeftoversGauge gauge = CreateGaugeForRow(rowGO, row);
            CreateUpgradeButtonForRow(rowGO, row, gauge);

            // Previous row is no longer the deepest -> hide its end cap so the pipe flows through
            Row prevRow = _rows.Count > 0 ? _rows[_rows.Count - 1] : null;
            if (prevRow != null) HideRowEndCap(prevRow);

            RowOutlet firstOutlet = row.AddOutlet();
            _rows.Add(row);

            // Grant a gatherer slot every Nth row unlock (newIndex is the row we just added)
            if (_rowsPerGathererSlot > 0 && newIndex % _rowsPerGathererSlot == 0)
            {
                _gathererSlotsAvailable++;
                Debug.Log("[BM] ShaftManager: +1 gatherer slot available at row " + newIndex + ", total=" + _gathererSlotsAvailable);
            }

            Debug.Log("[BM] ShaftManager: Row_" + newIndex + " unlocked at y=" + yPos + " with 1 outlet");
        }

        public void Descend()
        {
            int nextIndex = _ghoulRowIndex + 1;
            if (nextIndex >= _rows.Count)
            {
                Debug.Log("[BM] ShaftManager: no row below to descend to");
                return;
            }

            _ghoulRowIndex = nextIndex;
            _viewedRowIndex = nextIndex;
            _nextRowUnlocked = false;
            Row nextRow = GetRow(_ghoulRowIndex);

            if (_ghoul != null)
            {
                _ghoul.MoveToRow(_ghoulRowIndex);
                _ghoul.transform.SetParent(nextRow.transform, false);
                _ghoul.transform.localPosition = new Vector3(0.24f, 0f, 0f);
            }

            // Camera stays fixed. Player stays at fixed screen position.
            // Shift the entire [Shaft] parent UP by one row spacing so the next row
            // slides up to where the player is. Completed rows scroll up behind the mask.
            if (_rowParent != null)
            {
                Vector3 shaftPos = _rowParent.position;
                shaftPos.y += _rowSpacing;
                _rowParent.position = shaftPos;
            }

            if (_gathererManager != null) _gathererManager.UpdateUnlockedBodies(_ghoulRowIndex);

            // Place a visual-only empty row below the active row (gauge bar only, no outlets)
            CreateEmptyRowBelow(nextRow);

            Debug.Log("[BM] ShaftManager: descended to Row_" + _ghoulRowIndex);
        }

        private GameObject _emptyRowVisual;

        private void CreateRowBackdrop(Row row)
        {
            if (_backdropBlocks == null || _backdropBlocks.Length == 0) return;

            int variantIdx = Mathf.Clamp(row.RowIndex / Mathf.Max(1, _rowsPerBackdropVariant), 0, _backdropBlocks.Length - 1);
            GameObject blockPrefab = _backdropBlocks[variantIdx];
            if (blockPrefab == null) return;

            GameObject backdropParent = new GameObject("Backdrop");
            backdropParent.transform.SetParent(row.transform, false);
            backdropParent.transform.localPosition = _backdropLocalCenter;

            float halfX = (_backdropTilesX - 1) * 0.5f;
            float halfY = (_backdropTilesY - 1) * 0.5f;

            for (int x = 0; x < _backdropTilesX; x++)
            {
                for (int y = 0; y < _backdropTilesY; y++)
                {
                    GameObject block = Instantiate(blockPrefab, backdropParent.transform);
                    block.name = "Block_" + x + "_" + y;
                    block.transform.localPosition = new Vector3(x - halfX, y - halfY, 0f);
                    block.transform.localRotation = Quaternion.identity;
                    // Strip any colliders so they don't intercept clicks
                    foreach (var col in block.GetComponentsInChildren<Collider>())
                        Destroy(col);
                }
            }
        }

        /// <summary>
        /// Spawns the per-row "pipe sides" visual as a child of the row. `unlocked` controls which
        /// prefab is used (unlocked = pipe continues down; locked = capped off).
        /// Previous sides on this row (if any) are destroyed so callers can swap states.
        /// </summary>
        private void CreateRowPipesSides(Row row, bool unlocked)
        {
            // Scene-placed PipesSides (e.g. Row 0) wins; leave it alone.
            Transform existing = row.transform.Find("PipesSides");
            if (existing != null) return;

            GameObject prefab = unlocked ? _pipesSidesUnlockedPrefab : _pipesSidesLockedPrefab;
            if (prefab == null) return;

            GameObject go = Instantiate(prefab, row.transform);
            go.name = "PipesSides";
            go.transform.localPosition = _pipesSidesLocalPos;
            go.transform.localRotation = Quaternion.Euler(_pipesSidesLocalRot);
            go.transform.localScale = _pipesSidesLocalScale;
            foreach (var col in go.GetComponentsInChildren<Collider>())
                Destroy(col);
        }

        /// <summary>
        /// When a row gets a row below it, it's no longer the deepest — hide its end cap
        /// so the pipe visually continues downward.
        /// </summary>
        private void HideRowEndCap(Row row)
        {
            if (row == null) return;
            Transform sides = row.transform.Find("PipesSides");
            if (sides == null) return;
            Transform endCap = sides.Find("PipeCapRound (2)");
            if (endCap != null) endCap.gameObject.SetActive(false);
        }

        private void CreateEmptyRowBelow(Row activeRow)
        {
            if (_emptyRowVisual != null) Object.Destroy(_emptyRowVisual);

            float belowLocalY = activeRow.transform.localPosition.y - _rowSpacing;
            _emptyRowVisual = new GameObject("EmptyRow_Visual");
            _emptyRowVisual.transform.SetParent(_rowParent, false);
            _emptyRowVisual.transform.localPosition = new Vector3(0f, belowLocalY, 0f);

            // Dark gauge BG only
            GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
            bg.name = "BG";
            bg.transform.SetParent(_emptyRowVisual.transform, false);
            bg.transform.localPosition = new Vector3(1.5f, -0.3f, 0f);
            bg.transform.localScale = new Vector3(6f, 0.1f, 2f);

            Collider col = bg.GetComponent<Collider>();
            if (col != null) Object.Destroy(col);

            Renderer rend = bg.GetComponent<Renderer>();
            if (rend != null)
            {
                Material mat = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
                mat.SetColor("_BaseColor", new Color(0.15f, 0.15f, 0.15f));
                rend.sharedMaterial = mat;
            }
        }

        private LeftoversGauge CreateGaugeForRow(GameObject rowGO, Row row)
        {
            GameObject gaugeGO = new GameObject("LeftoversGauge");
            gaugeGO.transform.SetParent(rowGO.transform, false);
            gaugeGO.transform.localPosition = new Vector3(1.5f, -0.3f, 0f);

            LeftoversGauge gauge = gaugeGO.AddComponent<LeftoversGauge>();

            GameObject bg = GameObject.CreatePrimitive(PrimitiveType.Cube);
            bg.name = "BG";
            bg.transform.SetParent(gaugeGO.transform, false);
            bg.transform.localPosition = Vector3.zero;
            bg.transform.localScale = new Vector3(6f, 0.1f, 2f);

            Renderer bgRend = bg.GetComponent<Renderer>();
            if (bgRend != null)
            {
                Material bgMat = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
                bgMat.SetColor("_BaseColor", new Color(0.15f, 0.15f, 0.15f));
                bgRend.sharedMaterial = bgMat;
            }

            Collider bgCol = bg.GetComponent<Collider>();
            if (bgCol != null) Object.Destroy(bgCol);

            GameObject fill = GameObject.CreatePrimitive(PrimitiveType.Cube);
            fill.name = "Fill";
            fill.transform.SetParent(gaugeGO.transform, false);
            fill.transform.localPosition = new Vector3(-3f, 0.15f, 0f);
            fill.transform.localScale = new Vector3(0f, 0.25f, 2f);

            Renderer fillRend = fill.GetComponent<Renderer>();
            if (fillRend != null)
            {
                Material fillMat = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
                fillMat.SetColor("_BaseColor", new Color(0.7f, 0.1f, 0.1f));
                fillRend.sharedMaterial = fillMat;
            }

            Collider fillCol = fill.GetComponent<Collider>();
            if (fillCol != null) Object.Destroy(fillCol);

            // Glass-top cover so characters appear to stand on the gauge recess
            GameObject glass = GameObject.CreatePrimitive(PrimitiveType.Cube);
            glass.name = "GlassTop";
            glass.transform.SetParent(gaugeGO.transform, false);
            glass.transform.localPosition = new Vector3(0f, 0.265f, 0f);
            glass.transform.localScale = new Vector3(6f, 0.02f, 2f);

            Collider glassCol = glass.GetComponent<Collider>();
            if (glassCol != null) Object.Destroy(glassCol);

            Renderer glassRend = glass.GetComponent<Renderer>();
            if (glassRend != null)
            {
                Material glassMat = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
                // Transparent surface
                glassMat.SetFloat("_Surface", 1f); // 0=Opaque, 1=Transparent
                glassMat.SetFloat("_Blend", 0f); // 0=Alpha
                glassMat.SetFloat("_SrcBlend", (float)UnityEngine.Rendering.BlendMode.SrcAlpha);
                glassMat.SetFloat("_DstBlend", (float)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                glassMat.SetFloat("_ZWrite", 0f);
                glassMat.renderQueue = 3000;
                glassMat.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
                glassMat.DisableKeyword("_ALPHATEST_ON");
                glassMat.SetColor("_BaseColor", new Color(0.6f, 0.7f, 0.8f, 0.25f));
                glassRend.sharedMaterial = glassMat;
            }

            LeftoversGaugeVisual visual = gaugeGO.AddComponent<LeftoversGaugeVisual>();
            System.Reflection.BindingFlags bf = System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance;
            typeof(LeftoversGaugeVisual).GetField("_leftoversGauge", bf).SetValue(visual, gauge);
            typeof(LeftoversGaugeVisual).GetField("_fill", bf).SetValue(visual, fill.transform);

            typeof(Row).GetField("_leftoversGauge", bf).SetValue(row, gauge);
            return gauge;
        }

        private void CreateUpgradeButtonForRow(GameObject rowGO, Row row, LeftoversGauge gauge)
        {
            System.Reflection.BindingFlags bf = System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance;

            GameObject upgradeGO = new GameObject("ToolUpgrade");
            upgradeGO.transform.SetParent(rowGO.transform, false);
            upgradeGO.transform.localPosition = new Vector3(3f, 0.1f, 0f);

            ToolUpgradeController controller = upgradeGO.AddComponent<ToolUpgradeController>();
            typeof(ToolUpgradeController).GetField("_leftoversGauge", bf).SetValue(controller, gauge);
            gauge.OnFilled.AddListener(() =>
            {
                if (controller.OnReady != null) controller.OnReady.Invoke();
            });

            GameObject buttonCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            buttonCube.name = "UpgradeButtonVisual";
            buttonCube.transform.SetParent(upgradeGO.transform, false);
            buttonCube.transform.localPosition = new Vector3(2.13f, 0.5f, 0f);
            buttonCube.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

            Renderer rend = buttonCube.GetComponent<Renderer>();
            if (rend != null)
            {
                Material mat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
                mat.SetColor("_BaseColor", Color.gray);
                rend.sharedMaterial = mat;
            }

            WorldUpgradeButton button = buttonCube.AddComponent<WorldUpgradeButton>();
            typeof(WorldUpgradeButton).GetField("_controller", bf).SetValue(button, controller);
            typeof(WorldUpgradeButton).GetField("_renderer", bf).SetValue(button, rend);

            controller.OnReady.AddListener(() =>
            {
                if (rend == null) return;
                MaterialPropertyBlock mpb = new MaterialPropertyBlock();
                rend.GetPropertyBlock(mpb);
                mpb.SetColor(Shader.PropertyToID("_BaseColor"), Color.red);
                rend.SetPropertyBlock(mpb);
            });
            controller.OnTierChanged.AddListener((tier) =>
            {
                if (rend == null) return;
                MaterialPropertyBlock mpb = new MaterialPropertyBlock();
                rend.GetPropertyBlock(mpb);
                mpb.SetColor(Shader.PropertyToID("_BaseColor"), Color.gray);
                rend.SetPropertyBlock(mpb);
            });

            typeof(Row).GetField("_toolUpgrade", bf).SetValue(row, controller);

            CreateAutoUpgradeButtonForRow(upgradeGO, row);

            Debug.Log("[BM] UpgradeButton + AutoUpgradeButton created for Row_" + row.RowIndex);
        }

        private void CreateAutoUpgradeButtonForRow(GameObject parentGO, Row row)
        {
            System.Reflection.BindingFlags bf = System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance;

            GameObject autoCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            autoCube.name = "AutoUpgradeButton";
            autoCube.transform.SetParent(parentGO.transform, false);
            autoCube.transform.localPosition = new Vector3(2.13f, -0.3f, 0f);
            autoCube.transform.localScale = new Vector3(0.6f, 0.4f, 0.6f);

            Renderer autoRend = autoCube.GetComponent<Renderer>();
            if (autoRend != null)
            {
                Material autoMat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
                autoMat.SetColor("_BaseColor", new Color(0.8f, 0.6f, 0.1f));
                autoRend.sharedMaterial = autoMat;
            }

            WorldAutoUpgradeButton autoBtn = autoCube.AddComponent<WorldAutoUpgradeButton>();
            typeof(WorldAutoUpgradeButton).GetField("_row", bf).SetValue(autoBtn, row);
            typeof(WorldAutoUpgradeButton).GetField("_bloodManager", bf).SetValue(autoBtn, _bloodManager);
            double autoCost = GetAutoButtonCost(row);
            typeof(WorldAutoUpgradeButton).GetField("_cost", bf).SetValue(autoBtn, autoCost);
        }
    }
}
