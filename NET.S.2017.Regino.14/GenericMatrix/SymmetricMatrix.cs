using System;

namespace GenericMatrix
{
    /// <summary>
    /// Class that represents a symmetric matrix.
    /// </summary>
    /// <typeparam name="T">Type of an element.</typeparam>
    class SymmetricMatrix<T>: SquareMatrix<T>
    {
        #region Constructors

        /// <summary>
        /// Constructor based on size of matrix.
        /// </summary>
        /// <param name="size">Size of matrix.</param>
        public SymmetricMatrix(int size)
        {
            Size = size;
            InnerArray = new T[Size * (Size + 1) / 2];
        }

        /// <summary>
        /// Constructor based on array.
        /// </summary>
        /// <param name="matrix">Array to create matrix from.</param>
        public SymmetricMatrix(int size, T[] matrix):this(size)
        {
            for (int i = 0; i < matrix.Length && i < InnerArray.Length; i++)
                InnerArray[i] = matrix[i];
        }

        #endregion

        protected override void SetElement(int i, int j, T value)
        {
            InnerArray[GetIndexInArray(i, j)] = value;
        }

        protected override T GetElement(int i, int j)
        {
            return InnerArray[GetIndexInArray(i, j)];
        }

        private int GetIndexInArray(int i, int j)
        {
            int less = i < j ? i : j;
            int more = i > j ? i : j;
            return more * (more + 1) / 2 + less;
        }
    }
}
