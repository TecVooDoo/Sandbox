using System.Collections.Generic;
using UnityEngine;

namespace SM.Core
{
    public abstract class GameEvent<T> : ScriptableObject
    {
        private readonly List<IGameEventListener<T>> _listeners = new List<IGameEventListener<T>>();

        public void Raise(T value)
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised(value);
            }
        }

        public void RegisterListener(IGameEventListener<T> listener)
        {
            if (!_listeners.Contains(listener))
            {
                _listeners.Add(listener);
            }
        }

        public void UnregisterListener(IGameEventListener<T> listener)
        {
            _listeners.Remove(listener);
        }
    }

    public interface IGameEventListener<T>
    {
        void OnEventRaised(T value);
    }

    [CreateAssetMenu(menuName = "SM/Game Event (Double)", fileName = "NewDoubleEvent")]
    public sealed class DoubleGameEvent : GameEvent<double> { }

    [CreateAssetMenu(menuName = "SM/Game Event (Int)", fileName = "NewIntEvent")]
    public sealed class IntGameEvent : GameEvent<int> { }
}