using MatrixExtension.Test.Comparers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExtension.Test
{
    [TestFixture]
    public class MatrixSortingsTests
    {
        private int[][] _initialMatrix;

        [SetUp]
        public void SetUp()
        {
            _initialMatrix = new[] { new [] { 1 }, new [] { 1, 2, 3, 4 }, new [] { 19, 34, 88, 2, 3 }, new [] { 115, 0, 0, 9 }, new [] { 8, 34, 71, 13 } };
        }

        [Test]
        public void BubbleSort_AscendingMinValues_PositiveTest()
        {
            int[][] transformedMatrix = new int[5][] { new int[] { 115, 0, 0, 9 }, new int[] { 1 }, new int[] { 1, 2, 3, 4 }, new int[] { 19, 34, 88, 2, 3 }, new int[] { 8, 34, 71, 13 } };

            MatrixExtension.MatrixSortingsVersionOne.BubbleSort(_initialMatrix, new AscendingMinValues());

            Assert.AreEqual(_initialMatrix, transformedMatrix);
        }

        [Test]
        public void BubbleSort_DescendingMinValues_PositiveTest()
        {
            int[][] transformedMatrix = new int[5][] { new int[] { 8, 34, 71, 13 }, new int[] { 19, 34, 88, 2, 3 }, new int[] { 1 }, new int[] { 1, 2, 3, 4 }, new int[] { 115, 0, 0, 9 } };

            MatrixExtension.MatrixSortingsVersionOne.BubbleSort(_initialMatrix, new DescendingMinValues());

            Assert.AreEqual(_initialMatrix, transformedMatrix);
        }

        [Test]
        public void BubbleSort_AscendingSums_PositiveTest()
        {
            int[][] transformedMatrix = new int[5][] { new int[] { 1 }, new int[] { 1, 2, 3, 4 }, new int[] { 115, 0, 0, 9 }, new int[] { 8, 34, 71, 13 }, new int[] { 19, 34, 88, 2, 3 } };

            MatrixExtension.MatrixSortingsVersionOne.BubbleSort(_initialMatrix, new AscendingSums());

            Assert.AreEqual(_initialMatrix, transformedMatrix);
        }

        [Test]
        public void BubbleSort_DescendingSums_PositiveTest()
        {
            int[][] transformedMatrix = new int[5][] { new int[] { 19, 34, 88, 2, 3 }, new int[] { 8, 34, 71, 13 }, new int[] { 115, 0, 0, 9 }, new int[] { 1, 2, 3, 4 }, new int[] { 1 } };

            MatrixExtension.MatrixSortingsVersionOne.BubbleSort(_initialMatrix, new DescendingSums());

            Assert.AreEqual(_initialMatrix, transformedMatrix);
        }

        [Test]
        public void BubbleSort_AscendingMaxValues_PositiveTest()
        {
            int[][] transformedMatrix = new int[5][] { new int[] { 1 }, new int[] { 1, 2, 3, 4 }, new int[] { 8, 34, 71, 13 }, new int[] { 19, 34, 88, 2, 3 }, new int[] { 115, 0, 0, 9 } };

            MatrixExtension.MatrixSortingsVersionOne.BubbleSort(_initialMatrix, new AscendingMaxValues());

            Assert.AreEqual(_initialMatrix, transformedMatrix);

        }

        [Test]
        public void BubbleSort_DescendingMaxValues_PositiveTest()
        {
            int[][] transformedMatrix = new int[5][] { new int[] { 115, 0, 0, 9 }, new int[] { 19, 34, 88, 2, 3 }, new int[] { 8, 34, 71, 13 }, new int[] { 1, 2, 3, 4 }, new int[] { 1 } };

            MatrixExtension.MatrixSortingsVersionOne.BubbleSort(_initialMatrix, new DescendingMaxValues());

            Assert.AreEqual(_initialMatrix, transformedMatrix);
        }

    }
}
