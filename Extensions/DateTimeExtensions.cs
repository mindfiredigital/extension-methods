using System;

namespace Extensions
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
        /// <param name="datePary">The date part.</param>
        /// <returns>Date Difference in System.long</returns>
        /// <exception cref="Exception"></exception>
        public static long DateDiff(this DateTime startDate, DateTime endDate, string datePary)
        {
            long DateDiffVal = 0;
            System.Globalization.Calendar cal = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar;
            TimeSpan ts = new TimeSpan(endDate.Ticks - startDate.Ticks);
            switch (datePary.ToLower().Trim())
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
                    throw new Exception(string.Format("DatePart \"{0}\" is unknown", datePary));
            }
            return DateDiffVal;
        }
    }
}
