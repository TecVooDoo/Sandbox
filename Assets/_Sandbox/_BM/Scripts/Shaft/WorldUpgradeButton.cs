using UnityEngine;

namespace BM.Shaft
{
    [RequireComponent(typeof(Collider))]
    public sealed class WorldUpgradeButton : MonoBehaviour
    {
        [SerializeField] private ToolUpgradeController _controller;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Color _readyColor = Color.red;
        [SerializeField] private Color _idleColor = Color.gray;

        private MaterialPropertyBlock _mpb;
        private static readonly int BaseColorId = Shader.PropertyToID("_BaseColor");

        private void Awake()
        {
            _mpb = new MaterialPropertyBlock();
            if (_controller != null)
            {
                _controller.OnReady.AddListener(HandleReady);
                _controller.OnTierChanged.AddListener(HandleTierChanged);
            }
            ApplyColor(_idleColor);
        }

        private void OnDestroy()
        {
            if (_controller != null)
            {
                _controller.OnReady.RemoveListener(HandleReady);
                _controller.OnTierChanged.RemoveListener(HandleTierChanged);
            }
        }

        private void OnMouseDown()
        {
            if (_controller != null) _controller.TryUpgrade();
        }

        private void HandleReady()
        {
            ApplyColor(_readyColor);
        }

        private void HandleTierChanged(int tier)
        {
            ApplyColor(_idleColor);
        }

        private void ApplyColor(Color c)
        {
            if (_renderer == null) return;
            _renderer.GetPropertyBlock(_mpb);
            _mpb.SetColor(BaseColorId, c);
            _renderer.SetPropertyBlock(_mpb);
        }
    }
}
