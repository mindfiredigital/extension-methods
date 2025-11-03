using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension.Methods
{
    public static class JsonExtensions
    {
        /// <summary>
        ///     Converts a Json string to object of type T method applicable for multi hierarchy objects i.e
        ///     having zero or many parent child relationships, Ignore loop references and do not serialize if cycles are detected.
        /// </summary>
        /// <typeparam name="T">object to convert to</typeparam>
        /// <param name="json">json</param>
        /// <returns>object</returns>
        public static T JsonToObject<T>(this string json)
        {
            var options = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.IgnoreCycles };
            return JsonSerializer.Deserialize<T>(json, options);
        }
        /// <summary>
        ///     Converts a Json string to dictionary object method applicable for single hierarchy objects i.e
        ///     no parent child relationships, for parent child relationships <see cref="JsonToExpanderObject" />
        /// </summary>
        /// <param name="val">string formated as Json</param>
        /// <returns>IDictionary Json object</returns>
        /// <remarks>
        ///     <exception cref="ArgumentNullException">if string parameter is null or empty</exception>
        /// </remarks>
        public static IDictionary<string, object> JsonToDictionary(this string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                throw new ArgumentNullException("val");
            }
            var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(val);
            return ConvertJsonElementDictionary(dict);
        }
        /// <summary>
        ///     Converts an object of type T to Json String. Method applicable for multi hierarchy objects i.e
        ///     having zero or many parent child relationships, Ignore loop references and do not serialize if cycles are detected.
        /// </summary>
        /// <param name="obj">Object to be converted to Json</param>
        /// <returns>system.strin</returns>
        public static string ToJson<T>(this T obj)
        {
            var options = new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.IgnoreCycles };
            return JsonSerializer.Serialize(obj, options);
        }

        private static IDictionary<string, object> ConvertJsonElementDictionary(IDictionary<string, object> source)
        {
            if (source == null) return null;
            var result = new Dictionary<string, object>(source.Count);
            foreach (var kvp in source)
            {
                result[kvp.Key] = ConvertJsonElement(kvp.Value);
            }
            return result;
        }

        private static object ConvertJsonElement(object value)
        {
            if (value is JsonElement el)
            {
                switch (el.ValueKind)
                {
                    case JsonValueKind.Object:
                        var dict = new Dictionary<string, object>();
                        foreach (var prop in el.EnumerateObject())
                        {
                            dict[prop.Name] = ConvertJsonElement(prop.Value);
                        }
                        return dict;
                    case JsonValueKind.Array:
                        var list = new List<object>();
                        foreach (var item in el.EnumerateArray())
                        {
                            list.Add(ConvertJsonElement(item));
                        }
                        return list;
                    case JsonValueKind.String:
                        if (el.TryGetDateTime(out var dt)) return dt;
                        return el.GetString();
                    case JsonValueKind.Number:
                        if (el.TryGetInt64(out var l)) return l;
                        if (el.TryGetDouble(out var d)) return d;
                        return el.GetRawText();
                    case JsonValueKind.True:
                        return true;
                    case JsonValueKind.False:
                        return false;
                    case JsonValueKind.Null:
                    case JsonValueKind.Undefined:
                        return null;
                    default:
                        return el.GetRawText();
                }
            }
            return value;
        }
    }
}
