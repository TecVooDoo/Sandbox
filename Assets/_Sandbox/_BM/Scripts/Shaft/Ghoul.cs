using UnityEngine;

namespace BM.Shaft
{
    public sealed class Ghoul : RowWorker
    {
        [SerializeField] private int _currentRowIndex;
        [SerializeField] private float _walkSpeed = 2.5f;
        [SerializeField] private float _arriveDistance = 0.15f;
        [SerializeField] private float _chopReach = 0.5f;

        private Animator _animator;
        private RowOutlet _targetOutlet;
        private bool _walking;

        private static readonly int _animIsWalking = Animator.StringToHash("IsWalking");
        private static readonly int _animAttack = Animator.StringToHash("Attack");

        public int CurrentRowIndex => _currentRowIndex;
        public bool IsWalking => _walking;

        protected override void Awake()
        {
            base.Awake();
            _animator = GetComponentInChildren<Animator>();
        }

        public void MoveToRow(int rowIndex)
        {
            _currentRowIndex = rowIndex;
        }

        public void GoToOutlet(RowOutlet outlet)
        {
            if (outlet == null) return;
            _targetOutlet = outlet;
            _walking = true;
            if (_animator != null) _animator.SetBool(_animIsWalking, true);
        }

        private void Update()
        {
            if (!_walking || _targetOutlet == null) return;

            Vector3 bodyPos = _targetOutlet.SpawnPoint.position;
            Vector3 ghoulPos = transform.position;

            float dirX = bodyPos.x - ghoulPos.x;
            float stopOffset = dirX > 0 ? -_chopReach : _chopReach;

            Vector3 goal = new Vector3(bodyPos.x + stopOffset, ghoulPos.y, bodyPos.z);

            if (Vector3.Distance(transform.position, goal) > _arriveDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, goal, _walkSpeed * Time.deltaTime);
                return;
            }

            _walking = false;
            if (_animator != null)
            {
                _animator.SetBool(_animIsWalking, false);
                _animator.SetTrigger(_animAttack);
            }
            _assignedOutlet = _targetOutlet;
            _targetOutlet = null;
            Chop();
        }
    }
}
