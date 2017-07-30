using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomSet
{
    /// <summary>
    /// Custom Set that provides functionality of a Set.
    /// </summary>
    /// <typeparam name="T">The type of objects to fill the Set(reference types with IEquatable).</typeparam>
    public class CustomSet<T>:IEnumerable<T> where T: class, IEquatable<T>
    {
        /// <summary>
        /// The length of instance.
        /// </summary>
        public int Count => _innerDataList.Count;

        private readonly List<T> _innerDataList = new List<T>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CustomSet()
        {
        }

        /// <summary>
        /// Constructor that takes IEnumerable as a parameter.
        /// </summary>
        /// <param name="collection">Some collection.</param>
        public CustomSet(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException($"{nameof(collection)} can not be null.");
            AddRange(collection);
        }

        /// <summary>
        /// Adds an element to the set.
        /// </summary>
        /// <param name="item">An element.</param>
        public void Add(T item)
        {
            if(Contains(item)) throw new ArgumentException("The set already contains the element.");
            _innerDataList.Add(item);
        }

        /// <summary>
        /// Adds some elements to the set.
        /// </summary>
        /// <param name="collection">Collection of elements.</param>
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Determines whether an element is in the CustomSet.
        /// </summary>
        /// <param name="item">The object to locate in the CustomSet.</param>
        /// <returns>true if item is found in the CustomSet; otherwise, false.</returns>
        public bool Contains(T item)
        {
            return _innerDataList.Contains(item);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the CustomSet.
        /// </summary>
        /// <param name="item">The object to remove from the CustomSet.</param>
        public void Remove(T item)
        {
            _innerDataList.Remove(item);
        }

        /// <summary>
        /// Clear collection.
        /// </summary>
        public void Clear()
        {
            _innerDataList.Clear();
        }

        /// <summary>
        /// Produces the set intersection of two sequences.
        /// </summary>
        /// <param name="first">An CustomSet whose distinct elements that also appear in second will be returned.</param>
        /// <param name="second">An CustomSet whose distinct elements that also appear in the first sequence will be returned.</param>
        /// <returns>A sequence that contains the elements that form the set intersection of two sequences.</returns>
        public static CustomSet<T> Intersect(CustomSet<T> first, CustomSet<T> second)
        {
            return SetOperation(first, second, (set, item) => second.Contains(item));
        }

        /// <summary>
        /// Produces the set union of two sequences by using the default equality comparer.
        /// </summary>
        /// <param name="first">An CustomSet whose distinct elements form the first set for the union.</param>
        /// <param name="second">An CustomSet whose distinct elements form the second set for the union.</param>
        /// <returns>An CustomSet that contains the elements from both input sequences, excluding duplicates.</returns>
        public static CustomSet<T> Union(CustomSet<T> first, CustomSet<T> second)
        {
            return SetOperation(first, second, (set, item) => true);
        }

        /// <summary>
        /// Produces the set that consists of defference between two sequences by using the default equality comparer.
        /// </summary>
        /// <param name="first">The first CustomSet.</param>
        /// <param name="second">The second CustomSet.</param>
        /// <returns>An CustomSet that contsins defference between two sequences.</returns>
        public static CustomSet<T> Distinction(CustomSet<T> first, CustomSet<T> second)
        {
            return SetOperation(first, second, (set, item) => !second.Contains(item));
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An IEnumerator object that can be used to iterate through the collection</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _innerDataList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private static CustomSet<T> SetOperation(CustomSet<T> first, CustomSet<T> second, Func< CustomSet<T>, T, bool> func)
        {
            if (first == null || second == null) throw new ArgumentNullException($"{nameof(first)} or {nameof(second)} is null.");
            var buferSet = new CustomSet<T>();

            foreach (var item in first)
            {
                if (func(second, item))
                    buferSet.Add(item);
            }

            return buferSet;
        }

        
    }
}
