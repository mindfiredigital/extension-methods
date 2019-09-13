using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Extensions
{
    public static class NumberExtensions
    {
        private static readonly Dictionary<string, CultureInfo> ISOCurrenciesToACultureMap =
        CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                            .Select(c => new { c, new RegionInfo(c.LCID).ISOCurrencySymbol })
                            .GroupBy(x => x.ISOCurrencySymbol)
                            .ToDictionary(g => g.Key, g => g.First().c, StringComparer.OrdinalIgnoreCase);

        #region Doubles
        /// <summary>
        /// Returns a formatted double or emtpy string
        /// </summary>
        /// <param name="t">double</param>
        /// <param name="format">double formatstring </param>
        /// <returns></returns>
        public static string ToString(this double t, string format)
        {
            return t.ToString(format);
        }
        /// <summary>
        /// Returns a formatted double or emtpy string
        /// </summary>
        /// <param name="t">double or null</param>
        /// <param name="format">double formatstring </param>
        /// <returns></returns>
        public static string ToString(this double? t, string format)
        {
            return t.HasValue ? t.Value.ToString(format) : string.Empty;
        }

        /// <summary>
        /// Format a double using the local culture currency settings.
        /// </summary>
        /// <param name="value">The double to be formatted.</param>
        /// <returns>The double formatted based on the local culture currency settings.</returns>
        public static string ToLocalCurrencyString(this double value)
        {
            return (string.Format("{0:C}", value));
        }

        /// <summary>
        /// Format a double using specific culture currency settings. $ by default
        /// </summary>
        /// <param name="value">The double to be formatted.</param>
        /// <param name="cultureName">The string representation for the culture to be used, for instance "en-US" for US English.</param>
        /// <returns>The double formatted based on specific culture currency settings.</returns>
        public static string ToCurrencyString(this double value, string cultureName = "en-US")
        {
            return value.ToString("C", CultureInfo.CreateSpecificCulture(cultureName));
        }

        /// <summary>
        /// Format a double to ISO Currency using specific culture currency settings. USD by default
        /// </summary>
        /// <param name="value">The double to be formatted.</param>
        /// <param name="cultureName">The string representation for the culture to be used, for instance "en-US" for US English.</param>
        /// <returns>The double formatted based on specific culture currency settings.</returns>
        public static string ToISOCurrencyString(this double value, string cultureName = "en-US")
        {
            var ca = new RegionInfo(cultureName);
            var cai = new CultureInfo(cultureName)
            {
                NumberFormat = new NumberFormatInfo
                {
                    CurrencySymbol = ca.ISOCurrencySymbol
                }
            };
            return value.ToString("C", cai);
        }
        /// <summary>
        /// Format a double to Currency using specific Currency code. If the amount is 123 and the currency code is USD, then the returned string is $123
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>The double formatted based on specific currency code</returns>
        public static string ToCurrencyStringByCurrencyCode(this double amount, string currencyCode)
        {
            CultureInfo culture;
            if (ISOCurrenciesToACultureMap.TryGetValue(currencyCode, out culture))
                return string.Format(culture, "{0:C}", amount);
            return amount.ToString("0.00");
        }

        /// <summary>
        /// Get a certain percentage of the specified number.
        /// </summary>
        /// <param name="value">The number to get the percentage of.</param>
        /// <param name="percentage">The percentage of the specified number to get.</param>
        /// <returns>The actual specified percentage of the specified number.</returns>
        public static double GetPercentage(this double value, int percentage)
        {
            var percentAsDouble = (double)percentage / 100;
            return value * percentAsDouble;
        }
        /// <summary>
        /// Get a certain percentage of the specified number.
        /// </summary>
        /// <param name="value">The number to get the percentage of.</param>
        /// <param name="percentage">The percentage of the specified number to get.</param>
        /// <returns>The actual specified percentage of the specified number.</returns>
        public static double GetPercentage(this double value, double percentage)
        {
            var percentAsDouble = percentage / 100;
            return value * percentAsDouble;
        }

        /// <summary>
        /// Converts a Double to a String with precision
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="precision">The precision.</param>
        /// <returns></returns>
        public static string DisplayDouble(this double value, int precision)
        {
            return value.ToString("N" + precision);
        }
        public static double RemoveTraillingZeros(this double number)
        {
            return double.Parse(number.ToString("G", CultureInfo.InvariantCulture));
        }
        #endregion

        #region Integers
        /// <summary>
        /// Returns a formatted integer or emtpy string
        /// </summary>
        /// <param name="t">integer</param>
        /// <param name="format">integer formatstring </param>
        /// <returns></returns>
        public static string ToString(this int t, string format)
        {
            return t.ToString(format);
        }
        /// <summary>
        /// Returns a formatted integer or emtpy string
        /// </summary>
        /// <param name="t">integer or null</param>
        /// <param name="format">integer formatstring </param>
        /// <returns></returns>
        public static string ToString(this int? t, string format)
        {
            return t.HasValue ? t.Value.ToString(format) : string.Empty;
        }

        /// <summary>
        /// Format a integer using the local culture currency settings.
        /// </summary>
        /// <param name="value">The integer to be formatted.</param>
        /// <returns>The integer formatted based on the local culture currency settings.</returns>
        public static string ToLocalCurrencyString(this int value)
        {
            return (string.Format("{0:C}", value));
        }

        /// <summary>
        /// Format a integer using specific culture currency settings. $ by default
        /// </summary>
        /// <param name="value">The integer to be formatted.</param>
        /// <param name="cultureName">The string representation for the culture to be used, for instance "en-US" for US English.</param>
        /// <returns>The integer formatted based on specific culture currency settings.</returns>
        public static string ToCurrencyString(this int value, string cultureName = "en-US")
        {
            return value.ToString("C", CultureInfo.CreateSpecificCulture(cultureName));
        }

        /// <summary>
        /// Format a integer to ISO Currency using specific culture currency settings. USD by default
        /// </summary>
        /// <param name="value">The integer to be formatted.</param>
        /// <param name="cultureName">The string representation for the culture to be used, for instance "en-US" for US English.</param>
        /// <returns>The integer formatted based on specific culture currency settings.</returns>
        public static string ToISOCurrencyString(this int value, string cultureName = "en-US")
        {
            var ca = new RegionInfo(cultureName);
            var cai = new CultureInfo(cultureName)
            {
                NumberFormat = new NumberFormatInfo
                {
                    CurrencySymbol = ca.ISOCurrencySymbol
                }
            };
            return value.ToString("C", cai);
        }
        /// <summary>
        /// Format a integer to Currency using specific Currency code. If the amount is 123 and the currency code is USD, then the returned string is $123
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>The integer formatted based on specific currency code</returns>
        public static string ToCurrencyStringByCurrencyCode(this int amount, string currencyCode)
        {
            CultureInfo culture;
            if (ISOCurrenciesToACultureMap.TryGetValue(currencyCode, out culture))
                return string.Format(culture, "{0:C}", amount);
            return amount.ToString("0.00");
        }

        /// <summary>
        /// Get a certain percentage of the specified number.
        /// </summary>
        /// <param name="value">The number to get the percentage of.</param>
        /// <param name="percentage">The percentage of the specified number to get.</param>
        /// <returns>The actual specified percentage of the specified number.</returns>
        public static double GetPercentage(this int value, int percentage)
        {
            var percentAsDouble = (double)percentage / 100;
            return value * percentAsDouble;
        }
        /// <summary>
        /// Get a certain percentage of the specified number.
        /// </summary>
        /// <param name="value">The number to get the percentage of.</param>
        /// <param name="percentage">The percentage of the specified number to get.</param>
        /// <returns>The actual specified percentage of the specified number.</returns>
        public static double GetPercentage(this int value, double percentage)
        {
            var percentAsDouble = percentage / 100;
            return value * percentAsDouble;
        }

        /// <summary>
        /// Converts a integer to a String with precision
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="precision">The precision.</param>
        /// <returns></returns>
        public static string DisplayDouble(this int value, int precision)
        {
            return value.ToString("N" + precision);
        }
        #endregion

    }
}
