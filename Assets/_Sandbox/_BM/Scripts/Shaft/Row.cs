using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using BM.Core;

namespace BM.Shaft
{
    public sealed class Row : MonoBehaviour
    {
        [SerializeField] private int _rowIndex;
        [SerializeField] private List<RowOutlet> _outlets = new List<RowOutlet>();
        [SerializeField] private List<RowWorker> _workers = new List<RowWorker>();
        [FormerlySerializedAs("_bloodBar")]
        [SerializeField] private LeftoversGauge _leftoversGauge;
        [SerializeField] private ToolUpgradeController _toolUpgrade;
        [SerializeField] private BloodManager _bloodManager;

        [Header("Outlet Spawning")]
        [SerializeField] private PipeNetwork _pipeNetwork;
        [SerializeField] private BodyPool _bodyPool;
        [SerializeField] private GameObject _pipeVisualPrefab;
        [SerializeField] private float _outletSpacing = 2f;
        [SerializeField] private float _outletHeight = 1.5f;
        [SerializeField] private int _maxOutlets = 4;

        [Header("Minion Visuals")]
        [SerializeField] private GameObject _minionModelPrefab;
        [SerializeField] private RuntimeAnimatorController _minionAnimCtrl;
        [SerializeField] private Material _minionMaterial;

        public int RowIndex => _rowIndex;
        public int OutletCount => _outlets.Count;
        public PipeNetwork PipeNetwork => _pipeNetwork;

        public void Init(int rowIndex, PipeNetwork pipeNetwork, BodyPool bodyPool, GameObject pipeVisualPrefab, BloodManager bloodManager, float outletSpacing = 1.5f,
            GameObject minionModel = null, RuntimeAnimatorController minionAnim = null, Material minionMat = null)
        {
            _rowIndex = rowIndex;
            _pipeNetwork = pipeNetwork;
            _bodyPool = bodyPool;
            _pipeVisualPrefab = pipeVisualPrefab;
            _bloodManager = bloodManager;
            _outletSpacing = outletSpacing;
            _minionModelPrefab = minionModel;
            _minionAnimCtrl = minionAnim;
            _minionMaterial = minionMat;
        }

        public bool BuyOutlet()
        {
            if (_outlets.Count >= _maxOutlets) return false;
            return AddOutlet() != null;
        }

        public bool BuyMinion()
        {
            RowOutlet target = GetNextUnminionedOutlet();
            if (target == null) return false;
            return AddChopMinion(target) != null;
        }
        public bool IsFullyBuilt => _outlets.Count >= _maxOutlets && ChopMinionCount >= _maxOutlets;

        public bool HasAutoButton
        {
            get
            {
                for (int i = 0; i < _workers.Count; i++)
                    if (_workers[i] is AutoButtonMinion) return true;
                return false;
            }
        }

        public bool BuyAutoButton()
        {
            if (HasAutoButton || _toolUpgrade == null) return false;
            return AddAutoButtonMinion() != null;
        }

        public int ChopMinionCount
        {
            get
            {
                int count = 0;
                for (int i = 0; i < _workers.Count; i++)
                {
                    if (_workers[i] is ChopMinion) count++;
                }
                return count;
            }
        }
        public LeftoversGauge LeftoversGauge => _leftoversGauge;
        public ToolUpgradeController ToolUpgrade => _toolUpgrade;
        public int MaxOutlets => _maxOutlets;

        public RowOutlet GetOutlet(int index)
        {
            if (index < 0 || index >= _outlets.Count) return null;
            return _outlets[index];
        }

        public RowOutlet GetNextUnminionedOutlet()
        {
            for (int i = 0; i < _outlets.Count; i++)
            {
                RowOutlet outlet = _outlets[i];
                bool hasMinion = false;
                for (int w = 0; w < _workers.Count; w++)
                {
                    if (_workers[w] is ChopMinion && _workers[w].AssignedOutlet == outlet)
                    {
                        hasMinion = true;
                        break;
                    }
                }
                if (!hasMinion) return outlet;
            }
            return null;
        }

