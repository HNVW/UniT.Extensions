#nullable enable
namespace UniT.Extensions
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class SerializeReferenceDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver where TKey : notnull
    {
        [SerializeField]
        [TupleDisplayNames("Key", "Value")]
        private List<SerializeReferenceTuple<TKey, TValue>> values = new();

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