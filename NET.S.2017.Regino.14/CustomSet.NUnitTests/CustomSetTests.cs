using System.Text;
using NUnit.Framework;

namespace CustomSet.NUnitTests
{
    [TestFixture]
    public class CustomSetTests
    {
        [TestCase("one", "two", "three", "four", "five", ExpectedResult = "onetwothreefoursixseveneight")]
        public string PositiveTest_1(params string[] strings)
        {
            CustomSet<string> set = new CustomSet<string>(strings);
            string[] strArr = {"six", "seven", "eight"};
            set.AddRange(strArr);
            set.Remove("five");
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in set)
            {
                stringBuilder.Append(item);
            }

            return stringBuilder.ToString();
        }

        [TestCase("one", "two", "three", "four", "five", ExpectedResult = "onefouronetwothreefourfivetwothreefive")]
        public string PositiveTest_2(params string[] strings)
        {
            CustomSet<string> set1 = new CustomSet<string>(strings);
            var set2 = new CustomSet<string> { "four", "seven", "one", "six" };
            StringBuilder stringBuilder = new StringBuilder();


            CustomSet<string> result = CustomSet<string>.Intersect(set1, set2);
            foreach (var item in result)
            {
                stringBuilder.Append(item);
            }
            result.Clear();

            result.AddRange(CustomSet<string>.Union(set1, set2));

            foreach (var item in result)
            {
                stringBuilder.Append(item);
            }
            result.Clear();
            result.AddRange(CustomSet<string>.Distinction(set1, set2));
            foreach (var item in result)
            {
                stringBuilder.Append(item);
            }

            return stringBuilder.ToString();
        }
    }
}
