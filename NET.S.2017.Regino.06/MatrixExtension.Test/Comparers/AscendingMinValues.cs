using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExtension.Test.Comparers
{
    public class AscendingMinValues : IMatrixComparer
    {
        public int Comparer(int[] lhs, int[] rhs)
        {
            return lhs.Min() > rhs.Min() ? 1 : -1;
        }
    }
}
