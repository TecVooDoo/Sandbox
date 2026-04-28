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
        [SerializeField] private float _outletSpacing = 1.39f;
        [SerializeField] private float _outletHeight = 1.5f;
        [SerializeField] private int _maxOutlets = 4;
        [SerializeField] private int _maxChopMinions = 2;

        [Header("Outlet Pipe Kit Transform")]
        [SerializeField] private Vector3 _outletKitLocalPos = new Vector3(-0.63f, -0.14f, -0.01f);
        [SerializeField] private Vector3 _outletKitLocalEuler = new Vector3(90f, 0f, 0f);
        [SerializeField] private Vector3 _outletKitLocalScale = new Vector3(3f, 3f, 3f);

        [Header("Worker Placement")]
        [Tooltip("X offset from outlet where ChopMinion stands (negative = to the left).")]
        [SerializeField] private float _minionXOffset = -1.15f;
        [Tooltip("X offset from outlet where body drops / spawns (typical: -0.6 to line up with pipe kit).")]
        [SerializeField] private float _bodyDropXOffset = -0.6f;

        private readonly List<GameObject> _pipesOutletKits = new List<GameObject>();

        [Header("Minion Visuals")]
        [SerializeField] private GameObject _minionModelPrefab;
        [SerializeField] private RuntimeAnimatorController _minionAnimCtrl;
        [SerializeField] private Material _minionMaterial;

        [Header("Chop VFX")]
        [Tooltip("Blood splat prefab applied to runtime-spawned ChopMinions.")]
        [SerializeField] private GameObject _bloodSplatPrefab;

        public int RowIndex => _rowIndex;
        public int OutletCount => _outlets.Count;
        public PipeNetwork PipeNetwork => _pipeNetwork;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (!Application.isPlaying) return;
            for (int w = 0; w < _workers.Count; w++)
            {
                var wk = _workers[w];
                if (wk == null) continue;
                if (wk is ChopMinion cm && cm.AssignedOutlet != null)
                {
                    Vector3 p = cm.transform.localPosition;
                    p.x = cm.AssignedOutlet.transform.localPosition.x + _minionXOffset;
                    cm.transform.localPosition = p;
                }
            }
            for (int i = 0; i < _outlets.Count; i++)
            {
                var outlet = _outlets[i];
                if (outlet == null) continue;
                var bd = outlet.transform.Find("BodyDrop");
                if (bd != null)
                {
                    Vector3 p = bd.localPosition;
                    p.x = _bodyDropXOffset;
                    bd.localPosition = p;
                }
            }
        }
