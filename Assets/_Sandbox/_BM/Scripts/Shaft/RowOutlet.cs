using UnityEngine;
using UnityEngine.Events;
using BM.Core;

namespace BM.Shaft
{
    public sealed class RowOutlet : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private BodyPool _pool;

        public UnityEvent OnBodyPlaced;
        public UnityEvent OnBodyCleared;

        private GameObject _currentBody;
        private BodyConfigSO _currentConfig;

        public Transform SpawnPoint => _spawnPoint;
        public BodyPool Pool { get => _pool; set => _pool = value; }
        public bool IsClear => _currentBody == null;
        public BodyConfigSO CurrentConfig => _currentConfig;

        private void Awake()
        {
            if (_spawnPoint == null) _spawnPoint = transform;
        }

        public void PlaceBody(BodyConfigSO config)
        {
            if (config == null || _pool == null || _spawnPoint == null)
            {
                Debug.LogWarning("[BM] Outlet.PlaceBody SKIPPED config=" + (config != null) + " pool=" + (_pool != null) + " spawnPoint=" + (_spawnPoint != null));
                return;
            }
            if (_currentBody != null) { Debug.LogWarning("[BM] Outlet.PlaceBody SKIPPED already has body"); return; }

            GameObject body = _pool.Rent(config);
            if (body == null) { Debug.LogWarning("[BM] Outlet.PlaceBody NULL from pool"); return; }

            body.transform.SetParent(_spawnPoint, false);
            body.transform.localPosition = Vector3.zero;
            body.transform.localRotation = Quaternion.identity;

            Renderer rend = body.GetComponentInChildren<Renderer>();
            string matInfo = "none";
            if (rend != null && rend.sharedMaterial != null)
            {
                Material mat = rend.sharedMaterial;
                matInfo = mat.name + "/" + (mat.shader != null ? mat.shader.name : "null-shader");
            }
            Debug.Log("[BM] Outlet.PlaceBody " + config.name + " body=" + body.name + " active=" + body.activeInHierarchy + " worldPos=" + body.transform.position + " lossyScale=" + body.transform.lossyScale + " rendType=" + (rend != null ? rend.GetType().Name : "null") + " rendEnabled=" + (rend != null ? rend.enabled.ToString() : "-") + " rendBounds=" + (rend != null ? rend.bounds.size.ToString() : "null") + " rendCenter=" + (rend != null ? rend.bounds.center.ToString() : "null") + " mat=" + matInfo);

            ClickableBody clickable = body.GetComponent<ClickableBody>();
            if (clickable == null) clickable = body.AddComponent<ClickableBody>();
            clickable.Bind(this, config);

            _currentBody = body;
            _currentConfig = config;
            if (OnBodyPlaced != null) OnBodyPlaced.Invoke();
        }

        public void ConsumeBody()
        {
            if (_currentBody == null || _pool == null || _currentConfig == null) return;
            _pool.Return(_currentBody, _currentConfig);
            _currentBody = null;
            _currentConfig = null;
            if (OnBodyCleared != null) OnBodyCleared.Invoke();
        }
    }
}
