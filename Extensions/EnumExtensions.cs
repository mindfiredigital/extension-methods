using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// <summary>
        /// Extension method to fetch attribute of a specific type of an Enum
        /// </summary>
        /// <param name="value">Enum having a specific Attribute</param>
        /// <returns>Attribute</returns>
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0 ? (T)attributes[0] : null;
        }

        /// <summary>
        /// Extension method that returns the value of the Description Attribute on an Enum
        /// </summary>
        /// <param name="value">Enum having Description Attribute</param>
        /// <returns>String</returns>
        public static string ToDescription(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }

    }
}
