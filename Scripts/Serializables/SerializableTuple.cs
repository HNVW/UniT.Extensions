#nullable enable
namespace UniT.Extensions
{
    using System;
    using System.Runtime.CompilerServices;
    using UnityEngine;

    [Serializable]
    public class SerializableTuple<T1, T2> : ITuple
    {
        [SerializeField] private T1 item1;
        [SerializeField] private T2 item2;

        public T1 Item1 => this.item1;
        public T2 Item2 => this.item2;

        public SerializableTuple() : this(default!, default!)
        {
        }

        public SerializableTuple(T1 item1, T2 item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public void Deconstruct(out T1 item1, out T2 item2)
        {
            item1 = this.item1;
            item2 = this.item2;
        }

        int ITuple.Length => 2;

        object? ITuple.this[int index] => index switch
        {
            0 => this.item1,
            1 => this.item2,
            _ => throw new IndexOutOfRangeException($"Index {index} is out of range for a 2-tuple"),
        };
    }

    [Serializable]
    public class SerializableTuple<T1, T2, T3> : ITuple
    {
        [SerializeField] private T1 item1;
        [SerializeField] private T2 item2;
        [SerializeField] private T3 item3;

        public T1 Item1 => this.item1;
        public T2 Item2 => this.item2;
        public T3 Item3 => this.item3;

        public SerializableTuple() : this(default!, default!, default!)
        {
        }

        public SerializableTuple(T1 item1, T2 item2, T3 item3)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
        }

        public void Deconstruct(out T1 item1, out T2 item2, out T3 item3)
        {
            item1 = this.item1;
            item2 = this.item2;
            item3 = this.item3;
        }

        int ITuple.Length => 3;

        object? ITuple.this[int index] => index switch
        {
            0 => this.item1,
            1 => this.item2,
            2 => this.item3,
            _ => throw new IndexOutOfRangeException($"Index {index} is out of range for a 3-tuple"),
        };
    }

    [Serializable]
    public class SerializableTuple<T1, T2, T3, T4> : ITuple
    {
        [SerializeField] private T1 item1;
        [SerializeField] private T2 item2;
        [SerializeField] private T3 item3;
        [SerializeField] private T4 item4;

        public T1 Item1 => this.item1;
        public T2 Item2 => this.item2;
        public T3 Item3 => this.item3;
        public T4 Item4 => this.item4;

        public SerializableTuple() : this(default!, default!, default!, default!)
        {
        }

        public SerializableTuple(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            this.item1 = item1;
            this.item2 = item2;
            this.item3 = item3;
            this.item4 = item4;
        }

        public void Deconstruct(out T1 item1, out T2 item2, out T3 item3, out T4 item4)
        {
            item1 = this.item1;
            item2 = this.item2;
            item3 = this.item3;
            item4 = this.item4;
        }

        int ITuple.Length => 4;

        object? ITuple.this[int index] => index switch
        {
            0 => this.item1,
            1 => this.item2,
            2 => this.item3,
            3 => this.item4,
            _ => throw new IndexOutOfRangeException($"Index {index} is out of range for a 4-tuple"),
        };
    }
}