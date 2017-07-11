using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logic.NUnitTests
{
    [TestFixture]
    public class SecondHWNUnitTests
    {

        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(0, 15, 30, 30, ExpectedResult = 0)]
        [TestCase(0, 15, 0, 30, ExpectedResult = 15)]
        [TestCase(int.MaxValue, int.MaxValue, 3, 5, ExpectedResult = 2147483647)]
        [TestCase(15, int.MaxValue, 3, 5, ExpectedResult = 63)]
        [TestCase(15, 15, 1, 3, ExpectedResult = 15)]
        [TestCase(15, 21, 3, 19, ExpectedResult = 23)]
        [TestCase(15, -15, 0, 4, ExpectedResult = 17)]
        [TestCase(15, -48, 1, 15, ExpectedResult = 65489)]
        [TestCase(-8, -15, 30, 4, ExpectedResult = 2147483640)]
        public int InsertBits_PositiveTest(int first, int second, int startPosition, int finishPosition)
        {
            return SecondHW.InsertBits(first, second, startPosition, finishPosition);
        }

        [TestCase(8, 15, -1, 5)]
        [TestCase(8, 15, 5, -1)]
        [TestCase(8, 15, 32, 5)]
        [TestCase(8, 15, 5, 32)]
        public void InsertBits_ThrowsArgumentOutOfRangeException(int first, int second, int startPosition, int finishPosition)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => SecondHW.InsertBits(first, second, startPosition, finishPosition));
        }

        [TestCase(new int[] { 1, 2, 3, 4, 3, 2, 1}, ExpectedResult = 3)]
        [TestCase(new int[] { 1, 100, 50, -51, 1, 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { 16, 2, 23, 4, 44, 2, 89 }, ExpectedResult = 5)]
        public int? FindIndex_PositiveTest(int [] array)
        {
            return SecondHW.FindIndex(array);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 8, 2, 1 }, ExpectedResult = null)]
        [TestCase(new int[] { 1, 120, 50, -51, 5, 1 }, ExpectedResult = null)]
        [TestCase(new int[] { 16, 2, 23, 5, 44, 14, 89 }, ExpectedResult = null)]
        public int? FindIndex_NegativeTest_ExpectedNull(int[] array)
        {
            return SecondHW.FindIndex(array);
        }

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        [TestCase(1204321, ExpectedResult = 1210234)]
        public int NextBiggerNumber_PositiveTest(int number)
        {
            string time; 

            return SecondHW.NextBiggerNumber(number, out time);
        }

        [TestCase(-8)]
        [TestCase(-812312312)]
        public void NextBiggerNumber_ThrowsArgumentException(int number)
        {
            string time;

            Assert.Throws<ArgumentException>(() => SecondHW.NextBiggerNumber(number, out time));
        }

    }
}
