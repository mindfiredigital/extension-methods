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
    }
}
