using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Extension.Methods
{
    public static class GenericExtensions
    {
        private static Random random = new Random();
        /// <summary>
        /// Itterates over any IEnumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="action">The action.</param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }
        /// <summary>
        /// Randomizes the specified target.
        /// OrderBy() is nice when you want a consistent & predictable ordering. This method is NOT THAT! Randomize() - Use this extension method when you want a different or random order every time! Useful when ordering a list of things for display to give each a fair chance of landing at the top or bottom on each hit.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> target)
        {
            return target.OrderBy(x => (random.Next()));
        }
        /// <summary>
        /// Determines whether an IEnumerable is null or Empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>
        ///   <c>true</c>if given collection is null or empty otherwise it returns<c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || (!source.Any());
        }
        /// <summary>
        /// Determines whether an IEnumerable is not null and Empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>
        ///   <c>false</c> if given collection is null or empty otherwise it returns<c>true</c>.
        /// </returns>
        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source != null && source.Any();
        }

        /// <summary>
        /// Convert a IEnumerable<T> to a Collection<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <returns></returns>
        public static Collection<T> ToCollection<T>(this IEnumerable<T> enumerable)
        {
            var collection = new Collection<T>();
            foreach (T i in enumerable)
                collection.Add(i);
            return collection;
        }
        /// <summary>
        /// Converts an Enumerable To the CSV string separated by ","
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public static string ToCSV<T>(this IEnumerable<T> instance)
        {
            StringBuilder csv;
            if (instance != null)
            {
                csv = new StringBuilder();
                instance.ForEach(v => csv.AppendFormat("{0},", v));
                return csv.ToString(0, csv.Length - 1);
            }
            return string.Empty;
        }
        /// <summary>
        /// Converts an Enumerable To the CSV string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public static string ToCSV<T>(this IEnumerable<T> instance, char separator)
        {
            StringBuilder csv;
            if (instance != null)
            {
                csv = new StringBuilder();
                instance.ForEach(value => csv.AppendFormat("{0}{1}", value, separator));
                return csv.ToString(0, csv.Length - 1);
            }
            return string.Empty;
        }

        /// <summary>
        /// Converts an IEnumerable to a HashSet
        /// </summary>
        /// <typeparam name="T">The IEnumerable type</typeparam>
        /// <param name="enumerable">The IEnumerable</param>
        /// <returns>A new HashSet</returns>
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable)
        {
            HashSet<T> hs = new HashSet<T>();
            foreach (T item in enumerable)
                hs.Add(item);
            return hs;
        }
        /// <summary>
        /// Returns the index of the first occurrence in a sequence by using the default equality comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="list">A sequence in which to locate a value.</param>
        /// <param name="value">The object to locate in the sequence</param>
        /// <returns>The zero-based index of the first occurrence of value within the entire sequence, if found; otherwise, –1.</returns>
        public static int IndexOf<TSource>(this IEnumerable<TSource> list, TSource value) where TSource : IEquatable<TSource>
        {

            return list.IndexOf<TSource>(value, EqualityComparer<TSource>.Default);

        }

        /// <summary>
        /// Returns the index of the first occurrence in a sequence by using a specified IEqualityComparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="list">A sequence in which to locate a value.</param>
        /// <param name="value">The object to locate in the sequence</param>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <returns>The zero-based index of the first occurrence of value within the entire sequence, if found; otherwise, –1.</returns>
        public static int IndexOf<TSource>(this IEnumerable<TSource> list, TSource value, IEqualityComparer<TSource> comparer)
        {
            int index = 0;
            foreach (var item in list)
            {
                if (comparer.Equals(item, value))
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        /// <summary>
        /// Concatenates a specified separator String between each element of a specified enumeration, yielding a single concatenated string.
        /// </summary>
        /// <typeparam name="T">any object</typeparam>
        /// <param name="list">The enumeration</param>
        /// <param name="separator">A String</param>
        /// <returns>A String consisting of the elements of value interspersed with the separator string.</returns>
        public static string ToString<T>(this IEnumerable<T> list, string separator)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var obj in list)
            {
                if (sb.Length > 0)
                {
                    sb.Append(separator);
                }
                sb.Append(obj);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Splits the items into different lists depending upon splitSize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="splitSize">Size of the split.</param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int splitSize)
        {
            using (IEnumerator<T> enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    yield return InnerSplit(enumerator, splitSize);
                }
            }

        }
        /// <summary>
        /// Continues processing items in a collection until the end condition is true.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="collection">The collection to iterate.</param>
        /// <param name="endCondition">The condition that returns true if iteration should stop.</param>
        /// <returns>Iterator of sub-list.</returns>
        public static IEnumerable<T> TakeUntil<T>(this IEnumerable<T> collection, Predicate<T> endCondition)
        {
            return collection.TakeWhile(item => !endCondition(item));
        }
        /// <summary>
        /// Selects a random element out of a sequence.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <returns>T selected at Random</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">The sequence is empty.</exception>
        public static T SelectRandom<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException();
            }
            if (!sequence.Any())
            {
                throw new ArgumentException("The sequence is empty.");
            }
            //optimization for ICollection<T>
            if (sequence is ICollection<T>)
            {
                ICollection<T> col = (ICollection<T>)sequence;
                return col.ElementAt(random.Next(col.Count));
            }
            int count = 1;
            T selected = default(T);
            foreach (T element in sequence)
            {
                if (random.Next(count++) == 0)
                {
                    //Select the current element with 1/count probability
                    selected = element;
                }
            }
            return selected;
        }
        /// <summary>
        /// Determines whether a sequence contains exactly one element.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="source"/></typeparam>
        /// <param name="source">The <see cref="IEnumerable{T}"/> to check for singularity.</param>
        /// <returns>
        /// <c>true</c> if the <paramref name="source"/> sequence contains exactly one element; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSingle<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            using (var enumerator = source.GetEnumerator())
            {
                return enumerator.MoveNext() && !enumerator.MoveNext();
            }
        }
        /// <summary>
        /// Creates a string that is each the elements' ToString() values wrapped in the 'tag' that is passed as a param. Good for converting an IEnum<T> into a block of HTML/XML.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="tagToWrap">The tag to wrap.</param>
        /// <returns></returns>
        public static string WrapEachWithTag<T>(this IEnumerable<T> source, string tagToWrap)
        {
            var tag = String.Format("</{0}>", tagToWrap);
            var s = "";
            foreach (T item in source)
            {
                s += tag.Replace(@"/", "") + item.ToString() + tag;
            }
            return s;
        }

        /// <summary>
        /// Determines whether the specified comparison is sorted.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="comparison">The comparison.</param>
        /// <returns>
        ///   <c>true</c> if the specified comparison is sorted; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSorted<T>(this IEnumerable<T> source, Comparison<T> comparison = null)
        {
            if (comparison == null)
                comparison = Comparer<T>.Default.Compare;

            using (IEnumerator<T> e = source.GetEnumerator())
            {
                if (!e.MoveNext())
                    return true;

                T prev = e.Current;
                while (e.MoveNext())
                {
                    T current = e.Current;
                    if (comparison(prev, current) > 0)
                        return false;

                    prev = current;
                }
            }
            return true;
        }
        /// <summary>
        /// Selects the object in a list with the minimum or maximum value on a particular property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="start">The start.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">source</exception>
        public static IEnumerable<T> Slice<T>(this IEnumerable<T> source, int start, int count)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Skip(start).Take(count);
        }
        /// <summary>
        /// Selects the object in a list with the minimum value on a particular property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public static T FindMin<T, TValue>(this IEnumerable<T> list, Func<T, TValue> predicate)
                                                        where TValue : IComparable<TValue>
        {

            T result = list.FirstOrDefault();
            if (result != null)
            {
                var bestMin = predicate(result);
                foreach (var item in list.Skip(1))
                {
                    var v = predicate(item);
                    if (v.CompareTo(bestMin) < 0)
                    {
                        bestMin = v;
                        result = item;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Selects the object in a list with the maximum value on a particular property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public static T FindMax<T, TValue>(this IEnumerable<T> list, Func<T, TValue> predicate)
                                                                where TValue : IComparable<TValue>
        {
            T result = list.FirstOrDefault();
            if (result != null)
            {
                var bestMax = predicate(result);
                foreach (var item in list.Skip(1))
                {
                    var v = predicate(item);
                    if (v.CompareTo(bestMax) > 0)
                    {
                        bestMax = v;
                        result = item;
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Inserts an element to the proper position in a sorted list. Make sure to sort the list before calling InsertSorted
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The sorted source.</param>
        /// <param name="value">The value to be inserted</param>
        /// <returns>Returns the position where the value was inserted</returns>
        /// <exception cref="ArgumentNullException">source</exception>
        public static int InsertSorted<T>(this IList<T> source, T value) where T : IComparable<T>
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            for (int i = 0; i < source.Count; i++)
            {
                if (value.CompareTo(source[i]) < 0)
                {
                    source.Insert(i, value);
                    return i;
                }
            }
            source.Add(value);
            return source.Count - 1;
        }

        /// <summary>
        /// Inserts an element to the proper position in a sorted list. Make sure to sort the list before calling InsertSorted
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The sorted source.</param>
        /// <param name="value">The value to be inserted</param>
        /// <param name="comparison">The comparison that implements the Compare() for comparision of two objects of Type T.</param>
        /// <returns>Returns the position where the value was inserted</returns>
        /// <exception cref="ArgumentNullException">source</exception>
        public static int InsertSorted<T>(this IList<T> source, T value, IComparer<T> comparison)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            for (int i = 0; i < source.Count; i++)
            {
                if (comparison.Compare(value, source[i]) < 0)
                {
                    source.Insert(i, value);
                    return i;
                }
            }
            source.Add(value);
            return source.Count - 1;
        }

        /// <summary>
        /// Inserts an element to the proper position in a sorted list. Make sure to sort the list before calling InsertSorted
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The sorted source.</param>
        /// <param name="value">The value to be inserted</param>
        /// <param name="comparison">The comparison deligate that compares two objects of Type T.</param>
        /// <returns>Returns the position where the value was inserted</returns>
        /// <exception cref="ArgumentNullException">source</exception>
        public static int InsertSorted<T>(this IList<T> source, T value, Comparison<T> comparison)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            for (int i = 0; i < source.Count; i++)
            {
                if (comparison(value, source[i]) < 0)
                {
                    source.Insert(i, value);
                    return i;
                }
            }
            source.Add(value);
            return source.Count - 1;
        }
        /// <summary>
        /// Returns an empty sequense if the sequense is Null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <returns></returns>
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> sequence)
        {
            return sequence ?? Enumerable.Empty<T>();
        }

        #region Private Methods
        private static IEnumerable<T> InnerSplit<T>(IEnumerator<T> enumerator, int splitSize)
        {
            int count = 0;
            do
            {
                count++;
                yield return enumerator.Current;
            }
            while (count % splitSize != 0
                 && enumerator.MoveNext());
        }
        #endregion
    }
}
