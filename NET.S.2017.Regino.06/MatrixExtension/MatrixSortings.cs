using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExtension
{
    public class MatrixSortings
    {
        public static void AscendingMinValues(int[][] matrix)
        {
            CheckForNull(matrix);
            int[] maxNumbers = FindMinValues(matrix);

            BubbleSort(matrix, maxNumbers, false);
        }

        public static void DescendingMinValues(int[][] matrix)
        {
            CheckForNull(matrix);
            int[] maxNumbers = FindMinValues(matrix);

            BubbleSort(matrix, maxNumbers, true);
        }

        public static void AscendingSums(int[][] matrix)
        {
            CheckForNull(matrix);
            int[] sums = FindSumsInRows(matrix);

            BubbleSort(matrix, sums, false);
        }

        public static void DescendingSums(int[][] matrix)
        {
            CheckForNull(matrix);
            int[] sums = FindSumsInRows(matrix);

            BubbleSort(matrix, sums, true);
        }

        public static void AscendingMaxValues(int [][] matrix)
        {
            CheckForNull(matrix);
            int[] maxNumbers = FindMaxValues(matrix);

            BubbleSort(matrix, maxNumbers, false);
        }

        public static void DescendingMaxValues(int[][] matrix)
        {
            CheckForNull(matrix);
            int[] maxNumbers = FindMaxValues(matrix);

            BubbleSort(matrix, maxNumbers, true);
        }

        private static int[] FindMaxValues(int[][] matrix)
        {
            int NumberOfRows = matrix.Length;
            int[] maxNumbers = new int[NumberOfRows];
            int maxValue;

            for (int i = 0; i < NumberOfRows; i++)
            {
                maxValue = matrix[i][0];
                for (int j = 1; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] > maxValue)
                        maxValue = matrix[i][j];
                }
                maxNumbers[i] = maxValue;
            }
            return maxNumbers;
        }

        private static int[] FindMinValues(int[][] matrix)
        {
            int NumberOfRows = matrix.Length;
            int[] minNumbers = new int[NumberOfRows];
            int minValue;

            for (int i = 0; i < NumberOfRows; i++)
            {
                minValue = matrix[i][0];
                for (int j = 1; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] < minValue)
                        minValue = matrix[i][j];
                }
                minNumbers[i] = minValue;
            }
            return minNumbers;
        }

        private static int[] FindSumsInRows(int[][] matrix)
        {
            int NumberOfRows = matrix.Length;
            int[] sums = new int[NumberOfRows];
            int sumInRow;

            for (int i = 0; i < NumberOfRows; i++)
            {
                sumInRow = matrix[i][0];

                for (int j = 1; j < matrix[i].Length; j++)
                    sumInRow += matrix[i][j];

                sums[i] = sumInRow;
            }

            return sums;
        }

        private static void BubbleSort(int[][] matrix, int[] keys, bool kindOfSort)//по возрастанию
        {
            for (int i = 0; i < keys.Length; i++)
            {
                for (int j = 0; j < keys.Length - 1 - i; j++)
                    if (keys[j] > keys[j + 1])
                    {
                        Swap(ref keys[j], ref keys[j + 1]);
                        Swap(ref matrix[j], ref matrix[j + 1]);
                    }
            }

            if (kindOfSort == true)
                Array.Reverse(matrix);
        }

        private static void Swap(ref int[] lhs, ref int[] rhs)
        {
            int[] tmpParam = lhs;
            lhs = rhs;
            rhs = tmpParam;
        }

        private static void Swap(ref int lhs, ref int rhs)
        {
            int tmpParam = lhs;
            lhs = rhs;
            rhs = tmpParam;
        }

        private static void CheckForNull(int[][] matrix)
        {
            if (matrix == null)
                throw new ArgumentException("Matrix is empty.");

            for (int i = 0; i < matrix.Length; i++)
            {
                if(matrix[i] == null)
                    throw new ArgumentException("It can't be empty lines.");
            }
        }
    }
}
