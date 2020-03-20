using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Extension.Methods
{
    public static class StringExtensions
    {
        /// <summary>
        ///     Checks if date with dateFormat is parse-able to System.DateTime format returns boolean value if true else false
        /// </summary>
        /// <param name="data">String date</param>
        /// <param name="dateFormat">date format example dd/MM/yyyy HH:mm:ss</param>
        /// <returns>boolean True False if is valid System.DateTime</returns>
        public static bool IsDateTime(this string data, string dateFormat = "dd/MM/yyyy")
        {
            // ReSharper disable once RedundantAssignment
            DateTime dateVal = default(DateTime);
            return DateTime.TryParseExact(data, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                out dateVal);
        }
        /// <summary>
        ///     IsInteger Function checks if a string is a valid int32 value
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>Boolean True if isInteger else False</returns>
        public static bool IsInteger(this string val)
        {
            // Variable to collect the Return value of the TryParse method.

            // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
            int retNum;

            // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
            // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
            bool isNum = int.TryParse(val, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        /// <summary>
        ///     IsDecimal Function checks if a string is a valid decimal value
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>Boolean True if IsDecimal else False</returns>
        public static bool IsDecimal(this string val)
        {
            // Variable to collect the Return value of the TryParse method.
            // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
            decimal retNum;
            // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
            // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
            bool isNum = decimal.TryParse(val, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        /// <summary>
        ///     IsNumeric checks if a string is a valid floating value
        /// </summary>
        /// <param name="val"></param>
        /// <returns>Boolean True if isNumeric else False</returns>
        /// <remarks></remarks>
        public static bool IsNumeric(this string val)
        {
            // Variable to collect the Return value of the TryParse method.

            // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
            double retNum;

            // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
            // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
            bool isNum = Double.TryParse(val, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        /// <summary>
        /// Checks if a string can be parsed to Guid or Not 
        /// </summary>
        /// <param name="s">A string containing a Guid to convert.</param>
        /// <value>
        /// <see langword="true" /> if <paramref name="s"/> was converted 
        /// successfully; otherwise, <see langword="false" />.
        /// </value>
        public static bool IsGuid(this string s)
        {
            if (s.IsNullOrEmpty())
                return false;
            return s.IsMatch("^[A-Fa-f0-9]{32}$|" +
                "^({|\\()?[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}(}|\\))?$|" +
                "^({)?[0xA-Fa-f0-9]{3,10}(, {0,1}[0xA-Fa-f0-9]{3,6}){2}, {0,1}({)([0xA-Fa-f0-9]{3,4}, {0,1}){7}[0xA-Fa-f0-9]{3,4}(}})$");
        }
        /// <summary>
        ///     Checks if the String contains only Unicode letters.
        ///     null will return false. An empty String ("") will return false.
        /// </summary>
        /// <param name="val">string to check if is Alpha</param>
        /// <returns>true if only contains letters, and is non-null</returns>
        public static bool IsAlpha(this string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return false;
            }
            return val.Trim().Replace(" ", "").All(Char.IsLetter);
        }

        /// <summary>
        ///     Checks if the String contains only Unicode letters, digits.
        ///     null will return false. An empty String ("") will return false.
        /// </summary>
        /// <param name="val">string to check if is Alpha or Numeric</param>
        /// <returns></returns>
        public static bool IsAlphaNumeric(this string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return false;
            }
            return val.Trim().Replace(" ", "").All(Char.IsLetterOrDigit);
        }
        /// <summary>
        ///     Validate email address
        /// </summary>
        /// <param name="val">string email address</param>
        /// <returns>true or false if email if valid</returns>
        public static bool IsEmailAddress(this string val)
        {
            string pattern =
                "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
            return Regex.IsMatch(val, pattern);
        }
        /// <summary>
        ///     Validates if a string is valid IPv4
        ///     Regular expression taken from <a href="http://regexlib.com/REDetails.aspx?regexp_id=2035">Regex reference</a>
        /// </summary>
        /// <param name="val">string IP address</param>
        /// <returns>true if string matches valid IP address else false</returns>
        public static bool IsIPv4(this string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return false;
            }
            return Regex.IsMatch(val,
                @"(?:^|\s)([a-z]{3,6}(?=://))?(://)?((?:25[0-5]|2[0-4]\d|[01]?\d\d?)\.(?:25[0-5]|2[0-4]\d|[01]?\d\d?)\.(?:25[0-5]|2[0-4]\d|[01]?\d\d?)\.(?:25[0-5]|2[0-4]\d|[01]?\d\d?))(?::(\d{2,5}))?(?:\s|$)");
        }
        /// <summary>
        /// Determines whether the specified string matches a regular expression or not.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="regEx">The reg ex.</param>
        /// <returns>
        ///   <c>true</c> if the specified reg ex is match; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMatch(this string content, string regEx)
        {
            if (string.IsNullOrEmpty(content)) return false;
            return Regex.IsMatch(content, regEx);
        }

        /// <summary>
        /// Determines whether this string is URL.
        /// </summary>
        /// <param name="val">The text.</param>
        /// <returns>
        ///   <c>true</c> if the specified text is URL; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsUrl(this string val)
        {
            var rx = new Regex(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
            return rx.IsMatch(val);
        }
        /// <summary>
        /// Converts an object to CSV String separated by a Separator
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>string</returns>
        public static string ToCSVString(this object obj, string separator = ",")
        {
            var res = new List<string>();
            foreach (PropertyInfo p in obj.GetType().GetProperties())
            {
                res.Add(p.GetValue(obj, null)?.ToString() ?? string.Empty);
            }
            return string.Join(separator, res);
        }

        /// <summary>
        ///     Returns an enumerable collection of the specified type containing the substrings in this instance that are
        ///     delimited by elements of a specified Char array
        /// </summary>
        /// <param name="val">The string.</param>
        /// <param name="separator">
        ///     An array of Unicode characters that delimit the substrings in this instance, an empty array containing no
        ///     delimiters, or null.
        /// </param>
        /// <typeparam name="T">
        ///     The type of the element to return in the collection, this type must implement IConvertible.
        /// </typeparam>
        /// <returns>
        ///     An enumerable collection whose elements contain the substrings in this instance that are delimited by one or more
        ///     characters in separator.
        /// </returns>
        public static IEnumerable<T> SplitTo<T>(this string val, params char[] separator) where T : IConvertible
        {
            return val.Split(separator, StringSplitOptions.None).Select(s => (T)Convert.ChangeType(s, typeof(T)));
        }

        /// <summary>
        ///     Returns an enumerable collection of the specified type containing the substrings in this instance that are
        ///     delimited by elements of a specified Char array
        /// </summary>
        /// <param name="val">The string.</param>
        /// <param name="options">StringSplitOptions <see cref="StringSplitOptions" /></param>
        /// <param name="separator">
        ///     An array of Unicode characters that delimit the substrings in this instance, an empty array containing no
        ///     delimiters, or null.
        /// </param>
        /// <typeparam name="T">
        ///     The type of the element to return in the collection, this type must implement IConvertible.
        /// </typeparam>
        /// <returns>
        ///     An enumerable collection whose elements contain the substrings in this instance that are delimited by one or more
        ///     characters in separator.
        /// </returns>
        public static IEnumerable<T> SplitTo<T>(this string val, StringSplitOptions options, params char[] separator) where T : IConvertible
        {
            return val.Split(separator, options).Select(s => (T)Convert.ChangeType(s, typeof(T)));
        }

        /// <summary>
        ///     Converts string to its boolean equivalent
        /// </summary>
        /// <param name="val">string to convert</param>
        /// <returns>boolean equivalent</returns>
        /// <remarks>
        ///     <exception cref="ArgumentException">
        ///         thrown in the event no boolean equivalent found or an empty or whitespace
        ///         string is passed
        ///     </exception>
        /// </remarks>
        public static bool ToBoolean(this string val)
        {
            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val))
            {
                throw new ArgumentException("value");
            }
            switch (val.ToLower().Trim())
            {
                case "false":
                    return false;
                case "f":
                    return false;
                case "true":
                    return true;
                case "t":
                    return true;
                case "yes":
                    return true;
                case "no":
                    return false;
                case "y":
                    return true;
                case "n":
                    return false;
                default:
                    throw new ArgumentException("Invalid boolean");
            }
        }


        /// <summary>
        ///     Converts string to its Enum type
        ///     Checks of string is a member of type T enum before converting
        ///     if fails returns default enum
        /// </summary>
        /// <typeparam name="T">generic type</typeparam>
        /// <param name="val"> The string representation of the enumeration name or underlying value to convert</param>
        /// <param name="defaultValue">Dafault value of the Enum</param>
        /// <param name="ignoreCase">Check if it checks case sensitivity of not</param>
        /// <returns>Enum object</returns>
        /// <remarks>
        ///     <exception cref="ArgumentException">
        ///         enumType is not an System.Enum.-or- value is either an empty string (string.Empty) or
        ///         only contains white space.-or- value is a name, but not one of the named constants defined for the enumeration
        ///     </exception>
        /// </remarks>
        public static T ToEnum<T>(this string val, T defaultValue = default(T), bool ignoreCase = false) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Type T Must of type System.Enum");
            }
            T result;
            bool isParsed = Enum.TryParse(val, ignoreCase, out result);
            return isParsed ? result : defaultValue;
        }

        /// <summary>
        ///     Gets empty String if passed value is of type Null/Nothing
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>System.String</returns>
        /// <remarks></remarks>
        public static string GetEmptyStringIfNull(this string val)
        {
            return (val != null ? val.Trim() : string.Empty);
        }

        /// <summary>
        ///     Checks if a string is Null or EmptyString (`string.Empty`), retuns NULL if the string is NULL or Empty and returns the same string if Not.
        /// </summary>
        /// <param name="val">String value</param>
        /// <returns>null/nothing if String IsEmpty</returns>
        /// <remarks></remarks>
        public static string GetNullIfEmptyString(this string val)
        {
            if (val == null || val.Length <= 0)
            {
                return null;
            }
            val = val.Trim();
            if (val.Length > 0)
            {
                return val;
            }
            return null;
        }

        /// <summary>
        ///     Gets first character in string
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>System.string</returns>
        public static string FirstCharacter(this string val)
        {
            return (!string.IsNullOrEmpty(val))
                ? (val.Length >= 1)
                    ? val.Substring(0, 1)
                    : val
                : null;
        }

        /// <summary>
        ///     Gets last character in string
        /// </summary>
        /// <param name="val">val</param>
        /// <returns>System.string</returns>
        public static string LastCharacter(this string val)
        {
            return (!string.IsNullOrEmpty(val))
                ? (val.Length >= 1)
                    ? val.Substring(val.Length - 1, 1)
                    : val
                : null;
        }

        /// <summary>
        ///     Check a String ends with another string ignoring the case.
        /// </summary>
        /// <param name="val">string</param>
        /// <param name="suffix">suffix</param>
        /// <returns>true or false</returns>
        public static bool EndsWithIgnoreCase(this string val, string suffix)
        {
            if (val == null)
            {
                throw new ArgumentNullException("val", "val parameter is null");
            }
            if (suffix == null)
            {
                throw new ArgumentNullException("suffix", "suffix parameter is null");
            }
            if (val.Length < suffix.Length)
            {
                return false;
            }
            return val.EndsWith(suffix, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        ///     Check a String starts with another string ignoring the case.
        /// </summary>
        /// <param name="val">string</param>
        /// <param name="prefix">prefix</param>
        /// <returns>true or false</returns>
        public static bool StartsWithIgnoreCase(this string val, string prefix)
        {
            if (val == null)
            {
                throw new ArgumentNullException("val", "val parameter is null");
            }
            if (prefix == null)
            {
                throw new ArgumentNullException("prefix", "prefix parameter is null");
            }
            if (val.Length < prefix.Length)
            {
                return false;
            }
            return val.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase);
        }
        /// <summary>
        ///     Read in a sequence of words from standard input and capitalize each
        ///     one (make first letter uppercase; make rest lowercase).
        /// </summary>
        /// <param name="s">string</param>
        /// <returns>Word with capitalization</returns>
        public static string Capitalize(this string s)
        {
            if (s == null)
                return null;
            if (s.Length == 0)
            {
                return s;
            }
            return s.Substring(0, 1).ToUpper() + s.Substring(1).ToLower();
        }
        /// <summary>
        ///     Remove Characters from string
        /// </summary>
        /// <param name="s">string to remove characters</param>
        /// <param name="chars">array of chars</param>
        /// <returns>System.string</returns>
        public static string RemoveChars(this string s, params char[] chars)
        {
            var sb = new StringBuilder(s.Length);
            foreach (char c in s.Where(c => !chars.Contains(c)))
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        ///     Replace specified characters with an empty string.
        /// </summary>
        /// <param name="s">the string</param>
        /// <param name="chars">list of characters to replace from the string</param>
        /// <example>
        ///     string s = "Friends";
        ///     s = s.Replace('F', 'r','i','s');  //s becomes 'end;
        /// </example>
        /// <returns>System.string</returns>
        public static string RemoveCharsIgnoreCase(this string s, params char[] chars)
        {
            return chars.Aggregate(s, (current, c) => current.ToLower().Replace(c.ToString(CultureInfo.InvariantCulture).ToLower(), string.Empty));
        }
        /// <summary>
        ///     Remove string from string
        /// </summary>
        /// <param name="s">string to remove characters</param>
        /// <param name="replaceString">String  to be removed</param>
        /// <returns>System.string</returns>
        public static string RemoveString(this string s, string replaceString)
        {
            return s.Replace(replaceString, string.Empty);
        }

        /// <summary>
        ///     Remove string from string ignoring case
        /// </summary>
        /// <param name="s">string to remove characters</param>
        /// <param name="replaceString">String  to be removed</param>
        /// <returns>System.string</returns>
        public static string RemoveStringIgnoreCase(this string s, string replaceString)
        {
            return Regex.Replace(s, replaceString, string.Empty, RegexOptions.IgnoreCase);
        }

        /// <summary>
        ///     Reverse string
        /// </summary>
        /// <param name="val">string to reverse</param>
        /// <returns>System.string</returns>
        public static string Reverse(this string val)
        {
            var chars = new char[val.Length];
            for (int i = val.Length - 1, j = 0; i >= 0; --i, ++j)
            {
                chars[j] = val[i];
            }
            val = new String(chars);
            return val;
        }
        /// <summary>
        ///     Appends String quotes for type CSV data
        /// </summary>
        /// <param name="val">val</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string ParseToCsv(this string val)
        {
            return '"' + GetEmptyStringIfNull(val).Replace("\"", "\"\"") + '"';
        }
        /// <summary>
        ///     Count number of occurrences in string
        /// </summary>
        /// <param name="val">string containing text</param>
        /// <param name="stringToMatch">string or pattern find</param>
        /// <returns></returns>
        public static int CountOccurrences(this string val, string stringToMatch)
        {
            return Regex.Matches(val, stringToMatch).Count;
        }
        /// <summary>
        ///     Count number of occurrences in string ignoring Case
        /// </summary>
        /// <param name="val">string containing text</param>
        /// <param name="stringToMatch">string or pattern find</param>
        /// <returns></returns>
        public static int CountOccurrencesIgnoreCase(this string val, string stringToMatch)
        {
            return Regex.Matches(val, stringToMatch, RegexOptions.IgnoreCase).Count;
        }

        /// <summary>
        ///     Removes the first part of the string, if no match found return original string
        /// </summary>
        /// <param name="val">string to remove prefix</param>
        /// <param name="prefix">prefix</param>
        /// <param name="ignoreCase">Indicates whether the compare should ignore case</param>
        /// <returns>trimmed string with no prefix or original string</returns>
        public static string RemovePrefix(this string val, string prefix, bool ignoreCase = true)
        {
            if (!string.IsNullOrEmpty(val) && (ignoreCase ? val.StartsWithIgnoreCase(prefix) : val.StartsWith(prefix)))
            {
                return val.Substring(prefix.Length, val.Length - prefix.Length);
            }
            return val;
        }

        /// <summary>
        ///     Removes the end part of the string, if no match found return original string
        /// </summary>
        /// <param name="val">string to remove suffix</param>
        /// <param name="suffix">suffix</param>
        /// <param name="ignoreCase">Indicates whether the compare should ignore case</param>
        /// <returns>trimmed string with no suffix or original string</returns>
        public static string RemoveSuffix(this string val, string suffix, bool ignoreCase = true)
        {
            if (!string.IsNullOrEmpty(val) && (ignoreCase ? val.EndsWithIgnoreCase(suffix) : val.EndsWith(suffix)))
            {
                return val.Substring(0, val.Length - suffix.Length);
            }
            return val;
        }

        /// <summary>
        ///     Appends the suffix to the end of the string if the string does not already end in the suffix.
        /// </summary>
        /// <param name="val">string to append suffix</param>
        /// <param name="suffix">suffix</param>
        /// <param name="ignoreCase">Indicates whether the compare should ignore case</param>
        /// <returns></returns>
        public static string AppendSuffixIfMissing(this string val, string suffix, bool ignoreCase = true)
        {
            if (string.IsNullOrEmpty(val) || (ignoreCase ? val.EndsWithIgnoreCase(suffix) : val.EndsWith(suffix)))
            {
                return val;
            }
            return val + suffix;
        }

        /// <summary>
        ///     Appends the prefix to the start of the string if the string does not already start with prefix.
        /// </summary>
        /// <param name="val">string to append prefix</param>
        /// <param name="prefix">prefix</param>
        /// <param name="ignoreCase">Indicates whether the compare should ignore case</param>
        /// <returns></returns>
        public static string AppendPrefixIfMissing(this string val, string prefix, bool ignoreCase = true)
        {
            if (string.IsNullOrEmpty(val) || (ignoreCase ? val.StartsWithIgnoreCase(prefix) : val.StartsWith(prefix)))
            {
                return val;
            }
            return prefix + val;
        }

        /// <summary>
        ///     Extracts the left part of the input string limited with the length parameter
        /// </summary>
        /// <param name="val">The input string to take the left part from</param>
        /// <param name="length">The total number characters to take from the input string</param>
        /// <returns>The substring starting at startIndex 0 until length</returns>
        /// <exception cref="ArgumentNullException">input is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Length is smaller than zero or higher than the length of input</exception>
        public static string Left(this string val, int length)
        {
            if (string.IsNullOrEmpty(val))
            {
                throw new ArgumentNullException("val");
            }
            if (length < 0 || length > val.Length)
            {
                throw new ArgumentOutOfRangeException("length",
                    "length cannot be higher than total string length or less than 0");
            }
            return val.Substring(0, length);
        }

        /// <summary>
        ///     Extracts the right part of the input string limited with the length parameter
        /// </summary>
        /// <param name="val">The input string to take the right part from</param>
        /// <param name="length">The total number characters to take from the input string</param>
        /// <returns>The substring taken from the input string</returns>
        /// <exception cref="ArgumentNullException">input is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">Length is smaller than zero or higher than the length of input</exception>
        public static string Right(this string val, int length)
        {
            if (string.IsNullOrEmpty(val))
            {
                throw new ArgumentNullException("val");
            }
            if (length < 0 || length > val.Length)
            {
                throw new ArgumentOutOfRangeException("length",
                    "length cannot be higher than total string length or less than 0");
            }
            return val.Substring(val.Length - length);
        }

        /// <summary>
        ///     Checks if a string is null
        /// </summary>
        /// <param name="val">string to evaluate</param>
        /// <returns>true if string is null else false</returns>
        public static bool IsNull(this string val)
        {
            return val == null;
        }

        /// <summary>
        ///     Checks if a string is null or empty
        /// </summary>
        /// <param name="val">string to evaluate</param>
        /// <returns>true if string is null or is empty else false</returns>
        public static bool IsNullOrEmpty(this string val)
        {
            return string.IsNullOrEmpty(val);
        }

        /// <summary>
        ///     Checks if a string is Null or white space
        /// </summary>
        /// <param name="val">string to evaluate</param>
        /// <returns>true if string is Null or white space else false</returns>
        public static bool IsNullOrWhiteSpace(this string val)
        {
            return string.IsNullOrWhiteSpace(val);
        }
        /// <summary>
        ///     Checks if string length is a certain minimum number of characters, does not ignore leading and trailing
        ///     white-space.
        ///     null strings will always evaluate to false.
        /// </summary>
        /// <param name="val">string to evaluate minimum length</param>
        /// <param name="minCharLength">minimum allowable string length</param>
        /// <returns>true if string is of specified minimum length</returns>
        public static bool IsMinLength(this string val, int minCharLength)
        {
            return val != null && val.Length >= minCharLength;
        }

        /// <summary>
        ///     Checks if string length is consists of specified allowable maximum char length. does not ignore leading and
        ///     trailing white-space.
        ///     null strings will always evaluate to false.
        /// </summary>
        /// <param name="val">string to evaluate maximum length</param>
        /// <param name="maxCharLength">maximum allowable string length</param>
        /// <returns>true if string has specified maximum char length</returns>
        public static bool IsMaxLength(this string val, int maxCharLength)
        {
            return val != null && val.Length <= maxCharLength;
        }

        /// <summary>
        ///     Checks if string length satisfies minimum and maximum allowable char length. does not ignore leading and
        ///     trailing white-space
        /// </summary>
        /// <param name="val">string to evaluate</param>
        /// <param name="minCharLength">minimum char length</param>
        /// <param name="maxCharLength">maximum char length</param>
        /// <returns>true if string satisfies minimum and maximum allowable length</returns>
        public static bool IsBetweenLength(this string val, int minCharLength, int maxCharLength)
        {
            return val != null && val.Length >= minCharLength && val.Length <= maxCharLength;
        }

        /// <summary>Splits the camel case into an IEnumerable, If the input is "FirstName", It will return "First" "Name"</summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static IEnumerable<string> SplitCamelCase(this string source)
        {
            const string pattern = @"[A-Z][a-z]*|[a-z]+|\d+";
            var matches = Regex.Matches(source, pattern);
            foreach (Match match in matches)
            {
                yield return match.Value;
            }
        }

        /// <summary>
        /// Converts to humancase. If the input is "FirstName", It will return "First Name"
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static string ToHumanCase(this string source)
        {
            var words = source.SplitCamelCase();
            string humanCased = string.Join(" ", words);
            return humanCased;
        }

        /// <summary>
        /// Converts a string to Title Case
        /// </summary>
        /// <param name="source">Given input string</param>
        /// <returns></returns>
        public static string ToTitleCase(this string source)
        {
            if (source == null) return source;

            CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            // TextInfo.ToTitleCase only operates on the string if is all lower case, otherwise it returns the string unchanged.
            return textInfo.ToTitleCase(source.ToLower());
        }

        /// <summary>
        /// Truncates a string to the specified maximum length.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <returns>System.String</returns>
        public static string Truncate(this string value, int maxLength)
        {
            if (value.IsNullOrEmpty()) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        /// <summary>
        ///     Encrypt a string using the supplied key. Encoding is done using RSA encryption.
        /// </summary>
        /// <param name="stringToEncrypt">String that must be encrypted.</param>
        /// <param name="key">Encryption key</param>
        /// <returns>A string representing a byte array separated by a minus sign.</returns>
        /// <exception cref="ArgumentException">Occurs when stringToEncrypt or key is null or empty.</exception>
        public static string Encrypt(this string stringToEncrypt, string key)
        {
            var cspParameter = new CspParameters { KeyContainerName = key };
            var rsaServiceProvider = new RSACryptoServiceProvider(cspParameter) { PersistKeyInCsp = true };
            byte[] bytes = rsaServiceProvider.Encrypt(Encoding.UTF8.GetBytes(stringToEncrypt), true);
            return BitConverter.ToString(bytes);
        }


        /// <summary>
        ///     Decrypt a string using the supplied key. Decoding is done using RSA encryption.
        /// </summary>
        /// <param name="stringToDecrypt">String that must be decrypted.</param>
        /// <param name="key">Decryption key.</param>
        /// <returns>The decrypted string or null if decryption failed.</returns>
        /// <exception cref="ArgumentException">Occurs when stringToDecrypt or key is null or empty.</exception>
        public static string Decrypt(this string stringToDecrypt, string key)
        {
            var cspParamters = new CspParameters { KeyContainerName = key };
            var rsaServiceProvider = new RSACryptoServiceProvider(cspParamters) { PersistKeyInCsp = true };
            string[] decryptArray = stringToDecrypt.Split(new[] { "-" }, StringSplitOptions.None);
            byte[] decryptByteArray = Array.ConvertAll(decryptArray,
                (s => Convert.ToByte(byte.Parse(s, NumberStyles.HexNumber))));
            byte[] bytes = rsaServiceProvider.Decrypt(decryptByteArray, true);
            string result = Encoding.UTF8.GetString(bytes);
            return result;
        }

        /// <summary>
        ///     Convert url query string to IDictionary value key pair
        /// </summary>
        /// <param name="queryString">query string value</param>
        /// <returns>IDictionary value key pair</returns>
        public static IDictionary<string, string> QueryStringToDictionary(this string queryString)
        {
            if (string.IsNullOrWhiteSpace(queryString))
                return null;
            if (!queryString.Contains("?"))
                return null;

            //If the User has sent the entire URL, find out only the query string.
            queryString = queryString.Right(queryString.Length - queryString.IndexOf("?"));
            string query = queryString.Replace("?", "");
            if (!query.Contains("="))
            {
                return null;
            }
            return query.Split('&').Select(p => p.Split('=')).ToDictionary(
                key => key[0].ToLower().Trim(), value => value[1]);
        }


        /// <summary>
        ///     Remove Line Feeds
        /// </summary>
        /// <param name="val">string to remove line feeds</param>
        /// <returns>System.string</returns>
        public static string RemoveLineFeeds(this string val)
        {
            return Regex.Replace(val, @"^[\r\n]+|\.|[\r\n]+$", "");
        }

        /// <summary>
        ///     Check if a string does not start with prefix
        /// </summary>
        /// <param name="val">string to evaluate</param>
        /// <param name="prefix">prefix</param>
        /// <returns>true if string does not match prefix else false, null values will always evaluate to false</returns>
        public static bool DoesNotStartWith(this string val, string prefix, bool ignoreCase = false)
        {
            if (ignoreCase)
                return val == null || prefix == null ||
                  !val.StartsWithIgnoreCase(prefix);
            else
                return val == null || prefix == null ||
                       !val.StartsWith(prefix, StringComparison.InvariantCulture);
        }

        /// <summary>
        ///     Check if a string does not end with prefix
        /// </summary>
        /// <param name="val">string to evaluate</param>
        /// <param name="suffix">suffix</param>
        /// <returns>true if string does not match prefix else false, null values will always evaluate to false</returns>
        public static bool DoesNotEndWith(this string val, string suffix, bool ignoreCase = false)
        {
            if (ignoreCase)
                return val == null || suffix == null ||
                  !val.EndsWithIgnoreCase(suffix);
            else
                return val == null || suffix == null ||
                       !val.EndsWith(suffix, StringComparison.InvariantCulture);
        }

        /// <summary>
        ///     Convert string to Hash using Sha512
        /// </summary>
        /// <param name="val">string to hash</param>
        /// <returns>Hashed string</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string CreateHashSha512(this string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                throw new ArgumentException("val");
            }
            var sb = new StringBuilder();
            using (SHA512 hash = SHA512.Create())
            {
                byte[] data = hash.ComputeHash(val.ToBytes());
                foreach (byte b in data)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }

        /// <summary>
        ///     Convert string to Hash using Sha256
        /// </summary>
        /// <param name="val">string to hash</param>
        /// <returns>Hashed string</returns>
        public static string CreateHashSha256(this string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                throw new ArgumentException("val");
            }
            var sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                byte[] data = hash.ComputeHash(val.ToBytes());
                foreach (byte b in data)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }
        /// <summary>
        ///     Convert a string to its equivalent byte array
        /// </summary>
        /// <param name="val">string to convert</param>
        /// <returns>System.byte array</returns>
        public static byte[] ToBytes(this string val)
        {
            var bytes = new byte[val.Length * sizeof(char)];
            Buffer.BlockCopy(val.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
        /// <summary>
        /// Checks string object's value to array of string values, does not ignore case sensitivity
        /// </summary>        
        /// <param name="stringValues">Array of string values to compare</param>
        /// <returns>Return true if any string value matches</returns>
        public static bool In(this string value, params string[] stringValues)
        {
            foreach (string otherValue in stringValues)
                if (string.Compare(value, otherValue) == 0)
                    return true;

            return false;
        }

        /// <summary>
        /// Checks string object's value to array of string values, ignores case sensitivity
        /// </summary>        
        /// <param name="stringValues">Array of string values to compare</param>
        /// <returns>Return true if any string value matches</returns>
        public static bool InWithIgnoreCase(this string value, params string[] stringValues)
        {
            foreach (string otherValue in stringValues)
                if (string.Compare(value.ToLower(), otherValue.ToLower()) == 0)
                    return true;

            return false;
        }
        /// <summary>
        /// Converts a string to a SEO friendly URL.
        /// </summary>
        /// <param name="maxLength">The maximum length.</param>
        /// <returns></returns>
        public static string SeoFriendlyURL(this string title, int maxLength)
        {
            Dictionary<string, string> dictWords = new Dictionary<string, string>{
                {"C#","c-sharp"},
                {"F#","f-sharp"} //Add Other list if possible
            };

            foreach (KeyValuePair<string, string> word in dictWords)
            {
                title = title.Replace(word.Key, word.Value);
            }

            var match = Regex.Match(title.ToLower(), "[\\w]+");
            StringBuilder seoUrl = new StringBuilder("");
            bool maxLengthHit = false;
            while (match.Success && !maxLengthHit)
            {
                if (seoUrl.Length + match.Value.Length <= maxLength)
                {
                    seoUrl.Append(match.Value + "-");
                }
                else
                {
                    maxLengthHit = true;
                    if (seoUrl.Length == 0)
                    {
                        seoUrl.Append(match.Value.Substring(0, maxLength));
                    }
                }
                match = match.NextMatch();
            }
            if (seoUrl[seoUrl.Length - 1] == '-')
            {
                seoUrl.Remove(seoUrl.Length - 1, 1);
            }
            return seoUrl.ToString();
        }

        /// <summary>
        ///     Replaces one or more format items in a specified string with the string representation of a specified object.
        /// </summary>
        /// <param name="value">A composite format string</param>
        /// <param name="arg0">An System.Object to format</param>
        /// <returns>A copy of format in which any format items are replaced by the string representation of arg0</returns>
        /// <exception cref="ArgumentNullException">format or args is null.</exception>
        /// <exception cref="FormatException">
        ///     format is invalid.-or- The index of a format item is less than zero, or
        ///     greater than or equal to the length of the args array.
        /// </exception>
        public static string Format(this string value, object arg0)
        {
            return string.Format(value, arg0);
        }

        /// <summary>
        ///     Replaces the format item in a specified string with the string representation of a corresponding object in a
        ///     specified array.
        /// </summary>
        /// <param name="value">A composite format string</param>
        /// <param name="args">An object array that contains zero or more objects to format</param>
        /// <returns>
        ///     A copy of format in which the format items have been replaced by the string representation of the
        ///     corresponding objects in args
        /// </returns>
        /// <exception cref="ArgumentNullException">format or args is null.</exception>
        /// <exception cref="FormatException">
        ///     format is invalid.-or- The index of a format item is less than zero, or
        ///     greater than or equal to the length of the args array.
        /// </exception>
        public static string Format(this string value, params object[] args)
        {
            return string.Format(value, args);
        }

        /// <summary>
        /// Gets the only digits from a specified string. If the string is "123-12-1234", returns "123121234".
        /// </summary>
        /// <param name="value">specified string</param>
        /// <returns>A string containing only digits</returns>
        public static string GetOnlyDigits(this string value)
        {
            return new string(value?.Where(c => char.IsDigit(c)).ToArray());
        }
        /// <summary>
        /// Masks the email string.
        /// If an email address is "abc@gmail.com", the output is a#c@g####.com
        /// </summary>
        /// <param name="emailAddress">The email address</param>
        /// <param name="maskChar">The mask character, "*" by default</param>
        /// <returns>system.string</returns>
        public static string MaskEmail(this string emailAddress, char maskChar = '*')
        {
            string pattern = @"(?<=[\w]{1})[\w-\._\+%\\]*(?=[\w]{1}@)|(?<=@[\w]{1})[\w-_\+%]*(?=\.)";
            if (!emailAddress.Contains("@"))
                return new string('*', emailAddress.Length);
            if (emailAddress.Split('@')[0].Length < 4)
                return @"*@*.*";
            return Regex.Replace(emailAddress, pattern, m => new string(maskChar, m.Length));
        }
        /// <summary>
        /// Masks the phone number.
        /// If a phone number is "(800) 555-1212", the output will be "(###) ### -1212"
        /// If a phone number is "800 555-7890", the output will be "### ###-7890"
        /// If a phone number is "1234561111", the output will be "######1111"
        /// </summary>
        /// <param name="phoneNumber">The phone number</param>
        /// <param name="maskChar">The mask character.</param>
        /// <returns>system.string</returns>
        public static string MaskPhoneNumber(this string phoneNumber, char maskChar = '*')
        {
            return Regex.Replace(phoneNumber, @"\d(?!\d{0,3}$)", maskChar.ToString());
        }
        /// <summary>
        /// Transforms a string to phone number
        /// If a phone number is "1234567890", then the formatted string will be "(123) 456-7890"
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>system.string</returns>
        public static string ToPhoneNumber(this string phoneNumber)
        {
            return Regex.Replace(phoneNumber, @"(\d{3})(\d{3})(\d{4})", "($1)-$2-$3");
        }

        /// <summary>
        /// Convert a (A)RGB string to a Color object
        /// </summary>
        /// <param name="argb">An RGB or an ARGB string</param>
        /// <returns>a Color object</returns>
        public static Color ToColor(this string argb)
        {
            argb = argb.Replace("#", "");
            byte a = Convert.ToByte("ff", 16);
            byte pos = 0;
            if (argb.Length == 8)
            {
                a = Convert.ToByte(argb.Substring(pos, 2), 16);
                pos = 2;
            }
            byte r = Convert.ToByte(argb.Substring(pos, 2), 16);
            pos += 2;
            byte g = Convert.ToByte(argb.Substring(pos, 2), 16);
            pos += 2;
            byte b = Convert.ToByte(argb.Substring(pos, 2), 16);
            return Color.FromArgb(a, r, g, b);
        }
        /// <summary>
        /// Count all words in a given string excluding white spaces, tabs, line breaks
        /// </summary>
        /// <param name="input">string to begin with</param>
        /// <returns>int</returns>
        public static int WordCount(this string input)
        {
            var count = 0;
            try
            {
                // Exclude whitespace, Tabs and line breaks
                var re = new Regex(@"[^\s]+");
                var matches = re.Matches(input);
                count = matches.Count;
            }
            catch
            {
            }
            return count;
        }
        /// <summary>
        /// Finds the index of the nth occurrence of a string in a string
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="stringToBeFound">The string to be found.</param>
        /// <param name="occurrence">The occurrence.</param>
        /// <returns></returns>
        public static int NthIndexOf(this string input, string stringToBeFound, int occurrence)
        {
            int occurrenceCounter = 0;
            int indexOfPassedString = 0 - stringToBeFound.Length;
            do
            {
                indexOfPassedString = input.IndexOf(stringToBeFound, indexOfPassedString + stringToBeFound.Length);
                if (indexOfPassedString == -1)
                    break;
                occurrenceCounter++;
            }
            while (occurrenceCounter != occurrence);

            return indexOfPassedString;
        }
    }
}
