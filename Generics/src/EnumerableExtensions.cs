namespace Assignment.Generics;
public static class EnumerableExtensions
{
    public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
    {
        if (pageNumber < 1) throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be at least 1.");
        if (pageSize < 1) throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be at least 1.");
        var skip = checked((pageNumber - 1) * pageSize);
        var index = 0;
        foreach (var item in source)
        {
            if (index >= skip && index < skip + pageSize) yield return item;
            if (index >= skip + pageSize) yield break;
            index++;
        }
    }
    public static T? FindById<T>(this IEnumerable<T> source, int id) where T : IHasId
    { foreach (var item in source) if (item.Id == id) return item; return default; }
    public static IReadOnlyDictionary<int, T> ToIdDictionary<T>(this IEnumerable<T> source) where T : IHasId
    { var result = new Dictionary<int, T>(); foreach (var item in source) result.Add(item.Id, item); return result; }
}
