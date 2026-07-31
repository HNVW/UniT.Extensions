#nullable enable
namespace UniT.Extensions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class Serializable2DArray<T> : IEnumerable<T>, ISerializationCallbackReceiver
    {
        [SerializeField] private Row[] rows;

        public Serializable2DArray() : this(0, 0)
        {
        }

        public Serializable2DArray(int width, int height)
        {
            this.rows = new Row[height];
            for (var y = 0; y < height; ++y) this.rows[y] = new(width);
        }

        public int Width => this.rows.Length > 0 ? this.rows[0].Cells.Length : 0;

        public int Height => this.rows.Length;

        public T this[int x, int y] { get => this.rows[y].Cells[x]; set => this.rows[y].Cells[x] = value; }

        public IEnumerable<T> GetColumn(int x) => this.rows.Select(static (row, x) => row.Cells[x], x);

        public IEnumerable<T> GetRow(int y) => this.rows[y].Cells;

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var row in this.rows)
            {
                foreach (var cell in row.Cells)
                {
                    yield return cell;
                }
            }
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            if (this.rows.Length is 0) return;
            var newWidth = this.rows[0].Cells.Length;
            for (var y = 1; y < this.rows.Length; ++y)
            {
                var oldRow = this.rows[y].Cells;
                var oldWidth = oldRow.Length;
                if (oldWidth == newWidth) continue;
                this.rows[y] = new Row(newWidth);
                Array.Copy(oldRow, this.rows[y].Cells, Mathf.Min(oldWidth, newWidth));
            }
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize() { }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        [Serializable]
        public sealed class Row
        {
            [SerializeField] private T[] cells;

            public T[] Cells => this.cells;

            public Row() : this(0)
            {
            }

            public Row(int width)
            {
                this.cells = new T[width];
            }
        }
    }
}