using UnityEngine;
using BM.Core;

namespace BM.Shaft
{
    public sealed class ClickableBody : MonoBehaviour
    {
        private RowOutlet _owner;
        private BodyConfigSO _config;

        public RowOutlet Owner => _owner;
        public BodyConfigSO Config => _config;

        public void Bind(RowOutlet owner, BodyConfigSO config)
        {
            _owner = owner;
            _config = config;
        }
    }
}
