# LinkedIn post drafts

These drafts are original summaries. The snippets were compiled and run locally with .NET 10.

## 1. HashSet.Contains vs List.Contains

Today I measured membership lookup in C#.

`List<T>.Contains` checks items one by one, so lookup is O(n). `HashSet<T>.Contains` uses hashing, so lookup is O(1) on average (with O(n) worst-case behavior).

```csharp
var list = new List<int>();
for (var i = 0; i < 100_000; i++) list.Add(i);
var set = new HashSet<int>(list);

for (var i = 0; i < 20_000; i++) list.Contains(99_999);
for (var i = 0; i < 20_000; i++) set.Contains(99_999);
```

On my machine: List = **218 ms**, HashSet = **less than 1 ms**. A HashSet costs extra memory and does not model ordered duplicates, but it is the better fit for repeated membership tests.

## 2. The yield keyword

`yield return` produces one value and pauses the iterator. `yield break` ends it. This makes an `IEnumerable<T>` lazy: it does not build the entire result first.

```csharp
static IEnumerable<int> CountTo(int max)
{
    for (var i = 1; i <= max; i++) {
        if (i > 5) yield break;
        yield return i;
    }
}
```

If the caller stops after three items, later items are never produced. One caution: iterator code runs during enumeration, so side effects and exceptions may happen later - and repeated enumeration repeats the work.

## 3. Span<T>

`Span<T>` is a lightweight view over contiguous memory. It can slice an array, stack buffer, or string data without copying that data.

```csharp
var text = "SIMULATION";
ReadOnlySpan<char> first = text.AsSpan(0, 3);
Console.WriteLine(first); // SIM
```

That is useful in parsers and hot paths where temporary substrings would allocate. One limitation is that Span is a `ref struct`: it cannot be stored as a field in a normal class or cross an `await` boundary in the same block.

Research: [Microsoft performance guide](https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/performance/) and [ref struct rules](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/ref-struct).

## 4. Extension members in C# 14 / .NET 10

Classic extension methods put `this` on their first parameter. C# 14 adds extension blocks. They keep extension methods and also enable extension properties and static extension members.

```csharp
// Before
public static int WordCount(this string value) => value.Split(' ').Length;

// C# 14
extension(string value)
{
    public int WordCount => value.Split(' ').Length;
    public static string Category => "Text";
}
```

Callers can use `text.WordCount`, and the extended type can expose a static member too. The syntax groups related additions without modifying or inheriting from the original type.

Research: [C# reference](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extension) and [C# 14 feature specification](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-14.0/extensions).
