using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortings
{
    public static class QuickSort
    {
        /// <summary>
        /// Quick sort.
        /// </summary>
        /// <param name="array">Initial array.</param>
        /// <param name="left">Left border of array(from where it will be sorted).</param>
        /// <param name="right">Right border of array.</param>
        public static void Sort(int[] array, int left, int right)
        {
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
                Sort(array, left, pivot - 1);
            }

            if (right > pivot)
            {
                Sort(array, pivot + 1, right);
            }
        }
    }
}
