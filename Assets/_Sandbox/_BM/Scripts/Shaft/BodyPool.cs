using System.Collections.Generic;
using UnityEngine;
using BM.Core;

namespace BM.Shaft
{
    public sealed class BodyPool : MonoBehaviour
    {
        [SerializeField] private Transform _inactiveParent;
        [SerializeField] private GameObject _fallbackPrefab;

        private readonly Dictionary<BodyConfigSO, Queue<GameObject>> _pools = new Dictionary<BodyConfigSO, Queue<GameObject>>();

        public GameObject Rent(BodyConfigSO config)
        {
            if (config == null) return null;
            if (!_pools.TryGetValue(config, out Queue<GameObject> pool))
            {
                pool = new Queue<GameObject>();
                _pools[config] = pool;
            }
            GameObject go;
            while (pool.Count > 0)
            {
                go = pool.Dequeue();
                if (go != null)
                {
                    go.SetActive(true);
                    return go;
                }
            }
            GameObject source = config.BodyPrefab != null ? config.BodyPrefab : _fallbackPrefab;
            if (source != null)
            {
                go = Instantiate(source);
            }
            else
            {
                go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.layer = LayerMask.NameToLayer("Body");
            }
            go.name = config.name + "_pooled";
            return go;
        }

        public void Return(GameObject go, BodyConfigSO config)
        {
            if (go == null || config == null)
            {
                if (go != null) Destroy(go);
                return;
            }
            if (!_pools.TryGetValue(config, out Queue<GameObject> pool))
            {
                pool = new Queue<GameObject>();
                _pools[config] = pool;
            }
            go.SetActive(false);
            if (_inactiveParent != null) go.transform.SetParent(_inactiveParent, false);
            pool.Enqueue(go);
        }
    }
}
