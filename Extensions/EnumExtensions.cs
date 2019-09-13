using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts an Enum to a list containinng all values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentException">T must be of type System.Enum</exception>
        public static IEnumerable<T> EnumToList<T>()
        {
            Type enumType = typeof(T);

            // Can't use type constraints on value types, so have to do check like this
            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be of type System.Enum");

            Array enumValArray = Enum.GetValues(enumType);
            List<T> enumValList = new List<T>(enumValArray.Length);
            foreach (int val in enumValArray)
            {
                enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
            }
            return enumValList.AsEnumerable();
        }
    }
}
