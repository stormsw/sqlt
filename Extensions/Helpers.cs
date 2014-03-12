namespace SQLt
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public static class HelpersExtensions
    {
        /// <summary>
        /// Use this helper when you dont like to check for null
        /// </summary>
        /// <remarks>
        /// <example>
        /// //Replace this
        /// if(nullableEnumerableVar!=null)
        /// {
        ///     foreach(var x in nullableEnumerableVar)
        ///     {
        ///     //...
        ///     }
        /// }
        /// //with this:
        /// foreach(var x in nullableEnumerableVar.OrEmptyIfNull())
        /// {
        ///     //...
        /// }
        /// </example>
        /// </remarks>
        /// <typeparam name="T">element Type</typeparam>
        /// <param name="source">enumerable variable</param>
        /// <returns>enumerableVar or empty one</returns>
        public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }

        public static IEnumerable<TResult> ForEachLazzy<TResult>(this IEnumerable<TResult> collection, Action<TResult> mapper)
        {
            using (var iterator = collection.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    mapper(iterator.Current);
                    yield return iterator.Current;
                }
            }
        }
        /// <summary>
        /// Applies a specified function to the corresponding elements of two sequences, producing a sequence of the results.
        /// </summary>
        /// <example>
        /// int[] numbers = { 1, 2, 3, 4 };
        /// string[] words = { "one", "two", "three" };
        /// var numbersAndWords = numbers.Zip(words, (collection, second) => collection + " " + second);
        /// /// numbersAndWords = {"1 one","2 two","3 three"}
        /// </example>
        /// <typeparam name="TFirst">The type of the elements of the collection input sequence.</typeparam>
        /// <typeparam name="TSecond">The type of the elements of the second input sequence.</typeparam>
        /// <typeparam name="TResult">The type of the elements of the result sequence.</typeparam>
        /// <param name="collection">Type: <typeparamref name="System.Collections.Generic.IEnumerable<TFirst>"/>
        /// The collection sequence to merge.</param>
        /// <param name="second">Type: <typeparamref name="System.Collections.Generic.IEnumerable<TSecond>"/>
        /// The second sequence to merge.</param>
        /// <param name="resultSelector">Type: <typeparamref name="System.Func<TFirst, TSecond, TResult>"/>
        /// A function that specifies how to merge the elements from the two sequences.</param>
        /// <returns>Type: <typeparamref name="System.Collections.Generic.IEnumerable<TResult>"/>
        /// An <typeparamref name="IEnumerable<T>"/> that contains merged elements of two input sequences.</returns>
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> resultSelector)
        {
            if (first == null || second == null)
            {
                throw new ArgumentNullException();
            }

            using (var iterFirst = first.GetEnumerator())
            {
                using (var iterSecond = second.GetEnumerator())
                {
                    while (iterFirst.MoveNext() && iterSecond.MoveNext())
                    {
                        yield return resultSelector(iterFirst.Current, iterSecond.Current);
                    }
                }
            }
        }
    }

    public static class XmlHelpers
    {
        /// <summary>
        /// Extension method to convert object to XML representation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="me"></param>
        /// <returns></returns>
        public static string ToXml<T>(this T me)//where T: IXmlSerializable
        {
            using (var writer = new StringWriter())
            {
                me.ToXml(writer);
                return writer.ToString();
            }
        }

        public static void ToXml<T>(this T me, StringWriter writer) //where T : IXmlSerializable
        {
            new XmlSerializer(typeof(T)).Serialize(writer, me);
        }

        public static void ToXml<T>(this T me, Stream stream)// where T : IXmlSerializable
        {
            new XmlSerializer(typeof(T)).Serialize(stream, me);
        }

        public static T fromXmlString<T>(string xml)
        {
            T result = default(T);
            //Stream s = new MemoryStream();
            //s.Write(xml,0,
            //new XmlSerializer(typeof(T)).Deserialize(xml);
            //.Serialize(stream, me);
            return result;
        }
    }
}