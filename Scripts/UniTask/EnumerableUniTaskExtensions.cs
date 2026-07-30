#nullable enable
namespace UniT.Extensions
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using Cysharp.Threading.Tasks;

    public static class EnumerableUniTaskExtensions
    {
        public static async UniTask ForEachAwaitAsync<T, TState>(this IEnumerable<T> enumerable, Func<T, TState, UniTask> action, TState state)
        {
            foreach (var item in enumerable) await action(item, state);
        }

        public static async UniTask ForEachAwaitAsync<T>(this IEnumerable<T> enumerable, Func<T, UniTask> action)
        {
            foreach (var item in enumerable) await action(item);
        }

        public static async UniTask ForEachAsync<T, TState>(this IEnumerable<T> enumerable, Func<T, TState, UniTask> action, TState state)
        {
            await enumerable.Select(action, state);
        }

        public static async UniTask ForEachAsync<T>(this IEnumerable<T> enumerable, Func<T, UniTask> action)
        {
            await enumerable.Select(action);
        }

        public static async UniTask SnapshotForEachAwaitAsync<T, TState>(this IEnumerable<T> enumerable, Func<T, TState, UniTask> action, TState state)
        {
            if (enumerable is ICollection<T> collection)
            {
                if (collection.Count is 0) return;
                var array = ArrayPool<T>.Shared.Rent(collection.Count);
                try
                {
                    collection.CopyTo(array, 0);
                    for (var i = 0; i < collection.Count; ++i)
                    {
                        await action(array[i], state);
                    }
                }
                finally
                {
                    ArrayPool<T>.Shared.Return(array, RuntimeHelpers.IsReferenceOrContainsReferences<T>());
                }
            }
            else
            {
                foreach (var item in enumerable.ToArray()) await action(item, state);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask SnapshotForEachAwaitAsync<T>(this IEnumerable<T> enumerable, Func<T, UniTask> action)
        {
            return enumerable.SnapshotForEachAwaitAsync(static (item, action) => action(item), action);
        }

        public static async UniTask SnapshotForEachAsync<T, TState>(this IEnumerable<T> enumerable, Func<T, TState, UniTask> action, TState state)
        {
            if (enumerable is ICollection<T> collection)
            {
                if (collection.Count is 0) return;
                var array = ArrayPool<T>.Shared.Rent(collection.Count);
                try
                {
                    collection.CopyTo(array, 0);
                    await array.Take(collection.Count).Select(action, state);
                }
                finally
                {
                    ArrayPool<T>.Shared.Return(array, RuntimeHelpers.IsReferenceOrContainsReferences<T>());
                }
            }
            else
            {
                await enumerable.ToArray().Select(action, state);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask SnapshotForEachAsync<T>(this IEnumerable<T> enumerable, Func<T, UniTask> action)
        {
            return enumerable.SnapshotForEachAsync(static (item, action) => action(item), action);
        }

        public static async UniTask<TResult[]> SelectAsync<T, TResult, TState>(this IEnumerable<T> enumerable, Func<T, TState, UniTask<TResult>> selector, TState state)
        {
            return await enumerable.Select(selector, state);
        }

        public static async UniTask<TResult[]> SelectAsync<T, TResult>(this IEnumerable<T> enumerable, Func<T, UniTask<TResult>> selector)
        {
            return await enumerable.Select(selector);
        }

        public static async UniTask ForEachAwaitAsync<T, TState>(this IEnumerable<T> enumerable, Func<T, TState, IProgress<float>?, CancellationToken, UniTask> action, IProgress<float>? progress, CancellationToken cancellationToken, TState state)
        {
            var collection = enumerable as ICollection<T> ?? enumerable.ToArray();
            using var subProgresses = progress.CreateSubProgresses(collection.Count).GetEnumerator();
            await collection.ForEachAwaitAsync(
                static (item, state) => state.action(item, state.state, state.subProgresses.GetNext(), state.cancellationToken),
                (action, subProgresses, cancellationToken, state)
            );
        }

        public static async UniTask ForEachAwaitAsync<T>(this IEnumerable<T> enumerable, Func<T, IProgress<float>?, CancellationToken, UniTask> action, IProgress<float>? progress, CancellationToken cancellationToken)
        {
            var collection = enumerable as ICollection<T> ?? enumerable.ToArray();
            using var subProgresses = progress.CreateSubProgresses(collection.Count).GetEnumerator();
            await collection.ForEachAwaitAsync(
                static (item, state) => state.action(item, state.subProgresses.GetNext(), state.cancellationToken),
                (action, subProgresses, cancellationToken)
            );
        }

        public static async UniTask ForEachAsync<T, TState>(this IEnumerable<T> enumerable, Func<T, TState, IProgress<float>?, CancellationToken, UniTask> action, IProgress<float>? progress, CancellationToken cancellationToken, TState state)
        {
            var collection = enumerable as ICollection<T> ?? enumerable.ToArray();
            using var subProgresses = progress.CreateSubProgresses(collection.Count).GetEnumerator();
            await collection.ForEachAsync(
                static (item, state) => state.action(item, state.state, state.subProgresses.GetNext(), state.cancellationToken),
                (action, subProgresses, cancellationToken, state)
            );
        }

        public static async UniTask ForEachAsync<T>(this IEnumerable<T> enumerable, Func<T, IProgress<float>?, CancellationToken, UniTask> action, IProgress<float>? progress, CancellationToken cancellationToken)
        {
            var collection = enumerable as ICollection<T> ?? enumerable.ToArray();
            using var subProgresses = progress.CreateSubProgresses(collection.Count).GetEnumerator();
            await collection.ForEachAsync(
                static (item, state) => state.action(item, state.subProgresses.GetNext(), state.cancellationToken),
                (action, subProgresses, cancellationToken)
            );
        }

        public static async UniTask<TResult[]> SelectAsync<T, TResult, TState>(this IEnumerable<T> enumerable, Func<T, TState, IProgress<float>?, CancellationToken, UniTask<TResult>> selector, IProgress<float>? progress, CancellationToken cancellationToken, TState state)
        {
            var collection = enumerable as ICollection<T> ?? enumerable.ToArray();
            using var subProgresses = progress.CreateSubProgresses(collection.Count).GetEnumerator();
            return await collection.SelectAsync(
                static (item, state) => state.selector(item, state.state, state.subProgresses.GetNext(), state.cancellationToken),
                (selector, subProgresses, cancellationToken, state)
            );
        }

        public static async UniTask<TResult[]> SelectAsync<T, TResult>(this IEnumerable<T> enumerable, Func<T, IProgress<float>?, CancellationToken, UniTask<TResult>> selector, IProgress<float>? progress, CancellationToken cancellationToken)
        {
            var collection = enumerable as ICollection<T> ?? enumerable.ToArray();
            using var subProgresses = progress.CreateSubProgresses(collection.Count).GetEnumerator();
            return await collection.SelectAsync(
                static (item, state) => state.selector(item, state.subProgresses.GetNext(), state.cancellationToken),
                (selector, subProgresses, cancellationToken)
            );
        }
    }
}