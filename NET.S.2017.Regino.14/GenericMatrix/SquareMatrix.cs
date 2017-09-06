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
        public int Size { get; protected set; }

        #region Constructors

        protected SquareMatrix()
        {
        }

        /// <summary>
        /// Constructor based on size of matrix.
        /// </summary>
        /// <param name="size">Size of matrix.</param>
        public SquareMatrix(int size)
        {
            Size = size;
            InnerArray = new T[size * size];
        }

        /// <summary>
        /// Constructor based on array.
        /// </summary>
        /// <param name="matrix">Array to create matrix from.</param>
        public SquareMatrix(int size, T[] matrix) : this(size)
        {
            for (int i = 0; i < matrix.Length && i < InnerArray.Length; i++)
                InnerArray[i] = matrix[i];
        }

        #endregion


        protected override T GetElement(int i, int j)
        {
            return InnerArray[Size * i + j];
        }

        protected override void SetElement(int i, int j, T value)
        {
            InnerArray[Size * i + j] = value;
        }

        protected override void CheckIndexes(int i, int j)
        {
            if (i < 0 || i >= Size || j < 0 || j >= Size)
                throw new ArgumentException("Index is out of range!");
        }

    }
}
