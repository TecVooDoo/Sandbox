using UnityEngine;
using BM.Core;

namespace BM.Gatherer
{
    public sealed class Gatherer : MonoBehaviour
    {
        private enum State
        {
            WalkingToPickup,
            Gathering,
            WalkingToDrop,
            Dropping
        }

        [SerializeField] private BodyFunnel _funnel;
        [SerializeField] private GathererManager _manager;
        [SerializeField] private Transform _pickupPoint;
        [SerializeField] private Transform _dropPoint;
        [SerializeField] private float _walkSpeed = 1.5f;
        [SerializeField] private float _pickupDelay = 0.4f;
        [SerializeField] private int _carryTier = 1;

        private State _state;
        private float _stateTimer;
        private BodyConfigSO _currentCarry;

        public int CarryTier { get => _carryTier; set => _carryTier = Mathf.Max(1, value); }
        public float WalkSpeed { get => _walkSpeed; set => _walkSpeed = Mathf.Max(0f, value); }
        public BodyConfigSO CurrentCarry => _currentCarry;

        public void Configure(GathererManager manager, BodyFunnel funnel, Transform pickup, Transform drop)
        {
            _manager = manager;
            _funnel = funnel;
            _pickupPoint = pickup;
            _dropPoint = drop;
            _state = State.WalkingToPickup;
            _stateTimer = 0f;
            _currentCarry = null;
        }

        private void Update()
        {
            if (_pickupPoint == null || _dropPoint == null) return;

            switch (_state)
            {
                case State.WalkingToPickup:
                    if (WalkTowards(_pickupPoint.position)) _state = State.Gathering;
                    break;
                case State.Gathering:
                    _stateTimer += Time.deltaTime;
                    if (_stateTimer >= _pickupDelay)
                    {
                        _stateTimer = 0f;
                        if (_manager != null) _currentCarry = _manager.PickRandomBody(_carryTier);
                        _state = _currentCarry != null ? State.WalkingToDrop : State.WalkingToPickup;
                    }
                    break;
                case State.WalkingToDrop:
                    if (WalkTowards(_dropPoint.position)) _state = State.Dropping;
                    break;
                case State.Dropping:
                    if (_funnel != null && _currentCarry != null)
                    {
                        Debug.Log("[BM] Gatherer drop " + _currentCarry.name);
                        _funnel.AcceptBody(_currentCarry);
                    }
                    else
                    {
                        Debug.LogWarning("[BM] Gatherer drop SKIPPED funnel=" + (_funnel != null) + " carry=" + (_currentCarry != null));
                    }
                    _currentCarry = null;
                    _state = State.WalkingToPickup;
                    break;
            }
        }

        private bool WalkTowards(Vector3 goal)
        {
            Vector3 flatGoal = new Vector3(goal.x, transform.position.y, goal.z);
            transform.position = Vector3.MoveTowards(transform.position, flatGoal, _walkSpeed * Time.deltaTime);
            return Vector3.Distance(transform.position, flatGoal) < 0.05f;
        }
    }
}
