using UnityEngine;
using BM.Core;

namespace BM.Shaft
{
    [RequireComponent(typeof(Collider))]
    public sealed class WorldAutoUpgradeButton : MonoBehaviour
    {
        [SerializeField] private Row _row;
        [SerializeField] private BloodManager _bloodManager;
        [SerializeField] private double _cost = 200;

        private Renderer _renderer;
        private MaterialPropertyBlock _mpb;
        private static readonly int BaseColorId = Shader.PropertyToID("_BaseColor");

        private void Awake()
        {
            _renderer = GetComponent<Renderer>();
            _mpb = new MaterialPropertyBlock();
        }

        private void OnMouseDown()
        {
            if (_row == null || _row.HasAutoButton) return;
            if (_bloodManager == null || !_bloodManager.TrySpend(_cost)) return;

            _row.BuyAutoButton();
            gameObject.SetActive(false);
        }
    }
}
