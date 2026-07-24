#nullable enable
namespace UniT.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public static class GroupExtensions
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IGrouping<TKey, TItem> MinByKey<TKey, TItem>(this IEnumerable<IGrouping<TKey, TItem>> enumerable, IComparer<TKey>? comparer = null)
        {
            return enumerable.MinBy(static kv => kv.Key, comparer);
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IGrouping<TKey, TItem> MinByKey<TKey, TItem, TCompareKey>(this IEnumerable<IGrouping<TKey, TItem>> enumerable, Func<TKey, TCompareKey> keySelector, IComparer<TCompareKey>? comparer = null)
        {
            return enumerable.MinBy(kv => keySelector(kv.Key), comparer);
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IGrouping<TKey, TItem> MaxByKey<TKey, TItem>(this IEnumerable<IGrouping<TKey, TItem>> enumerable, IComparer<TKey>? comparer = null)
        {
            return enumerable.MaxBy(static kv => kv.Key, comparer);
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IGrouping<TKey, TItem> MaxByKey<TKey, TItem, TCompareKey>(this IEnumerable<IGrouping<TKey, TItem>> enumerable, Func<TKey, TCompareKey> keySelector, IComparer<TCompareKey>? comparer = null)
        {
            return enumerable.MaxBy(kv => keySelector(kv.Key), comparer);
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IOrderedEnumerable<IGrouping<TKey, TItem>> OrderByKey<TItem, TKey>(this IEnumerable<IGrouping<TKey, TItem>> enumerable, IComparer<TKey>? comparer = null)
        {
            return enumerable.OrderBy(static group => group.Key, comparer);
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IOrderedEnumerable<IGrouping<TKey, TItem>> OrderByKey<TItem, TKey, TOrderKey>(this IEnumerable<IGrouping<TKey, TItem>> enumerable, Func<TKey, TOrderKey> keySelector, IComparer<TOrderKey>? comparer = null)
        {
            return enumerable.OrderBy(group => keySelector(group.Key), comparer);
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IOrderedEnumerable<IGrouping<TKey, TItem>> OrderByDescendingKey<TItem, TKey>(this IEnumerable<IGrouping<TKey, TItem>> enumerable, IComparer<TKey>? comparer = null)
        {
            return enumerable.OrderByDescending(static group => group.Key, comparer);
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IOrderedEnumerable<IGrouping<TKey, TItem>> OrderByDescendingKey<TItem, TKey, TOrderKey>(this IEnumerable<IGrouping<TKey, TItem>> enumerable, Func<TKey, TOrderKey> keySelector, IComparer<TOrderKey>? comparer = null)
        {
            return enumerable.OrderByDescending(group => keySelector(group.Key), comparer);
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IOrderedEnumerable<IGrouping<TKey, TItem>> ThenByKey<TItem, TKey>(this IOrderedEnumerable<IGrouping<TKey, TItem>> enumerable, IComparer<TKey>? comparer = null)
        {
            return enumerable.ThenBy(static group => group.Key, comparer);
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IOrderedEnumerable<IGrouping<TKey, TItem>> ThenByKey<TItem, TKey, TOrderKey>(this IOrderedEnumerable<IGrouping<TKey, TItem>> enumerable, Func<TKey, TOrderKey> keySelector, IComparer<TOrderKey>? comparer = null)
        {
            return enumerable.ThenBy(group => keySelector(group.Key), comparer);
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IOrderedEnumerable<IGrouping<TKey, TItem>> ThenByDescendingKey<TItem, TKey>(this IOrderedEnumerable<IGrouping<TKey, TItem>> enumerable, IComparer<TKey>? comparer = null)
        {
            return enumerable.ThenByDescending(static group => group.Key, comparer);
        }

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IOrderedEnumerable<IGrouping<TKey, TItem>> ThenByDescendingKey<TItem, TKey, TOrderKey>(this IOrderedEnumerable<IGrouping<TKey, TItem>> enumerable, Func<TKey, TOrderKey> keySelector, IComparer<TOrderKey>? comparer = null)
        {
            return enumerable.ThenByDescending(group => keySelector(group.Key), comparer);
        }
    }
}