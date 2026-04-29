using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BM.Core;

namespace BM.Shaft
{
    public sealed class RowOutlet : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private BodyPool _pool;

        [Header("Backup System")]
        [Tooltip("Total bodies the outlet will hold before pausing further deliveries. Includes the body currently on display.")]
        [SerializeField] private int _maxQueue = 3;
        [Tooltip("After the outlet fully clears (current body chopped, backlog empty) it ignores re-pause for this many seconds. Lets a quick burst flow through without thrashing.")]
        [SerializeField] private float _graceAfterClear = 1.5f;

        [Header("Backup Visual")]
        [Tooltip("Heat-shader material applied to the kit's PipeTCrossSmall renderer when this outlet pauses. Swapped via sharedMaterial -- per-renderer reference flip, doesn't bleed into other outlets sharing the cool material.")]
        [SerializeField] private Material _heatMaterial;
        [Tooltip("Child name to find the renderer on. The Pipes_Outlet kit ships PipeTCrossSmall as the central piece.")]
        [SerializeField] private string _heatRendererChildName = "PipeTCrossSmall";

        public Material HeatMaterial { get => _heatMaterial; set => _heatMaterial = value; }

        private Renderer _pipeRenderer;
        private Material _coolMaterial;

        public UnityEvent OnBodyPlaced = new UnityEvent();
        public UnityEvent OnBodyCleared = new UnityEvent();
        public UnityEvent OnPaused = new UnityEvent();
        public UnityEvent OnResumed = new UnityEvent();

        private GameObject _currentBody;
        private BodyConfigSO _currentConfig;
        private readonly Queue<BodyConfigSO> _backlog = new Queue<BodyConfigSO>();
        private bool _paused;
        private float _pauseAllowedAt;

        public Transform SpawnPoint => _spawnPoint;
        public BodyPool Pool { get => _pool; set => _pool = value; }
        /// <summary>True iff there is no body on display. Choppers use this to find a target.</summary>
        public bool IsClear => _currentBody == null;
        public BodyConfigSO CurrentConfig => _currentConfig;
        /// <summary>True iff the outlet will accept another delivery from the pipe network.</summary>
        public bool IsAcceptingBodies => !_paused;
        public int BacklogCount => _backlog.Count;
        public int TotalBodies => (_currentBody != null ? 1 : 0) + _backlog.Count;
        public bool IsPaused => _paused;
        public int MaxQueue => _maxQueue;

        private void Awake()
        {
            if (_spawnPoint == null) _spawnPoint = transform;
            CacheHeatRenderer();
        }

        private void CacheHeatRenderer()
        {
            // Walk children to find the named pipe piece. The kit nests PipesOutletKit/PipeTCrossSmall.
            Transform found = FindChildRecursive(transform, _heatRendererChildName);
            if (found == null) return;
            _pipeRenderer = found.GetComponent<Renderer>();
            if (_pipeRenderer != null) _coolMaterial = _pipeRenderer.sharedMaterial;
        }

        private static Transform FindChildRecursive(Transform parent, string name)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform c = parent.GetChild(i);
                if (c.name == name) return c;
                Transform deeper = FindChildRecursive(c, name);
                if (deeper != null) return deeper;
            }
            return null;
        }

        /// <summary>
        /// Externally-driven visual state. PipeNetwork sets this every frame so that an outlet
        /// downstream of a paused one (cascade-blocked) shows the heat material even though it's
        /// not paused itself.
        /// </summary>
        public void SetBlockedVisual(bool hot)
        {
            // Runtime-spawned outlets get their PipesOutletKit child AFTER Awake runs, so the
            // initial CacheHeatRenderer call finds nothing. Lazy-retry the cache until the kit is in.
            if (_pipeRenderer == null) CacheHeatRenderer();
            if (_pipeRenderer == null) return;
            Material target = hot ? _heatMaterial : _coolMaterial;
            if (target == null) return;
            if (_pipeRenderer.sharedMaterial != target) _pipeRenderer.sharedMaterial = target;
        }

        public void PlaceBody(BodyConfigSO config)
        {
            if (config == null || _pool == null || _spawnPoint == null)
            {
                Debug.LogWarning("[BM] Outlet.PlaceBody SKIPPED config=" + (config != null) + " pool=" + (_pool != null) + " spawnPoint=" + (_spawnPoint != null));
                return;
            }
            if (!IsAcceptingBodies)
            {
                Debug.LogWarning("[BM] Outlet.PlaceBody REJECTED -- outlet paused");
                return;
            }

            _backlog.Enqueue(config);
            if (_currentBody == null) PlaceFromBacklog();

            // Re-pause only if the post-clear grace has elapsed.
            if (TotalBodies >= _maxQueue && Time.time >= _pauseAllowedAt)
            {
                _paused = true;
                if (OnPaused != null) OnPaused.Invoke();
            }
        }

        private void PlaceFromBacklog()
        {
            if (_backlog.Count == 0 || _pool == null || _spawnPoint == null) return;

            BodyConfigSO config = _backlog.Dequeue();
            GameObject body = _pool.Rent(config);
            if (body == null) { Debug.LogWarning("[BM] Outlet.PlaceFromBacklog NULL from pool"); return; }

            body.transform.SetParent(_spawnPoint, false);
            body.transform.localPosition = Vector3.zero;
            body.transform.localRotation = Quaternion.identity;

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

            if (_backlog.Count > 0)
            {
                PlaceFromBacklog();
                return;
            }

            // Fully cleared -- if we were paused, resume and start the grace window.
            if (_paused)
            {
                _paused = false;
                _pauseAllowedAt = Time.time + _graceAfterClear;
                if (OnResumed != null) OnResumed.Invoke();
            }
        }
    }
}
