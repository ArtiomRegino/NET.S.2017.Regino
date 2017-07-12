using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExtension.Test.Comparers
{
    public class AscendingMaxValues : IMatrixComparer
    {
        public int Comparer(int[] lhs, int[] rhs)
        {
            return lhs.Max() > rhs.Max() ? 1 : -1;
        }
    }
}
