#nullable enable
namespace UniT.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using Cysharp.Threading.Tasks;

    public static class DictionaryUniTaskExtensions
    {
        private static readonly HashSet<object> Locks = new();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TValue> GetValueOrDefaultAsync<TKey, TValue, TState>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TState, UniTask<TValue>> valueFactory, TState state) where TKey : notnull
        {
            return dictionary.TryGetValue(key, out var value) ? UniTask.FromResult(value) : valueFactory(state);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TValue> GetValueOrDefaultAsync<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<UniTask<TValue>> valueFactory) where TKey : notnull
        {
            return dictionary.TryGetValue(key, out var value) ? UniTask.FromResult(value) : valueFactory();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TValue> GetValueOrDefaultAsync<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, UniTask<TValue>> valueFactory) where TKey : notnull
        {
            return dictionary.GetValueOrDefaultAsync(key, valueFactory, key);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TValue> RemoveOrDefaultAsync<TKey, TValue, TState>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TState, UniTask<TValue>> valueFactory, TState state) where TKey : notnull
        {
            return dictionary.Remove(key, out var value) ? UniTask.FromResult(value) : valueFactory(state);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TValue> RemoveOrDefaultAsync<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<UniTask<TValue>> valueFactory) where TKey : notnull
        {
            return dictionary.Remove(key, out var value) ? UniTask.FromResult(value) : valueFactory();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TValue> RemoveOrDefaultAsync<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, UniTask<TValue>> valueFactory) where TKey : notnull
        {
            return dictionary.RemoveOrDefaultAsync(key, valueFactory, key);
        }

        public static async UniTask<TValue> GetOrAddAsync<TKey, TValue, TState>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TState, UniTask<TValue>> valueFactory, TState state) where TKey : notnull
        {
            var @lock = (object)(dictionary, key);
            if (Locks.Contains(@lock)) await UniTask.WaitUntil(@lock, static @lock => !Locks.Contains(@lock));
            if (dictionary.TryGetValue(key, out var value)) return value;
            Locks.Add(@lock);
            try
            {
                value = await valueFactory(state);
                dictionary.Add(key, value);
                return value;
            }
            finally
            {
                Locks.Remove(@lock);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TValue> GetOrAddAsync<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<UniTask<TValue>> valueFactory) where TKey : notnull
        {
            return dictionary.GetOrAddAsync(key, static valueFactory => valueFactory(), valueFactory);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TValue> GetOrAddAsync<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, UniTask<TValue>> valueFactory) where TKey : notnull
        {
            return dictionary.GetOrAddAsync(key, valueFactory, key);
        }

        public static async UniTask<bool> TryAddAsync<TKey, TValue, TState>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TState, UniTask<TValue>> valueFactory, TState state) where TKey : notnull
        {
            var @lock = (object)(dictionary, key);
            if (Locks.Contains(@lock)) await UniTask.WaitUntil(@lock, static @lock => !Locks.Contains(@lock));
            if (dictionary.ContainsKey(key)) return false;
            Locks.Add(@lock);
            try
            {
                dictionary.Add(key, await valueFactory(state));
                return true;
            }
            finally
            {
                Locks.Remove(@lock);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<bool> TryAddAsync<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<UniTask<TValue>> valueFactory) where TKey : notnull
        {
            return dictionary.TryAddAsync(key, static valueFactory => valueFactory(), valueFactory);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<bool> TryAddAsync<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, UniTask<TValue>> valueFactory) where TKey : notnull
        {
            return dictionary.TryAddAsync(key, valueFactory, key);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask ForEachAwaitAsync<TKey, TValue, TState>(this IEnumerable<KeyValuePair<TKey, TValue>> dictionary, Func<TKey, TValue, TState, UniTask> action, TState state) where TKey : notnull
        {
            return dictionary.ForEachAwaitAsync(static (kv, state) => state.action(kv.Key, kv.Value, state.state), (action, state));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask ForEachAwaitAsync<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> dictionary, Func<TKey, TValue, UniTask> action) where TKey : notnull
        {
            return dictionary.ForEachAwaitAsync(static (kv, action) => action(kv.Key, kv.Value), action);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask ForEachAsync<TKey, TValue, TState>(this IEnumerable<KeyValuePair<TKey, TValue>> dictionary, Func<TKey, TValue, TState, UniTask> action, TState state) where TKey : notnull
        {
            return dictionary.ForEachAsync(static (kv, state) => state.action(kv.Key, kv.Value, state.state), (action, state));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask ForEachAsync<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> dictionary, Func<TKey, TValue, UniTask> action) where TKey : notnull
        {
            return dictionary.ForEachAsync(static (kv, action) => action(kv.Key, kv.Value), action);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask SnapshotForEachAwaitAsync<TKey, TValue, TState>(this IEnumerable<KeyValuePair<TKey, TValue>> dictionary, Func<TKey, TValue, TState, UniTask> action, TState state) where TKey : notnull
        {
            return dictionary.SnapshotForEachAwaitAsync(static (kv, state) => state.action(kv.Key, kv.Value, state.state), (action, state));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask SnapshotForEachAwaitAsync<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> dictionary, Func<TKey, TValue, UniTask> action) where TKey : notnull
        {
            return dictionary.SnapshotForEachAwaitAsync(static (kv, action) => action(kv.Key, kv.Value), action);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask SnapshotForEachAsync<TKey, TValue, TState>(this IEnumerable<KeyValuePair<TKey, TValue>> dictionary, Func<TKey, TValue, TState, UniTask> action, TState state) where TKey : notnull
        {
            return dictionary.SnapshotForEachAsync(static (kv, state) => state.action(kv.Key, kv.Value, state.state), (action, state));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask SnapshotForEachAsync<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> dictionary, Func<TKey, TValue, UniTask> action) where TKey : notnull
        {
            return dictionary.SnapshotForEachAsync(static (kv, action) => action(kv.Key, kv.Value), action);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TResult[]> SelectAsync<TKey, TValue, TResult, TState>(this IEnumerable<KeyValuePair<TKey, TValue>> dictionary, Func<TKey, TValue, TState, UniTask<TResult>> selector, TState state) where TKey : notnull
        {
            return dictionary.SelectAsync(static (kv, state) => state.selector(kv.Key, kv.Value, state.state), (selector, state));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TResult[]> SelectAsync<TKey, TValue, TResult>(this IEnumerable<KeyValuePair<TKey, TValue>> dictionary, Func<TKey, TValue, UniTask<TResult>> selector) where TKey : notnull
        {
            return dictionary.SelectAsync(static (kv, selector) => selector(kv.Key, kv.Value), selector);
        }
    }
}