using System;

namespace MatrixExtension
{
    internal class Adapter: IMatrixComparer
    {
        private readonly Func<int[], int[], int> _compFunc;

        public Adapter(Func<int[], int[], int> compFunc)
        {
            _compFunc = compFunc;
        }

        public int Comparer(int[] lhs, int[] rhs)
        {
            return _compFunc(lhs, rhs);
        }
    }
}
