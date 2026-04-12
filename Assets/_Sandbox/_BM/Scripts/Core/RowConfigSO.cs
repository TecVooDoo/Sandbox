using UnityEngine;

namespace BM.Core
{
    [CreateAssetMenu(fileName = "RowConfig", menuName = "Blood Miner/Row Config")]
    public sealed class RowConfigSO : ScriptableObject
    {
        [SerializeField] private int _depth;
        [SerializeField] private float _baseBodyRate = 1f;
        [SerializeField] private double _baseBloodMultiplier = 1.0;
        [SerializeField] private BodyConfigSO[] _unlockBodyTypes;

        public int Depth => _depth;
        public float BaseBodyRate => _baseBodyRate;
        public double BaseBloodMultiplier => _baseBloodMultiplier;
        public BodyConfigSO[] UnlockBodyTypes => _unlockBodyTypes;
    }
}
