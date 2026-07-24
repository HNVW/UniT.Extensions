#nullable enable
namespace UniT.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public static class IterTools
    {
        [Pure]
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            using var enumerator1 = first.GetEnumerator();
            using var enumerator2 = second.GetEnumerator();
            var hasValue1 = enumerator1.MoveNext();
            var hasValue2 = enumerator2.MoveNext();
            while (hasValue1 && hasValue2)
            {
                yield return resultSelector(enumerator1.Current, enumerator2.Current);
                hasValue1 = enumerator1.MoveNext();
                hasValue2 = enumerator2.MoveNext();
            }
            if (hasValue1 || hasValue2) throw new InvalidOperationException("The number of items are different. If this is intentional, use ZipShortest or ZipLongest instead.");
        }

        [Pure]
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult, TState>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TState, TResult> resultSelector, TState state) where TState : notnull
        {
            using var enumerator1 = first.GetEnumerator();
            using var enumerator2 = second.GetEnumerator();
            var hasValue1 = enumerator1.MoveNext();
            var hasValue2 = enumerator2.MoveNext();
            while (hasValue1 && hasValue2)
            {
                yield return resultSelector(enumerator1.Current, enumerator2.Current, state);
                hasValue1 = enumerator1.MoveNext();
                hasValue2 = enumerator2.MoveNext();
            }
            if (hasValue1 || hasValue2) throw new InvalidOperationException("The number of items are different. If this is intentional, use ZipShortest or ZipLongest instead.");
        }

        [Pure]
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TThird, TResult>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, IEnumerable<TThird> third, Func<TFirst, TSecond, TThird, TResult> resultSelector)
        {
            using var enumerator1 = first.GetEnumerator();
            using var enumerator2 = second.GetEnumerator();
            using var enumerator3 = third.GetEnumerator();
            var hasValue1 = enumerator1.MoveNext();
            var hasValue2 = enumerator2.MoveNext();
            var hasValue3 = enumerator3.MoveNext();
            while (hasValue1 && hasValue2 && hasValue3)
            {
                yield return resultSelector(enumerator1.Current, enumerator2.Current, enumerator3.Current);
                hasValue1 = enumerator1.MoveNext();
                hasValue2 = enumerator2.MoveNext();
                hasValue3 = enumerator3.MoveNext();
            }
            if (hasValue1 || hasValue2 || hasValue3) throw new InvalidOperationException("The number of items are different. If this is intentional, use ZipShortest or ZipLongest instead.");
        }

        [Pure]
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TThird, TResult, TState>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, IEnumerable<TThird> third, Func<TFirst, TSecond, TThird, TState, TResult> resultSelector, TState state) where TState : notnull
        {
            using var enumerator1 = first.GetEnumerator();
            using var enumerator2 = second.GetEnumerator();
            using var enumerator3 = third.GetEnumerator();
            var hasValue1 = enumerator1.MoveNext();
            var hasValue2 = enumerator2.MoveNext();
            var hasValue3 = enumerator3.MoveNext();
            while (hasValue1 && hasValue2 && hasValue3)
            {
                yield return resultSelector(enumerator1.Current, enumerator2.Current, enumerator3.Current, state);
                hasValue1 = enumerator1.MoveNext();
                hasValue2 = enumerator2.MoveNext();
                hasValue3 = enumerator3.MoveNext();
            }
            if (hasValue1 || hasValue2 || hasValue3) throw new InvalidOperationException("The number of items are different. If this is intentional, use ZipShortest or ZipLongest instead.");
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<(TFirst, TSecond)> Zip<TFirst, TSecond>(IEnumerable<TFirst> first, IEnumerable<TSecond> second)
        {
            return Zip(first, second, static (i1, i2) => (i1, i2));
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<(TFirst, TSecond, TThird)> Zip<TFirst, TSecond, TThird>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, IEnumerable<TThird> third)
        {
            return Zip(first, second, third, static (i1, i2, i3) => (i1, i2, i3));
        }

        [Pure]
        public static IEnumerable<TResult> ZipShortest<TFirst, TSecond, TResult>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            using var enumerator1 = first.GetEnumerator();
            using var enumerator2 = second.GetEnumerator();
            while (enumerator1.TryGetNext(out var item1) && enumerator2.TryGetNext(out var item2))
            {
                yield return resultSelector(item1, item2);
            }
        }

        [Pure]
        public static IEnumerable<TResult> ZipShortest<TFirst, TSecond, TResult, TState>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TState, TResult> resultSelector, TState state) where TState : notnull
        {
            using var enumerator1 = first.GetEnumerator();
            using var enumerator2 = second.GetEnumerator();
            while (enumerator1.TryGetNext(out var item1) && enumerator2.TryGetNext(out var item2))
            {
                yield return resultSelector(item1, item2, state);
            }
        }

        [Pure]
        public static IEnumerable<TResult> ZipShortest<TFirst, TSecond, TThird, TResult>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, IEnumerable<TThird> third, Func<TFirst, TSecond, TThird, TResult> resultSelector)
        {
            using var enumerator1 = first.GetEnumerator();
            using var enumerator2 = second.GetEnumerator();
            using var enumerator3 = third.GetEnumerator();
            while (enumerator1.TryGetNext(out var item1) && enumerator2.TryGetNext(out var item2) && enumerator3.TryGetNext(out var item3))
            {
                yield return resultSelector(item1, item2, item3);
            }
        }

        [Pure]
        public static IEnumerable<TResult> ZipShortest<TFirst, TSecond, TThird, TResult, TState>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, IEnumerable<TThird> third, Func<TFirst, TSecond, TThird, TState, TResult> resultSelector, TState state) where TState : notnull
        {
            using var enumerator1 = first.GetEnumerator();
            using var enumerator2 = second.GetEnumerator();
            using var enumerator3 = third.GetEnumerator();
            while (enumerator1.TryGetNext(out var item1) && enumerator2.TryGetNext(out var item2) && enumerator3.TryGetNext(out var item3))
            {
                yield return resultSelector(item1, item2, item3, state);
            }
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<(TFirst, TSecond)> ZipShortest<TFirst, TSecond>(IEnumerable<TFirst> first, IEnumerable<TSecond> second)
        {
            return ZipShortest(first, second, static (i1, i2) => (i1, i2));
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<(TFirst, TSecond, TThird)> ZipShortest<TFirst, TSecond, TThird>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, IEnumerable<TThird> third)
        {
            return ZipShortest(first, second, third, static (i1, i2, i3) => (i1, i2, i3));
        }

        [Pure]
        public static IEnumerable<TResult> ZipLongest<TFirst, TSecond, TResult>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst?, TSecond?, TResult> resultSelector)
        {
            using var enumerator1 = first.GetEnumerator();
            using var enumerator2 = second.GetEnumerator();
            var hasValue1 = enumerator1.TryGetNext(out var item1);
            var hasValue2 = enumerator2.TryGetNext(out var item2);
            while (hasValue1 || hasValue2)
            {
                yield return resultSelector(item1, item2);
                hasValue1 = enumerator1.TryGetNext(out item1);
                hasValue2 = enumerator2.TryGetNext(out item2);
            }
        }

        [Pure]
        public static IEnumerable<TResult> ZipLongest<TFirst, TSecond, TResult, TState>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst?, TSecond?, TState, TResult> resultSelector, TState state) where TState : notnull
        {
            using var enumerator1 = first.GetEnumerator();
            using var enumerator2 = second.GetEnumerator();
            var hasValue1 = enumerator1.TryGetNext(out var item1);
            var hasValue2 = enumerator2.TryGetNext(out var item2);
            while (hasValue1 || hasValue2)
            {
                yield return resultSelector(item1, item2, state);
                hasValue1 = enumerator1.TryGetNext(out item1);
                hasValue2 = enumerator2.TryGetNext(out item2);
            }
        }

        [Pure]
        public static IEnumerable<TResult> ZipLongest<TFirst, TSecond, TThird, TResult>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, IEnumerable<TThird> third, Func<TFirst?, TSecond?, TThird?, TResult> resultSelector)
        {
            using var enumerator1 = first.GetEnumerator();
            using var enumerator2 = second.GetEnumerator();
            using var enumerator3 = third.GetEnumerator();
            var hasValue1 = enumerator1.TryGetNext(out var item1);
            var hasValue2 = enumerator2.TryGetNext(out var item2);
            var hasValue3 = enumerator3.TryGetNext(out var item3);
            while (hasValue1 || hasValue2 || hasValue3)
            {
                yield return resultSelector(item1, item2, item3);
                hasValue1 = enumerator1.TryGetNext(out item1);
                hasValue2 = enumerator2.TryGetNext(out item2);
                hasValue3 = enumerator3.TryGetNext(out item3);
            }
        }

        [Pure]
        public static IEnumerable<TResult> ZipLongest<TFirst, TSecond, TThird, TResult, TState>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, IEnumerable<TThird> third, Func<TFirst?, TSecond?, TThird?, TState, TResult> resultSelector, TState state) where TState : notnull
        {
            using var enumerator1 = first.GetEnumerator();
            using var enumerator2 = second.GetEnumerator();
            using var enumerator3 = third.GetEnumerator();
            var hasValue1 = enumerator1.TryGetNext(out var item1);
            var hasValue2 = enumerator2.TryGetNext(out var item2);
            var hasValue3 = enumerator3.TryGetNext(out var item3);
            while (hasValue1 || hasValue2 || hasValue3)
            {
                yield return resultSelector(item1, item2, item3, state);
                hasValue1 = enumerator1.TryGetNext(out item1);
                hasValue2 = enumerator2.TryGetNext(out item2);
                hasValue3 = enumerator3.TryGetNext(out item3);
            }
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<(TFirst?, TSecond?)> ZipLongest<TFirst, TSecond>(IEnumerable<TFirst> first, IEnumerable<TSecond> second)
        {
            return ZipLongest(first, second, static (i1, i2) => (i1, i2));
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<(TFirst?, TSecond?, TThird?)> ZipLongest<TFirst, TSecond, TThird>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, IEnumerable<TThird> third)
        {
            return ZipLongest(first, second, third, static (i1, i2, i3) => (i1, i2, i3));
        }

        [Pure]
        public static IEnumerable<TResult> Product<TFirst, TSecond, TResult>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            var firstCollection = first as ICollection<TFirst> ?? first.ToArray();
            var secondCollection = second as ICollection<TSecond> ?? second.ToArray();
            foreach (var i1 in firstCollection)
            {
                foreach (var i2 in secondCollection)
                {
                    yield return resultSelector(i1, i2);
                }
            }
        }

        [Pure]
        public static IEnumerable<TResult> Product<TFirst, TSecond, TResult, TState>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TState, TResult> resultSelector, TState state) where TState : notnull
        {
            var firstCollection = first as ICollection<TFirst> ?? first.ToArray();
            var secondCollection = second as ICollection<TSecond> ?? second.ToArray();
            foreach (var i1 in firstCollection)
            {
                foreach (var i2 in secondCollection)
                {
                    yield return resultSelector(i1, i2, state);
                }
            }
        }

        [Pure]
        public static IEnumerable<TResult> Product<TFirst, TSecond, TThird, TResult>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, IEnumerable<TThird> third, Func<TFirst, TSecond, TThird, TResult> resultSelector)
        {
            var firstCollection = first as ICollection<TFirst> ?? first.ToArray();
            var secondCollection = second as ICollection<TSecond> ?? second.ToArray();
            var thirdCollection = third as ICollection<TThird> ?? third.ToArray();
            foreach (var i1 in firstCollection)
            {
                foreach (var i2 in secondCollection)
                {
                    foreach (var i3 in thirdCollection)
                    {
                        yield return resultSelector(i1, i2, i3);
                    }
                }
            }
        }

        [Pure]
        public static IEnumerable<TResult> Product<TFirst, TSecond, TThird, TResult, TState>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, IEnumerable<TThird> third, Func<TFirst, TSecond, TThird, TState, TResult> resultSelector, TState state) where TState : notnull
        {
            var firstCollection = first as ICollection<TFirst> ?? first.ToArray();
            var secondCollection = second as ICollection<TSecond> ?? second.ToArray();
            var thirdCollection = third as ICollection<TThird> ?? third.ToArray();
            foreach (var i1 in firstCollection)
            {
                foreach (var i2 in secondCollection)
                {
                    foreach (var i3 in thirdCollection)
                    {
                        yield return resultSelector(i1, i2, i3, state);
                    }
                }
            }
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<(TFirst, TSecond)> Product<TFirst, TSecond>(IEnumerable<TFirst> first, IEnumerable<TSecond> second)
        {
            return Product(first, second, static (i1, i2) => (i1, i2));
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<(TFirst, TSecond, TThird)> Product<TFirst, TSecond, TThird>(IEnumerable<TFirst> first, IEnumerable<TSecond> second, IEnumerable<TThird> third)
        {
            return Product(first, second, third, static (i1, i2, i3) => (i1, i2, i3));
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<(int, int)> Product(int first, int second)
        {
            return Product(Ranges.Take(first), Ranges.Take(second));
        }

        [Pure]
        public static IEnumerable<IReadOnlyList<T>> Permutations<T>(IEnumerable<T> enumerable, int count, bool useSharedBuffer = false)
        {
            var items = enumerable as IList<T> ?? enumerable.ToArray();
            var buffer = new List<T>(count);
            var used = new bool[items.Count];
            return PermutationsRecursive(items, count, buffer, used, useSharedBuffer);

            static IEnumerable<IReadOnlyList<T>> PermutationsRecursive(IList<T> items, int count, List<T> buffer, bool[] used, bool useSharedBuffer)
            {
                if (count is 0)
                {
                    yield return useSharedBuffer ? buffer : buffer.ToArray();
                    yield break;
                }

                for (var i = 0; i < items.Count; ++i)
                {
                    if (used[i]) continue;

                    used[i] = true;
                    buffer.Add(items[i]);

                    foreach (var result in PermutationsRecursive(items, count - 1, buffer, used, useSharedBuffer))
                    {
                        yield return result;
                    }

                    buffer.RemoveAt(buffer.Count - 1);
                    used[i] = false;
                }
            }
        }

        [Pure]
        public static IEnumerable<IReadOnlyList<T>> Permutations<T>(IEnumerable<T> enumerable, bool useSharedBuffer = false)
        {
            var items = enumerable as IList<T> ?? enumerable.ToArray();
            return Permutations(items, items.Count, useSharedBuffer);
        }

        [Pure]
        public static IEnumerable<IReadOnlyList<T>> Combinations<T>(IEnumerable<T> enumerable, int count, bool useSharedBuffer = false)
        {
            var items = enumerable as IList<T> ?? enumerable.ToArray();
            var buffer = new List<T>(count);
            return CombinationsRecursive(items, count, 0, buffer, useSharedBuffer);

            static IEnumerable<IReadOnlyList<T>> CombinationsRecursive(IList<T> items, int count, int startIndex, List<T> buffer, bool useSharedBuffer)
            {
                if (count is 0)
                {
                    yield return useSharedBuffer ? buffer : buffer.ToArray();
                    yield break;
                }

                for (var i = startIndex; i <= items.Count - count; ++i)
                {
                    buffer.Add(items[i]);

                    foreach (var result in CombinationsRecursive(items, count - 1, i + 1, buffer, useSharedBuffer))
                    {
                        yield return result;
                    }

                    buffer.RemoveAt(buffer.Count - 1);
                }
            }
        }

        [Pure]
        public static IEnumerable<IReadOnlyList<T>> CombinationsWithReplacement<T>(IEnumerable<T> enumerable, int count, bool useSharedBuffer = false)
        {
            var items = enumerable as IList<T> ?? enumerable.ToArray();
            var buffer = new List<T>(count);
            return CombinationsWithReplacementRecursive(items, count, 0, buffer, useSharedBuffer);

            static IEnumerable<IReadOnlyList<T>> CombinationsWithReplacementRecursive(IList<T> items, int count, int startIndex, List<T> buffer, bool useSharedBuffer)
            {
                if (count is 0)
                {
                    yield return useSharedBuffer ? buffer : buffer.ToArray();
                    yield break;
                }

                for (var i = startIndex; i < items.Count; ++i)
                {
                    buffer.Add(items[i]);

                    foreach (var result in CombinationsWithReplacementRecursive(items, count - 1, i, buffer, useSharedBuffer))
                    {
                        yield return result;
                    }

                    buffer.RemoveAt(buffer.Count - 1);
                }
            }
        }

        [Pure]
        public static IEnumerable<T> Repeat<T>(Func<T> itemFactory, int count)
        {
            while (count-- > 0) yield return itemFactory();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Repeat(Action action, int count)
        {
            while (count-- > 0) action();
        }
    }
}