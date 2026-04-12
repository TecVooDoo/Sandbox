using System.Collections.Generic;
using UnityEngine;

namespace BM.VFX
{
    public sealed class NumberPop : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private float _riseDuration = 0.8f;
        [SerializeField] private float _riseHeight = 1.5f;
        [SerializeField] private float _fontSize = 0.3f;
        [SerializeField] private int _poolSize = 10;

        [Header("Colors")]
        [SerializeField] private Color _normalColor = Color.white;
        [SerializeField] private Color _critColor = new Color(1f, 0.85f, 0.2f, 1f);

        private readonly List<PopInstance> _active = new List<PopInstance>();
        private readonly Queue<TextMesh> _pool = new Queue<TextMesh>();
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;

            for (int i = 0; i < _poolSize; i++)
            {
                GameObject go = new GameObject("NumberPop_" + i);
                go.transform.SetParent(transform);
                TextMesh tm = go.AddComponent<TextMesh>();
                tm.alignment = TextAlignment.Center;
                tm.anchor = TextAnchor.MiddleCenter;
                tm.characterSize = _fontSize;
                tm.fontSize = 48;
                tm.fontStyle = FontStyle.Bold;
                tm.color = _normalColor;
                go.SetActive(false);
                _pool.Enqueue(tm);
            }
        }

        private void LateUpdate()
        {
            for (int i = _active.Count - 1; i >= 0; i--)
            {
                PopInstance pop = _active[i];
                pop.Elapsed += Time.deltaTime;
                float t = pop.Elapsed / _riseDuration;

                if (t >= 1f)
                {
                    pop.TextMesh.gameObject.SetActive(false);
                    _pool.Enqueue(pop.TextMesh);
                    _active.RemoveAt(i);
                    continue;
                }

                // Rise and fade
                Vector3 pos = pop.StartPosition + Vector3.up * (_riseHeight * t);
                pop.TextMesh.transform.position = pos;

                // Face camera
                if (_camera != null)
                    pop.TextMesh.transform.rotation = _camera.transform.rotation;

                // Fade out in last 30%
                float alpha = t > 0.7f ? 1f - ((t - 0.7f) / 0.3f) : 1f;
                Color c = pop.TextMesh.color;
                c.a = alpha;
                pop.TextMesh.color = c;

                // Scale punch
                float scale = t < 0.15f ? 1f + (1f - t / 0.15f) * 0.5f : 1f;
                pop.TextMesh.transform.localScale = Vector3.one * scale;

                _active[i] = pop;
            }
        }

        public void Show(Vector3 worldPosition, double soulValue, bool isCrit)
        {
            if (_pool.Count == 0) return;

            TextMesh tm = _pool.Dequeue();
            tm.text = "+" + FormatNumber(soulValue);
            tm.color = isCrit ? _critColor : _normalColor;
            tm.transform.position = worldPosition + Vector3.up * 0.5f;
            tm.transform.localScale = Vector3.one;
            tm.gameObject.SetActive(true);

            PopInstance pop = new PopInstance
            {
                TextMesh = tm,
                StartPosition = worldPosition + Vector3.up * 0.5f,
                Elapsed = 0f
            };
            _active.Add(pop);
        }

        private static string FormatNumber(double value)
        {
            if (value >= 1000000) return (value / 1000000).ToString("F1") + "M";
            if (value >= 10000) return (value / 1000).ToString("F1") + "K";
            if (value >= 100) return ((long)value).ToString();
            return value.ToString("F1");
        }

        private struct PopInstance
        {
            public TextMesh TextMesh;
            public Vector3 StartPosition;
            public float Elapsed;
        }
    }
}