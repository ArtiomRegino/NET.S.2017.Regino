using System;

namespace MatrixExtension
{
    /// <summary>
    /// Contains matrix sorting.
    /// </summary>
    public class MatrixSortingsVersionOne
    {
        /// <summary>
        /// BubbleSort of Matrix.
        /// </summary>
        /// <param name="matrix">Initial matrix.</param>
        /// <param name="comparer">Benchmark.</param>
        public static void BubbleSort(int[][] matrix, IMatrixComparer comparer)
        {
            CheckForNull(matrix);

            for (int i = 0; i < matrix.Length; i++)
                for (int j = 0; j < matrix.Length - 1 - i; j++)
                    if (comparer.Comparer(matrix[j], matrix[j + 1]) == 1)
                        Swap(ref matrix[j], ref matrix[j + 1]);
        }

        public static void BubbleSort(int[][] matrix, Func<int[], int[], int> func)
        {
            if(func == null)
                throw new ArgumentNullException(nameof(func), "Delegate cant be null");

            var adapter = new Adapter(func);

            BubbleSort(matrix, adapter);
        }

        private static void Swap(ref int[] lhs, ref int[] rhs)
        {
            int[] tmpParam = lhs;
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