#endif

        private void Awake()
        {
            for (int i = 0; i < _outlets.Count; i++)
            {
                if (_outlets[i] == null) continue;
                Transform kit = _outlets[i].transform.Find("PipesOutletKit");
                if (kit == null)
                {
                    Transform legacy = _outlets[i].transform.Find("PipeVisual");
                    if (legacy != null) Destroy(legacy.gameObject);
                    if (_pipeVisualPrefab != null)
                    {
                        GameObject pv = Instantiate(_pipeVisualPrefab, _outlets[i].transform);
                        pv.name = "PipesOutletKit";
                        pv.transform.localPosition = _outletKitLocalPos;
                        pv.transform.localRotation = Quaternion.Euler(_outletKitLocalEuler);
                        pv.transform.localScale = _outletKitLocalScale;
                        kit = pv.transform;
                    }
                }
                if (kit != null) _pipesOutletKits.Add(kit.gameObject);
            }
            UpdateOutletCaps();
        }

        public void Init(int rowIndex, PipeNetwork pipeNetwork, BodyPool bodyPool, GameObject pipeVisualPrefab, BloodManager bloodManager, float outletSpacing = 1.39f,
            GameObject minionModel = null, RuntimeAnimatorController minionAnim = null, Material minionMat = null,
            GameObject bloodSplatPrefab = null)
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
            if (bloodSplatPrefab != null) _bloodSplatPrefab = bloodSplatPrefab;
        }

        public bool BuyOutlet()
        {
            if (_outlets.Count >= _maxOutlets) return false;
            return AddOutlet() != null;
        }

        public bool BuyMinion()
        {
            if (ChopMinionCount >= _maxChopMinions) return false;
            return AddChopMinion() != null;
        }
        public bool CanBuyMinion => ChopMinionCount < _maxChopMinions;
        public int MaxChopMinions => _maxChopMinions;
        /// <summary>4 outlets + 1 minion. Triggers next-row unlock.</summary>
        public bool IsUnlockReady => _outlets.Count >= _maxOutlets && ChopMinionCount >= 1;
        /// <summary>4 outlets + 2 minions (second minion is a luxury purchase, not required to progress).</summary>
        public bool IsComplete => _outlets.Count >= _maxOutlets && ChopMinionCount >= _maxChopMinions;

        /// <summary>
        /// True if another ChopMinion in this row is already targeting this outlet.
        /// Used by ChopMinion target selection to prevent two minions racing the same body.
        /// </summary>
        public bool IsOutletClaimedByMinion(RowOutlet outlet, ChopMinion except)
        {
            if (outlet == null) return false;
            for (int i = 0; i < _workers.Count; i++)
            {
                if (_workers[i] is ChopMinion cm && cm != except && cm.Target == outlet)
                    return true;
            }
            return false;
        }

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
            bodyDrop.transform.localPosition = new Vector3(_bodyDropXOffset, -_outletHeight, 0f);

            System.Reflection.FieldInfo spField = typeof(RowOutlet).GetField("_spawnPoint",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            spField.SetValue(outlet, bodyDrop.transform);

            if (_pipeVisualPrefab != null)
            {
                GameObject pv = Instantiate(_pipeVisualPrefab, outletGO.transform);
                pv.name = "PipesOutletKit";
                pv.transform.localPosition = _outletKitLocalPos;
                pv.transform.localRotation = Quaternion.Euler(_outletKitLocalEuler);
                pv.transform.localScale = _outletKitLocalScale;
                _pipesOutletKits.Add(pv);
            }

            _outlets.Add(outlet);
            if (_pipeNetwork != null) _pipeNetwork.RegisterOutlet(outlet);

            UpdateOutletCaps();

            Debug.Log("[BM] Row " + _rowIndex + " AddOutlet idx=" + idx + " pos=" + outletGO.transform.position);
            return outlet;
        }

        private void UpdateOutletCaps()
        {
            for (int i = 0; i < _pipesOutletKits.Count; i++)
            {
                bool isLast = (i == _pipesOutletKits.Count - 1);
                SetKitLastState(_pipesOutletKits[i], isLast);
            }
        }

        private static void SetKitLastState(GameObject kit, bool isLast)
        {
            if (kit == null) return;
            Transform through = kit.transform.Find("PipeCapWhole (2)");
            Transform end = kit.transform.Find("PipeCapRound (3)");
            if (end == null) end = kit.transform.Find("PipeCapRound");
            if (through != null) through.gameObject.SetActive(!isLast);
            if (end != null) end.gameObject.SetActive(isLast);
        }

        public ChopMinion AddChopMinion()
        {
            if (ChopMinionCount >= _maxChopMinions) return null;

            // Spawn each minion next to a different outlet column so they don't pile up at start.
            int minionIdx = ChopMinionCount;
            RowOutlet spawnRef = minionIdx < _outlets.Count ? _outlets[minionIdx] : (_outlets.Count > 0 ? _outlets[0] : null);
            float spawnX = spawnRef != null ? spawnRef.transform.localPosition.x + _minionXOffset : 0f;

            GameObject minionGO = new GameObject("ChopMinion_" + _workers.Count);
            minionGO.transform.SetParent(transform, false);
            minionGO.transform.localPosition = new Vector3(spawnX, 0f, 0f);

            ChopMinion minion = minionGO.AddComponent<ChopMinion>();
            if (_minionModelPrefab != null)
                minion.SetupModel(_minionModelPrefab, _minionAnimCtrl, _minionMaterial);
            if (_bloodSplatPrefab != null) minion.BloodSplatPrefab = _bloodSplatPrefab;

            _workers.Add(minion);
            Debug.Log("[BM] Row " + _rowIndex + " AddChopMinion (#" + ChopMinionCount + "/" + _maxChopMinions + ")");
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
