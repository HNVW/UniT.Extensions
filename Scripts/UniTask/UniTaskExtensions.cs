#nullable enable
namespace UniT.Extensions
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using Cysharp.Threading.Tasks;

    public static class UniTaskExtensions
    {
        public static async UniTask ContinueWith<T, TState>(this UniTask<T> task, Action<T, TState> continuationFunction, TState state)
        {
            continuationFunction(await task, state);
        }

        public static async UniTask ContinueWith<T, TState>(this UniTask<T> task, Func<T, TState, UniTask> continuationFunction, TState state)
        {
            await continuationFunction(await task, state);
        }

        public static async UniTask<TResult> ContinueWith<T, TResult, TState>(this UniTask<T> task, Func<T, TState, TResult> continuationFunction, TState state)
        {
            return continuationFunction(await task, state);
        }

        public static async UniTask<TResult> ContinueWith<T, TResult, TState>(this UniTask<T> task, Func<T, TState, UniTask<TResult>> continuationFunction, TState state)
        {
            return await continuationFunction(await task, state);
        }

        public static async UniTask ContinueWith<TState>(this UniTask task, Action<TState> continuationFunction, TState state)
        {
            await task;
            continuationFunction(state);
        }

        public static async UniTask ContinueWith<TState>(this UniTask task, Func<TState, UniTask> continuationFunction, TState state)
        {
            await task;
            await continuationFunction(state);
        }

        public static async UniTask<TResult> ContinueWith<TResult, TState>(this UniTask task, Func<TState, TResult> continuationFunction, TState state)
        {
            await task;
            return continuationFunction(state);
        }

        public static async UniTask<TResult> ContinueWith<TResult, TState>(this UniTask task, Func<TState, UniTask<TResult>> continuationFunction, TState state)
        {
            await task;
            return await continuationFunction(state);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TBase> UpCast<TDerived, TBase>(this UniTask<TDerived> task) where TDerived : TBase
        {
            return task.ContinueWith(Item.UpCast<TDerived, TBase>);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UniTask<TDerived> DownCast<TBase, TDerived>(this UniTask<TBase> task) where TDerived : TBase
        {
            return task.ContinueWith(Item.DownCast<TBase, TDerived>);
        }

        public static async UniTask<T> RunOnThreadPool<T, TState>(Func<TState, T> func, TState state, CancellationToken cancellationToken = default)
        {
#if !UNITY_WEBGL
            await UniTask.SwitchToThreadPool();
            await using var _ = UniTask.ReturnToMainThread(cancellationToken);
#endif
            return func(state);
        }

        public static async UniTask<T> RunOnThreadPool<T>(Func<T> func, CancellationToken cancellationToken = default)
        {
#if !UNITY_WEBGL
            await UniTask.SwitchToThreadPool();
            await using var _ = UniTask.ReturnToMainThread(cancellationToken);
#endif
            return func();
        }
    }
}