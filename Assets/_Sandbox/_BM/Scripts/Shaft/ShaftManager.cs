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

        [Header("Minion Visuals")]
        [SerializeField] private GameObject _minionModelPrefab;
        [SerializeField] private RuntimeAnimatorController _minionAnimCtrl;
        [SerializeField] private Material _minionMaterial;

        private readonly List<Row> _rows = new List<Row>();
        private int _ghoulRowIndex;
        private bool _nextRowUnlocked;
        private int _gathererSlotsAvailable;

        public int GhoulRowIndex => _ghoulRowIndex;
        public int RowCount => _rows.Count;
        public BloodManager BloodManager => _bloodManager;
        public bool CanDescend => _ghoulRowIndex + 1 < _rows.Count;

        public Row ActiveRow => GetRow(_ghoulRowIndex);

        private double GetRowDepthMultiplier(Row row)
        {
            return 1.0 + row.RowIndex * 0.1;
        }

        public double GetOutletCost(Row row)
        {
            int purchased = Mathf.Max(0, row.OutletCount - 1);
            return 50 * System.Math.Pow(2, purchased) * GetRowDepthMultiplier(row);
        }

        public double GetMinionCost(Row row)
        {
            return 30 * System.Math.Pow(1.8, row.ChopMinionCount) * GetRowDepthMultiplier(row);
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

        public GathererManager GathererMgr => _gathererManager;

        public double GetGathererSpeedCost()
        {
            if (_gathererManager == null) return 0;
            return 100 * System.Math.Pow(3, _gathererManager.SpeedTier - 1);
        }

        public int GathererSlotsAvailable => _gathererSlotsAvailable;
        public bool CanBuyGatherer => _gathererManager != null && _gathererSlotsAvailable > 0 && _gathererManager.Count < 10;

        public double GetGathererCountCost()
        {
            if (_gathererManager == null) return 0;
            return 80 * System.Math.Pow(2, _gathererManager.Count - 1);
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

            if (UnityEngine.InputSystem.Keyboard.current != null
                && UnityEngine.InputSystem.Keyboard.current.dKey.wasPressedThisFrame)
            {
                Descend();
            }
        }

        public void UnlockNextRow()
        {
            int newIndex = _rows.Count;
            float yPos = -newIndex * _rowSpacing;

            GameObject rowGO = new GameObject("Row_" + newIndex);
            rowGO.transform.SetParent(_rowParent, false);
            rowGO.transform.localPosition = new Vector3(0f, yPos, 0f);

            Row row = rowGO.AddComponent<Row>();
            row.Init(newIndex, _pipeNetwork, _bodyPool, _pipeVisualPrefab, _bloodManager, 1.5f,
                _minionModelPrefab, _minionAnimCtrl, _minionMaterial);

            LeftoversGauge gauge = CreateGaugeForRow(rowGO, row);
            CreateUpgradeButtonForRow(rowGO, row, gauge);

            RowOutlet firstOutlet = row.AddOutlet();
            _rows.Add(row);

            _gathererSlotsAvailable++;
            Debug.Log("[BM] ShaftManager: +1 gatherer slot available, total=" + _gathererSlotsAvailable);

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
            _nextRowUnlocked = false;
            Row nextRow = GetRow(_ghoulRowIndex);

            if (_ghoul != null)
            {
                _ghoul.MoveToRow(_ghoulRowIndex);
                _ghoul.transform.SetParent(nextRow.transform, false);
                _ghoul.transform.localPosition = new Vector3(-1f, 0.65f, 0f);
            }

            if (_mainCamera != null)
            {
                // Single camera: pan down to keep active row visible
                // Center camera between surface (y=4.5) and active row, clamping so active row stays in view
                float activeRowY = nextRow.transform.position.y;
                float surfaceY = 4.5f;
                float camY = (surfaceY + activeRowY) * 0.5f + 1f;
                // Don't let camera go too high (surface only visible when rows are shallow)
                float minCamY = activeRowY + 2f;
                if (camY < minCamY) camY = minCamY;
                Vector3 camPos = _mainCamera.transform.position;
                camPos.x = 2f;
                camPos.y = camY;
                _mainCamera.transform.position = camPos;
            }

            if (_gathererManager != null) _gathererManager.UpdateUnlockedBodies(_ghoulRowIndex);

            Debug.Log("[BM] ShaftManager: descended to Row_" + _ghoulRowIndex);
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

            Debug.Log("[BM] UpgradeButton created for Row_" + row.RowIndex);
        }
    }
}
