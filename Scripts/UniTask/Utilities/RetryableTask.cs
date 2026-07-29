#nullable enable
namespace UniT.Extensions
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using Cysharp.Threading.Tasks;
    using UnityEngine;

    public sealed class RetryableTask
    {
        private readonly int retryCount;
        private readonly float retryIntervalSeconds;
        private readonly float retryIntervalMultiplier;
        private readonly float retryIntervalMax;
        private readonly bool ignoreTimeScale;

        public RetryableTask(int retryCount = -1, float retryIntervalSeconds = 1, float retryIntervalMultiplier = 2, float retryIntervalMax = 32, bool ignoreTimeScale = true)
        {
            this.retryCount = retryCount;
            this.retryIntervalSeconds = retryIntervalSeconds;
            this.retryIntervalMultiplier = retryIntervalMultiplier;
            this.retryIntervalMax = retryIntervalMax;
            this.ignoreTimeScale = ignoreTimeScale;
        }

        private CancellationTokenSource? cts;

        public async UniTask<bool> RunAsync<TState>(Func<TState, CancellationToken, UniTask<bool>> taskFactory, TState state)
        {
            this.cts ??= new();
            var attempt = 0;
            while (true)
            {
                if (await taskFactory(state, this.cts.Token)) return true;
                if (attempt == this.retryCount) return false;
                await UniTask.WaitForSeconds(
                    Mathf.Min(
                        this.retryIntervalSeconds * Mathf.Pow(this.retryIntervalMultiplier, attempt),
                        this.retryIntervalMax
                    ),
                    this.ignoreTimeScale,
                    cancellationToken: this.cts.Token
                );
                ++attempt;
            }
        }

        public async UniTask RunAsync<TState>(Func<TState, CancellationToken, UniTask> taskFactory, TState state)
        {
            this.cts ??= new();
            var attempt = 0;
            while (true)
            {
                try
                {
                    await taskFactory(state, this.cts.Token);
                    return;
                }
                catch (Exception e) when (e is not OperationCanceledException)
                {
                    if (attempt == this.retryCount) throw;
                }
                await UniTask.WaitForSeconds(
                    Mathf.Min(
                        this.retryIntervalSeconds * Mathf.Pow(this.retryIntervalMultiplier, attempt),
                        this.retryIntervalMax
                    ),
                    this.ignoreTimeScale,
                    cancellationToken: this.cts.Token
                );
                ++attempt;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UniTask<bool> RunAsync(Func<CancellationToken, UniTask<bool>> taskFactory)
        {
            return this.RunAsync(static (taskFactory, ct) => taskFactory(ct), taskFactory);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UniTask RunAsync(Func<CancellationToken, UniTask> taskFactory)
        {
            return this.RunAsync(static (taskFactory, ct) => taskFactory(ct), taskFactory);
        }

        public void Cancel()
        {
            this.cts?.Cancel();
            this.cts?.Dispose();
            this.cts = null;
        }
    }
}