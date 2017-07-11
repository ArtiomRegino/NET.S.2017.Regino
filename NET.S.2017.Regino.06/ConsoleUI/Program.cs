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
            int[][] m = new int[5][] { new int[] {1}, new int[] {1,2,3,4 }, new int[] {19, 34,88,2,3 }, new int[] {115, 0, 0, 9 }, new int[] { 8, 34, 71, 13} };




            int[][] myArr = new int[4][];
            myArr[0] = new int[4];
            myArr[1] = new int[6];
            myArr[2] = new int[3];
            myArr[3] = new int[2];

            int i = 0;

            Print(m);

            MatrixExtension.MatrixSortings.DescendingMaxValues(m);
            Console.WriteLine();
            Console.WriteLine();

            Print(m);
        }

        public static void Print(int [][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write("{0}\t", matrix[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
