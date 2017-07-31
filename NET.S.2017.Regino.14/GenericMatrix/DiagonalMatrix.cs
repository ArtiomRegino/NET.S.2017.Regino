using System;

namespace GenericMatrix
{
    /// <summary>
    /// Class that represents a diagonal matrix.
    /// </summary>
    /// <typeparam name="T">Type of an element.</typeparam>
    class DiagonalMatrix<T>: SymmetricMatrix<T>
    {
        #region Constructors
        
        /// <summary>
        /// Constructor based on size of matrix.
        /// </summary>
        /// <param name="size">Size of matrix.</param>
        public DiagonalMatrix(int size):base(size)
        {}

        /// <summary>
        /// Constructor based on array.
        /// </summary>
        /// <param name="matrix">Array to create matrix from.</param>
        public DiagonalMatrix(T[,] matrix) : base(matrix)
        {
            if (!IsDiagonal(matrix)) throw new ArgumentException("Matrix must be symmetric.");
        }

        #endregion

        protected override T GetElement(int i, int j)
        {
            return i != j ? default(T) : _data[i, j];
        }

        protected override void SetElement(int i, int j, T value)
        {
            if(i == j)
                _data[i, j] = value;
            else throw new ArgumentException("Only main diagonal can be changed.");
        }

        protected bool IsDiagonal(T[,] data)
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (i != j && !data[i, j].Equals(default(T))) return false;

            return true;
        }
    }
}
