using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task2.Logic.NUnit.Tests
{
    [TestFixture]
    public class ArrayExtensionTests
    {

        [TestCase(new[] { 1, 3, 5, 6, 8, 99, 123, 3243 }, 3, ExpectedResult = 1)]
        [TestCase(new[] { 1, 3, 5, 6, 8, 99, 123, 3243 }, 8, ExpectedResult = 4)]
        [TestCase(new[] { 1, 3, 5, 6, 8, 99, 123, 3243 }, 99, ExpectedResult = 5)]
        [TestCase(new [] { 1, 3, 5, 6, 8, 99, 123, 3243 }, 32143, ExpectedResult = -1)]
        [TestCase(new[] { 1, 3, 5, 6, 8, 99, 123, 3243 }, 55, ExpectedResult = -1)]
        [TestCase(new int[] { 1 }, int.MaxValue, ExpectedResult = -1)]
        public int BinarySerachIntArrayComparision_PositiveTesting(int[] arr, int element) => ArrayExtension
            .BinarySearch(arr, element, (x, y) => x - y);

        [TestCase(new double[] { 1, 2, 3 }, 2, ExpectedResult = 1)]
        [TestCase(new double[] { 1, 2, 3 }, 1, ExpectedResult = 0)]
        [TestCase(new double[] { 1, 2, 3 }, 3, ExpectedResult = 2)]
        [TestCase(new double[] { }, 2, ExpectedResult = -1)]
        [TestCase(new double[] { 1, 2, 3 }, 4, ExpectedResult = -1)]
        [TestCase(new double[] { 1, 2, 3 }, int.MaxValue, ExpectedResult = -1)]
        public int BinarySerachDoubleArrayComparision_PositiveTesting(double[] arr, int element) =>
            ArrayExtension.BinarySearch(arr, element, (x, y) => (int)(x - y));

        [TestCase(new[] { "a", "b", "c" }, "b", ExpectedResult = 1)]
        [TestCase(new[] { "a", "b", "c" }, "a", ExpectedResult = 0)]
        [TestCase(new[] { "a", "b", "c" }, "c", ExpectedResult = 2)]
        [TestCase(new string[] { }, "b", ExpectedResult = -1)]
        [TestCase(new[] { "a", "b", "c" }, "d", ExpectedResult = -1)]
        [TestCase(new[] { "a", "b", "c" }, "absa", ExpectedResult = -1)]
        public int BinarySerachStringArrayComparision_PositiveTesting(string[] arr, string element) =>
            ArrayExtension.BinarySearch(arr, element,
                (x, y) => String.Compare(x, y, StringComparison.Ordinal));

        [TestCase(new[] { 1, 2, 3 }, 2, ExpectedResult = 1)]
        [TestCase(new[] { 1, 2, 3 }, 1, ExpectedResult = 0)]
        [TestCase(new[] { 1, 2, 3 }, 3, ExpectedResult = 2)]
        [TestCase(new int[] { }, 2, ExpectedResult = -1)]
        [TestCase(new[] { 1, 2, 3 }, 4, ExpectedResult = -1)]
        [TestCase(new[] { 1, 2, 3 }, int.MaxValue, ExpectedResult = -1)]
        public int BinarySerachIntArrayIComparer_PositiveTesting(int[] arr, int element) => arr.BinarySearch(element,
            new Comparing<int>());

        [TestCase(new double[] { 1, 2, 3 }, 2, ExpectedResult = 1)]
        [TestCase(new double[] { 1, 2, 3 }, 1, ExpectedResult = 0)]
        [TestCase(new double[] { 1, 2, 3 }, 3, ExpectedResult = 2)]
        [TestCase(new double[] { }, 2, ExpectedResult = -1)]
        [TestCase(new double[] { 1, 2, 3 }, 4, ExpectedResult = -1)]
        [TestCase(new double[] { 1, 2, 3 }, int.MaxValue, ExpectedResult = -1)]
        public int BinarySerachDoubleArrayIComparer_PositiveTesting(double[] arr, int element) => arr.BinarySearch(
            element, new Comparing<double>());

        [TestCase(new[] { "a", "b", "d" }, "b", ExpectedResult = 1)]
        [TestCase(new[] { "a", "b", "d" }, "a", ExpectedResult = 0)]
        [TestCase(new[] { "a", "b", "d" }, "d", ExpectedResult = 2)]
        [TestCase(new string[] { }, "b", ExpectedResult = -1)]
        [TestCase(new[] { "a", "b", "d" }, "c", ExpectedResult = -1)]
        [TestCase(new[] { "a", "b", "d" }, "absa", ExpectedResult = -1)]
        public int BinarySerachStringArrayIComparer_PositiveTesting(string[] arr, string element) => arr.BinarySearch(
            element, new Comparing<string>());

        [Test]
        public void BinarySerach_Null_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () => ArrayExtension.BinarySearch(null, 1, (x, y) => x - y));
            Assert.Throws<ArgumentNullException>(
                () => ArrayExtension.BinarySearch<double>(null, 1, (x, y) => (int)(x - y)));
            Assert.Throws<ArgumentNullException>(
                () => ArrayExtension.BinarySearch(null, "str",
                    (x, y) => String.Compare(x, y, StringComparison.Ordinal)));
            Assert.Throws<ArgumentNullException>(
                () => ArrayExtension.BinarySearch(null, new ArrayExtensionTests(),
                    (x, y) => y.GetHashCode() - x.GetHashCode()));
        }

        private class Comparing<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y) => x.CompareTo(y);
        }
    }
}
