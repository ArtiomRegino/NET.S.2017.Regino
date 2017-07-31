using System;

namespace GenericMatrix
{
    /// <summary>
    /// Class that represents a square matrix.
    /// </summary>
    /// <typeparam name="T">Type of an element.</typeparam>
    public class SquareMatrix<T>: Matrix<T>
    {
        /// <summary>
        /// Size of matrix.
        /// </summary>
        public int Size { get; private set; }

        #region Constructors

        /// <summary>
        /// Constructor based on size of matrix.
        /// </summary>
        /// <param name="size">Size of matrix.</param>
        public SquareMatrix(int size):base(size, size)
        {
            Size = size;
        }

        /// <summary>
        /// Constructor based on array.
        /// </summary>
        /// <param name="matrix">Array to create matrix from.</param>
        public SquareMatrix(T[,] matrix) 
        {
            if(matrix.Rank != 2) throw new ArgumentException("Matrix must have two dimensions.");
            if(!IsSquare(matrix)) throw new ArgumentException("Matrix must be square.");

            Size = matrix.GetLength(0);
            _data = new T[Size, Size];
            Collumns = Size;
            Rows = Size;

            InitializeMatrix(matrix, Size, Size);
        }

        #endregion

        protected bool IsSquare(T[,] matrix)
        {
            return matrix.GetLength(0) == matrix.GetLength(1);
        }
    }
}
