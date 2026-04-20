using System.Collections;
using UnityEngine;
using BM.Core;

namespace BM.Shaft
{
    public abstract class RowWorker : MonoBehaviour
    {
        [SerializeField] protected RowOutlet _assignedOutlet;
        [SerializeField] protected float _chopAmount = 10f;
        [SerializeField] protected float _chopImpactDelay = 0.7f;

        protected Row _row;

        public RowOutlet AssignedOutlet { get => _assignedOutlet; set => _assignedOutlet = value; }
        public Row Row => _row;

        protected virtual void Awake()
        {
            _row = GetComponentInParent<Row>();
        }

        /// <summary>
        /// Starts the chop: plays animation (via subclass) and schedules the body consumption
        /// at the animation's impact frame so the body doesn't vanish before the swing lands.
        /// </summary>
        public virtual void Chop()
        {
            if (_assignedOutlet == null || _assignedOutlet.IsClear) return;
            StartCoroutine(ChopImpactRoutine(_assignedOutlet));
        }

        private IEnumerator ChopImpactRoutine(RowOutlet outlet)
        {
            yield return new WaitForSeconds(_chopImpactDelay);
            if (outlet == null || outlet.IsClear) yield break;
            float bodyValue = 1f;
            BodyConfigSO config = outlet.CurrentConfig;
            if (config != null) bodyValue = (float)config.BaseBloodValue;
            outlet.ConsumeBody();
            if (_row != null) _row.OnChop(_chopAmount * bodyValue);
        }
    }
}
