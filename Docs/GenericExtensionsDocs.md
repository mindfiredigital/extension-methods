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

#### Example

```csharp
var randomized = new[] { 1, 2, 3, 4, 5 }.Randomize().ToList();
```

- ### IsNullOrEmpty()
  True if the sequence is null or has no elements.

```csharp
public static bool IsNullOrEmpty<T>(this IEnumerable<T> source);
```

#### Example

```csharp
List<int> empty = new List<int>();
bool result = empty.IsNullOrEmpty(); // true
```

- ### IsNotNullOrEmpty()
  True if the sequence is not null and has at least one element.

```csharp
public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> source);
```

#### Example

```csharp
var numbers = new[] { 10 };
bool hasItems = numbers.IsNotNullOrEmpty(); // true
```

- ### IsNullOrDefault()
  Checks a nullable struct for null or default value.

```csharp
public static bool IsNullOrDefault<T>(this T? value) where T : struct;
```

#### Example

```csharp
int? a = null;           // true
bool r1 = a.IsNullOrDefault();

int? b = 0;              // true (default of int)
bool r2 = b.IsNullOrDefault();

int? c = 5;              // false
bool r3 = c.IsNullOrDefault();
```

- ### ToCollection()
  Converts an `IEnumerable<T>` to `Collection<T>`.

```csharp
public static Collection<T> ToCollection<T>(this IEnumerable<T> enumerable);
```

#### Example

```csharp
var coll = new[] { "a", "b" }.ToCollection();
```

- ### ToCSV()
  Converts an `IEnumerable<T>` to CSV string with optional separator.

```csharp
public static string ToCSV<T>(this IEnumerable<T> instance);
public static string ToCSV<T>(this IEnumerable<T> instance, char separator);
```

#### Example

```csharp
var csv1 = new[] { "x", "y", "z" }.ToCSV();      // "x,y,z"
var csv2 = new[] { 1, 2, 3 }.ToCSV(';');             // "1;2;3"
```

- ### ToHashSet()
  Converts an `IEnumerable<T>` to `HashSet<T>`.

```csharp
public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable);
```

#### Example

```csharp
var set = new[] { 1, 1, 2, 3 }.ToHashSet(); // {1,2,3}
```

- ### IndexOf()
  Finds index of first occurrence using default or provided comparer.

```csharp
public static int IndexOf<TSource>(this IEnumerable<TSource> list, TSource value) where TSource : IEquatable<TSource>;
public static int IndexOf<TSource>(this IEnumerable<TSource> list, TSource value, IEqualityComparer<TSource> comparer);
```

#### Example

```csharp
int idx = new[] { "a", "b", "c" }.IndexOf("b"); // 1
```

- ### ToString(separator)
  Joins a sequence with a separator into a single string.

```csharp
public static string ToString<T>(this IEnumerable<T> list, string separator);
```

#### Example

```csharp
string s = new[] { 1, 2, 3 }.ToString(" - "); // "1 - 2 - 3"
```

- ### Split()
  Splits a sequence into chunks of a given size.

```csharp
public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int splitSize);
```

#### Example

```csharp
var chunks = Enumerable.Range(1, 7).Split(3).Select(c => c.ToList()).ToList();
// chunks: [ [1,2,3], [4,5,6], [7] ]
```

- ### TakeUntil()
  Continues processing items until the end condition becomes true.

```csharp
public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> collection, Predicate<T> endCondition);
```

#### Example

```csharp
var taken = Enumerable.Range(1, 10).TakeUntil(i => i > 5).ToList(); // [1,2,3,4,5]
```

- ### SelectRandom()
  Selects a random element from a sequence.

```csharp
public static T SelectRandom<T>(this IEnumerable<T> sequence);
```

#### Example

```csharp
var any = new[] { "red", "green", "blue" }.SelectRandom();
```

- ### IsSingle()
  True if the sequence contains exactly one element.

```csharp
public static bool IsSingle<T>(this IEnumerable<T> source);
```

#### Example

```csharp
bool single = new[] { 42 }.IsSingle(); // true
```

- ### WrapEachWithTag()
  Wraps each element’s `ToString()` with the specified tag and concatenates.

