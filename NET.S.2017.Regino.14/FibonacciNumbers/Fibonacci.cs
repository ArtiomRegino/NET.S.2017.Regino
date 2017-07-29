using System;
using System.Collections.Generic;

namespace FibonacciNumbers
{
    public static class Fibonacci
    {
        /// <summary>
        /// Generates Fibonacci sequence.
        /// </summary>
        /// <param name="quantity">Quantity of elemnts in the sequence.</param>
        /// <returns>IEnumerator on the sequence.</returns>
        public static IEnumerator<long> GenerateNumbers(int quantity)
        {
            if (quantity < 1) throw new ArgumentException();

            yield return 1;
            long previous = 0;
            long current = 1;

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
