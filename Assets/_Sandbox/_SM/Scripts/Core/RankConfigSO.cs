using UnityEngine;

namespace SM.Core
{
    [CreateAssetMenu(menuName = "SM/Rank Config", fileName = "NewRankConfig")]
    public sealed class RankConfigSO : ScriptableObject
    {
        [Header("Identity")]
        [SerializeField] private int _rankIndex;
        [SerializeField] private string _title = "Soul Minor";
        [SerializeField, TextArea(2, 5)] private string _promotionLetterText;

        [Header("Requirements")]
        [SerializeField] private double _soulThreshold;

        [Header("Unlocks")]
        [SerializeField] private int _unlocksZoneIndex = -1;

        [Header("Visuals")]
        [SerializeField] private GameObject _characterPrefab;

        public int RankIndex => _rankIndex;
        public string Title => _title;
        public string PromotionLetterText => _promotionLetterText;
        public double SoulThreshold => _soulThreshold;
        public int UnlocksZoneIndex => _unlocksZoneIndex;
        public GameObject CharacterPrefab => _characterPrefab;
    }
}