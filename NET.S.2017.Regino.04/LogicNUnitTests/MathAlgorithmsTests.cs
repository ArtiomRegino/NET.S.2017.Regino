using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Tests
{
    [TestFixture]
    public class MathAlgorithmsTests
    {
        [TestCase(2, 25, 0.000001)]
        [TestCase(23, 2745, 0.000001)]
        [TestCase(27, 0, 0.000001)]
        [TestCase(5, 1, 0.000001)]
        [TestCase(1, 89, 0.000001)]
        [TestCase(1, -10, 0.000001)]
        public void SqrtNewton_PowerAndNumberAreGreaterThanZero_ReturnsPositiveNumbers(int power, double number, double accuracy)
        {
            Assert.IsTrue( Math.Abs(Logic.MathAlgorithms.SqrtNewton(power, number, accuracy) - Math.Pow(number, 1.0/ power)) < accuracy);
        }

        [TestCase(0, 89, 0.000001)]
        [TestCase(2, -10, 0.000001)]
        public void SqrtNewton_ArgumentOutOfRangeException(int power, double number, double accuracy)
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => Logic.MathAlgorithms.SqrtNewton(power, number, accuracy));
        }
    }
}
