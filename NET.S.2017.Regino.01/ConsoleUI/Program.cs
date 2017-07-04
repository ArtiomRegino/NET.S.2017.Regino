using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //int[] testArrQSort = { 1, -2, 7, 4, 9, 5, -343, -12, 465, 9, 2, 45, -7, 9, -3 };

            //Console.WriteLine("Initial array: ");
            //foreach (var item in testArrQSort)
            //{
            //    Console.WriteLine(item);
            //}

            //Logic.ArrayExtension.QuickSort(testArrQSort, 0, testArrQSort.Length - 1);

            //Console.WriteLine("Sorted array: ");
            //foreach (var item in testArrQSort)
            //{
            //    Console.WriteLine(item);
            //}

            int[] testArrMSort = { 1, -2, 7, 4, 9, 5, -343, -12, 465, 9, 2, 45, -7, 9, -3 };

            Console.WriteLine("Initial array: ");
            foreach (var item in testArrMSort)
            {
                Console.WriteLine(item);
            }

            Logic.ArrayExtension.MergeSort(testArrMSort);

            Console.WriteLine("Sorted array: ");

            foreach (var item in testArrMSort)
            {
                Console.WriteLine(item);
            }
        }
    }
}