```csharp
public static string WrapEachWithTag<T>(this IEnumerable<T> source, string tagToWrap);
```

#### Example

```csharp
string html = new[] { "one", "two" }.WrapEachWithTag("li");
// "<li>one</li><li>two</li>"
```

- ### IsSorted()
  Checks whether a sequence is sorted according to a comparison (defaults to `Comparer<T>.Default`).

```csharp
public static bool IsSorted<T>(this IEnumerable<T> source, Comparison<T> comparison = null);
```

#### Example

```csharp
bool sorted = new[] { 1, 2, 3 }.IsSorted(); // true
bool notSorted = new[] { 3, 2, 1 }.IsSorted(); // false
```

- ### Slice()
  Returns a portion of a sequence starting at index `start` for `count` items.

```csharp
public static IEnumerable<T> Slice<T>(this IEnumerable<T> source, int start, int count);
```

#### Example

```csharp
var sub = Enumerable.Range(1, 10).Slice(3, 4).ToList(); // [4,5,6,7]
```

- ### FindMin() / FindMax()
  Returns the element with min/max value by a selector.

```csharp
public static T FindMin<T, TValue>(this IEnumerable<T> list, Func<T, TValue> predicate) where TValue : IComparable<TValue>;
public static T FindMax<T, TValue>(this IEnumerable<T> list, Func<T, TValue> predicate) where TValue : IComparable<TValue>;
```

#### Example

```csharp
var people = new[] {
    new { Name = "A", Age = 30 },
    new { Name = "B", Age = 25 },
    new { Name = "C", Age = 40 }
};
var youngest = people.FindMin(p => p.Age); // {Name=B, Age=25}
var oldest = people.FindMax(p => p.Age);  // {Name=C, Age=40}
```

- ### InsertSorted()
  Inserts an element into a pre-sorted list at its proper position.

```csharp
public static int InsertSorted<T>(this IList<T> source, T value) where T : IComparable<T>;
public static int InsertSorted<T>(this IList<T> source, T value, IComparer<T> comparison);
public static int InsertSorted<T>(this IList<T> source, T value, Comparison<T> comparison);
```

#### Example

```csharp
var list = new List<int> { 1, 3, 5 };
int pos = list.InsertSorted(4); // pos = 2, list = [1,3,4,5]
```

- ### EmptyIfNull()
  Returns an empty sequence if the sequence is null.

```csharp
public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> sequence);
```

#### Example

```csharp
IEnumerable<int> src = null;
var safe = src.EmptyIfNull().ToList(); // []
```

- ### AddRange()
  Adds multiple elements to a list (params overload).

```csharp
public static void AddRange<T, S>(this IList<T> list, params S[] values) where S : T;
```

#### Example

```csharp
var nums = new List<int>();
nums.AddRange(1, 2, 3); // [1,2,3]
```

- ### BinarySearch()
  Binary search in a sorted list by key selector.

```csharp
public static T BinarySearch<T, TKey>(this IList<T> list, Func<T, TKey> keySelector, TKey key) where TKey : IComparable<TKey>;
```

#### Example

```csharp
var items = new List<(int Id, string Name)> {
    (1, "A"), (2, "B"), (3, "C")
};
// list must be sorted by Id
var found = items.BinarySearch(x => x.Id, 2); // (2, "B")
```

- ### IndicesOf()
  Finds all indexes of a given value or collection of values.

```csharp
public static IEnumerable<int> IndicesOf<T>(this IEnumerable<T> seq, T value);
public static IEnumerable<int> IndicesOf<T>(this IEnumerable<T> obj, IEnumerable<T> values);
```

#### Example

```csharp
var arr = new[] { 1, 2, 1, 3, 2 };
var idx1 = arr.IndicesOf(1).ToList();            // [0,2]
var idx2 = arr.IndicesOf(new[] { 2, 3 }).ToList(); // [1,3,4]
```

- ### ToSortedString()
  Returns an alphabetically sorted list of property names and values of an object, joined by a separator.

```csharp
public static string ToSortedString(this object value, string charSeparator = ", ");
```

#### Example

```csharp
var obj = new { B = 1, A = 2 };
string desc = obj.ToSortedString(" | "); // "A=2 | B=1"