using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueue
{
    public class Queue<T>
    {

        private T[] _array;
        private int _count;

        public int End { get; set; } = -1;//to work correctly in the beggining
        public int Begin { get; set; }

        public int Count
        {
            get { return _count; }
            private set { _count = value; }
        }

        public Queue()
        {
            _array = new T[10];
        }

        public Queue(int capacity)
        {
            _array = new T[capacity];
        }

        public Queue(IEnumerable<T> collEnumerable)
        {
            foreach (var item in collEnumerable)
            {
                this.Enqueue(item);
            }
        }

        public void Enqueue(T item)
        {

            if (Count < _array.Length)
            {
                if (Begin < End && End == _array.Length - 1)
                {
                    _array[0] = item;
                    End = 0;
                }
                else
                    _array[++End] = item;
                Count++;
            }
            else
            {
                int j = 0;
                T[] tempArray = new T[Count * 2];
                for (int i = Begin; i <= End; i++)
                {
                    if (i == Count)
                        i = 0;
                    tempArray[j] = _array[i];
                    j++;
                }

                Begin = 0;
                End = j;
                tempArray[j] = item;
                Count++;
                _array = tempArray;
            }

        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Empty queue.");

            T item = _array[Begin];
            Count--;
            if (Begin < _array.Length - 1)
                Begin++;
            else Begin = 0;

            return item;
        }
    }
}
