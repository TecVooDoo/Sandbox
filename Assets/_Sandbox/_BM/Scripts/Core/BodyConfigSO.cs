using UnityEngine;

namespace BM.Core
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

    [CreateAssetMenu(menuName = "BM/Body Config", fileName = "NewBodyConfig")]
    public sealed class BodyConfigSO : ScriptableObject
    {
        [Header("Identity")]
        [SerializeField] private BodyType _bodyType;
        [SerializeField] private double _baseBloodValue = 1;
        [SerializeField] private int _carryTierRequired = 1;
        [SerializeField] private int _unlockRow = 1;

        [Header("Visuals")]
        [SerializeField] private GameObject _bodyPrefab;
        [SerializeField] private GameObject _gorePrefab;
        [SerializeField] private Color _particleColor = Color.red;
        [SerializeField] private GameObject[] _bodyPartPrefabs;

        [Header("Audio")]
        [SerializeField] private AudioClip _harvestSound;

        public BodyType BodyType => _bodyType;
        public double BaseBloodValue => _baseBloodValue;
        public int CarryTierRequired => _carryTierRequired;
        public int UnlockRow => _unlockRow;
        public GameObject BodyPrefab => _bodyPrefab;
        public GameObject GorePrefab => _gorePrefab;
        public Color ParticleColor => _particleColor;
        public GameObject[] BodyPartPrefabs => _bodyPartPrefabs;
        public AudioClip HarvestSound => _harvestSound;
    }
}