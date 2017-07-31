using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    /// <summary>
    /// Class that represents a matrix.
    /// </summary>
    /// <typeparam name="T">Type of an element.</typeparam>
    public class Matrix<T>: IEnumerable<T>
    {
        /// <summary>
        /// Quantity of rows.
        /// </summary>
        public int Rows { get; protected set; }

        /// <summary>
        /// Quantity of collumns.
        /// </summary>
        public int Collumns { get; protected set; }
        protected  T[,] _data;

        /// <summary>
        /// EventHandler for event while an element of a matrix was changed.
        /// </summary>
        public event EventHandler<ChangedElementEventArgs<T>> ChangedElement = delegate { };

        #region Constructors

        /// <summary>
        /// Constructor based on dimensions.
        /// </summary>
        /// <param name="rows">Quantity of rows.</param>
        /// <param name="collumns">Quantity of collumns.</param>
        public Matrix(int rows, int collumns)
        {
            CheckDimensions(rows, collumns);
            _data = new T[rows, collumns];

            Rows = rows;
            Collumns = collumns;
        }

        /// <summary>
        /// Constructor based on array.
        /// </summary>
        /// <param name="matrix">Array to create matrix from.</param>
        /// <param name="rows">Quantity of rows.</param>
        /// <param name="collumns">Quantity of collumns.</param>
        public Matrix(T[,] matrix, int rows, int collumns)
        {
            if(matrix == null) throw new ArgumentNullException($"nameof(matrix) can't be null.");
            CheckDimensions(rows, collumns);

            _data = new T[rows, collumns];

            InitializeMatrix(matrix, rows, collumns);
        }

        protected Matrix()
        {}

        #endregion

        /// <summary>
        /// Indexator for matrix.
        /// </summary>
        /// <param name="i">Current row.</param>
        /// <param name="j">Current collumn.</param>
        /// <returns>Value on this position.</returns>
        public T this[int i, int j]
        {
            get
            {
                CheckIndexes(i, j);
                return GetElement(i, j);
            }
            set
            {
                CheckIndexes(i, j);
                OnChangedElement(new ChangedElementEventArgs<T>(_data[i, j],
                                               value, i, j, "Matrix changed."));
                SetElement(i, j, value);
            }
        }

        /// <summary>
        /// Returns enumerator for matrix.
        /// </summary>
        /// <returns>Enumerator for matrix.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Collumns; j++)
                    yield return _data[i, j];
        }

        /// <summary>
        /// Returns a string that represents the current matrix.
        /// </summary>
        /// <returns>String that represents the current matrix.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Collumns; j++)
                    stringBuilder.Append($"{_data[i, j]} ");

                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }

        protected virtual T GetElement(int i, int j)
        {
            return _data[i, j];
        }

        protected virtual void SetElement(int i, int j, T value)
        {
            _data[i, j] = value;
        }

        protected void CheckIndexes(int i, int j)
        {
            if (i <= 0 || j <= 0 || i >= Rows || j >= Collumns) throw new ArgumentOutOfRangeException("No one index of a matrix can't be 0 or less.");
        }

        protected void CheckDimensions(int i, int j)
        {
            if (i <= 0 || j <= 0) throw new ArgumentOutOfRangeException("No one demission of a matrix can't be 0 or less.");
        }

        protected void InitializeMatrix(T[,] matrix, int rows, int collumns)
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < collumns; j++)
                    _data[i, j] = matrix[i, j];

            Rows = rows;
            Collumns = collumns;
        }

        protected virtual void OnChangedElement(ChangedElementEventArgs<T> e)
        {
            var temp = ChangedElement;
            temp?.Invoke(this, e);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
