namespace Assignment.Generics;
public sealed class Store<T> where T : IHasId
{
    private readonly Dictionary<int, T> _items = [];
    public void Add(T item)
    {
        if (_items.ContainsKey(item.Id)) throw new InvalidOperationException($"An item with ID {item.Id} already exists.");
        _items.Add(item.Id, item);
    }
    public T? GetById(int id) => _items.TryGetValue(id, out var item) ? item : default;
    public IReadOnlyCollection<T> GetAll() => _items.Values;
    public void Remove(int id) => _items.Remove(id);
}
