using UnityEngine;

namespace SM.Core
{
    [CreateAssetMenu(menuName = "SM/Zone Config", fileName = "NewZoneConfig")]
    public sealed class ZoneConfigSO : ScriptableObject
    {
        [Header("Identity")]
        [SerializeField] private string _zoneName = "New Zone";
        [SerializeField] private string _flavorText;
        [SerializeField] private int _requiredRank;

        [Header("Gameplay")]
        [SerializeField] private BodyConfigSO[] _bodyTypePool;
        [SerializeField] private float _soulMultiplier = 1f;
        [SerializeField] private int _levelCount = 3;

        [Header("Visuals")]
        [SerializeField] private GameObject _backgroundPrefab;

        [Header("Audio")]
        [SerializeField] private AudioClip _ambientClip;

        public string ZoneName => _zoneName;
        public string FlavorText => _flavorText;
        public int RequiredRank => _requiredRank;
        public BodyConfigSO[] BodyTypePool => _bodyTypePool;
        public float SoulMultiplier => _soulMultiplier;
        public int LevelCount => _levelCount;
        public GameObject BackgroundPrefab => _backgroundPrefab;
        public AudioClip AmbientClip => _ambientClip;
    }
}