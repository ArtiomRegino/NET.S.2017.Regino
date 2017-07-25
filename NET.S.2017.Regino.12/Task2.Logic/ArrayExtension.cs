using System;
using System.Collections.Generic;

namespace Task2.Logic
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Binary search.
        /// </summary>
        /// <typeparam name="T">The type of objects to compare.</typeparam>
        /// <param name="array">Array to search in.</param>
        /// <param name="key">Value to find.</param>
        /// <param name="comparison">Defines a method that a type implements to compare two objects.</param>
        /// <returns></returns>
        public static int BinarySearch<T>(T[] array, T key, Comparison<T> comparison)
        {
            if(array == null)
                throw new ArgumentNullException(nameof(array), "Array can't be null.");
            if (array.Length == 0)
                return -1;

            int left = 0;
            int right = array.Length;
            int mid;

            while (!(left >= right))
            {
                mid = left + (right - left) / 2;

                if (array[mid].Equals(key))
                    return mid;

                if (comparison(array[mid], key) > 0)
                    right = mid;
                else
                    left = mid + 1;
            }

            return -1;
        }

        /// <summary>
        /// Binary search.
        /// </summary>
        /// <typeparam name="T">The type of objects to compare.</typeparam>
        /// <param name="array">Array to search in.</param>
        /// <param name="element">Value to find.</param>
        /// <param name="comparer">Defines a method that a type implements to compare two objects.</param>
        /// <returns></returns>
        public static int BinarySearch<T>(this T[] array, T element, IComparer<T> comparer)
        {
            return BinarySearch(array, element, comparer.Compare);
        }

    }
}
