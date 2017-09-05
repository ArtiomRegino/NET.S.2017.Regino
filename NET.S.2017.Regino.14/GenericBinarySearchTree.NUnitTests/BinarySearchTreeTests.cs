using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BinarySearchTree;
using static System.String;

namespace GenericBinarySearchTree.NUnitTests
{
    public class BinarySearchTreeTests
    {
        [TestCase(new int[] { 23, 54654, 234, 546, 12, 546, 49 }, ExpectedResult = true)]
        public bool Tree_IntTest(int[] array)
        {
            var tree = new BinarySearchTree<int> { array };
            var treeModulo = new BinarySearchTree<int>(new IntComparer()) { array };
            IntComparer comp = new IntComparer();
            List<int> al = new List<int>(tree);
            for (int i = 1; i < al.Count; i++)
                if (al[i] < al[i - 1]) return false;
            al = new List<int>(treeModulo);
            for (int i = 1; i < al.Count; i++)
                if (comp.Compare(al[i], al[i - 1]) < 0) return false;
            return true;
        }

        [TestCase("14123", "2342565", "34534", "8", "444434", "333333333", "23423", "8712", "45", ExpectedResult = true)]
        public bool Tree_StringTest(params string[] array)
        {
            var tree = new BinarySearchTree<string> { array };
            var treeModulo = new BinarySearchTree<string>(new StringComparer()) { array };
            StringComparer comp = new StringComparer();
            List<string> al = new List<string>(tree);
            for (int i = 1; i < al.Count; i++)
                if (Compare(al[i], al[i - 1], StringComparison.Ordinal) < 0) return false;
            al = new List<string>(treeModulo);
            for (int i = 1; i < al.Count; i++)
                if (comp.Compare(al[i], al[i - 1]) < 0) return false;
            return true;
        }

        [TestCase(new int[] { 91, 82, 73, 64, 55, 46, 169, 67, 46, 97 }, ExpectedResult = true)]
        public bool Tree_PointTest(int[] arrayInt)
        {
            Point[] array = new Point[5];
            for (int i = 0; i < 5; i++)
                array[i] = new Point(arrayInt[2 * i], arrayInt[2 * i + 1]);
            var tree = new BinarySearchTree<Point>(new PointComparer()) { array };
            PointComparer comp = new PointComparer();
            List<Point> al = new List<Point>(tree);
            for (int i = 1; i < al.Count; i++)
                if (comp.Compare(al[i], al[i - 1]) < 0) return false;
            return true;
        }
    }

    public class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y) => x - y;
    }

    public class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y) => x.Length - y.Length;
    }

    public class PointComparer : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            return x.X - y.X;
        }
    }

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
