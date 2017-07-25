using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Logic
{
    public static class ArrayExtension
    {
        
        public static int? BinarySearch<T>(T[] array, T key)
        {
            if (array.Length == 0)
                return null;

            int left = 0;
            int right = array.Length;
            int mid = 0;

            while (!(left >= right))
            {
                mid = left + (right - left) / 2;

                if (array[mid].Equals(key))
                    return mid;

                if (array[mid] > key)
                    right = mid;
                else
                    left = mid + 1;
            }

            return null;
        }

    }
}
