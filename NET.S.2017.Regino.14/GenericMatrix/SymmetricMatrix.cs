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
        public SymmetricMatrix(int size):base(size)
        {}

        /// <summary>
        /// Constructor based on array.
        /// </summary>
        /// <param name="matrix">Array to create matrix from.</param>
        public SymmetricMatrix(T[,] matrix):base(matrix)
        {
            if (!IsSymmetric(matrix)) throw new ArgumentException("Matrix must be symmetric.");
        }

        #endregion

        protected override void SetElement(int i, int j, T value)
        {
            if(i != j)
                throw new InvalidOperationException("Only main diagonal can be changed.");
            _data[i, j] = value;
        }

        protected bool IsSymmetric(T[,] matrix)
        {
            for (int i = 0; i < Size; i++)
                for (int j = i; j < Size; j++)
                    if (!_data[i, j].Equals(_data[j, i])) return false;

            return true;
        }
    }
}
