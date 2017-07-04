using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Class provides the possibility of using different sorts of sorting.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Quick sort.
        /// </summary>
        /// <param name="array">Initial array.</param>
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Quick sort.
        /// </summary>
        /// <param name="array">Initial array.</param>
        /// <param name="left">Left border of array(from where it will be sorted).</param>
        /// <param name="right">Right border of array.</param>
        public static void QuickSort(int[] array, int left, int right)
        {
            if (array == null)
                throw new ArgumentNullException("This reference = \"null\".");

            if (left < 0 || left > array.Length - 1 || right < 0 || right > array.Length - 1)
                throw new ArgumentOutOfRangeException("The bounds of sorting can't be negative or more than length of the array.");

            int pivot, leftend, rightend;

            leftend = left;
            rightend = right;
            pivot = array[left];

            while (left < right)
            {
                while ((array[right] >= pivot) && (left < right))
                {
                    right--;
                }

                if (left != right)
                {
                    array[left] = array[right];
                    left++;
                }

                while ((array[left] <= pivot) && (left < right))
                {
                    left++;
                }

                if (left != right)
                {
                    array[right] = array[left];
                    right--;
                }
            }

            array[left] = pivot;
            pivot = left;
            left = leftend;
            right = rightend;

            if (left < pivot)
            {
                QuickSort(array, left, pivot - 1);
            }

            if (right > pivot)
            {
                QuickSort(array, pivot + 1, right);
            }
        }

        /// <summary>
        /// Merge sort.
        /// </summary>
        /// <param name="data"> Your's initial array.</param>
        /// <returns>Sorted array.</returns>
        public static void MergeSort(int[] data)
        {
            if (data == null)
                throw new ArgumentNullException("This reference = \"null\".");

            int[] currentArray = Sort(data);
            Array.Copy(currentArray, data, data.Length);
        }

        private static int[] Sort(int[] data)
        {
            if (data.Length == 1)
                return data;
            int middle = data.Length / 2;
            int[] leftArray = data.Take(middle).ToArray();
            int[] rightArray = data.Skip(middle).ToArray();

            return Merge(Sort(leftArray), Sort(rightArray));
        }

        private static int[] Merge(int[] leftArray, int[] rightArray)
        {
            int[] mergedArray = new int[leftArray.Length + rightArray.Length];
            int leftArrayIndex = 0, rightArrayIndex = 0;

            for (int i = 0; i < mergedArray.Length; ++i)
            {


                if (leftArrayIndex < leftArray.Length & rightArrayIndex < rightArray.Length)
                {
                    if (leftArray[leftArrayIndex] > rightArray[rightArrayIndex])
                        mergedArray[i] = rightArray[rightArrayIndex++];
                    else
                        mergedArray[i] = leftArray[leftArrayIndex++];
                }

                else
                {
                    if (rightArrayIndex < rightArray.Length)
                        mergedArray[i] = rightArray[rightArrayIndex++];
                    else
                        mergedArray[i] = leftArray[leftArrayIndex++];
                }
            }
            return mergedArray;
        }

    }
}
