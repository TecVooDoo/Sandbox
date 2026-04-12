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

        public int GetClearOutletCount()
        {
            int count = 0;
            for (int i = 0; i < _registeredOutlets.Count; i++)
            {
                RowOutlet o = _registeredOutlets[i];
                if (o != null && o.IsClear) count++;
            }
            return count;
        }

        public bool DeliverBody(BodyConfigSO config)
        {
            if (config == null || _registeredOutlets.Count == 0) return false;
            for (int step = 0; step < _registeredOutlets.Count; step++)
            {
                int idx = (_nextOutletIndex + step) % _registeredOutlets.Count;
                RowOutlet candidate = _registeredOutlets[idx];
                if (candidate != null && candidate.IsClear)
                {
                    candidate.PlaceBody(config);
                    _nextOutletIndex = (idx + 1) % _registeredOutlets.Count;
                    return true;
                }
            }
            return false;
        }
    }
}
