using UnityEngine;
using UnityEngine.Events;

namespace BM.Shaft
{
    public sealed class LeftoversGauge : MonoBehaviour
    {
        [SerializeField] private float _capacity = 100f;
        [SerializeField] private float _current;

        public UnityEvent OnFilled = new UnityEvent();
        public UnityEvent OnEmptied = new UnityEvent();

        public float Capacity => _capacity;
        public float Current => _current;
        public float Normalized => _capacity <= 0f ? 0f : _current / _capacity;
        public bool IsFull => _current >= _capacity;

        public void Add(float amount)
        {
            if (amount <= 0f) return;
            _current = Mathf.Min(_capacity, _current + amount);
            if (IsFull && OnFilled != null) OnFilled.Invoke();
        }

        public void Empty()
        {
            _current = 0f;
            if (OnEmptied != null) OnEmptied.Invoke();
        }

        public void SetCapacity(float newCapacity)
        {
            _capacity = Mathf.Max(1f, newCapacity);
        }
    }
}
