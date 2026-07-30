#nullable enable
namespace UniT.Extensions
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public static class ParallelEnumerableExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ParallelForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            Parallel.ForEach(enumerable, action);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SnapshotParallelForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable is ICollection<T> collection)
            {
                if (collection.Count is 0) return;
                var array = ArrayPool<T>.Shared.Rent(collection.Count);
                try
                {
                    collection.CopyTo(array, 0);
                    array.Take(collection.Count).ParallelForEach(action);
                }
                finally
                {
                    ArrayPool<T>.Shared.Return(array, RuntimeHelpers.IsReferenceOrContainsReferences<T>());
                }
            }
            else
            {
                enumerable.ToArray().ParallelForEach(action);
            }
        }
    }
}