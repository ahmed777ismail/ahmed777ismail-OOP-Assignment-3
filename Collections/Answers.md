# Collections - answers

## Task 2.1 - research

Sources: [IReadOnlyDictionary API](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ireadonlydictionary-2?view=net-10.0), [SortedDictionary API](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2?view=net-10.0), [Selecting a collection](https://learn.microsoft.com/dotnet/standard/collections/selecting-a-collection-class), and [sorted collections](https://learn.microsoft.com/en-us/dotnet/standard/collections/sorted-collection-types).

`IReadOnlyDictionary<TKey,TValue>` is a read-only key/value contract: callers can enumerate and look up, but the interface exposes no mutation. `Dictionary` is mutable. Returning the interface communicates the API contract and avoids coupling callers to an implementation. It is a read-only view, not necessarily an immutable snapshot.

`SortedDictionary<TKey,TValue>` maintains comparer-based key order. `Dictionary` is hash-based and promises no sorted order. Dictionary lookup is average O(1), while SortedDictionary lookup, insert, and removal are O(log n). Choose SortedDictionary when data changes over time but must always enumerate by key.

## Task 2.2 - pick the collection

| Scenario | Collection | Why |
|---|---|---|
| S1 | `Dictionary` | Average O(1) lookup suits frequent national-ID searches. |
| S2 | `HashSet` | It naturally prevents duplicate tags. |
| S3 | `List` | It preserves entry order and permits duplicates. |
| S4 | `IReadOnlyDictionary` | It exposes lookup without mutation operations. |
| S5 | `SortedDictionary` | It stays ordered by session start time. |
| S6 | `IEnumerable` | It supports lazy one-pass enumeration and early stopping. |
