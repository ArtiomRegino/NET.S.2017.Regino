using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExtension.Test
{
    [TestFixture]
    class MatrixSortingExceptionsTests
    {
        [Test]
        public void AscendingMinValues_EmptyMatrix_ArgumentException()
        {
            int[][] initialMatrix = null;

            Assert.Catch<ArgumentException>(() => MatrixExtension.MatrixSortings.AscendingMinValues(initialMatrix));
        }

        [Test]
        public void DescendingMinValues_EmptyMatrix_ArgumentException()
        {
            int[][] initialMatrix = null;

            Assert.Catch<ArgumentException>(() => MatrixExtension.MatrixSortings.DescendingMinValues(initialMatrix));
        }

        [Test]
        public void AscendingSums_EmptyMatrix_ArgumentException()
        {
            int[][] initialMatrix = null;

            Assert.Catch<ArgumentException>(() => MatrixExtension.MatrixSortings.AscendingSums(initialMatrix));
        }

        [Test]
        public void DescendingSums_EmptyMatrix_ArgumentException()
        {
            int[][] initialMatrix = null;

            Assert.Catch<ArgumentException>(() => MatrixExtension.MatrixSortings.DescendingSums(initialMatrix));
        }

        [Test]
        public void AscendingMaxValues_EmptyMatrix_ArgumentException()
        {
            int[][] initialMatrix = null;

            Assert.Catch<ArgumentException>(() => MatrixExtension.MatrixSortings.AscendingMaxValues(initialMatrix));

        }

        [Test]
        public void DescendingMaxValues_EmptyMatrix_ArgumentException()
        {
            int[][] initialMatrix = null;

            Assert.Catch<ArgumentException>(() => MatrixExtension.MatrixSortings.DescendingMaxValues(initialMatrix));
        }

        [Test]
        public void AscendingMinValues_EmptyRow_ArgumentException()
        {
            int[][] initialMatrix = CreateMatrix();

            Assert.Catch<ArgumentException>(() => MatrixExtension.MatrixSortings.AscendingMinValues(initialMatrix));
        }

        [Test]
        public void DescendingMinValues_EmptyRow_ArgumentException()
        {
            int[][] initialMatrix = CreateMatrix();

            Assert.Catch<ArgumentException>(() => MatrixExtension.MatrixSortings.DescendingMinValues(initialMatrix));
        }

        [Test]
        public void AscendingSums_EmptyRow_ArgumentException()
        {
            int[][] initialMatrix = CreateMatrix();

            Assert.Catch<ArgumentException>(() => MatrixExtension.MatrixSortings.AscendingSums(initialMatrix));
        }

        [Test]
        public void DescendingSums_EmptyRow_ArgumentException()
        {
            int[][] initialMatrix = CreateMatrix();

            Assert.Catch<ArgumentException>(() => MatrixExtension.MatrixSortings.DescendingSums(initialMatrix));
        }

        [Test]
        public void AscendingMaxValues_EmptyRow_ArgumentException()
        {
            int[][] initialMatrix = CreateMatrix();

            Assert.Catch<ArgumentException>(() => MatrixExtension.MatrixSortings.AscendingMaxValues(initialMatrix));

        }

        [Test]
        public void DescendingMaxValues_EmptyRow_ArgumentException()
        {
            int[][] initialMatrix = CreateMatrix();

            Assert.Catch<ArgumentException>(() => MatrixExtension.MatrixSortings.DescendingMaxValues(initialMatrix));
        }

        private int[][] CreateMatrix()
        {
            int[][] initialMatrix = new int[4][];
            initialMatrix[0] = new int[4];
            initialMatrix[1] = new int[6];
            initialMatrix[3] = new int[2];

            return initialMatrix;
        }
    }
}
