using System.Collections.Generic;
using UnityEngine;

namespace BM.Core
{
    [CreateAssetMenu(menuName = "BM/Organ Pool", fileName = "OrganPool")]
    public sealed class OrganPool : ScriptableObject
    {
        [SerializeField] private GameObject[] _smallOrgans;
        [SerializeField] private GameObject[] _largeOrgans;

        public IReadOnlyList<GameObject> SmallOrgans => _smallOrgans;
        public IReadOnlyList<GameObject> LargeOrgans => _largeOrgans;

        public GameObject PickRandom(OrganSize size)
        {
            GameObject[] arr = size == OrganSize.Large ? _largeOrgans : _smallOrgans;
            if (arr == null || arr.Length == 0) return null;
            return arr[Random.Range(0, arr.Length)];
        }
    }
}
