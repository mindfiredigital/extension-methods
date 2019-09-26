using System;
using System.Collections.Generic;
using System.Linq;

namespace Extension.Methods
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts a given datetime to MM/dd/yyyy. You can also specify the separator. 
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>Returns string in the format of  MM/dd/yyyy</returns>
        public static string ToMMDDYY(this DateTime dateTime, char separator = '/')
        {
            return dateTime.ToString($"MM{separator}dd{separator}yyyy");
        }

        /// <summary>
        /// Converts a given nullable datetime to MM/dd/yyyy. You can also specify the separator.
        /// Returns an empty string if the given date in null.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>Returns string in the format of  MM/dd/yyyy, and Empty String if the date is NULL</returns>
        public static string ToMMDDYY(this DateTime? dateTime, char separator = '/')
        {
            return dateTime.HasValue ?
                        dateTime.Value.ToString($"MM{separator}dd{separator}yyyy")
                        : string.Empty;
        }
        /// <summary>
        /// Converts a given datetime to dd/MM/yyyy. You can also specify the separator. 
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>Returns string in the format of  dd/MM/yyyy</returns>
        public static string ToDDMMYY(this DateTime dateTime, char separator = '/')
        {
            return dateTime.ToString($"dd{separator}MM{separator}yyyy");
        }

        /// <summary>
        /// Converts a given nullable datetime to dd/MM/yyyy. You can also specify the separator.
        /// Returns an empty string if the given date in null.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>Returns string in the format of  dd/MM/yyyy, and Empty String if the date is NULL</returns>
        public static string ToDDMMYY(this DateTime? dateTime, char separator = '/')
        {
            return dateTime.HasValue ?
                        dateTime.Value.ToString($"dd{separator}MM{separator}yyyy")
                        : string.Empty;
        }
        /// <summary>
        /// Converts Date to Time String in "hh:mm tt" format
        /// </summary>
        /// <param name="dateTime">Date</param>
        /// <returns>String in "hh:mm tt" or Empty String if null</returns>
        public static string ToTime(this DateTime dateTime)
        {
            return dateTime.ToString("hh:mm tt");
        }
        /// <summary>
        /// Converts Date to Time String in "hh:mm tt" format
        /// </summary>
        /// <param name="dateTime">Date</param>
        /// <returns>String in "hh:mm tt" or Empty String if null</returns>
        public static string ToTime(this DateTime? dateTime)
        {
            return dateTime?.ToString("hh:mm tt") ?? string.Empty;
        }
        /// <summary>
        /// Converts Date to Time String in a format
        /// </summary>
        /// <param name="dateTime">Date</param>
        /// <param name="format">The format. By default the format is "MM/dd/yyyy hh:mm tt"</param>
        /// <returns>
        /// String in "MM/dd/yyyy hh:mm tt" or Empty String if null
        /// </returns>
        public static string ToDateTimeString(this DateTime dateTime, string format = "MM/dd/yyyy hh:mm tt")
        {
            return dateTime.ToString(format);
        }

        /// <summary>
        /// Converts Nullable Date to Time String in a format
        /// </summary>
        /// <param name="dateTime">Date</param>
        /// <param name="format">The format. By default the format is "MM/dd/yyyy hh:mm tt"</param>
        /// <returns>
        /// String in "MM/dd/yyyy hh:mm tt" or Empty String if null
        /// </returns>
        public static string ToDateTimeString(this DateTime? dateTime, string format = "MM/dd/yyyy hh:mm tt")
        {
            return dateTime?.ToDateTimeString(format) ?? string.Empty;
        }
        /// <summary>
        /// DateDiff in SQL style.
        /// Datepart implemented:
        /// "year" (abbr. "yy", "yyyy"),
        /// "quarter" (abbr. "qq", "q"),
        /// "month" (abbr. "mm", "m"),
        /// "day" (abbr. "dd", "d"),
        /// "week" (abbr. "wk", "ww"),
        /// "hour" (abbr. "hh"),
        /// "minute" (abbr. "mi", "n"),
        /// "second" (abbr. "ss", "s"),
        /// "millisecond" (abbr. "ms").
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="datePart">The date part.</param>
        /// <returns>Date Difference in System.long</returns>
        /// <exception cref="Exception"></exception>
        public static long DateDiff(this DateTime startDate, DateTime endDate, string datePart)
        {
            long DateDiffVal = 0;
            System.Globalization.Calendar cal = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar;
            TimeSpan ts = new TimeSpan(endDate.Ticks - startDate.Ticks);
            switch (datePart.ToLower().Trim())
            {
                #region year
                case "year":
                case "yy":
                case "yyyy":
                    DateDiffVal = (long)(cal.GetYear(endDate) - cal.GetYear(startDate));
                    break;
                #endregion

                #region quarter
                case "quarter":
                case "qq":
                case "q":
                    DateDiffVal = (long)((((cal.GetYear(endDate)
                                        - cal.GetYear(startDate)) * 4)
                                        + ((cal.GetMonth(endDate) - 1) / 3))
                                        - ((cal.GetMonth(startDate) - 1) / 3));
                    break;
                #endregion

                #region month
                case "month":
                case "mm":
                case "m":
                    DateDiffVal = (long)(((cal.GetYear(endDate)
                                        - cal.GetYear(startDate)) * 12
                                        + cal.GetMonth(endDate))
                                        - cal.GetMonth(startDate));
                    break;
                #endregion

                #region day
                case "day":
                case "d":
                case "dd":
                    DateDiffVal = (long)ts.TotalDays;
                    break;
                #endregion

                #region week
                case "week":
                case "wk":
                case "ww":
                    DateDiffVal = (long)(ts.TotalDays / 7);
                    break;
                #endregion

                #region hour
                case "hour":
                case "hh":
                    DateDiffVal = (long)ts.TotalHours;
                    break;
                #endregion

                #region minute
                case "minute":
                case "mi":
                case "n":
                    DateDiffVal = (long)ts.TotalMinutes;
                    break;
                #endregion

                #region second
                case "second":
                case "ss":
                case "s":
                    DateDiffVal = (long)ts.TotalSeconds;
                    break;
                #endregion

                #region millisecond
                case "millisecond":
                case "ms":
                    DateDiffVal = (long)ts.TotalMilliseconds;
                    break;
                #endregion

                default:
                    throw new Exception(string.Format("DatePart \"{0}\" is unknown", datePart));
            }
            return DateDiffVal;
        }

        /// <summary>
        /// Converts a given DateTime to Readable string. Like "2 seconds ago", "3 years ago" etc
        /// </summary>
        /// <param name="dateTime">The value.</param>
        /// <returns>System.String</returns>
        public static string ToReadableTime(this DateTime dateTime)
        {
            var ts = new TimeSpan(DateTime.Now.Ticks - dateTime.Ticks);
            double delta = ts.TotalSeconds;
            if (delta < 60)
            {
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            }
            if (delta < 120)
            {
                return "a minute ago";
            }
            if (delta < 2700) // 45 * 60
            {
                return ts.Minutes + " minutes ago";
            }
            if (delta < 5400) // 90 * 60
            {
                return "an hour ago";
            }
            if (delta < 86400) // 24 * 60 * 60
            {
                return ts.Hours + " hours ago";
            }
            if (delta < 172800) // 48 * 60 * 60
            {
                return "yesterday";
            }
            if (delta < 2592000) // 30 * 24 * 60 * 60
            {
                return ts.Days + " days ago";
            }
            if (delta < 31104000) // 12 * 30 * 24 * 60 * 60
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            var years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "one year ago" : years + " years ago";
        }
        /// <summary>
        /// Converts a given Nullable DateTime to Readable string. Like "2 seconds ago", "3 years ago" etc
        /// </summary>
        /// <param name="dateTime">The value.</param>
        /// <returns>
        /// System.String if the datetime is not null and an Empty string if the given date is null.
        /// </returns>
        public static string ToReadableTime(this DateTime? dateTime)
        {
            return dateTime?.ToReadableTime() ?? string.Empty;
        }
        /// <summary>
        /// Converts a Date to Friendly Day. Today @ 5.30 PM 
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>system.string</returns>
        public static string ToFriendlyDayString(this DateTime date)
        {
            string formattedDate = "";
            if (date.Date > DateTime.Today)
            {
                formattedDate = date.ToString("MMMM dd, yyyy");
            }
            else if (date.Date == DateTime.Today)
            {
                formattedDate = "Today";
            }
            else if (date.Date == DateTime.Today.AddDays(-1))
            {
                formattedDate = "Yesterday";
            }
            else if (date.Date > DateTime.Today.AddDays(-6))
            {
                // *** Show the Day of the week
                formattedDate = date.ToString("dddd").ToString();
            }
            else
            {
                formattedDate = date.ToString("MMMM dd, yyyy");
            }

            //append the time portion to the output
            formattedDate += " @ " + date.ToString("t").ToLower();
            return formattedDate;
        }
        /// <summary>
        /// Checks if a given date lies between a Range of Dates.
        /// </summary>
        /// <param name="date">The given date.</param>
        /// <param name="rangeStart">The range start.</param>
        /// <param name="rangeEnd">The range end.</param>
        /// <returns>True, if the date is between rangeStart and rangeEnd, else returns false</returns>
        public static bool IsInBetween(this DateTime date, DateTime rangeStart, DateTime rangeEnd)
        {
            return date.Ticks >= rangeStart.Ticks && date.Ticks <= rangeEnd.Ticks;
        }

        /// <summary>
        /// Calculates the age for a given Date.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>Integer</returns>
        public static int CalculateAge(this DateTime dateTime)
        {
            var age = DateTime.Now.Year - dateTime.Year;
            if (DateTime.Now < dateTime.AddYears(age))
                age--;
            return age;
        }

        /// <summary>
        /// Determines whether a given date is a WeekDay (Monday-Friday)
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        ///   <c>true</c> if the date is WeekDay; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWeekDay(this DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }
        /// <summary>
        /// Determines whether a given date is a WeekEnd (Daturday-Sunday)
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        ///   <c>true</c> if the date is WeekEnd; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
        /// <summary>
        /// Determines whether the dayOfWeek is weekday.
        /// </summary>
        /// <param name="dayOfWeek">The dayOfWeek</param>
        /// <returns>
        ///   <c>true</c> if the specified dayOfWeek is weekday; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWeekday(this DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                case DayOfWeek.Saturday: return false;

                default: return true;
            }
        }
        /// <summary>
        /// Determines whether the dayOfWeek is weekend.
        /// </summary>
        /// <param name="dayOfWeek">The dayOfWeek</param>
        /// <returns>
        ///   <c>true</c> if the specified dayOfWeek is weekend; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWeekend(this DayOfWeek d)
        {
            return !d.IsWeekday();
        }
        /// <summary>
        /// Gets the Next working day (Monday - Friday) for a given Date
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>System.DateTime</returns>
        public static DateTime NextWorkday(this DateTime date)
        {
            var nextDay = date;
            while (!nextDay.IsWeekDay())
            {
                nextDay = nextDay.AddDays(1);
            }
            return nextDay;
        }

        /// <summary>
        /// Gets the next Date for the specified day of week.
        /// </summary>
        /// <param name="current">The current.</param>
        /// <param name="dayOfWeek">The day of week.</param>
        /// <returns>System.DateTime</returns>
        public static DateTime Next(this DateTime current, DayOfWeek dayOfWeek)
        {
            int offsetDays = dayOfWeek - current.DayOfWeek;
            if (offsetDays <= 0)
            {
                offsetDays += 7;
            }
            DateTime result = current.AddDays(offsetDays);
            return result;
        }

        /// <summary>
        /// Determines whether a the given date's year is a Leap Year.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if a the given date's year is a Leap Year ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsLeapYear(this DateTime value)
        {
            return (DateTime.DaysInMonth(value.Year, 2) == 29);
        }

        /// <summary>
        /// Get the First day of month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>system.DateTime</returns>
        public static DateTime FirstDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }
        /// <summary>
        /// Get the Last day of month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>system.DateTime</returns>
        public static DateTime LastDayOfMonth(this DateTime date)
        {
            return date.FirstDayOfMonth().AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// Gets the range of dates between two given dates.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">End date.</param>
        /// <returns> IEnumerable<DateTime></returns>
        public static IEnumerable<DateTime> GetDateRange(this DateTime startDate, DateTime endDate)
        {
            var range = Enumerable.Range(0, (endDate - startDate).Days + 1);

            return from p in range
                   select startDate.Date.AddDays(p);
        }
        /// <summary>
        /// Gets the date range for current month for a given Date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>IEnumerable<DateTime></returns>
        public static IEnumerable<DateTime> GetDateRangeForCurrentMonth(this DateTime date)
        {
            return GetDateRange(date.FirstDayOfMonth(), date.LastDayOfMonth());
        }

        /// <summary>
        /// Gets the date range for current week.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="startDayOfWeek">The start day of week.</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> GetDateRangeForCurrentWeek(this DateTime date, DayOfWeek startDayOfWeek = DayOfWeek.Monday)
        {
            return GetDateRange(date.FirstDateOfWeek(startDayOfWeek), date.LastDateOfWeek(startDayOfWeek));
        }
        /// <summary>
        /// Adds a given number of Working Days (Monday-Friday) to the given date. 
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="days">The no of days.</param>
        /// <returns>system.DateTime</returns>
        public static DateTime AddWorkdays(this DateTime date, int days)
        {
            DateTime tmpDate = date;
            while (days > 0)
            {
                tmpDate = tmpDate.AddDays(1);
                if (tmpDate.IsWeekDay())
                    days--;
            }
            return tmpDate;
        }
        /// <summary>
        /// Adds a given number of Working Days (Monday-Friday) to the given date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="days">The no of days.</param>
        /// <param name="holidays">The holidays. You can pass a list of dates as holidays and they will be considered as non working days</param>
        /// <returns>system.DateTime</returns>
        public static DateTime AddWorkdays(this DateTime date, int days, IEnumerable<DateTime> holidays)
        {
            DateTime tmpDate = date;
            while (days > 0)
            {
                tmpDate = tmpDate.AddDays(1);
                if (tmpDate.IsWeekDay() && !holidays.Contains(tmpDate))
                    days--;
            }
            return tmpDate;
        }

        /// <summary>
        /// Gets the start date of a week for a given date. By default, it considers start of week as Monday
        /// </summary>
        /// <param name="date">The given date.</param>
        /// <param name="startOfWeek">The start of week. By Default Monday</param>
        /// <returns>system.DateTime</returns>
        public static DateTime FirstDateOfWeek(this DateTime date, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            int diff = (7 + (date.DayOfWeek - startOfWeek)) % 7;
            return date.AddDays(-1 * diff).Date;
        }
        /// <summary>
        /// Gets the end date of a week for a given date. By default, it considers start of week as Monday
        /// </summary>
        /// <param name="date">The given date.</param>
        /// <param name="startOfWeek">The start of week. By Default Monday</param>
        /// <returns>system.DateTime</returns>
        public static DateTime LastDateOfWeek(this DateTime date, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            return date.FirstDateOfWeek(startOfWeek).AddDays(6);
        }
        /// <summary>
        /// Checks if a range decided by a given date and end date intersects the daterange betweer intersectingStartDate and intersectingEndDate
        /// </summary>
        /// <param name="startDate">The given start date of the range to be compared</param>
        /// <param name="endDate">The given end date of the range to be compared</param>
        /// <param name="intersectingStartDate">The intersecting start date.</param>
        /// <param name="intersectingEndDate">The intersecting end date.</param>
        /// <returns>True, if the range interscects else false</returns>
        public static bool Intersects(this DateTime startDate, DateTime endDate, DateTime intersectingStartDate, DateTime intersectingEndDate)
        {
            return (intersectingEndDate >= startDate && intersectingStartDate <= endDate);
        }

        /// <summary>
        /// Determines whether a date is Last Date of the Month.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>
        ///   <c>true</c> if a date is Last Date of the Month otherwise, <c>false</c>.
        /// </returns>
        public static bool IsLastDayOfTheMonth(this DateTime dateTime)
        {
            return dateTime.Date == dateTime.LastDayOfMonth().Date;
        }

        /// <summary>
        /// Determines whether a date is First Date of the Month.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>
        ///   <c>true</c> if a date is First Date of the Month otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFirstDayOfTheMonth(this DateTime dateTime)
        {
            return dateTime.Date == dateTime.FirstDayOfMonth().Date;
        }
        /// <summary>
        /// Gets the quarter for a given date. It can be 1, 2, 3, 4
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <returns></returns>
        public static int GetQuarter(this DateTime fromDate)
        {
            return ((fromDate.Month - 1) / 3) + 1;
        }

        /// <summary>
        /// Determines whether the date is a future date from today. This only compares the date, ignoring the time.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="from">From date</param>
        /// <returns>
        ///   <c>true</c> if the date is future to the specified from today; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFutureDate(this DateTime date)
        {
            return date.IsFutureDate(DateTime.Today);
        }

        /// <summary>
        /// Determines whether the date is Today's date or Not.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        ///   <c>true</c> if the specified date is today; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsToday(this DateTime date)
        {
            return date.Date == DateTime.Today.Date;
        }
        /// <summary>
        /// Determines whether the date is a future date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        ///   <c>true</c> if the specified date is a future date; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAfterToday(this DateTime date)
        {
            return date.IsFutureDate();
        }
        /// <summary>
        /// Determines whether the date is either today or a future date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        ///   <c>true</c> if the specified date is either today or a future date; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsOnOrAfterToday(this DateTime date)
        {
            return date.IsToday() || date.IsFutureDate();
        }
        /// <summary>
        /// Determines whether the date is a past date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        ///   <c>true</c> if the specified date is a past date; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsBeforeToday(this DateTime date)
        {
            return date.IsPastDate();
        }
        /// <summary>
        /// Determines whether the date is either today or a past date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        ///   <c>true</c> if the specified date is either today or a past date; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsOnOrBeforeToday(this DateTime date)
        {
            return date.IsToday() || date.IsPastDate();
        }
        /// <summary>
        /// Determines whether the date is a future date from the specified from date. This only compares the date, ignoring the time.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="from">From date</param>
        /// <returns>
        ///   <c>true</c> if the date is future to the specified from date; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFutureDate(this DateTime date, DateTime from)
        {
            return date.Date > from.Date;
        }
        /// <summary>
        /// Determines whether the date is a past date from the specified from date. This only compares the date, ignoring the time.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="from">From date</param>
        /// <returns>
        ///   <c>true</c> if the date is past to the specified from date; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsPastDate(this DateTime date, DateTime from)
        {
            return date.Date < from.Date;
        }
        /// <summary>
        /// Determines whether the date is a past date from today. This only compares the date, ignoring the time.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="from">From date</param>
        /// <returns>
        ///   <c>true</c> if the date is past to the specified from today; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsPastDate(this DateTime date)
        {
            return date.IsPastDate(DateTime.Now);
        }
    }
}
