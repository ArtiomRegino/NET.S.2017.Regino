using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomQueue
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        #region Properties And Insdexator

        /// <summary>
        /// Property for getting the length of the queue. 
        /// </summary>
        public int Length => InnerArray.Length;
        
        /// <summary>
        /// Quantity of elements in the queue.
        /// </summary>
        public int Count { get; set; }
        private bool IsEmpty => Count == 0;
        private T[] InnerArray { get; set; }
        private int Tail { get; set; }
        private int Head { get; set; }
        private bool IsFull => InnerArray.Length == Count;
        private T this[int index] => InnerArray[(Head + index) % InnerArray.Length];

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CustomQueue()
        {
            InnerArray = new T[10];
        }

        /// <summary>
        /// Constructor that takes capicity of queue.
        /// </summary>
        /// <param name="capacity"></param>
        public CustomQueue(int capacity)
        {
            InnerArray = new T[capacity];
        }

        /// <summary>
        /// Constructor that takes parametrized IEnumerable as a parameter.
        /// </summary>
        /// <param name="collEnumerable"></param>
        public CustomQueue(IEnumerable<T> collEnumerable)
        {
            InnerArray = new T[collEnumerable.Count()];
            foreach (var item in collEnumerable)
            {
                Enqueue(item);
            }
        }

        #endregion

        /// <summary>
        /// Add a new element to the tail of the queue.
        /// </summary>
        /// <param name="item">Element to add.</param>
        public void Enqueue(T item)
        {
            if (IsFull) Resize();

            InnerArray[Tail] = item;
            Tail = (++Tail) % InnerArray.Length;
            Count++;
        }

        /// <summary>
        /// Remove an element from the head of the queue.
        /// </summary>
        /// <returns>An element.</returns>
        public T Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Empty queue.");

            T item = InnerArray[Head];
            Head = (++Head) % InnerArray.Length;
            Count--;

            return item;
        }

        /// <summary>
        /// Show an element in the head of the queue.
        /// </summary>
        /// <returns>An element.</returns>
        public T Peek()
        {
            if(IsEmpty) throw new InvalidOperationException("Empty queue.");

            return this[0];
        }

        /// <summary>
        /// Clear the queue.
        /// </summary>
        public void Clear()
        {
            InnerArray = new T[InnerArray.Length];
            Tail = 0;
            Head = 0;
        }

        /// <summary>
        /// Method for getting an enumerator for current collection.
        /// </summary>
        /// <returns>Enumerator for current collection.</returns>
        public IEnumerator<T> GetEnumerator() 
        {
            return new CustomIterator(this);
        }

        private void Resize(int resParam = 2)
        {
            T[] bufferArray = new T[Length * resParam];

            for (int i = 0; i < Length; i++)
                bufferArray[i] = this[i];

            InnerArray = bufferArray;
            Head = 0;
            Tail = Count;
        }

        IEnumerator IEnumerable.GetEnumerator() 
        {
            throw new NotImplementedException();
        }

        private struct CustomIterator : IEnumerator<T>
        {
            private readonly CustomQueue<T> _collection;
            private int _currentIndex;

            public CustomIterator(CustomQueue<T> collection)
            {
                _currentIndex = -1;
                _collection = collection;
            }

            public T Current
            {
                get
                {
                    if (_currentIndex == -1 || _currentIndex == _collection.Count)
                        throw new InvalidOperationException();

                    return _collection[_currentIndex];
                }
            }

            object IEnumerator.Current
            {
                get { throw new NotImplementedException(); }
            }

            public void Reset()
            {
                _currentIndex = -1;
            }

            public bool MoveNext()
            {
                return ++_currentIndex < _collection.Count;
            }

            public void Dispose()
            {}
        }
    }
}
