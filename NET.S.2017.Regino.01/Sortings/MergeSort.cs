using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortings
{
    public static class MergeSort
    {

        /// <summary>
        /// Merge sort.
        /// </summary>
        /// <param name="data"> Your's initial array.</param>
        /// <returns>Sorted array.</returns>
        public static Int32[] Sort(Int32[] data)
        {
            if (data.Length == 1)
                return data;
            Int32 middle = data.Length / 2;
            Int32[] leftArray = data.Take(middle).ToArray();
            Int32[] rightArray = data.Skip(middle).ToArray();

            return Merge(Sort(leftArray), Sort(rightArray));
        }

        static Int32[] Merge(Int32[] leftArray, Int32[] rightArray)
        {
            Int32[] mergedArray = new Int32[leftArray.Length + rightArray.Length];
            Int32 leftArrayIndex = 0, rightArrayIndex = 0;

            for (Int32 i = 0; i < mergedArray.Length; ++i)
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
