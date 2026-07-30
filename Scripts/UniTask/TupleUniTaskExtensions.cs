#nullable enable
namespace UniT.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using Cysharp.Threading.Tasks;

    public static class TupleUniTaskExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask ForEachAwaitAsync<TFirst, TSecond, TState>(this IEnumerable<(TFirst, TSecond)> tuples, Func<TFirst, TSecond, TState, UniTask> action, TState state)
        {
            return tuples.ForEachAwaitAsync(static (tuple, state) => state.action(tuple.Item1, tuple.Item2, state.state), (action, state));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask ForEachAwaitAsync<TFirst, TSecond>(this IEnumerable<(TFirst, TSecond)> tuples, Func<TFirst, TSecond, UniTask> action)
        {
            return tuples.ForEachAwaitAsync(static (tuple, action) => action(tuple.Item1, tuple.Item2), action);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask ForEachAwaitAsync<TFirst, TSecond, TThird, TState>(this IEnumerable<(TFirst, TSecond, TThird)> tuples, Func<TFirst, TSecond, TThird, TState, UniTask> action, TState state)
        {
            return tuples.ForEachAwaitAsync(static (tuple, state) => state.action(tuple.Item1, tuple.Item2, tuple.Item3, state.state), (action, state));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask ForEachAwaitAsync<TFirst, TSecond, TThird>(this IEnumerable<(TFirst, TSecond, TThird)> tuples, Func<TFirst, TSecond, TThird, UniTask> action)
        {
            return tuples.ForEachAwaitAsync(static (tuple, action) => action(tuple.Item1, tuple.Item2, tuple.Item3), action);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask ForEachAsync<TFirst, TSecond, TState>(this IEnumerable<(TFirst, TSecond)> tuples, Func<TFirst, TSecond, TState, UniTask> action, TState state)
        {
            return tuples.ForEachAsync(static (tuple, state) => state.action(tuple.Item1, tuple.Item2, state.state), (action, state));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask ForEachAsync<TFirst, TSecond>(this IEnumerable<(TFirst, TSecond)> tuples, Func<TFirst, TSecond, UniTask> action)
        {
            return tuples.ForEachAsync(static (tuple, action) => action(tuple.Item1, tuple.Item2), action);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask ForEachAsync<TFirst, TSecond, TThird, TState>(this IEnumerable<(TFirst, TSecond, TThird)> tuples, Func<TFirst, TSecond, TThird, TState, UniTask> action, TState state)
        {
            return tuples.ForEachAsync(static (tuple, state) => state.action(tuple.Item1, tuple.Item2, tuple.Item3, state.state), (action, state));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask ForEachAsync<TFirst, TSecond, TThird>(this IEnumerable<(TFirst, TSecond, TThird)> tuples, Func<TFirst, TSecond, TThird, UniTask> action)
        {
            return tuples.ForEachAsync(static (tuple, action) => action(tuple.Item1, tuple.Item2, tuple.Item3), action);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask SnapshotForEachAwaitAsync<TFirst, TSecond, TState>(this IEnumerable<(TFirst, TSecond)> tuples, Func<TFirst, TSecond, TState, UniTask> action, TState state)
        {
            return tuples.SnapshotForEachAwaitAsync(static (tuple, state) => state.action(tuple.Item1, tuple.Item2, state.state), (action, state));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask SnapshotForEachAwaitAsync<TFirst, TSecond>(this IEnumerable<(TFirst, TSecond)> tuples, Func<TFirst, TSecond, UniTask> action)
        {
            return tuples.SnapshotForEachAwaitAsync(static (tuple, action) => action(tuple.Item1, tuple.Item2), action);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask SnapshotForEachAwaitAsync<TFirst, TSecond, TThird, TState>(this IEnumerable<(TFirst, TSecond, TThird)> tuples, Func<TFirst, TSecond, TThird, TState, UniTask> action, TState state)
        {
            return tuples.SnapshotForEachAwaitAsync(static (tuple, state) => state.action(tuple.Item1, tuple.Item2, tuple.Item3, state.state), (action, state));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask SnapshotForEachAwaitAsync<TFirst, TSecond, TThird>(this IEnumerable<(TFirst, TSecond, TThird)> tuples, Func<TFirst, TSecond, TThird, UniTask> action)
        {
            return tuples.SnapshotForEachAwaitAsync(static (tuple, action) => action(tuple.Item1, tuple.Item2, tuple.Item3), action);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask SnapshotForEachAsync<TFirst, TSecond, TState>(this IEnumerable<(TFirst, TSecond)> tuples, Func<TFirst, TSecond, TState, UniTask> action, TState state)
        {
            return tuples.SnapshotForEachAsync(static (tuple, state) => state.action(tuple.Item1, tuple.Item2, state.state), (action, state));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask SnapshotForEachAsync<TFirst, TSecond>(this IEnumerable<(TFirst, TSecond)> tuples, Func<TFirst, TSecond, UniTask> action)
        {
            return tuples.SnapshotForEachAsync(static (tuple, action) => action(tuple.Item1, tuple.Item2), action);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask SnapshotForEachAsync<TFirst, TSecond, TThird, TState>(this IEnumerable<(TFirst, TSecond, TThird)> tuples, Func<TFirst, TSecond, TThird, TState, UniTask> action, TState state)
        {
            return tuples.SnapshotForEachAsync(static (tuple, state) => state.action(tuple.Item1, tuple.Item2, tuple.Item3, state.state), (action, state));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask SnapshotForEachAsync<TFirst, TSecond, TThird>(this IEnumerable<(TFirst, TSecond, TThird)> tuples, Func<TFirst, TSecond, TThird, UniTask> action)
        {
            return tuples.SnapshotForEachAsync(static (tuple, action) => action(tuple.Item1, tuple.Item2, tuple.Item3), action);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TResult[]> SelectAsync<TFirst, TSecond, TResult, TState>(this IEnumerable<(TFirst, TSecond)> tuples, Func<TFirst, TSecond, TState, UniTask<TResult>> selector, TState state)
        {
            return tuples.SelectAsync(static (tuple, state) => state.selector(tuple.Item1, tuple.Item2, state.state), (selector, state));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TResult[]> SelectAsync<TFirst, TSecond, TResult>(this IEnumerable<(TFirst, TSecond)> tuples, Func<TFirst, TSecond, UniTask<TResult>> selector)
        {
            return tuples.SelectAsync(static (tuple, selector) => selector(tuple.Item1, tuple.Item2), selector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TResult[]> SelectAsync<TFirst, TSecond, TThird, TResult, TState>(this IEnumerable<(TFirst, TSecond, TThird)> tuples, Func<TFirst, TSecond, TThird, TState, UniTask<TResult>> selector, TState state)
        {
            return tuples.SelectAsync(static (tuple, state) => state.selector(tuple.Item1, tuple.Item2, tuple.Item3, state.state), (selector, state));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TResult[]> SelectAsync<TFirst, TSecond, TThird, TResult>(this IEnumerable<(TFirst, TSecond, TThird)> tuples, Func<TFirst, TSecond, TThird, UniTask<TResult>> selector)
        {
            return tuples.SelectAsync(static (tuple, selector) => selector(tuple.Item1, tuple.Item2, tuple.Item3), selector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask ContinueWith<TFirst, TSecond>(this UniTask<(TFirst, TSecond)> task, Func<TFirst, TSecond, UniTask> continuationFunction)
        {
            return task.ContinueWith(static (tuple, continuationFunction) => continuationFunction(tuple.Item1, tuple.Item2), continuationFunction);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask ContinueWith<TFirst, TSecond, TThird>(this UniTask<(TFirst, TSecond, TThird)> task, Func<TFirst, TSecond, TThird, UniTask> continuationFunction)
        {
            return task.ContinueWith(static (tuple, continuationFunction) => continuationFunction(tuple.Item1, tuple.Item2, tuple.Item3), continuationFunction);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask ContinueWith<TFirst, TSecond>(this UniTask<(TFirst, TSecond)> task, Action<TFirst, TSecond> continuationFunction)
        {
            return task.ContinueWith(static (tuple, continuationFunction) => continuationFunction(tuple.Item1, tuple.Item2), continuationFunction);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask ContinueWith<TFirst, TSecond, TThird>(this UniTask<(TFirst, TSecond, TThird)> task, Action<TFirst, TSecond, TThird> continuationFunction)
        {
            return task.ContinueWith(static (tuple, continuationFunction) => continuationFunction(tuple.Item1, tuple.Item2, tuple.Item3), continuationFunction);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TResult> ContinueWith<TFirst, TSecond, TResult>(this UniTask<(TFirst, TSecond)> task, Func<TFirst, TSecond, UniTask<TResult>> continuationFunction)
        {
            return task.ContinueWith(static (tuple, continuationFunction) => continuationFunction(tuple.Item1, tuple.Item2), continuationFunction);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TResult> ContinueWith<TFirst, TSecond, TThird, TResult>(this UniTask<(TFirst, TSecond, TThird)> task, Func<TFirst, TSecond, TThird, UniTask<TResult>> continuationFunction)
        {
            return task.ContinueWith(static (tuple, continuationFunction) => continuationFunction(tuple.Item1, tuple.Item2, tuple.Item3), continuationFunction);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TResult> ContinueWith<TFirst, TSecond, TResult>(this UniTask<(TFirst, TSecond)> task, Func<TFirst, TSecond, TResult> continuationFunction)
        {
            return task.ContinueWith(static (tuple, continuationFunction) => continuationFunction(tuple.Item1, tuple.Item2), continuationFunction);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TResult> ContinueWith<TFirst, TSecond, TThird, TResult>(this UniTask<(TFirst, TSecond, TThird)> task, Func<TFirst, TSecond, TThird, TResult> continuationFunction)
        {
            return task.ContinueWith(static (tuple, continuationFunction) => continuationFunction(tuple.Item1, tuple.Item2, tuple.Item3), continuationFunction);
        }
    }
}