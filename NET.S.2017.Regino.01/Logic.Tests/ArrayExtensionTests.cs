using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logic.Tests
{
    [TestFixture]
    public class ArrayExtensionTests
    {
        [Test]
        public void MergeSort_CheckIfItsCorrectlySorts()
        {
            int[] testArrQSort1 = { 1, -2, 7, 4, 9, 5, -343, -12, 465, 9, 2, 45, -7, 9, -3 };
            int[] testArrQSort2 = { 1, -2, 7, 4, 9, 5, -343, -12, 465, 9, 2, 45, -7, 9, -3 };

            Logic.ArrayExtension.MergeSort(testArrQSort1);
            Array.Sort(testArrQSort2);

            Assert.AreEqual(testArrQSort1, testArrQSort2);
        }

        [Test]
        public void QuickSort_CheckIfItsCorrectlySorts()
        {
            int[] testArrQSort1 = { 1, -2, 7, 4, 9, 5, -343, -12, 465, 9, 2, 45, -7, 9, -3 };
            int[] testArrQSort2 = { 1, -2, 7, 4, 9, 5, -343, -12, 465, 9, 2, 45, -7, 9, -3 };

            Logic.ArrayExtension.QuickSort(testArrQSort1, 0, testArrQSort1.Length - 1);
            Array.Sort(testArrQSort2);

            Assert.AreEqual(testArrQSort1, testArrQSort2);
        }

        [Test]
        public void QuickSort_ThrowsArgumentOutOfRangeException()
        {
            int[] testArrQSort1 = new int[1001];

            Assert.Throws<ArgumentOutOfRangeException>(() => Logic.ArrayExtension.QuickSort(testArrQSort1, -1, testArrQSort1.Length - 1));
        }
    }
}
