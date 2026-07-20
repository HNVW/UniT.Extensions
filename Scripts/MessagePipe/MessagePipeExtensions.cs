#nullable enable
namespace UniT.Extensions
{
    using System;
    using System.Threading;
    using Cysharp.Threading.Tasks;
    using MessagePipe;

    public static class MessagePipeExtensions
    {
        public static async UniTask WaitForMessageAsync<T>(this ISubscriber<T> subscriber, Func<T, bool>? predicate = null, CancellationToken cancellationToken = default) where T : notnull
        {
            predicate ??= static _ => true;
            var tcs = new UniTaskCompletionSource();
            using var _ = subscriber.Subscribe(message =>
            {
                if (predicate(message)) tcs.TrySetResult();
            });
            await tcs.Task.AttachExternalCancellation(cancellationToken);
        }
    }
}