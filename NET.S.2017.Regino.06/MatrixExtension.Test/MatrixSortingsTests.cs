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
        private int[][] initialMatrix;

        [SetUp]
        public void SetUp()
        {
            initialMatrix = new int[5][] { new int[] { 1 }, new int[] { 1, 2, 3, 4 }, new int[] { 19, 34, 88, 2, 3 }, new int[] { 115, 0, 0, 9 }, new int[] { 8, 34, 71, 13 } };
        }

        [Test]
        public void AscendingMinValues_PositiveTest()
        {
            int[][] transformedMatrix = new int[5][] { new int[] { 115, 0, 0, 9 }, new int[] { 1 }, new int[] { 1, 2, 3, 4 },  new int[] { 19, 34, 88, 2, 3 }, new int[] { 8, 34, 71, 13 }  };

            MatrixExtension.MatrixSortings.AscendingMinValues(initialMatrix);

            Assert.AreEqual(initialMatrix, transformedMatrix);
        }

        [Test]
        public void DescendingMinValues_PositiveTest()
        {
            int[][] transformedMatrix = new int[5][] { new int[] { 8, 34, 71, 13 }, new int[] { 19, 34, 88, 2, 3 }, new int[] { 1, 2, 3, 4 }, new int[] { 1 }, new int[] { 115, 0, 0, 9 } };

            MatrixExtension.MatrixSortings.DescendingMinValues(initialMatrix);

            Assert.AreEqual(initialMatrix, transformedMatrix);
        }

        [Test]
        public void AscendingSums_PositiveTest()
        {
            int[][] transformedMatrix = new int[5][] { new int[] { 1 }, new int[] { 1, 2, 3, 4 }, new int[] { 115, 0, 0, 9 }, new int[] { 8, 34, 71, 13 }, new int[] { 19, 34, 88, 2, 3 } };

            MatrixExtension.MatrixSortings.AscendingSums(initialMatrix);

            Assert.AreEqual(initialMatrix, transformedMatrix);
        }

        [Test]
        public void DescendingSums_PositiveTest()
        {
            int[][] transformedMatrix = new int[5][] { new int[] { 19, 34, 88, 2, 3 }, new int[] { 8, 34, 71, 13 }, new int[] { 115, 0, 0, 9 }, new int[] { 1, 2, 3, 4 }, new int[] { 1 } };

            MatrixExtension.MatrixSortings.DescendingSums(initialMatrix);

            Assert.AreEqual(initialMatrix, transformedMatrix);
        }

        [Test]
        public void AscendingMaxValues_PositiveTest()
        {
            int[][] transformedMatrix = new int[5][] { new int[] { 1 }, new int[] { 1, 2, 3, 4 }, new int[] { 8, 34, 71, 13 }, new int[] { 19, 34, 88, 2, 3 }, new int[] { 115, 0, 0, 9 } };

            MatrixExtension.MatrixSortings.AscendingMaxValues(initialMatrix);

            Assert.AreEqual(initialMatrix, transformedMatrix);

        }

        [Test]
        public void DescendingMaxValues_PositiveTest()
        {
            int[][] transformedMatrix = new int[5][] { new int[] { 115, 0, 0, 9 }, new int[] { 19, 34, 88, 2, 3 }, new int[] { 8, 34, 71, 13 }, new int[] { 1, 2, 3, 4 }, new int[] { 1 } };

            MatrixExtension.MatrixSortings.DescendingMaxValues(initialMatrix);

            Assert.AreEqual(initialMatrix, transformedMatrix);
        }

    }
}
