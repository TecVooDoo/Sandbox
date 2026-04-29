using System.Collections.Generic;
using UnityEngine;
using BM.Core;

namespace BM.Shaft
{
    public sealed class PipeNetwork : MonoBehaviour
    {
        [SerializeField] private Transform _funnelInput;
        [SerializeField] private List<RowOutlet> _registeredOutlets = new List<RowOutlet>();

        private int _nextOutletIndex;

        public int OutletCount => _registeredOutlets.Count;

        public void RegisterOutlet(RowOutlet outlet)
        {
            if (outlet != null && !_registeredOutlets.Contains(outlet))
                _registeredOutlets.Add(outlet);
        }

        public void UnregisterOutlet(RowOutlet outlet)
        {
            _registeredOutlets.Remove(outlet);
        }

        /// <summary>
        /// First paused-outlet index in physical pipe order, or count if none. Outlets at this
        /// index and beyond are cascade-blocked: bodies physically can't traverse a backed-up
        /// section of pipe, so downstream outlets stop receiving until the upstream one drains.
        /// </summary>
        private int FindCascadeBarrier()
        {
            for (int i = 0; i < _registeredOutlets.Count; i++)
            {
                var o = _registeredOutlets[i];
                if (o != null && !o.IsAcceptingBodies) return i;
            }
            return _registeredOutlets.Count;
        }

        /// <summary>Outlets that can actually receive a body right now (un-paused AND upstream of any paused outlet).</summary>
        public int GetAcceptingOutletCount()
        {
            return FindCascadeBarrier();
        }

        private void Update()
        {
            // Drive each outlet's blocked visual based on the cascade barrier:
            // outlets at index >= barrier are either paused themselves or downstream of a paused one.
            int barrier = FindCascadeBarrier();
            for (int i = 0; i < _registeredOutlets.Count; i++)
            {
                RowOutlet o = _registeredOutlets[i];
                if (o == null) continue;
                o.SetBlockedVisual(i >= barrier);
            }
        }

        public bool DeliverBody(BodyConfigSO config)
        {
            if (config == null || _registeredOutlets.Count == 0) return false;

            int barrier = FindCascadeBarrier();
            if (barrier == 0) return false; // outlet 0 paused -> nothing receives

            // Round-robin only among outlets before the cascade barrier.
            for (int step = 0; step < barrier; step++)
            {
                int idx = (_nextOutletIndex + step) % barrier;
                RowOutlet candidate = _registeredOutlets[idx];
                if (candidate != null && candidate.IsAcceptingBodies)
                {
                    candidate.PlaceBody(config);
                    _nextOutletIndex = (idx + 1) % barrier;
                    return true;
                }
            }
            return false;
        }
    }
}
