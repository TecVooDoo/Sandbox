using System.Collections.Generic;
using UnityEngine;
using SM.Core;

namespace SM.Mine
{
    public sealed class BodyPile : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private int _maxBodies = 10;
        [SerializeField] private float _respawnTime = 5f;

        [Header("Visual")]
        [SerializeField] private Transform _pileRoot;

        private readonly List<BodyInstance> _bodies = new List<BodyInstance>();
        private BodyConfigSO[] _bodyPool;
        private float _respawnTimer;
        private int _harvestedCount;

        public int ActiveBodyCount => _maxBodies - _harvestedCount;
        public bool HasBodies => _harvestedCount < _bodies.Count;

        public void Initialize(BodyConfigSO[] bodyPool)
        {
            _bodyPool = bodyPool;
            SpawnInitialBodies();
        }

        private void Update()
        {
            if (_harvestedCount <= 0) return;

            _respawnTimer += Time.deltaTime;
            if (_respawnTimer >= _respawnTime)
            {
                _respawnTimer = 0f;
                RespawnOne();
            }
        }

        public BodyConfigSO TryHarvest(Vector3 hitPoint)
        {
            if (_bodies.Count == 0 || !HasBodies) return null;

            // Find closest unharvested body to hit point
            float closestDist = float.MaxValue;
            int closestIndex = -1;

            for (int i = 0; i < _bodies.Count; i++)
            {
                if (_bodies[i].IsHarvested) continue;

                float dist = Vector3.SqrMagnitude(_bodies[i].Transform.position - hitPoint);
                if (dist < closestDist)
                {
                    closestDist = dist;
                    closestIndex = i;
                }
            }

            if (closestIndex < 0) return null;

            BodyInstance body = _bodies[closestIndex];
            body.IsHarvested = true;
            _bodies[closestIndex] = body;
            _harvestedCount++;

            if (body.GameObject != null)
                body.GameObject.SetActive(false);

            return body.Config;
        }

        private void SpawnInitialBodies()
        {
            if (_bodyPool == null || _bodyPool.Length == 0) return;

            Transform parent = _pileRoot != null ? _pileRoot : transform;

            for (int i = 0; i < _maxBodies; i++)
            {
                BodyConfigSO config = _bodyPool[Random.Range(0, _bodyPool.Length)];

                GameObject bodyGO = null;
                if (config.BodyPrefab != null)
                {
                    bodyGO = Instantiate(config.BodyPrefab, parent);
                    bodyGO.transform.localPosition = GetPilePosition(i);
                    bodyGO.transform.localRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), Random.Range(-15f, 15f));
                }

                BodyInstance instance = new BodyInstance
                {
                    Config = config,
                    GameObject = bodyGO,
                    Transform = bodyGO != null ? bodyGO.transform : null,
                    IsHarvested = false
                };

                _bodies.Add(instance);
            }
        }

        private void RespawnOne()
        {
            for (int i = 0; i < _bodies.Count; i++)
            {
                if (!_bodies[i].IsHarvested) continue;

                BodyInstance body = _bodies[i];
                body.IsHarvested = false;
                _bodies[i] = body;
                _harvestedCount--;

                if (body.GameObject != null)
                    body.GameObject.SetActive(true);

                return;
            }
        }

        private Vector3 GetPilePosition(int index)
        {
            float x = (index % 5 - 2) * 0.8f + Random.Range(-0.15f, 0.15f);
            float y = 0.6f + (index / 5) * 0.6f;
            float z = Random.Range(-0.2f, 0.2f);
            return new Vector3(x, y, z);
        }

        private struct BodyInstance
        {
            public BodyConfigSO Config;
            public GameObject GameObject;
            public Transform Transform;
            public bool IsHarvested;
        }
    }
}
