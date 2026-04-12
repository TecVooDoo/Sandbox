using UnityEngine;
using UnityEngine.Events;

namespace BM.Core
{
    public sealed class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent _gameEvent;
        [SerializeField] private UnityEvent _response;

        private void OnEnable()
        {
            if (_gameEvent != null)
            {
                _gameEvent.RegisterListener(this);
            }
        }

        private void OnDisable()
        {
            if (_gameEvent != null)
            {
                _gameEvent.UnregisterListener(this);
            }
        }

        public void OnEventRaised()
        {
            _response?.Invoke();
        }
    }
}