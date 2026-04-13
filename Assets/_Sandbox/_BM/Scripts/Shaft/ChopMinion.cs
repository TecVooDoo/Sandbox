using UnityEngine;

namespace BM.Shaft
{
    public sealed class ChopMinion : RowWorker
    {
        [SerializeField] private float _chopInterval = 1f;

        private float _chopTimer;
        private Animator _animator;
        private static readonly int _animAttack = Animator.StringToHash("Attack");

        protected override void Awake()
        {
            base.Awake();
            _animator = GetComponentInChildren<Animator>();
            if (_animator == null) CreatePlaceholderVisual();
        }

        public void SetupModel(GameObject modelPrefab, RuntimeAnimatorController animCtrl, Material mat)
        {
            if (modelPrefab == null) return;
            var model = Instantiate(modelPrefab, transform);
            model.name = "MinionModel";
            model.transform.localPosition = Vector3.zero;
            model.transform.localRotation = Quaternion.identity;
            model.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            SetLayerRecursive(model, gameObject.layer);

            if (mat != null)
                foreach (var rend in model.GetComponentsInChildren<Renderer>())
                    rend.sharedMaterial = mat;

            _animator = model.GetComponent<Animator>();
            if (_animator == null) _animator = model.AddComponent<Animator>();
            if (animCtrl != null) _animator.runtimeAnimatorController = animCtrl;
        }

        private static void SetLayerRecursive(GameObject go, int layer)
        {
            go.layer = layer;
            for (int i = 0; i < go.transform.childCount; i++)
                SetLayerRecursive(go.transform.GetChild(i).gameObject, layer);
        }

        private void Update()
        {
            if (_assignedOutlet == null || _assignedOutlet.IsClear) return;

            _chopTimer += Time.deltaTime;
            if (_chopTimer >= _chopInterval)
            {
                _chopTimer = 0f;
                if (_animator != null) _animator.SetTrigger(_animAttack);
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
