using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAlgorithms.NUnitTests
{
    [TestFixture]
    public class GCDTests
    {
        [TestCase(78, 26, ExpectedResult = 26)]
        [TestCase(-70, 0, ExpectedResult = 70)]
        [TestCase(-2136126, -12351, ExpectedResult = 3)]
        public long EuclidAlgorithm_2args_ComputingCorrectly(long a, long b)
        {
            return MathAlgorithms.GCD.EuclidAlgorithm(a, b);
        }

        [TestCase(0, 0)]
        public void EuclidAlgorithm_2args_ArgumentException(long a, long b)
        {
            Assert.Catch<ArgumentException>(() => MathAlgorithms.GCD.EuclidAlgorithm(a, b));
        }

        [TestCase(78, 26, ExpectedResult = 26)]
        [TestCase(-70, 0, ExpectedResult = 70)]
        [TestCase(-2136126, -12351, ExpectedResult = 3)]
        public long SteinAlgorithm__2args_ComputingCorrectly(long a, long b)
        {
            return MathAlgorithms.GCD.SteinAlgorithm(a, b);
        }

        [TestCase(0, 0)]
        public void SteinAlgorithm__2args_ArgumentException(long a, long b)
        {
            Assert.Catch<ArgumentException>(() => MathAlgorithms.GCD.SteinAlgorithm(a, b));
        }

        [TestCase(12432, 123183243, 522362, ExpectedResult = 1)]
        [TestCase(-70, 21, -49000, ExpectedResult = 7)]
        [TestCase(-2136126, -12351, -24560, ExpectedResult = 1)]
        public long EuclidAlgorithm_3args_ComputingCorrectly(long a, long b, long c)
        {
            return MathAlgorithms.GCD.EuclidAlgorithm(a, b, c);
        }

        [TestCase(0, 0, 0)]
        public void EuclidAlgorithm_3args_ArgumentException(long a, long b, long c)
        {
            Assert.Catch<ArgumentException>(() => MathAlgorithms.GCD.EuclidAlgorithm(a, b, c));
        }

        [TestCase(12432, 123183243, 522362, ExpectedResult = 1)]
        [TestCase(-70, 21, -4900, ExpectedResult = 7)]
        [TestCase(-2136126, -12351, -24560, ExpectedResult = 1)]
        public long SteinAlgorithm__3args_ComputingCorrectly(long a, long b, long c)
        {
            return MathAlgorithms.GCD.SteinAlgorithm(a, b, c);
        }

        [TestCase(0, 0, 0)]
        public void SteinAlgorithm__3args_ArgumentException(long a, long b, long c)
        {
            Assert.Catch<ArgumentException>(() => MathAlgorithms.GCD.SteinAlgorithm(a, b, c));
        }

        [TestCase(12432, 123183243, 522362, 12312, ExpectedResult = 1)]
        [TestCase(-70, 21, -49000, 777, ExpectedResult = 7)]
        [TestCase(-2136126, -12352, -24560, 234234, ExpectedResult = 2)]
        public long EuclidAlgorithm_4args_ComputingCorrectly(long a, long b, long c, long d)
        {
            return MathAlgorithms.GCD.EuclidAlgorithm(a, b, c, d);
        }

        [TestCase(0, 0, 0, 0)]
        public void EuclidAlgorithm_4args_ArgumentException(long a, long b, long c, long d)
        {
            Assert.Catch<ArgumentException>(() => MathAlgorithms.GCD.EuclidAlgorithm(a, b, c, d));
        }

        [TestCase(12432, 123183243, 522362, 12312, ExpectedResult = 1)]
        [TestCase(-70, 21, -49000, 777, ExpectedResult = 7)]
        [TestCase(-2136126, -12352, -24560, 234234, ExpectedResult = 2)]
        public long SteinAlgorithm__4args_ComputingCorrectly(long a, long b, long c, long d)
        {
            return MathAlgorithms.GCD.SteinAlgorithm(a, b, c, d);
        }

        [TestCase(0, 0, 0, 0)]
        public void SteinAlgorithm__4args_ArgumentException(long a, long b, long c, long d)
        {
            Assert.Catch<ArgumentException>(() => MathAlgorithms.GCD.SteinAlgorithm(a, b, c, d));
        }

        [TestCase(12432, 123183243, 522362, 12312, 123312, ExpectedResult = 1)]
        [TestCase(-70, 21, -49000, 777, 28, ExpectedResult = 7)]
        [TestCase(-2136126, -12352, -24560, 234234, 66, ExpectedResult = 2)]
        public long EuclidAlgorithm_nArgs_ComputingCorrectly(long a, long b, long c, long d, long e)
        {
            return MathAlgorithms.GCD.EuclidAlgorithm(a, b, c, d, e);
        }

        [TestCase(0, 0, 0, 0, 0)]
        public void EuclidAlgorithm_nArgs_ArgumentException(long a, long b, long c, long d, long e)
        {
            Assert.Catch<ArgumentException>(() => MathAlgorithms.GCD.EuclidAlgorithm(a, b, c, d, e));
        }

        [TestCase(12432, 123183243, 522362, 12312, 123312, ExpectedResult = 1)]
        [TestCase(-70, 21, -49000, 777, 28, ExpectedResult = 7)]
        [TestCase(-2136126, -12352, -24560, 234234, 66, ExpectedResult = 2)]
        public long SteinAlgorithm__nArgs_ComputingCorrectly(long a, long b, long c, long d, long e)
        {
            return MathAlgorithms.GCD.SteinAlgorithm(a, b, c, d, e);
        }

        [TestCase(0, 0, 0, 0, 0)]
        public void SteinAlgorithm__nArgs_ArgumentException(long a, long b, long c, long d, long e)
        {
            Assert.Catch<ArgumentException>(() => MathAlgorithms.GCD.SteinAlgorithm(a, b, c, d, e));
        }
    }
}
