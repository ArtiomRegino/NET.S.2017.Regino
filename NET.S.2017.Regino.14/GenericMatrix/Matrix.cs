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
    public abstract class Matrix<T>
    {

        protected T[] InnerArray { get; set; }

        /// <summary>
        /// EventHandler for event while an element of a matrix was changed.
        /// </summary>
        public event EventHandler<ChangedElementEventArgs<T>> ChangedElement = delegate { };

        #region Constructors

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
                T previous = GetElement(i, j);
                SetElement(i, j, value);
                OnChangedElement(new ChangedElementEventArgs<T>(previous,
                                               value, i, j, "Matrix changed."));
            }
        }

        protected abstract T GetElement(int i, int j);
        protected abstract void SetElement(int i, int j, T value);
        protected abstract  void CheckIndexes(int i, int j);

        protected virtual void OnChangedElement(ChangedElementEventArgs<T> e)
        {
            var temp = ChangedElement;
            temp?.Invoke(this, e);
        }
    }
}
