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

        public void Descend()
        {
        }

        public void UnlockNextRow()
        {
        }
    }
}
