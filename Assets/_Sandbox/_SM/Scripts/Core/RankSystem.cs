using UnityEngine;

namespace SM.Core
{
    public sealed class RankSystem : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private RankConfigSO[] _ranks;

        [Header("Events")]
        [SerializeField] private IntGameEvent _onRankUp;

        [Header("References")]
        [SerializeField] private SoulManager _soulManager;

        private int _currentRankIndex;

        public int CurrentRankIndex => _currentRankIndex;
        public RankConfigSO CurrentRank => _ranks != null && _currentRankIndex < _ranks.Length
            ? _ranks[_currentRankIndex]
            : null;

        public RankConfigSO GetRank(int index)
        {
            if (_ranks == null || index < 0 || index >= _ranks.Length) return null;
            return _ranks[index];
        }

        public int RankCount => _ranks != null ? _ranks.Length : 0;

        private void Update()
        {
            if (_soulManager == null || _ranks == null) return;

            int nextRankIndex = _currentRankIndex + 1;
            if (nextRankIndex >= _ranks.Length) return;

            RankConfigSO nextRank = _ranks[nextRankIndex];
            if (_soulManager.LifetimeSoulsHarvested >= nextRank.SoulThreshold)
            {
                _currentRankIndex = nextRankIndex;

                if (_onRankUp != null)
                    _onRankUp.Raise(_currentRankIndex);
            }
        }

        public void SetRank(int rankIndex)
        {
            if (_ranks == null || rankIndex < 0 || rankIndex >= _ranks.Length) return;
            _currentRankIndex = rankIndex;
        }

        public float GetProgressToNextRank()
        {
            if (_soulManager == null || _ranks == null) return 0f;

            int nextRankIndex = _currentRankIndex + 1;
            if (nextRankIndex >= _ranks.Length) return 1f;

            double currentThreshold = _currentRankIndex > 0
                ? _ranks[_currentRankIndex].SoulThreshold
                : 0;
            double nextThreshold = _ranks[nextRankIndex].SoulThreshold;
            double range = nextThreshold - currentThreshold;

            if (range <= 0) return 1f;

            double progress = _soulManager.LifetimeSoulsHarvested - currentThreshold;
            return Mathf.Clamp01((float)(progress / range));
        }
    }
}