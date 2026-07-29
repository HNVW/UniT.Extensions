#nullable enable
namespace UniT.Extensions
{
    using System;
    using System.Threading;
    using Cysharp.Threading.Tasks;

    public sealed class CancellableTask
    {
        private CancellationTokenSource? cts;

        public UniTask RunAsync<TState>(Func<TState, CancellationToken, UniTask> taskFactory, TState state)
        {
            this.cts ??= new();
            return taskFactory(state, this.cts.Token);
        }

        public UniTask RunAsync(Func<CancellationToken, UniTask> taskFactory)
        {
            this.cts ??= new();
            return taskFactory(this.cts.Token);
        }

        public void Cancel()
        {
            this.cts?.Cancel();
            this.cts?.Dispose();
            this.cts = null;
        }
    }
}