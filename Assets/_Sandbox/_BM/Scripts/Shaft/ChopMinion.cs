using UnityEngine;

namespace BM.Shaft
{
    public sealed class ChopMinion : RowWorker
    {
        [SerializeField] private float _chopInterval = 1f;

        private float _chopTimer;

        protected override void Awake()
        {
            base.Awake();
            CreatePlaceholderVisual();
        }

        private void Update()
        {
            if (_assignedOutlet == null || _assignedOutlet.IsClear) return;

            _chopTimer += Time.deltaTime;
            if (_chopTimer >= _chopInterval)
            {
                _chopTimer = 0f;
                Chop();
            }
        }

        private void CreatePlaceholderVisual()
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name = "MinionVisual";
            cube.transform.SetParent(transform, false);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

            Renderer rend = cube.GetComponent<Renderer>();
            if (rend != null)
            {
                Material mat = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
                mat.SetColor("_BaseColor", new Color(0.2f, 0.8f, 0.2f));
                rend.sharedMaterial = mat;
            }

            Collider col = cube.GetComponent<Collider>();
            if (col != null) Destroy(col);
        }
    }
}
