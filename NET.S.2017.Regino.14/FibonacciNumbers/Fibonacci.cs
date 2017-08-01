using System;
using System.Collections.Generic;
using System.Numerics;

namespace FibonacciNumbers
{
    public static class Fibonacci
    {
        /// <summary>
        /// Generates Fibonacci sequence.
        /// </summary>
        /// <param name="quantity">Quantity of elemnts in the sequence.</param>
        /// <returns>Enumerator on the sequence.</returns>
        public static IEnumerable<BigInteger> GenerateNumbers(BigInteger quantity)
        {
            if (quantity < 1) throw new ArgumentException();

            BigInteger previous = 0;
            BigInteger current = 1;

            for (int i = 0; i < quantity - 2; i++)
            {
                var temprorary = previous + current;
                previous = current;
                current = temprorary;

                yield return current;
            }

        }
    }
}
