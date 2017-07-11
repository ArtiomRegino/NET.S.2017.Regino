using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Provides mathematical functions.
    /// </summary>
    public static class MathAlgorithms
    {

        /// <summary>
        /// Returns the root of specified number.
        /// </summary>
        /// <param name="power">Power of root.</param>
        /// <param name="number">The number whose root is to be found.</param>
        /// <param name="accuracy">Precision.</param>
        /// <returns>Returns the root of specified number.</returns>
        public static double SqrtNewton(int power, double number, double accuracy = 0.00001)
        {
            if (power <= 0 || (number < 0 && power % 2 == 0))
                throw new ArgumentOutOfRangeException();

            if (power == 1 || number == 0)
                return number;

            double xPrevious, xCurrent = number / power;
            //double accuracy = Double.Parse(ConfigurationManager.AppSettings["accuracy"]);

            do
            {
                xPrevious = xCurrent;
                xCurrent = (1.0 / power) * ((power - 1) * xPrevious + number / Math.Pow(xPrevious, power - 1));
            } while (Math.Abs(xCurrent - xPrevious) > accuracy);

            return xCurrent;
        }

    }
}
