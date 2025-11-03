# DateTime Extension Methods
This contains Extension Methods that mostly deal with `DateTime` and related operations.
Followings are the Methods available for public use.

- [ToMMDDYY()](#tommddyy)
- [ToDDMMYY()](#toddmmyy)
- [ToTime()](#totime)
- [ToDateTimeString()](#todatetimestring)
- [DateDiff()](#datediff)
- [ToReadableTime()](#toreadabletime)
- [ToFriendlyDayString()](#tofriendlydaystring)
- [IsInBetween()](#isinbetween)
- [CalculateAge()](#calculateage)
- [IsWeekDay()](#isweekday)
- [IsWeekend()](#isweekend)
- [NextWorkday()](#nextworkday)
- [Next()](#next)
- [IsLeapYear()](#isleapyear)
- [FirstDayOfMonth()](#firstdayofmonth)
- [LastDayOfMonth()](#lastdayofmonth)
- [GetDateRange()](#getdaterange)
- [GetDateRangeForCurrentMonth()](#getdaterangeforcurrentmonth)
- [GetDateRangeForCurrentWeek()](#getdaterangeforcurrentweek)
- [AddWorkdays()](#addworkdays)
- [FirstDateOfWeek()](#firstdateofweek)
- [LastDateOfWeek()](#lastdateofweek)
- [Intersects()](#intersects)
- [IsLastDayOfTheMonth()](#islastdayofthemonth)
- [IsFirstDayOfTheMonth()](#isfirstdayofthemonth)
- [GetQuarter()](#getquarter)
- [IsFutureDate()](#isfuturedate)
- [IsToday()](#istoday)
- [IsAfterToday()](#isaftertoday)
- [IsOnOrAfterToday()](#isonoraftertoday)
- [IsBeforeToday()](#isbeforetoday)
- [IsOnOrBeforeToday()](#isonorbeforetoday)
- [IsPastDate()](#ispastdate)

## Api Reference Details

- ### ToMMDDYY()
  Converts a given date-time to `MM/dd/yyyy`. Overload available for `DateTime?` returning empty string when null.

```csharp
public static string ToMMDDYY(this DateTime dateTime, char separator = '/');
public static string ToMMDDYY(this DateTime? dateTime, string separator = "/");
```

#### Example

```csharp
    var s1 = new DateTime(2025, 11, 01).ToMMDDYY();      // "11/01/2025"
    DateTime? n = null;
    var s2 = n.ToMMDDYY("-");                            // ""
```

- ### ToDDMMYY()
  Converts a given date-time to `dd/MM/yyyy`. Overload available for `DateTime?` returning empty string when null.

```csharp
public static string ToDDMMYY(this DateTime dateTime, string separator = "/");
public static string ToDDMMYY(this DateTime? dateTime, char separator = '/');
```

#### Example

```csharp
    var s = new DateTime(2025, 11, 01).ToDDMMYY("-"); // "01-11-2025"
```

- ### ToTime()
  Converts a date to a time string in "hh:mm tt" format. Overload for `DateTime?` returns empty string if null.

```csharp
public static string ToTime(this DateTime dateTime);
public static string ToTime(this DateTime? dateTime);
```

#### Example

```csharp
    var t = DateTime.Today.AddHours(17).AddMinutes(30).ToTime(); // e.g. "05:30 PM"
```

- ### ToDateTimeString()
  Converts a date to string using a custom format. Overload for `DateTime?` returns empty string if null.

```csharp
public static string ToDateTimeString(this DateTime dateTime, string format = "MM/dd/yyyy hh:mm tt");
public static string ToDateTimeString(this DateTime? dateTime, string format = "MM/dd/yyyy hh:mm tt");
```

#### Example

```csharp
    var s = DateTime.Now.ToDateTimeString("yyyy-MM-dd HH:mm");
```

- ### DateDiff()
  DateDiff in SQL style. Supports: year, quarter, month, day, week, hour, minute, second, millisecond.

```csharp
public static long DateDiff(this DateTime startDate, DateTime endDate, string datePart);
```

#### Example

```csharp
    var days = new DateTime(2025,1,1).DateDiff(new DateTime(2025,1,31), "day"); // 30
    var months = new DateTime(2024,11,1).DateDiff(new DateTime(2025,2,1), "month"); // 3
```

- ### ToReadableTime()
  Converts a DateTime to a friendly relative string like "2 hours ago". Overload for `DateTime?` returns empty string if null.

```csharp
public static string ToReadableTime(this DateTime dateTime);
public static string ToReadableTime(this DateTime? dateTime);
```

#### Example

```csharp
    var ago = DateTime.Now.AddMinutes(-5).ToReadableTime(); // "5 minutes ago"
```

- ### ToFriendlyDayString()
  Returns a friendly day string like "Today @ 5:30 pm", "Yesterday @ ...", weekday name, or full date.

```csharp
public static string ToFriendlyDayString(this DateTime date);
```

#### Example

```csharp
    var s = DateTime.Today.ToFriendlyDayString(); // "Today @ ..."
```

- ### IsInBetween()
  Checks if a date lies between a range (inclusive).

```csharp
public static bool IsInBetween(this DateTime date, DateTime rangeStart, DateTime rangeEnd);
```

#### Example

```csharp
    var ok = new DateTime(2025,1,15).IsInBetween(new DateTime(2025,1,1), new DateTime(2025,1,31)); // true
```

- ### CalculateAge()
  Calculates age in years from a given date.

```csharp
public static int CalculateAge(this DateTime dateTime);
```

#### Example

```csharp
    var age = new DateTime(2000, 11, 1).CalculateAge();
```

- ### IsWeekDay()
  Returns true if the date is Monday–Friday. Overload `IsWeekend()` returns true for Saturday or Sunday. Also available for `DayOfWeek`.

```csharp
public static bool IsWeekDay(this DateTime date);
public static bool IsWeekend(this DateTime date);
public static bool IsWeekday(this DayOfWeek dayOfWeek);
public static bool IsWeekend(this DayOfWeek dayOfWeek);
```

#### Example

```csharp
    var isWd = new DateTime(2025,11,3).IsWeekDay(); // true if Monday–Friday
```

- ### NextWorkday()
  Gets the next working day (Monday–Friday) for a given date (could be same day if already weekday).

```csharp
public static DateTime NextWorkday(this DateTime date);
```

#### Example

```csharp
    var next = new DateTime(2025,11,1).NextWorkday();
```

- ### Next()
  Gets the next occurrence of a specified `DayOfWeek` from a date.

```csharp
public static DateTime Next(this DateTime current, DayOfWeek dayOfWeek);
```

#### Example

```csharp
    var nextMonday = DateTime.Today.Next(DayOfWeek.Monday);
```

- ### IsLeapYear()
  Determines whether the date's year is a leap year.

```csharp
public static bool IsLeapYear(this DateTime value);
```

- ### FirstDayOfMonth() / LastDayOfMonth()
  Get the first/last day of the month for the given date.

```csharp
public static DateTime FirstDayOfMonth(this DateTime date);
public static DateTime LastDayOfMonth(this DateTime date);
```

- ### GetDateRange()
  Gets the range of dates (inclusive) between two dates.

```csharp
public static IEnumerable<DateTime> GetDateRange(this DateTime startDate, DateTime endDate);
```

#### Example

```csharp
    var days = new DateTime(2025,1,1).GetDateRange(new DateTime(2025,1,3)).ToArray();
    // { 2025-01-01, 2025-01-02, 2025-01-03 }
```

- ### GetDateRangeForCurrentMonth() / GetDateRangeForCurrentWeek()
  Helpers to get ranges for the month/week of a given date.

```csharp
public static IEnumerable<DateTime> GetDateRangeForCurrentMonth(this DateTime date);
public static IEnumerable<DateTime> GetDateRangeForCurrentWeek(this DateTime date, DayOfWeek startDayOfWeek = DayOfWeek.Monday);
```

- ### AddWorkdays()
  Adds a number of working days (Mon–Fri) to a date, with optional holidays excluded.

```csharp
public static DateTime AddWorkdays(this DateTime date, int days);
public static DateTime AddWorkdays(this DateTime date, int days, IEnumerable<DateTime> holidays);
```

#### Example

```csharp
    var target = new DateTime(2025,11,3).AddWorkdays(5);
```

- ### FirstDateOfWeek() / LastDateOfWeek()
  Start and end date of the week containing the given date.

```csharp
public static DateTime FirstDateOfWeek(this DateTime date, DayOfWeek startOfWeek = DayOfWeek.Monday);
public static DateTime LastDateOfWeek(this DateTime date, DayOfWeek startOfWeek = DayOfWeek.Monday);
```

- ### Intersects()
  Checks if two date ranges intersect.

```csharp
public static bool Intersects(this DateTime startDate, DateTime endDate, DateTime intersectingStartDate, DateTime intersectingEndDate);
```

#### Example

```csharp
    var intersects = new DateTime(2025,1,10).Intersects(new DateTime(2025,1,20), new DateTime(2025,1,15), new DateTime(2025,1,25)); // true
```

- ### IsLastDayOfTheMonth() / IsFirstDayOfTheMonth()
  Determines whether a date is the first/last day of its month.

```csharp
public static bool IsLastDayOfTheMonth(this DateTime dateTime);
public static bool IsFirstDayOfTheMonth(this DateTime dateTime);
```

- ### GetQuarter()
  Returns the quarter (1–4) for a given date.

```csharp
public static int GetQuarter(this DateTime fromDate);
```

- ### IsFutureDate(), IsToday(), IsAfterToday(), IsOnOrAfterToday(), IsBeforeToday(), IsOnOrBeforeToday(), IsPastDate()
  Helpers to compare a date with today or another date (date-only comparisons, time ignored).

```csharp
public static bool IsFutureDate(this DateTime date);
public static bool IsToday(this DateTime date);
public static bool IsAfterToday(this DateTime date);
public static bool IsOnOrAfterToday(this DateTime date);
public static bool IsBeforeToday(this DateTime date);
public static bool IsOnOrBeforeToday(this DateTime date);
public static bool IsFutureDate(this DateTime date, DateTime from);
public static bool IsPastDate(this DateTime date, DateTime from);
public static bool IsPastDate(this DateTime date);
```

#### Example

```csharp
    var f1 = DateTime.Today.AddDays(1).IsFutureDate(); // true
    var p1 = DateTime.Today.AddDays(-1).IsPastDate();  // true