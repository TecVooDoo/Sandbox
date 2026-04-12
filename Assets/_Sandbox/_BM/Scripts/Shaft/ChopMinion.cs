using UnityEngine;

namespace BM.Shaft
{
    public sealed class ChopMinion : RowWorker
    {
        [SerializeField] private float _chopInterval = 1f;

        private float _chopTimer;

        private void Update()
        {
            _chopTimer += Time.deltaTime;
            if (_chopTimer >= _chopInterval)
            {
                _chopTimer = 0f;
                Chop();
            }
        }
    }
}
