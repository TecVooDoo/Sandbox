using UnityEngine;
using UnityEngine.InputSystem;

namespace BM.Shaft
{
    public sealed class Ghoul : RowWorker
    {
        [SerializeField] private int _currentRowIndex;
        [SerializeField] private float _walkSpeed = 2.5f;
        [Tooltip("Horizontal hit radius for Swing(). Body must be within this many world units of the Ghoul's X to be chopped.")]
        [SerializeField] private float _chopReach = 1.2f;

        [Header("Movement Bounds (local X on row)")]
        [SerializeField] private float _minLocalX = -1.5f;
        [SerializeField] private float _maxLocalX = 4.7f;

        [Header("Swing")]
        [Tooltip("Cooldown between swings, regardless of whether anything was hit.")]
        [SerializeField] private float _swingCooldown = 0.45f;

        private Animator _animator;
        private Transform _model;
        private float _swingTimer;
        private bool _walking;
        // +1 = facing world +X (screen-left under mirrored camera), -1 = facing world -X (screen-right).
        // Player movement (A/D) sets this; Swing() respects it -- the ghoul never auto-pivots toward a body.
        private int _facingDir = -1;

        private static readonly int _animIsWalking = Animator.StringToHash("IsWalking");
        private static readonly int _animAttack = Animator.StringToHash("Attack");

        public int CurrentRowIndex => _currentRowIndex;
        public bool IsWalking => _walking;

        protected override void Awake()
        {
            base.Awake();
            _animator = GetComponentInChildren<Animator>();
            if (_animator != null) _animator.applyRootMotion = false;
            if (transform.childCount > 0) _model = transform.GetChild(0);
        }

        public void MoveToRow(int rowIndex, Row newRow = null)
        {
            _currentRowIndex = rowIndex;
            // _row is cached in RowWorker.Awake(). When ShaftManager.Descend reparents us under a
            // new row, the cached reference is otherwise stale and Swing() searches the old row's
            // outlets (which are empty after descend). Caller passes the new Row; if not, fall back
            // to a parent walk.
            if (newRow != null) _row = newRow;
            else _row = GetComponentInParent<Row>();
        }

        private void Update()
        {
            if (_swingTimer > 0f) _swingTimer -= Time.deltaTime;

            // Camera is rotated 180° around Y, so world +X appears LEFT on screen and -X appears RIGHT.
            // Map A/Left → screen-left (which is world +X) and D/Right → screen-right (world -X).
            var kb = Keyboard.current;
            float axis = 0f;
            if (kb != null)
            {
                if (kb.aKey.isPressed || kb.leftArrowKey.isPressed) axis += 1f;
                if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) axis -= 1f;
            }
            // Up/Down arrows are reserved for ScrollView in ShaftManager — don't treat them as movement.

            bool moving = Mathf.Abs(axis) > 0.01f;
            if (moving)
            {
                Vector3 lp = transform.localPosition;
                lp.x = Mathf.Clamp(lp.x + axis * _walkSpeed * Time.deltaTime, _minLocalX, _maxLocalX);
                transform.localPosition = lp;

                // Player input is authoritative for facing. Y=90 faces world +X (screen-left), Y=270 faces world -X (screen-right).
                _facingDir = axis > 0f ? 1 : -1;
                if (_model != null)
                    _model.localRotation = Quaternion.Euler(0f, _facingDir > 0 ? 90f : 270f, 0f);
            }

            SetWalking(moving);
        }

        /// <summary>
        /// Player swing input. Plays the attack anim and, if a body sits within reach of the Ghoul's
        /// current X on its row, chops it. Otherwise just swings into air (foreshadows future
        /// damageable-minion AoE — see BM_Status "Queued / Design Decisions").
        /// </summary>
        public void Swing()
        {
            DoSwing();
        }

        /// <summary>
        /// Player swing with click position. Turns the ghoul to face the side the player clicked
        /// (relative to the ghoul's screen position) and then swings on that side. Lets the player
        /// stand between two outlets and hit whichever one they click without using A/D.
        /// </summary>
        public void SwingAt(Vector2 screenPosition, Camera cam)
        {
            if (cam != null)
            {
                Vector3 ghoulScreen = cam.WorldToScreenPoint(transform.position);
                float dx = screenPosition.x - ghoulScreen.x;
                if (Mathf.Abs(dx) > 1f)
                {
                    // Camera is rotated 180° around Y. Click on screen-right -> world -X (_facingDir = -1).
                    // Click on screen-left -> world +X (_facingDir = +1).
                    _facingDir = dx > 0f ? -1 : 1;
                    if (_model != null)
                        _model.localRotation = Quaternion.Euler(0f, _facingDir > 0 ? 90f : 270f, 0f);
                }
            }
            DoSwing();
        }

        private void DoSwing()
        {
            if (_swingTimer > 0f) return;
            _swingTimer = _swingCooldown;

            // Always swing in the ghoul's current facing direction. If a body is in front and
            // within reach, hit it. If not, swing into air.
            if (_animator != null) _animator.SetTrigger(_animAttack);

            RowOutlet target = FindOutletInFront();
            if (target == null) return;
            _assignedOutlet = target;
            Chop();
        }

        private RowOutlet FindOutletInFront()
        {
            if (_row == null) return null;
            float ghoulX = transform.position.x;
            RowOutlet best = null;
            float bestDist = _chopReach;
            for (int i = 0; i < _row.OutletCount; i++)
            {
                RowOutlet outlet = _row.GetOutlet(i);
                if (outlet == null || outlet.IsClear) continue;
                Transform sp = outlet.SpawnPoint != null ? outlet.SpawnPoint : outlet.transform;
                float signed = sp.position.x - ghoulX;
                // Body must be on the side we're facing. _facingDir +1 = looking at world +X (signed > 0).
                if (signed * _facingDir < 0f) continue;
                float d = Mathf.Abs(signed);
                if (d <= bestDist)
                {
                    bestDist = d;
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
    }
}
