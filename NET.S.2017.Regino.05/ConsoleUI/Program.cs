using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string time;
            Console.WriteLine(Euclid(70, 45, out time));
            Console.WriteLine(time);
            Console.WriteLine(gcd_3(70, 45, out time));
            Console.WriteLine(time);
        }

        public static long Euclid(long a, long b, out string time)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            a = Math.Abs(a);
            b = Math.Abs(b);

            while (a > 0 && b > 0)
                if (a >= b)
                    a %= b;
                else
                    b %= a;
            watch.Stop();
            time = watch.Elapsed.ToString();
            return a | b;
        }

        public static long gcd_3(long a, long b, out string time)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            a = Math.Abs(a);
            b = Math.Abs(b);

            while (a != b)
                if (a > b)
                    a -= b;
                else
                    b -= a;

            watch.Stop();
            time = watch.Elapsed.ToString();
            return a;
        }
    }
}
