using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( MathAlgorithms.SqrtNewton(23, 2745, 0.000001) ); 
        }
    }
}
