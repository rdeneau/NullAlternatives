using System.Linq;

// ReSharper disable once CheckNamespace
// ReSharper disable PossibleMultipleEnumeration
namespace System.Collections.Generic
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TItem> DefaultIfEmpty<TItem>(this IEnumerable<TItem> source, Func<TItem> lambda)
        {
            return source.Any() ? source : new[] { lambda() };
        }
    }
}
