using System.Collections.Generic;
using UnityEngine;
using BM.Core;

namespace BM.Gatherer
{
    public sealed class GathererManager : MonoBehaviour
    {
        [SerializeField] private Gatherer _gathererPrefab;
        [SerializeField] private Transform _spawnParent;
        [SerializeField] private BodyFunnel _funnel;
        [SerializeField] private Transform _pickupPoint;
        [SerializeField] private Transform _dropPoint;
        [SerializeField] private BodyConfigSO[] _allBodies;
        [SerializeField] private int _count = 1;
        [SerializeField] private int _speedTier = 1;
        [SerializeField] private int _defaultCarryTier = 1;
        [SerializeField] private float _baseSpeed = 1.5f;
        [SerializeField] private float _speedPerTier = 0.5f;
        [SerializeField] private float _spawnStagger = 0.35f;

        private readonly List<Gatherer> _gatherers = new List<Gatherer>();
        private readonly List<BodyConfigSO> _filterBuffer = new List<BodyConfigSO>();
        private readonly List<BodyConfigSO> _unlockedBodies = new List<BodyConfigSO>();
        private int _currentRowDepth;

        public int Count => _count;
        public int SpeedTier => _speedTier;
        public BodyFunnel Funnel => _funnel;

        public void SetCount(int count)
        {
            _count = Mathf.Clamp(count, 0, 10);
            SyncGatherers();
        }

        public void SetSpeedTier(int tier)
        {
            _speedTier = Mathf.Max(1, tier);
            ApplySpeedToAll();
        }

        public void UpdateUnlockedBodies(int currentRowDepth)
        {
            _currentRowDepth = currentRowDepth;
            _unlockedBodies.Clear();
            if (_allBodies == null) return;
            for (int i = 0; i < _allBodies.Length; i++)
            {
                if (_allBodies[i] != null && _allBodies[i].UnlockRow <= currentRowDepth + 1)
                    _unlockedBodies.Add(_allBodies[i]);
            }
            Debug.Log("[BM] GathererManager: " + _unlockedBodies.Count + " body types unlocked at row depth " + currentRowDepth);
        }

        public BodyConfigSO PickRandomBody(int carryTierLimit)
        {
            if (_unlockedBodies.Count == 0) return null;
            _filterBuffer.Clear();
            for (int i = 0; i < _unlockedBodies.Count; i++)
            {
                BodyConfigSO body = _unlockedBodies[i];
                if (body != null && body.CarryTierRequired <= carryTierLimit)
                    _filterBuffer.Add(body);
            }
            if (_filterBuffer.Count == 0) return null;
            return _filterBuffer[Random.Range(0, _filterBuffer.Count)];
        }

        private void Awake()
        {
            UpdateUnlockedBodies(0);
            SyncGatherers();
        }

        private void SyncGatherers()
        {
            while (_gatherers.Count < _count) SpawnOne();
            while (_gatherers.Count > _count) DespawnOne();
            ApplySpeedToAll();
        }

        private void SpawnOne()
        {
            if (_gathererPrefab == null || _pickupPoint == null || _dropPoint == null || _funnel == null) return;
            Transform parent = _spawnParent != null ? _spawnParent : transform;
            Vector3 startOffset = new Vector3(_gatherers.Count * _spawnStagger, 0f, 0f);
            Gatherer g = Instantiate(_gathererPrefab, _pickupPoint.position + startOffset, Quaternion.identity, parent);
            g.CarryTier = _defaultCarryTier;
            g.Configure(this, _funnel, _pickupPoint, _dropPoint);
            _gatherers.Add(g);
        }

        private void DespawnOne()
        {
            int last = _gatherers.Count - 1;
            if (last < 0) return;
            Gatherer g = _gatherers[last];
            _gatherers.RemoveAt(last);
            if (g != null) Destroy(g.gameObject);
        }

        private void ApplySpeedToAll()
        {
            float speed = _baseSpeed + (_speedTier - 1) * _speedPerTier;
            for (int i = 0; i < _gatherers.Count; i++)
            {
                if (_gatherers[i] != null) _gatherers[i].WalkSpeed = speed;
            }
        }
    }
}
