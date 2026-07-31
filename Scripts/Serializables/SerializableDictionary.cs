#nullable enable
namespace UniT.Extensions
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver where TKey : notnull
    {
        [SerializeField]
        [TupleDisplayNames("Key", "Value")]
        private List<SerializableTuple<TKey, TValue>> values;

        public SerializableDictionary() : this(new())
        {
        }

        public SerializableDictionary(List<SerializableTuple<TKey, TValue>> values)
        {
            this.values = values;
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            this.values.Clear();
            this.values.Capacity = this.Count;
            foreach (var (key, value) in this)
            {
                this.values.Add(new(key, value));
            }
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            this.Clear();
            this.EnsureCapacity(this.values.Count);
            foreach (var (key, value) in this.values)
            {
                this.Add(key, value);
            }
        }
    }
}