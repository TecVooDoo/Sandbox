using System.Collections.Generic;
using UnityEngine;

namespace BM.Shaft
{
    public sealed class ShaftManager : MonoBehaviour
    {
        [SerializeField] private Transform _rowParent;
        [SerializeField] private Row _rowPrefab;
        [SerializeField] private float _rowSpacing = 3f;

        private readonly List<Row> _rows = new List<Row>();
        private int _ghoulRowIndex;

        public int GhoulRowIndex => _ghoulRowIndex;
        public int RowCount => _rows.Count;

        private void Awake()
        {
            _rows.Clear();
            if (_rowParent == null) return;
            _rowParent.GetComponentsInChildren<Row>(true, _rows);
        }

        public Row GetRow(int index)
        {
            if (index < 0 || index >= _rows.Count) return null;
            return _rows[index];
        }

        private void Update()
        {
            if (_rows.Count == 0) return;
            Row activeRow = GetRow(_ghoulRowIndex);
            if (activeRow == null) return;

            if (UnityEngine.InputSystem.Keyboard.current != null)
            {
                if (UnityEngine.InputSystem.Keyboard.current.oKey.wasPressedThisFrame)
                {
                    RowOutlet newOutlet = activeRow.AddOutlet();
                    if (newOutlet != null)
                        Debug.Log("[BM] ShaftManager: outlet added, total=" + activeRow.OutletCount);
                    else
                        Debug.Log("[BM] ShaftManager: outlet at max (" + activeRow.MaxOutlets + ")");
                }

                if (UnityEngine.InputSystem.Keyboard.current.mKey.wasPressedThisFrame)
                {
                    RowOutlet target = activeRow.GetNextUnminionedOutlet();
                    if (target != null)
                    {
                        ChopMinion minion = activeRow.AddChopMinion(target);
                        if (minion != null)
                            Debug.Log("[BM] ShaftManager: minion added for " + target.name);
                    }
                    else
                    {
                        Debug.Log("[BM] ShaftManager: all outlets have minions");
                    }
                }
            }
        }

        public void Descend()
        {
        }

        public void UnlockNextRow()
        {
        }
    }
}
