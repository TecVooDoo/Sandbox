using UnityEngine;

namespace BM.Shaft
{
    /// <summary>
    /// Toggles the surface pipe between "flowing" (RegularPipeMed) and "blocked" (PipeBlock with PipeBaloon)
    /// based on whether ANY outlet on any row is currently paused. Sits on Surface_Pipe_Connection.
    /// </summary>
    public sealed class SurfacePipeBlockIndicator : MonoBehaviour
    {
        [SerializeField] private GameObject _normalPipe;
        [SerializeField] private GameObject _blockedPipe;
        [SerializeField] private ShaftManager _shaftManager;

        private void Awake()
        {
            if (_normalPipe == null)
            {
                Transform t = transform.Find("RegularPipeMed");
                if (t != null) _normalPipe = t.gameObject;
            }
            if (_blockedPipe == null)
            {
                Transform t = transform.Find("PipeBlock");
                if (t != null) _blockedPipe = t.gameObject;
            }
            if (_shaftManager == null) _shaftManager = FindAnyObjectByType<ShaftManager>();
        }

        private void Update()
        {
            if (_shaftManager == null || _normalPipe == null || _blockedPipe == null) return;
            bool blocked = _shaftManager.AnyOutletPaused();
            if (_normalPipe.activeSelf == blocked) _normalPipe.SetActive(!blocked);
            if (_blockedPipe.activeSelf != blocked) _blockedPipe.SetActive(blocked);
        }
    }
}
