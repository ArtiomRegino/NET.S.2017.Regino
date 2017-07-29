using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var iteraEnumerator = FibonacciNumbers.Fibonacci.GenerateNumbers(20);

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(iteraEnumerator.Current);
                iteraEnumerator.MoveNext();
            }
            
        }
    }
}
