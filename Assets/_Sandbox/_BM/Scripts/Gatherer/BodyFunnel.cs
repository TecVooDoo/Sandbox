using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BM.Core;
using BM.Shaft;

namespace BM.Gatherer
{
    public sealed class BodyFunnel : MonoBehaviour
    {
        [SerializeField] private PipeNetwork _pipeNetwork;
        [SerializeField] private Transform _dropPoint;
        [SerializeField] private float _baseTickInterval = 2f;

        public UnityEvent OnBodyAccepted;
        public UnityEvent OnBodyDispatched;

        private readonly Queue<BodyConfigSO> _queue = new Queue<BodyConfigSO>();
        private float _tickTimer;

        public Transform DropPoint => _dropPoint;
        public int QueueCount => _queue.Count;

        public void AcceptBody(BodyConfigSO config)
        {
            if (config == null) { Debug.LogWarning("[BM] Funnel.AcceptBody NULL config"); return; }
            _queue.Enqueue(config);
            Debug.Log("[BM] Funnel accept " + config.name + " queue=" + _queue.Count);
            if (OnBodyAccepted != null) OnBodyAccepted.Invoke();
        }

        private void Update()
        {
            if (_pipeNetwork == null || _queue.Count == 0) return;

            int clear = _pipeNetwork.GetClearOutletCount();
            if (clear <= 0)
            {
                _tickTimer = 0f;
                return;
            }

            float interval = _baseTickInterval / clear;
            _tickTimer += Time.deltaTime;
            if (_tickTimer >= interval)
            {
                _tickTimer = 0f;
                BodyConfigSO next = _queue.Dequeue();
                Debug.Log("[BM] Funnel tick dispatch " + next.name + " clearOutlets=" + clear);
                if (_pipeNetwork.DeliverBody(next))
                {
                    Debug.Log("[BM] Funnel dispatch SUCCESS");
                    if (OnBodyDispatched != null) OnBodyDispatched.Invoke();
                }
                else
                {
                    Debug.LogWarning("[BM] Funnel dispatch FAILED, re-queuing");
                    _queue.Enqueue(next);
                }
            }
        }
    }
}
