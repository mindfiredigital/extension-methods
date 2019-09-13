namespace Extensions
{
    public static class NumberExtensions
    {
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
    }
}
