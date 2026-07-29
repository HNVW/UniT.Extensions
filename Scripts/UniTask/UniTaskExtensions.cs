#nullable enable
namespace UniT.Extensions
{
    using System;
    using System.Threading;
    using Cysharp.Threading.Tasks;

    public static class UniTaskExtensions
    {
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