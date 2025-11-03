# Generic Extension Methods
This contains Extension Methods that work across generic collections and objects.
Followings are the Methods available for public use.

- [ForEach()](#foreach)
- [Randomize()](#randomize)
- [IsNullOrEmpty()](#isnullorempty)
- [IsNotNullOrEmpty()](#isnotnullorempty)
- [IsNullOrDefault()](#isnullordefault)
- [ToCollection()](#tocollection)
- [ToCSV()](#tocsv)
- [ToHashSet()](#tohashset)
- [IndexOf()](#indexof)
- [ToString(separator)](#tostringseparator)
- [Split()](#split)
- [TakeUntil()](#takeuntil)
- [SelectRandom()](#selectrandom)
- [IsSingle()](#issingle)
- [WrapEachWithTag()](#wrapeachwithtag)
- [IsSorted()](#issorted)
- [Slice()](#slice)
- [FindMin()](#findmin)
- [FindMax()](#findmax)
- [InsertSorted()](#insertsorted)
- [EmptyIfNull()](#emptyifnull)
- [AddRange()](#addrange)
- [BinarySearch()](#binarysearch)
- [IndicesOf()](#indicesof)
- [ToSortedString()](#tosortedstring)

## Api Reference Details

- ### ForEach()
  Iterates over any `IEnumerable<T>` and executes an action per item.

```csharp
public static void ForEach<T>(this IEnumerable<T> source, Action<T> action);
```

#### Example

```csharp
    new[]{1,2,3}.ForEach(i => Console.Write(i)); // 123
```

- ### Randomize()
  Returns a randomized ordering of a sequence.

```csharp
public static IEnumerable<T> Randomize<T>(this IEnumerable<T> target);
```

- ### IsNullOrEmpty()
  True if the sequence is null or has no elements.

```csharp
public static bool IsNullOrEmpty<T>(this IEnumerable<T> source);
```

- ### IsNotNullOrEmpty()
  True if the sequence is not null and has at least one element.

```csharp
public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> source);
```

- ### IsNullOrDefault()
  Checks a nullable struct for null or default value.

```csharp
public static bool IsNullOrDefault<T>(this T? value) where T : struct;
```

- ### ToCollection()
  Converts an `IEnumerable<T>` to `Collection<T>`.

```csharp
public static Collection<T> ToCollection<T>(this IEnumerable<T> enumerable);
```

- ### ToCSV()
  Converts an `IEnumerable<T>` to CSV string with optional separator.

```csharp
public static string ToCSV<T>(this IEnumerable<T> instance);
public static string ToCSV<T>(this IEnumerable<T> instance, char separator);
```

- ### ToHashSet()
  Converts an `IEnumerable<T>` to `HashSet<T>`.

```csharp
public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable);
```

- ### IndexOf()
  Finds index of first occurrence using default or provided comparer.

```csharp
public static int IndexOf<TSource>(this IEnumerable<TSource> list, TSource value) where TSource : IEquatable<TSource>;
public static int IndexOf<TSource>(this IEnumerable<TSource> list, TSource value, IEqualityComparer<TSource> comparer);
```

- ### ToString(separator)
  Joins a sequence with a separator into a single string.

```csharp
public static string ToString<T>(this IEnumerable<T> list, string separator);
```

- ### Split()
  Splits a sequence into chunks of a given size.

```csharp
public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int splitSize);
```

- ### TakeUntil()
  Continues processing items until the end condition becomes true.

```csharp
public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> collection, Predicate<T> endCondition);
```

- ### SelectRandom()
  Selects a random element from a sequence.

```csharp
public static T SelectRandom<T>(this IEnumerable<T> sequence);
```

- ### IsSingle()
  True if the sequence contains exactly one element.

```csharp
public static bool IsSingle<T>(this IEnumerable<T> source);
```

- ### WrapEachWithTag()
  Wraps each element’s `ToString()` with the specified tag and concatenates.

```csharp
public static string WrapEachWithTag<T>(this IEnumerable<T> source, string tagToWrap);
```

- ### IsSorted()
  Checks whether a sequence is sorted according to a comparison (defaults to `Comparer<T>.Default`).

```csharp
public static bool IsSorted<T>(this IEnumerable<T> source, Comparison<T> comparison = null);
```

- ### Slice()
  Returns a portion of a sequence starting at index `start` for `count` items.

```csharp
public static IEnumerable<T> Slice<T>(this IEnumerable<T> source, int start, int count);
```

- ### FindMin() / FindMax()
  Returns the element with min/max value by a selector.

```csharp
public static T FindMin<T, TValue>(this IEnumerable<T> list, Func<T, TValue> predicate) where TValue : IComparable<TValue>;
public static T FindMax<T, TValue>(this IEnumerable<T> list, Func<T, TValue> predicate) where TValue : IComparable<TValue>;
```

- ### InsertSorted()
  Inserts an element into a pre-sorted list at its proper position.

```csharp
public static int InsertSorted<T>(this IList<T> source, T value) where T : IComparable<T>;
public static int InsertSorted<T>(this IList<T> source, T value, IComparer<T> comparison);
public static int InsertSorted<T>(this IList<T> source, T value, Comparison<T> comparison);
```

- ### EmptyIfNull()
  Returns an empty sequence if the sequence is null.

```csharp
public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> sequence);
```

- ### AddRange()
  Adds multiple elements to a list (params overload).

```csharp
public static void AddRange<T, S>(this IList<T> list, params S[] values) where S : T;
```

- ### BinarySearch()
  Binary search in a sorted list by key selector.

```csharp
public static T BinarySearch<T, TKey>(this IList<T> list, Func<T, TKey> keySelector, TKey key) where TKey : IComparable<TKey>;
```

- ### IndicesOf()
  Finds all indexes of a given value or collection of values.

```csharp
public static IEnumerable<int> IndicesOf<T>(this IEnumerable<T> seq, T value);
public static IEnumerable<int> IndicesOf<T>(this IEnumerable<T> obj, IEnumerable<T> values);
```

- ### ToSortedString()
  Returns an alphabetically sorted list of property names and values of an object, joined by a separator.

```csharp
public static string ToSortedString(this object value, string charSeparator = ", ");