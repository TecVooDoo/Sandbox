using UnityEngine;

namespace BM.Shaft
{
    public abstract class RowWorker : MonoBehaviour
    {
        [SerializeField] protected RowOutlet _assignedOutlet;
        [SerializeField] protected float _chopAmount = 10f;

        protected Row _row;

        public RowOutlet AssignedOutlet => _assignedOutlet;
        public Row Row => _row;

        protected virtual void Awake()
        {
            _row = GetComponentInParent<Row>();
        }

        public virtual void Chop()
        {
            if (_row != null) _row.OnChop(_chopAmount);
        }
    }
}
