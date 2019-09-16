using Newtonsoft.Json;
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
            var settings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            return JsonConvert.DeserializeObject<T>(json, settings);
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
            return
                (Dictionary<string, object>)JsonConvert.DeserializeObject(val, typeof(Dictionary<string, object>));
        }
        /// <summary>
        ///     Converts an object of type T to Json String. Method applicable for multi hierarchy objects i.e
        ///     having zero or many parent child relationships, Ignore loop references and do not serialize if cycles are detected.
        /// </summary>
        /// <param name="obj">Object to be converted to Json</param>
        /// <returns>system.strin</returns>
        public static string ToJson<T>(this T obj)
        {
            var settings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}
