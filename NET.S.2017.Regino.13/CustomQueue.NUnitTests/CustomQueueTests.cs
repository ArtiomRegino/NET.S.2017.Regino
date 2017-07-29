using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CustomQueue.NUnitTests
{
    [TestFixture]
    public class CustomQueueTests
    {
        [TestCase(new [] {12, 34, 56, 2, 564, 78, 1}, ExpectedResult = 747)]
        [TestCase(new[] { 12, 34, 56, 2, 564, 78, 1 }, ExpectedResult = 747)]
        [TestCase(new[] { 12.0, 34, 56, 2, 564.0, 78, 1 }, ExpectedResult = 747)]
        public int PositiveTest_CustomQueueUsesForech_ValueType(int[] array)
        {
            CustomQueue<int> queue = new CustomQueue<int>(array);

            return queue.Sum();
        }

        [TestCase( "one", "two", "three", "four", ExpectedResult = "onetwothreefour")]
        public string PositiveTest_CustomQueueUsesForech_RferenceType(params string[] array)
        {
            CustomQueue<string> queue = new CustomQueue<string>(array);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in queue)
            {
                stringBuilder.Append(item);
            }

            return stringBuilder.ToString();
        }

    }
}
