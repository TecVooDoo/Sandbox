using System.Collections.Generic;
using UnityEngine;

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

        private readonly List<Row> _rows = new List<Row>();
        private int _ghoulRowIndex;
        private bool _nextRowUnlocked;

        public int GhoulRowIndex => _ghoulRowIndex;
        public int RowCount => _rows.Count;

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

            if (UnityEngine.InputSystem.Keyboard.current != null)
            {
                if (UnityEngine.InputSystem.Keyboard.current.oKey.wasPressedThisFrame)
                {
                    RowOutlet newOutlet = activeRow.AddOutlet();
                    if (newOutlet != null)
                        Debug.Log("[BM] ShaftManager: outlet added, total=" + activeRow.OutletCount);
                    else
                        Debug.Log("[BM] ShaftManager: outlet at max (" + activeRow.MaxOutlets + ")");
                }

                if (UnityEngine.InputSystem.Keyboard.current.mKey.wasPressedThisFrame)
                {
                    RowOutlet target = activeRow.GetNextUnminionedOutlet();
                    if (target != null)
                    {
                        ChopMinion minion = activeRow.AddChopMinion(target);
                        if (minion != null)
                            Debug.Log("[BM] ShaftManager: minion added for " + target.name);
                    }
                    else
                    {
                        Debug.Log("[BM] ShaftManager: all outlets have minions");
                    }
                }

                if (UnityEngine.InputSystem.Keyboard.current.dKey.wasPressedThisFrame)
                {
                    Descend();
                }
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
            row.Init(newIndex, _pipeNetwork, _bodyPool, _pipeVisualPrefab);

            LeftoversGauge gauge = CreateGaugeForRow(rowGO, row);
            CreateUpgradeButtonForRow(rowGO, row, gauge);

            RowOutlet firstOutlet = row.AddOutlet();
            _rows.Add(row);

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
                _ghoul.transform.localPosition = new Vector3(0f, 0.65f, 0f);
            }

            if (_mainCamera != null)
            {
                Vector3 camPos = _mainCamera.transform.position;
                camPos.y = nextRow.transform.position.y + 2.2f;
                _mainCamera.transform.position = camPos;
                _mainCamera.transform.LookAt(nextRow.transform.position + new Vector3(0f, 1f, 0f));
            }

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
            buttonCube.transform.localPosition = Vector3.zero;
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
