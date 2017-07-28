using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueue
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        #region Properties And Insdexator

        public T[] InnerArray { get; set; }

        public int Tail { get; set; } = -1; //to work correctly in the beggining
        public int Head { get; set; }

        public int Count { get; set; }

        private T this[int index] => InnerArray[(Head + index) % InnerArray.Length];

        #endregion

        #region Constructors

        public CustomQueue()
        {
            InnerArray = new T[10];
        }

        public CustomQueue(int capacity)
        {
            InnerArray = new T[capacity];
        }

        public CustomQueue(IEnumerable<T> collEnumerable)
        {
            foreach (var item in collEnumerable)
            {
                Enqueue(item);
            }
        }

        #endregion

        public void Enqueue(T item)
        {

            if (Count < InnerArray.Length)
            {
                Tail = (++Tail) % InnerArray.Length;
                InnerArray[Tail] = item;
                Count++;
            }
            else
            {
                int j = 0;
                T[] tempArray = new T[Count * 2];
                for (int i = Head; i <= Tail; i++)
                {
                    if (i == Count)
                        i = 0;
                    tempArray[j] = InnerArray[i];
                    j++;
                }

                Head = 0;
                Tail = j;
                tempArray[j] = item;
                Count++;
                InnerArray = tempArray;
            }

        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Empty queue.");

            T item = InnerArray[Head];
            Count--;
            if (Head < InnerArray.Length - 1)
                Head++;
            else Head = 0;

            return item;
        }

        public void Clear()
        {
            InnerArray = new T[InnerArray.Length];
            Tail = 0;
            Head = 0;
        }

        public IEnumerator<T> GetEnumerator() 
        {
            return new CustomIterator(this);
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
                    {
                        throw new InvalidOperationException();
                    }
                    return _collection[_currentIndex];
                }
            }

            object System.Collections.IEnumerator.Current
            {
                get { throw new NotImplementedException(); }
            }

            public void Reset()
            {
                _currentIndex = -1;
                //throw new NotSupportedException();
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
