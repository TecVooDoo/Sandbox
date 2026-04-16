using UnityEngine;

namespace BM.Shaft
{
    public sealed class AutoButtonMinion : RowWorker
    {
        [SerializeField] private ToolUpgradeController _target;
        [SerializeField] private float _pressDelay = 0.25f;

        private float _timer;

        private void Update()
        {
            if (_target == null || !_target.IsReady) return;
            _timer += Time.deltaTime;
            if (_timer >= _pressDelay)
            {
                _timer = 0f;
                _target.TryUpgrade();
            }
        }
    }
}
