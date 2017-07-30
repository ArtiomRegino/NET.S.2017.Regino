using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSet;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var set1 = new CustomSet<string> {"one", "two", "three", "four", "five"};
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

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
