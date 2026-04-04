using UnityEngine;
using SM.Core;

namespace SM.Mine
{
    public sealed class ZoneInitializer : MonoBehaviour, IGameEventListener<double>
    {
        [Header("Zone")]
        [SerializeField] private ZoneConfigSO _zoneConfig;

        [Header("Mine Levels")]
        [SerializeField] private MineLevel[] _mineLevels;

        [Header("Elevator -> Warehouse")]
        [SerializeField] private Elevator _elevator;
        [SerializeField] private Warehouse _warehouse;
        [SerializeField] private DoubleGameEvent _onSoulDelivered;

        private void Start()
        {
            if (_zoneConfig == null) return;

            BodyConfigSO[] bodyPool = _zoneConfig.BodyTypePool;

            for (int i = 0; i < _mineLevels.Length; i++)
            {
                if (_mineLevels[i] != null)
                    _mineLevels[i].Initialize(bodyPool);
            }
        }

        private void OnEnable()
        {
            if (_onSoulDelivered != null)
                _onSoulDelivered.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (_onSoulDelivered != null)
                _onSoulDelivered.UnregisterListener(this);
        }

        public void OnEventRaised(double amount)
        {
            if (_warehouse != null)
                _warehouse.ReceiveSouls(amount);
        }
    }
}