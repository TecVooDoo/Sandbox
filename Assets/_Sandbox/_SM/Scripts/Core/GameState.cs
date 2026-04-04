using UnityEngine;

namespace SM.Core
{
    public sealed class GameState : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private SoulManager _soulManager;
        [SerializeField] private RankSystem _rankSystem;

        [Header("Zone")]
        [SerializeField] private ZoneConfigSO[] _zones;

        private int _activeZoneIndex;

        public SoulManager SoulManager => _soulManager;
        public RankSystem RankSystem => _rankSystem;
        public int ActiveZoneIndex => _activeZoneIndex;

        public ZoneConfigSO ActiveZone => _zones != null && _activeZoneIndex < _zones.Length
            ? _zones[_activeZoneIndex]
            : null;

        public bool TrySwitchZone(int zoneIndex)
        {
            if (_zones == null || zoneIndex < 0 || zoneIndex >= _zones.Length) return false;

            ZoneConfigSO zone = _zones[zoneIndex];
            if (_rankSystem.CurrentRankIndex < zone.RequiredRank) return false;

            _activeZoneIndex = zoneIndex;
            return true;
        }

        public bool IsZoneUnlocked(int zoneIndex)
        {
            if (_zones == null || zoneIndex < 0 || zoneIndex >= _zones.Length) return false;
            return _rankSystem.CurrentRankIndex >= _zones[zoneIndex].RequiredRank;
        }

        public int ZoneCount => _zones != null ? _zones.Length : 0;
    }
}
