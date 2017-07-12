using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <returns>Greatest common divisor of numbers.</returns>
        public static long EuclidAlgorithm(long a, long b)
        {
            Check(a, b);
            return Euclid(a, b);
        }

        /// <summary>
        /// The Euclidean algorithm for computing GCD.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <returns>Greatest common divisor of numbers.</returns>
        public static long EuclidAlgorithm(long a, long b, long c)
        {
            Check(a, b, c);
            return EuclidAlgorithm(Euclid(a, b), c);
        }

        /// <summary>
        /// The Euclidean algorithm for computing GCD.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <param name="d">Fourth number.</param>
        /// <returns>Greatest common divisor of numbers.</returns>
        public static long EuclidAlgorithm(long a, long b, long c, long d)
        {
            Check(a, b, c, d);
            return Euclid(EuclidAlgorithm(a, b, c), d);
        }

        /// <summary>
        /// The Euclidean algorithm for computing GCD.
        /// </summary>
        /// <param name="parameters">Numbers.</param>
        /// <returns>Greatest common divisor of numbers.</returns>
        public static long EuclidAlgorithm(params long[] parameters)
        {
            Check(parameters);

            for (int i = 0; i < parameters.Length - 1; i++)
            {
                parameters[i + 1] = Euclid(parameters[i], parameters[i + 1]);
            }
            return parameters[parameters.Length - 1];
        }

        #endregion

        #region SteinAlgorithm

        /// <summary>
        /// The Stein's algorithm for computing GCD.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>Greatest common divisor of numbers.</returns>
        public static long SteinAlgorithm(long a, long b)
        {
            Check(a, b);
            return Stein(a, b);
        }

        /// <summary>
        /// The Stein's algorithm for computing GCD.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <returns>Greatest common divisor of numbers.</returns>
        public static long SteinAlgorithm(long a, long b, long c)
        {
            Check(a, b, c);
            return Stein(Stein(a, b), c);
        }

        /// <summary>
        /// The Stein's algorithm for computing GCD.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <param name="c">Third number.</param>
        /// <param name="d">Fourth number.</param>
        /// <returns>Greatest common divisor of numbers.</returns>
        public static long SteinAlgorithm(long a, long b, long c, long d)
        {
            return Stein(SteinAlgorithm(a, b, c), d);
        }

        /// <summary>
        /// The Stein's algorithm for computing GCD.
        /// </summary>
        /// <param name="parameters">Numbers.</param>
        /// <returns>Greatest common divisor of numbers.</returns>
        public static long SteinAlgorithm(params long[] parameters)
        {
            Check(parameters);

            for (int i = 0; i < parameters.Length - 1; i++)
            {
                parameters[i + 1] = Stein(parameters[i], parameters[i + 1]);
            }
            return parameters[parameters.Length - 1];
        }

        #endregion

        #region Logic
        
        private static long Euclid(long a, long b/*, out string time*/)
        {
            //Stopwatch watch = new Stopwatch();
            //watch.Start();

            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0) return b;
            if (b == 0) return a;

            while (a != b)
                if (a > b)
                    a -= b;
                else
                    b -= a;

            //watch.Stop();
            //time = watch.Elapsed.ToString();
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

            long count = 0;

            for (int i = 0; i < parametors.Length; i++)
                if (parametors[i] == 0)
                    count++;

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
