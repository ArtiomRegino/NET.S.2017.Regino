using System;

namespace GenericMatrix
{
    /// <summary>
    /// Class that represents a diagonal matrix.
    /// </summary>
    /// <typeparam name="T">Type of an element.</typeparam>
    class DiagonalMatrix<T>: Matrix<T>
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
        public DiagonalMatrix(int size)
        {
            Size = size;
            InnerArray = new T[size * size];
        }

        /// <summary>
        /// Constructor based on array.
        /// </summary>
        /// <param name="matrix">Array to create matrix from.</param>
        public DiagonalMatrix(int size, T[] matrix) : this(size)
        {
            for (int i = 0; i < matrix.Length && i < InnerArray.Length; i++)
                InnerArray[i] = matrix[i];
        }

        #endregion

        protected override T GetElement(int i, int j)
        {
            return i == j ? InnerArray[i] : default(T);
        }

        protected override void SetElement(int i, int j, T value)
        {
            if (i != j)
                throw new ArgumentException("Cannot change non diagonal elements!");
            InnerArray[i] = value;
        }

        protected override void CheckIndexes(int i, int j)
        {
            if (i < 0 || i >= Size || j < 0 || j >= Size)
                throw new ArgumentException("Index is out of range!");
        }
    }
}
