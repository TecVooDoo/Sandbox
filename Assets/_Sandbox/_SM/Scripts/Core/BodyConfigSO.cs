using UnityEngine;

namespace SM.Core
{
    public enum BodyType
    {
        Cat,
        Dog,
        Pig,
        Sheep,
        Rabbit,
        Chicken,
        Cow
    }

    [CreateAssetMenu(menuName = "SM/Body Config", fileName = "NewBodyConfig")]
    public sealed class BodyConfigSO : ScriptableObject
    {
        [Header("Identity")]
        [SerializeField] private BodyType _bodyType;
        [SerializeField] private double _baseSoulValue = 1;

        [Header("Visuals")]
        [SerializeField] private GameObject _bodyPrefab;
        [SerializeField] private GameObject _gorePrefab;
        [SerializeField] private Color _particleColor = Color.red;
        [SerializeField] private GameObject[] _bodyPartPrefabs;

        [Header("Audio")]
        [SerializeField] private AudioClip _harvestSound;

        public BodyType BodyType => _bodyType;
        public double BaseSoulValue => _baseSoulValue;
        public GameObject BodyPrefab => _bodyPrefab;
        public GameObject GorePrefab => _gorePrefab;
        public Color ParticleColor => _particleColor;
        public GameObject[] BodyPartPrefabs => _bodyPartPrefabs;
        public AudioClip HarvestSound => _harvestSound;
    }
}