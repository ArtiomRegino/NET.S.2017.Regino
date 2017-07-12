using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExtension.Test.Comparers
{
    public class AscendingSums : IMatrixComparer
    {
        public int Comparer(int[] lhs, int[] rhs)
        {
            return lhs.Sum() > rhs.Sum() ? 1 : -1;
        }
    }
}
