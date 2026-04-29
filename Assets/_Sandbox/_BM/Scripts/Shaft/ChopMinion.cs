using UnityEngine;

namespace BM.Shaft
{
    public sealed class ChopMinion : RowWorker
    {
        [SerializeField] private float _chopInterval = 1f;
        [SerializeField] private float _modelYRotation = 90f;
        [Header("Movement")]
        [SerializeField] private float _walkSpeed = 2.0f;
        [SerializeField] private float _arriveDistance = 0.15f;
        [SerializeField] private float _chopReach = 0.7f;

        private float _chopTimer;
        private Animator _animator;
        private Transform _model;
        private RowOutlet _target;
        private bool _walking;
        private static readonly int _animAttack = Animator.StringToHash("Attack");
        private static readonly int _animIsWalking = Animator.StringToHash("IsWalking");

        public RowOutlet Target => _target;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_model != null)
                _model.localRotation = Quaternion.Euler(0f, _modelYRotation, 0f);
        }
#endif

        protected override void Awake()
        {
            base.Awake();
            _animator = GetComponentInChildren<Animator>();
            if (_animator != null) _animator.applyRootMotion = false;
            else CreatePlaceholderVisual();
        }

        public void SetupModel(GameObject modelPrefab, RuntimeAnimatorController animCtrl, Material mat)
        {
            if (modelPrefab == null) return;
            Transform placeholder = transform.Find("MinionVisual");
            if (placeholder != null) Destroy(placeholder.gameObject);
            var model = Instantiate(modelPrefab, transform);
            model.name = "MinionModel";
            model.transform.localPosition = Vector3.zero;
            model.transform.localRotation = Quaternion.Euler(0f, _modelYRotation, 0f);
            model.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            _model = model.transform;
            SetLayerRecursive(model, gameObject.layer);

            if (mat != null)
                foreach (var rend in model.GetComponentsInChildren<Renderer>())
                    rend.sharedMaterial = mat;

            _animator = model.GetComponent<Animator>();
            if (_animator == null) _animator = model.AddComponent<Animator>();
            if (animCtrl != null) _animator.runtimeAnimatorController = animCtrl;
            _animator.applyRootMotion = false;
        }

        private static void SetLayerRecursive(GameObject go, int layer)
        {
            go.layer = layer;
            for (int i = 0; i < go.transform.childCount; i++)
                SetLayerRecursive(go.transform.GetChild(i).gameObject, layer);
        }

        private void Update()
        {
            // Release target if it got consumed (including by our own chop via ConsumeBody).
            if (_target != null && _target.IsClear) _target = null;

            // Find a new target if idle.
            if (_target == null)
            {
                _target = FindNearestUnclaimedOutletWithBody();
                if (_target == null)
                {
                    SetWalking(false);
                    return;
                }
            }

            // Walk toward the body drop, stopping _chopReach away.
            Vector3 bodyPos = _target.SpawnPoint.position;
            Vector3 myPos = transform.position;
            float dirX = bodyPos.x - myPos.x;
            float stopOffset = dirX > 0 ? -_chopReach : _chopReach;
            Vector3 goal = new Vector3(bodyPos.x + stopOffset, myPos.y, bodyPos.z);

            if (Vector3.Distance(transform.position, goal) > _arriveDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, goal, _walkSpeed * Time.deltaTime);
                // Face movement direction (model default faces -X/270, so +X needs 90).
                if (_model != null)
                    _model.localRotation = Quaternion.Euler(0f, dirX > 0 ? 90f : 270f, 0f);
                SetWalking(true);
                _chopTimer = 0f;
                return;
            }

            SetWalking(false);

            // Even when we don't walk this frame (already at goal), face the body before chopping
            // so a re-pick to a target on the opposite side doesn't chop the air.
            if (_model != null)
            {
                float targetDirX = bodyPos.x - transform.position.x;
                if (Mathf.Abs(targetDirX) > 0.001f)
                    _model.localRotation = Quaternion.Euler(0f, targetDirX > 0f ? 90f : 270f, 0f);
            }

            _chopTimer += Time.deltaTime;
            if (_chopTimer >= _chopInterval)
            {
                _chopTimer = 0f;
                if (_animator != null) _animator.SetTrigger(_animAttack);
                _assignedOutlet = _target; // Chop() reads this
                Chop();
            }
        }

        private RowOutlet FindNearestUnclaimedOutletWithBody()
        {
            if (_row == null) return null;
            RowOutlet best = null;
            float bestDist = float.MaxValue;
            for (int i = 0; i < _row.OutletCount; i++)
            {
                RowOutlet outlet = _row.GetOutlet(i);
                if (outlet == null || outlet.IsClear) continue;
                if (_row.IsOutletClaimedByMinion(outlet, this)) continue;
                float dist = Mathf.Abs(outlet.transform.position.x - transform.position.x);
                if (dist < bestDist)
                {
                    bestDist = dist;
                    best = outlet;
                }
            }
            return best;
        }

        private void SetWalking(bool walking)
        {
            if (_walking == walking) return;
            _walking = walking;
            if (_animator != null) _animator.SetBool(_animIsWalking, walking);
        }

        private void CreatePlaceholderVisual()
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name = "MinionVisual";
            cube.transform.SetParent(transform, false);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

            Renderer rend = cube.GetComponent<Renderer>();
            if (rend != null)
            {
                Material mat = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
                mat.SetColor("_BaseColor", new Color(0.2f, 0.8f, 0.2f));
                rend.sharedMaterial = mat;
            }

            Collider col = cube.GetComponent<Collider>();
            if (col != null) Destroy(col);
        }
    }
}
