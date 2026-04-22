using UnityEngine;

namespace BM.Shaft
{
    public sealed class ChopMinion : RowWorker
    {
        [SerializeField] private float _chopInterval = 1f;
        [SerializeField] private float _modelYRotation = 90f;

        private float _chopTimer;
        private Animator _animator;
        private Transform _model;
        private static readonly int _animAttack = Animator.StringToHash("Attack");

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_model != null)
                _model.localRotation = Quaternion.Euler(0f, _modelYRotation, 0f);
        }
#endif

        protected override void Awake()
        {
            base.Awake();
            _animator = GetComponentInChildren<Animator>();
            if (_animator != null) _animator.applyRootMotion = false;
            else CreatePlaceholderVisual();
        }

        public void SetupModel(GameObject modelPrefab, RuntimeAnimatorController animCtrl, Material mat)
        {
            if (modelPrefab == null) return;
            Transform placeholder = transform.Find("MinionVisual");
            if (placeholder != null) Destroy(placeholder.gameObject);
            var model = Instantiate(modelPrefab, transform);
            model.name = "MinionModel";
            model.transform.localPosition = Vector3.zero;
            model.transform.localRotation = Quaternion.Euler(0f, _modelYRotation, 0f);
            model.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            _model = model.transform;
            SetLayerRecursive(model, gameObject.layer);

            if (mat != null)
                foreach (var rend in model.GetComponentsInChildren<Renderer>())
                    rend.sharedMaterial = mat;

            _animator = model.GetComponent<Animator>();
            if (_animator == null) _animator = model.AddComponent<Animator>();
            if (animCtrl != null) _animator.runtimeAnimatorController = animCtrl;
            _animator.applyRootMotion = false;
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
