using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathAlgorithms
{
    public static class GCD
    {

        public static long EuclidAlgorithm(long a, long b)
        {

            return Euclid(a, b);
        }

        public static long EuclidAlgorithm(long a, long b, long c)
        {

            return Euclid(Euclid(a, b), c);
        }

        public static long EuclidAlgorithm(long a, long b, long c, long d)
        {

            return Euclid(EuclidAlgorithm(a, b, c), d);
        }

        public static long SteinAlgorithm(long a, long b)
        {

            return Stein(a, b);
        }

        public static long SteinAlgorithm(long a, long b, long c)
        {

            return Stein(Stein(a, b), c);
        }

        public static long SteinAlgorithm(long a, long b, long c, long d)
        {

            return Euclid(SteinAlgorithm(a, b, c), d);
        }

        public static long Euclid(long a, long b/*, out string time*/)
        {
            //Stopwatch watch = new Stopwatch();
            //watch.Start();

            a = Math.Abs(a);
            b = Math.Abs(b);

            while (a != b)
                if (a > b)
                    a -= b;
                else
                    b -= a;

            //watch.Stop();
            //time = watch.Elapsed.ToString();
            return a;
        }

        public static long Stein(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == b) return a;
            if (a == 0) return b;
            if (b == 0) return a;

            if ((~a & 1) != 0)
                if ((b & 1) != 0)
                    return Stein(a >> 1, b);
                else
                    return Stein(a >> 1, b >> 1) << 1;

            if ((~b & 1) != 0)
                return Stein(a, b >> 1);

            if (a > b)
                return Stein((a - b) >> 1, b);

            return Stein((b - a) >> 1, a);
        }
    }
}
