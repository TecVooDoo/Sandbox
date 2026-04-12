using UnityEngine;

namespace BM.Shaft
{
    public sealed class Ghoul : RowWorker
    {
        [SerializeField] private int _currentRowIndex;
        [SerializeField] private float _walkSpeed = 2.5f;
        [SerializeField] private float _arriveDistance = 0.15f;
        [SerializeField] private float _patrolChopInterval = 0.5f;

        private int _patrolTargetIndex;
        private float _patrolCooldown;
        private bool _patrolActive;

        public int CurrentRowIndex => _currentRowIndex;
        public bool PatrolActive => _patrolActive;

        public void MoveToRow(int rowIndex)
        {
            _currentRowIndex = rowIndex;
            _patrolTargetIndex = 0;
            _patrolCooldown = 0f;
        }

        private void Update()
        {
            if (_row == null) return;

            int outletCount = _row.OutletCount;
            _patrolActive = outletCount > 1;
            if (!_patrolActive) return;

            RowOutlet target = _row.GetOutlet(_patrolTargetIndex % outletCount);
            if (target == null) return;

            Vector3 goal = target.transform.position;
            goal.y = transform.position.y;

            if (Vector3.Distance(transform.position, goal) > _arriveDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, goal, _walkSpeed * Time.deltaTime);
                return;
            }

            _assignedOutlet = target;

            _patrolCooldown -= Time.deltaTime;
            if (_patrolCooldown <= 0f)
            {
                _patrolCooldown = _patrolChopInterval;
                Chop();
                _patrolTargetIndex = (_patrolTargetIndex + 1) % outletCount;
            }
        }
    }
}
