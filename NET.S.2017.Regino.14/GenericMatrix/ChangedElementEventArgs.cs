using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    public class ChangedElementEventArgs<T>: EventArgs
    {
        public T Previous { get; private set; }
        public T Current { get; private set; }
        public int Row { get; private set; }
        public int Collumn { get; private set; }
        public string Message { get; private set; }

        public ChangedElementEventArgs(T previous, T current, int i, int j, string message)
        {
            Previous = previous;
            Current = current;
            Message = message;
            Row = i;
            Collumn = j;
        }
    }
}
