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

        [Header("Weapon")]
        [Tooltip("Weapon prop attached to the minion's hand.r bone (e.g. Skeleton_Dagger). Optional.")]
        [SerializeField] private GameObject _weaponPrefab;
        [Tooltip("Material applied to weapon renderers (typically Mat_Skeleton). Optional.")]
        [SerializeField] private Material _weaponMaterial;

        public GameObject WeaponPrefab { get => _weaponPrefab; set => _weaponPrefab = value; }
        public Material WeaponMaterial { get => _weaponMaterial; set => _weaponMaterial = value; }

        [Header("Damageable")]
        [Tooltip("Time the minion stays offline (in DeathPose) after the death anim finishes, before reviving.")]
        [SerializeField] private float _deadDuration = 3f;
        [Tooltip("Length of the death anim (Skeletons_Death). Hold a minimum before checking for revive.")]
        [SerializeField] private float _deathAnimLength = 2f;
        [Tooltip("Length of the resurrect anim (Skeletons_Death_Resurrect). Resume Active when it finishes.")]
        [SerializeField] private float _resurrectAnimLength = 2.7f;

        private enum LifeState { Active, Dying, Dead, Reviving }
        private LifeState _life = LifeState.Active;
        private float _lifeTimer;

        private float _chopTimer;
        private Animator _animator;
        private Transform _model;
        private RowOutlet _target;
        private bool _walking;
        private static readonly int _animAttack = Animator.StringToHash("Attack");
        private static readonly int _animIsWalking = Animator.StringToHash("IsWalking");
        private static readonly int _animDeath = Animator.StringToHash("Death");
        private static readonly int _animRevive = Animator.StringToHash("Revive");

        public RowOutlet Target => _life == LifeState.Active ? _target : null;
        public bool IsAlive => _life == LifeState.Active;

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

            AttachWeapon(model.transform);
        }

        private void AttachWeapon(Transform modelRoot)
        {
            if (_weaponPrefab == null || modelRoot == null) return;
            // KayKit Rig_Medium hierarchy: model > Rig_Medium > root > hips > spine > chest > upperarm.r > lowerarm.r > wrist.r > hand.r > handslot.r
            // Parent to handslot.r (not hand.r) -- handslot is authored with the correct grip rotation
            // for KayKit weapons. Resetting the weapon transform under handslot lines it up perfectly.
            // Falls back to hand.r if handslot.r is missing (non-KayKit rig).
            Transform attach = FindChildByName(modelRoot, "handslot.r");
            if (attach == null) attach = FindChildByName(modelRoot, "hand.r");
            if (attach == null) return;
            var weapon = Instantiate(_weaponPrefab, attach);
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;
            weapon.transform.localScale = Vector3.one;
            if (_weaponMaterial != null)
                foreach (var rend in weapon.GetComponentsInChildren<Renderer>())
                    rend.sharedMaterial = _weaponMaterial;
        }

        private static Transform FindChildByName(Transform root, string name)
        {
            if (root.name == name) return root;
            for (int i = 0; i < root.childCount; i++)
            {
                var found = FindChildByName(root.GetChild(i), name);
                if (found != null) return found;
            }
            return null;
        }

        private static void SetLayerRecursive(GameObject go, int layer)
        {
            go.layer = layer;
            for (int i = 0; i < go.transform.childCount; i++)
                SetLayerRecursive(go.transform.GetChild(i).gameObject, layer);
        }

        /// <summary>
        /// Take a hit from the Ghoul. Triggers the death anim, releases the outlet, and stays offline
        /// for _deathAnimLength + _deadDuration seconds before reviving (Skeletons_Death_Resurrect plays
        /// then state returns to Active). No-op if already dying/dead/reviving.
        /// </summary>
        public void Hit()
        {
            if (_life != LifeState.Active) return;
            _life = LifeState.Dying;
            _lifeTimer = _deathAnimLength;
            _target = null; // release outlet so other minions can claim it
            _chopTimer = 0f;
            SetWalking(false);
            if (_animator != null) _animator.SetTrigger(_animDeath);
        }

        private void Update()
        {
            // Damageable lifecycle: when not Active, tick lifecycle timers and skip normal AI.
            if (_life != LifeState.Active)
            {
                TickLifecycle();
                return;
            }

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

        private void TickLifecycle()
        {
            _lifeTimer -= Time.deltaTime;
            if (_lifeTimer > 0f) return;

            switch (_life)
            {
                case LifeState.Dying:
                    // Death anim has played; enter the offline pose for _deadDuration before reviving.
                    _life = LifeState.Dead;
                    _lifeTimer = _deadDuration;
                    break;
                case LifeState.Dead:
                    // Time's up. Fire the Revive trigger; controller transitions DeathPose -> Resurrect.
                    _life = LifeState.Reviving;
                    _lifeTimer = _resurrectAnimLength;
                    if (_animator != null) _animator.SetTrigger(_animRevive);
                    break;
                case LifeState.Reviving:
                    // Resurrect anim done; back to normal duty.
                    _life = LifeState.Active;
                    break;
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
