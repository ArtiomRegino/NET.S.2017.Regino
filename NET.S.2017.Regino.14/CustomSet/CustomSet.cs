using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomSet
{
    /// <summary>
    /// Custom Set that provides functionality of a Set.
    /// </summary>
    /// <typeparam name="T">The type of objects to fill the Set(reference types with IEquatable).</typeparam>
    public class CustomSet<T>:ISet<T> where T: class
    {
        #region Fields and properties

        /// <summary>
        /// The length of instance.
        /// </summary>
        public int Count => _innerDataList.Count;

        /// <summary>
        /// Gets a value indicating whether the ICollection is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        private List<T> _innerDataList = new List<T>();

        #endregion

        #region Constructors

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

        #endregion

        #region Public methods

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
        /// Clear collection.
        /// </summary>
        public void Clear()
        {
            _innerDataList.Clear();
        }

        /// <summary>
        /// Adds an element to the current set and returns a value to indicate if the element was successfully added.
        /// </summary>
        /// <param name="item">The element to add to the set.</param>
        /// <returns>True if the element is added to the set; false if the element is already in the set.</returns>
        public bool Add(T item)
        {
            if (!Contains(item)) 
                _innerDataList.Add(item);

            return true;
        }

        /// <summary>
        /// Modifies the current set so that it contains all elements that are present in the current set, in the specified collection, or in both.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        public void UnionWith(IEnumerable<T> other)
        {
            _innerDataList = _innerDataList.Union(other).ToList();
        }

        /// <summary>
        /// Modifies the current set so that it contains only elements that are also in a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        public void IntersectWith(IEnumerable<T> other)
        {
            _innerDataList = _innerDataList.Intersect(other).ToList();
        }

        /// <summary>
        /// Removes all elements in the specified collection from the current set.
        /// </summary>
        /// <param name="other">The collection of items to remove from the set.</param>
        public void ExceptWith(IEnumerable<T> other)
        {
            _innerDataList = _innerDataList.Except(other).ToList();
        }

        /// <summary>
        /// Modifies the current set so that it contains only elements that are present either in the current set or in the specified collection, but not both.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            var intersectList = _innerDataList.Intersect(other);
            var unionList = _innerDataList.Union(other);
            _innerDataList = unionList.Except(intersectList).ToList();
        }

        /// <summary>
        /// Determines whether a set is a subset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>True if the current set is a subset of other; otherwise, false.</returns>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            return _innerDataList.All(item => other.Contains(item));
        }

        /// <summary>
        /// Determines whether the current set is a superset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>True if the current set is a superset of other; otherwise, false.</returns>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            return other.All(item => _innerDataList.Contains(item));
        }

        /// <summary>
        /// Determines whether the current set is a proper (strict) subset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>The collection to compare to the current set.</returns>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            return IsSupersetOf(other) && !IsSubsetOf(other);
        }

        /// <summary>
        /// Determines whether the current set is a proper (strict) superset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>True if the current set is a proper superset of other; otherwise, false.</returns>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            return IsSubsetOf(other) && !IsSupersetOf(other);
        }

        /// <summary>
        /// Determines whether the current set overlaps with the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>true if the current set and other share at least one common element; otherwise, false.</returns>
        public bool Overlaps(IEnumerable<T> other) => other.Any(item => Contains(item));

        /// <summary>
        /// Determines whether the current set and the specified collection contain the same elements.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns>true if the current set is equal to other; otherwise, false.</returns>
        public bool SetEquals(IEnumerable<T> other) => other.All(item => Contains(item));

        /// <summary>
        /// Copies the elements of the ICollection to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from ICollection.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {                                                        
            _innerDataList.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the CustomSet.
        /// </summary>
        /// <param name="item">The object to remove from the CustomSet.</param>
        public bool Remove(T item)
        {
            return _innerDataList.Remove(item);
        }

        #endregion

        #region Private methods

        void ICollection<T>.Add(T item)
        {
            Add(item);
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
        
        #endregion
    }
}
