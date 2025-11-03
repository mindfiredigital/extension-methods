# Number Extension Methods
This contains Extension Methods that deal with numbers (`double`, `int`).
Followings are the Methods available for public use.

- [Double.ToString()](#doubletostring)
- [Double.ToLocalCurrencyString()](#doubletolocalcurrencystring)
- [Double.ToCurrencyString()](#doubletocurrencystring)
- [Double.ToISOCurrencyString()](#doubletoisocurrencystring)
- [Double.ToCurrencyStringByCurrencyCode()](#doubletocurrencystringbycurrencycode)
- [Double.GetPercentage()](#doublegetpercentage)
- [Double.DisplayDouble()](#doubledisplaydouble)
- [Double.RemoveTraillingZeros()](#doubleremovetraillingzeros)
- [Int.Range()](#intrange)
- [Int.ToString()](#inttostring)
- [Int.ToLocalCurrencyString()](#inttolocalcurrencystring)
- [Int.ToCurrencyString()](#inttocurrencystring)
- [Int.ToISOCurrencyString()](#inttoisocurrencystring)
- [Int.ToCurrencyStringByCurrencyCode()](#inttocurrencystringbycurrencycode)
- [Int.GetPercentage()](#intgetpercentage)
- [Int.DisplayDouble()](#intdisplaydouble)

## Api Reference Details

### Double Extension Methods

- ### Double.ToString()
  Returns a formatted double (or empty string for nullable when null).

```csharp
public static string ToString(this double t, string format);
public static string ToString(this double? t, string format);
```

#### Example

```csharp
    var s1 = 1234.567.ToString("N2"); // "1,234.57"
    double? n = null;
    var s2 = n.ToString("N2");        // ""
```

- ### Double.ToLocalCurrencyString()
  Formats a double using the local culture currency settings.

```csharp
public static string ToLocalCurrencyString(this double value);
```

#### Example

```csharp
    var s = 123.45.ToLocalCurrencyString(); // e.g. "$123.45" for en-US
```

- ### Double.ToCurrencyString()
  Formats a double to currency using a specific culture (e.g., "en-US").

```csharp
public static string ToCurrencyString(this double value, string cultureName = "en-US");
```

#### Example

```csharp
    var s = 123.45.ToCurrencyString("fr-FR"); // e.g. "123,45 €"
```

- ### Double.ToISOCurrencyString()
  Formats a double to currency using the ISO currency symbol of a specific culture.

```csharp
public static string ToISOCurrencyString(this double value, string cultureName = "en-US");
```

#### Example

```csharp
    var s = 123.45.ToISOCurrencyString("en-US"); // "USD123.45"
```

- ### Double.ToCurrencyStringByCurrencyCode()
  Formats a double using a specific ISO currency code (e.g., USD, EUR). Falls back to "0.00" format if code not found.

```csharp
public static string ToCurrencyStringByCurrencyCode(this double amount, string currencyCode);
```

#### Example

```csharp
    var s = 123.0.ToCurrencyStringByCurrencyCode("USD"); // "$123.00" in an en-US culture
```

- ### Double.GetPercentage()
  Gets a certain percentage of a number.

```csharp
public static double GetPercentage(this double value, int percentage);
public static double GetPercentage(this double value, double percentage);
```

#### Example

```csharp
    var part = 200.0.GetPercentage(15);   // 30
    var part2 = 200.0.GetPercentage(12.5);// 25
```

- ### Double.DisplayDouble()
  Converts a double to string with a given precision (e.g., N2).

```csharp
public static string DisplayDouble(this double value, int precision);
```

#### Example

```csharp
    var s = 1.2345.DisplayDouble(3); // "1.235"
```

- ### Double.RemoveTraillingZeros()
  Removes trailing zeros using general format.

```csharp
public static double RemoveTraillingZeros(this double number);
```

#### Example

```csharp
    var v = 123.4500.RemoveTraillingZeros(); // 123.45
```

### Int Extension Methods

- ### Int.Range()
  Generates a sequence 0..n-1. Equivalent to `Enumerable.Range(0, n)`.

```csharp
public static IEnumerable<int> Range(this int n);
```

#### Example

```csharp
    var seq = 5.Range().ToArray(); // {0,1,2,3,4}
```

- ### Int.ToString()
  Returns a formatted integer (or empty string for nullable when null).

```csharp
public static string ToString(this int t, string format);
public static string ToString(this int? t, string format);
```

#### Example

```csharp
    var s = 123.ToString("D5"); // "00123"
    int? x = null;
    var e = x.ToString("D2");   // ""
```

- ### Int.ToLocalCurrencyString()
  Formats an integer using the local culture currency settings.

```csharp
public static string ToLocalCurrencyString(this int value);
```

- ### Int.ToCurrencyString()
  Formats an integer to currency using a specific culture.

```csharp
public static string ToCurrencyString(this int value, string cultureName = "en-US");
```

- ### Int.ToISOCurrencyString()
  Formats an integer to currency using the ISO currency symbol of a specific culture.

```csharp
public static string ToISOCurrencyString(this int value, string cultureName = "en-US");
```

- ### Int.ToCurrencyStringByCurrencyCode()
  Formats an integer using a specific ISO currency code (e.g., USD, EUR). Falls back to "0.00" format if code not found.

```csharp
public static string ToCurrencyStringByCurrencyCode(this int amount, string currencyCode);
```

- ### Int.GetPercentage()
  Gets a certain percentage of a number (returns double).

```csharp
public static double GetPercentage(this int value, int percentage);
public static double GetPercentage(this int value, double percentage);
```

- ### Int.DisplayDouble()
  Converts an integer to string with a given precision (e.g., N2).

```csharp
public static string DisplayDouble(this int value, int precision);