        public void OnChop(float amount)
        {
            float multiplier = _toolUpgrade != null ? 1f + _toolUpgrade.ToolTier : 1f;
            float final = amount * multiplier;
            if (_leftoversGauge != null) _leftoversGauge.Add(final);
            if (_bloodManager != null) _bloodManager.AddBlood(final);
        }

        public RowOutlet AddOutlet()
        {
            if (_outlets.Count >= _maxOutlets) return null;

            int idx = _outlets.Count;
            float xPos = idx * _outletSpacing;

            GameObject outletGO = new GameObject("Outlet_" + idx);
            outletGO.transform.SetParent(transform, false);
            outletGO.transform.localPosition = new Vector3(xPos, _outletHeight, 0f);

            RowOutlet outlet = outletGO.AddComponent<RowOutlet>();
            outlet.Pool = _bodyPool;

            GameObject bodyDrop = new GameObject("BodyDrop");
            bodyDrop.transform.SetParent(outletGO.transform, false);
            bodyDrop.transform.localPosition = new Vector3(0f, -_outletHeight, 0f);

            System.Reflection.FieldInfo spField = typeof(RowOutlet).GetField("_spawnPoint",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            spField.SetValue(outlet, bodyDrop.transform);

            if (_pipeVisualPrefab != null)
            {
                GameObject pv = Instantiate(_pipeVisualPrefab, outletGO.transform);
                pv.name = "PipeVisual";
                pv.transform.localPosition = Vector3.zero;
                pv.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }

            _outlets.Add(outlet);
            if (_pipeNetwork != null) _pipeNetwork.RegisterOutlet(outlet);

            Debug.Log("[BM] Row " + _rowIndex + " AddOutlet idx=" + idx + " pos=" + outletGO.transform.position);
            return outlet;
        }

        public ChopMinion AddChopMinion(RowOutlet outlet)
        {
            if (outlet == null) return null;

            GameObject minionGO = new GameObject("ChopMinion_" + _workers.Count);
            minionGO.transform.SetParent(transform, false);
            minionGO.transform.localPosition = new Vector3(outlet.transform.localPosition.x - 0.8f, 0f, 0f);

            ChopMinion minion = minionGO.AddComponent<ChopMinion>();
            minion.AssignedOutlet = outlet;
            if (_minionModelPrefab != null)
                minion.SetupModel(_minionModelPrefab, _minionAnimCtrl, _minionMaterial);

            _workers.Add(minion);
            Debug.Log("[BM] Row " + _rowIndex + " AddChopMinion for outlet " + outlet.name);
            return minion;
        }

        public AutoButtonMinion AddAutoButtonMinion()
        {
            if (HasAutoButton || _toolUpgrade == null) return null;

            GameObject go = new GameObject("AutoButtonMinion");
            go.transform.SetParent(transform, false);
            // Position near the upgrade button (right side of row)
            go.transform.localPosition = new Vector3(5.5f, 0f, 0f);

            AutoButtonMinion abm = go.AddComponent<AutoButtonMinion>();

            // Wire the target via reflection (serialized field)
            System.Reflection.BindingFlags bf = System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance;
            typeof(AutoButtonMinion).GetField("_target", bf).SetValue(abm, _toolUpgrade);

            // Give it a visual
            if (_minionModelPrefab != null)
            {
                var model = Instantiate(_minionModelPrefab, go.transform);
                model.name = "AutoButtonModel";
                model.transform.localPosition = Vector3.zero;
                model.transform.localRotation = Quaternion.Euler(0f, 270f, 0f);
                model.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

                if (_minionMaterial != null)
                    foreach (var rend in model.GetComponentsInChildren<Renderer>())
                        rend.sharedMaterial = _minionMaterial;
            }

            _workers.Add(abm);
            Debug.Log("[BM] Row " + _rowIndex + " AddAutoButtonMinion");
            return abm;
        }
    }
}
