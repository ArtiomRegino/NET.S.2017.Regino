using System;
using System.Diagnostics;
using System.Linq;

namespace MathAlgorithms
{
    public static class GCD
    {
        #region EuclidAlgorithm

        /// <summary>
        /// The Euclidean algorithm for computing GCD.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="time">Time for execution.</param>
        /// <returns>Greatest common divisor of numbers.</returns>
        public static long EuclidAlgorithm(long a, long b, out string time) => Gcd(a, b, Euclid, out time);


        /// <summary>
        /// The Euclidean algorithm for computing GCD.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <param name="time">Time for execution.</param>
        /// <returns>Greatest common divisor of numbers.</returns>
        public static long EuclidAlgorithm(long a, long b, long c, out string time) => Gcd(a, b, c, Euclid, out time);


        /// <summary>
        /// The Euclidean algorithm for computing GCD.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <param name="d">Fourth number.</param>
        /// <param name="time">Time for execution.</param>
        /// <returns>Greatest common divisor of numbers.</returns>
        public static long EuclidAlgorithm(long a, long b, long c, long d, out string time) => Gcd(a, b, c, d, Euclid, out time);

        /// <summary>
        /// The Euclidean algorithm for computing GCD.
        /// </summary>
        /// <param name="parameters">Numbers.</param>
        /// <param name="time">Time for execution.</param>
        /// <returns>Greatest common divisor of numbers.</returns>
        public static long EuclidAlgorithm(out string time, params long[] parameters) => Gcd(Euclid, out time, parameters);

        #endregion

        #region SteinAlgorithm

        /// <summary>
        /// The Stein's algorithm for computing GCD.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="time">Time for execution.</param>
        /// <returns>Greatest common divisor of numbers.</returns>
        public static long SteinAlgorithm(long a, long b, out string time) => Gcd(a, b, Stein, out time);

        /// <summary>
        /// The Stein's algorithm for computing GCD.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <param name="time">Time for execution.</param>
        /// <returns>Greatest common divisor of numbers.</returns>
        public static long SteinAlgorithm(long a, long b, long c, out string time) => Gcd(a, b, c, Stein, out time);

        /// <summary>
        /// The Stein's algorithm for computing GCD.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <param name="d">Fourth number.</param>
        /// <param name="time">Time for execution.</param>
        /// <returns>Greatest common divisor of numbers.</returns>
        public static long SteinAlgorithm(long a, long b, long c, long d, out string time) => Gcd(a, b, c, d, Stein, out time);

        /// <summary>
        /// The Stein's algorithm for computing GCD.
        /// </summary>
        /// <param name="time">Time for execution.</param>
        /// <param name="parameters">Numbers.</param>
        /// <returns>Greatest common divisor of numbers.</returns>
        public static long SteinAlgorithm(out string time, params long[] parameters) => Gcd(Stein, out time, parameters);
       
        #endregion

        #region Logic

        private static long Gcd(long a, long b, Func<long, long, long> func, out string time)
        {
            Check(a, b);
            Stopwatch watch = new Stopwatch();

            watch.Start();
            long rezult = func(a, b);
            watch.Stop();
            time = watch.Elapsed.ToString();

            return rezult;
        }

        private static long Gcd(long a, long b, long c, Func<long, long, long> func, out string time)
        {
            Check(a, b, c);
            Stopwatch watch = new Stopwatch();

            watch.Start();
            long rezult = func(func(a, b), c);
            watch.Stop();
            time = watch.Elapsed.ToString();

            return rezult;
        }

        private static long Gcd(long a, long b, long c, long d, Func<long, long, long> func, out string time)
        {
            Check(a, b, c, d);
            Stopwatch watch = new Stopwatch();

            watch.Start();
            long rezult = func(func(func(a, b), c), d);
            watch.Stop();
            time = watch.Elapsed.ToString();

            return rezult;
        }

        private static long Gcd(Func<long, long, long> func, out string time, params long[] parameters) 
        {
            Stopwatch watch = new Stopwatch();
            
            if (parameters == null) throw new ArgumentException($"{nameof(parameters)} can't be null.");
            Check(parameters);

            watch.Start();
            var rezult = parameters.Aggregate(func);
            watch.Stop();

            time = watch.Elapsed.ToString();

            return rezult;
            
        }

        private static long Euclid(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0) return b;
            if (b == 0) return a;

            while (a != b)
                if (a > b)
                    a -= b;
                else
                    b -= a;

            
            return a;
        }

        private static long Stein(long a, long b)
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

        #endregion

        #region Verifications

        private static void Check(params long[] parametors)
        {
            if (parametors.Length < 2)
                throw new ArgumentOutOfRangeException("It can't be less than 2 operands.");

            var count = parametors.LongCount(t => t == 0);

            if(count == parametors.Length)
                throw new ArgumentException("All numbers can't be zero.");
        }

        private static void Check(long a, long b)
        {
            if (a == 0 && b == 0)
                throw new ArgumentException("All numbers can't be zero.");
        } 

        private static void Check(long a, long b, long c)
        {
            if (a == 0 && b == 0 && c == 0)
                throw new ArgumentException("All numbers can't be zero.");
        }

        private static void Check(long a, long b, long c, long d)
        {
            if (a == 0 && b == 0 && c == 0 && d == 0)
                throw new ArgumentException("All numbers can't be zero.");
        }
        #endregion
    }
}
