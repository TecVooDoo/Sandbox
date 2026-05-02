using System.Collections;
using UnityEngine;
using BM.Core;

namespace BM.Shaft
{
    public abstract class RowWorker : MonoBehaviour
    {
        [SerializeField] protected RowOutlet _assignedOutlet;
        [SerializeField] protected float _chopAmount = 10f;
        [SerializeField] protected float _chopImpactDelay = 0.3f;
        [Tooltip("If true, the body skips Whole→TwoPiece and consumes on the first hit (FourPiece + organs + outlet release fire immediately). Ghoul = always true; ChopMinion = true only when equipped with a chainsaw-tier weapon.")]
        [SerializeField] protected bool _oneShotKill = false;
        public bool OneShotKill { get => _oneShotKill; set => _oneShotKill = value; }

        [Header("Chop VFX")]
        [Tooltip("Optional blood splat / burst prefab spawned at the body position when the chop lands.")]
        [SerializeField] protected GameObject _bloodSplatPrefab;
        [SerializeField] protected Vector3 _bloodSplatLocalOffset = Vector3.zero;
        [SerializeField] protected Vector3 _bloodSplatLocalEuler = Vector3.zero;
        [SerializeField] protected float _bloodSplatScale = 1f;
        [SerializeField] protected float _bloodSplatLifetime = 1.5f;

        protected Row _row;

        public RowOutlet AssignedOutlet { get => _assignedOutlet; set => _assignedOutlet = value; }
        public Row Row => _row;
        public GameObject BloodSplatPrefab { get => _bloodSplatPrefab; set => _bloodSplatPrefab = value; }

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

            // If the body is a SliceableBody, dispatch through it. The body owns its own
            // hit FX (blood splat + explosion + flying pieces + organs), so the worker's
            // legacy splat is suppressed in that path. Outlet only releases on the final
            // hit (Hit 2 = organs spawn), and Row.OnChop only fires on the final hit so
            // total gauge fill per body matches the legacy single-chop behavior.
            GameObject body = outlet.CurrentBody;
            SliceableBody slice = body != null ? body.GetComponent<SliceableBody>() : null;
            if (slice != null)
            {
                Vector3 swingDir = transform.forward;
                bool consumed = slice.Hit(swingDir, _oneShotKill);
                if (consumed)
                {
                    outlet.ConsumeBody();
                    if (_row != null) _row.OnChop(_chopAmount * bodyValue);
                }
                yield break;
            }

            // Legacy single-chop path for bodies without SliceableBody.
            SpawnBloodSplat(outlet);
            outlet.ConsumeBody();
            if (_row != null) _row.OnChop(_chopAmount * bodyValue);
        }

        private void SpawnBloodSplat(RowOutlet outlet)
        {
            if (_bloodSplatPrefab == null || outlet == null) return;
            Transform anchor = outlet.SpawnPoint != null ? outlet.SpawnPoint : outlet.transform;
            GameObject splat = Instantiate(_bloodSplatPrefab, anchor);
            splat.transform.localPosition = _bloodSplatLocalOffset;
            splat.transform.localRotation = Quaternion.Euler(_bloodSplatLocalEuler);
            splat.transform.localScale = Vector3.one * _bloodSplatScale;
            if (_bloodSplatLifetime > 0f) Destroy(splat, _bloodSplatLifetime);
        }
    }
}
