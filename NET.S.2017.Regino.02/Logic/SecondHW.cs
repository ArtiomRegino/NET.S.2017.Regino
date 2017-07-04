using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class SecondHW
    {

        /// <summary>
        /// Gets an index n for which the sum of the elements on the left of it is equal to the sum of the elements on the right.
        /// </summary>
        /// <param name="array">Initial array.</param>
        /// <returns>Returns null if there is no correct number and index if it's not so.</returns>
        public static int? FindIndex (int [] array)
        {
            int leftSum = 0;
            int rightSum = 0;
            int length = array.Length;

            if (length > 1000 || length < 0)
                throw new ArgumentOutOfRangeException("The length of the array is out of bounds(0,1000).");

            for (int i = 1; i < length; i++)
            {
                leftSum = 0;
                rightSum = 0;

                for (int j = 0; j < i; j++)
                {
                    leftSum += array[j];
                }

                for (int k = i + 1; k < length; k++)
                {
                    rightSum += array[k];
                }

                if (leftSum == rightSum)
                    return i;
            }

            return null;
        }

        /// <summary>
        /// Takes a positive integer and returns the largest integer consisting of the digits of the original number.
        /// </summary>
        /// <param name="number">Initial number.</param>
        /// <returns>New number or -1 if there is no correct answer.</returns>
        public static int NextBiggerNumber(int number)
        {
            if (number < 0)
                throw new ArgumentException("The number must be positive.");

            int length = 0;
            int currentDigit = number;

            while (currentDigit > 0)
            {
                currentDigit = (currentDigit - currentDigit % 10) / 10;
                length++;
            }

            currentDigit = number;
            int [] digits = new int[length];

            for (int i = 0; i < length; i++)
            {
                digits[i] = currentDigit % 10;
                currentDigit = (currentDigit - digits[i]) / 10;
            }

            //List<int> digits = new List<int>();

            //while (numberCopy > 0)
            //{
            //    digits.Add(numberCopy % 10);
            //    numberCopy = (numberCopy - numberCopy % 10) / 10;
            //}

            currentDigit = -1;

            for (int i = 0; i < length - 1; i++)
            {
                if (digits[i + 1] < digits[i])
                {
                    
                    int minDigit = 9;
                    int indexOfMinDigit = 0;

                    for (int j = 0; j < i + 1; j++)
                    {
                        if (digits[j] < minDigit && digits[j] > digits[i + 1])
                        {
                            minDigit = digits[j];
                            indexOfMinDigit = j;
                        }
                    }
                    Swap(ref digits[i + 1], ref digits[indexOfMinDigit]);

                    for (int j = 1; j < i + 1; j++)
                        for (int k = j; k > 0 && digits[k - 1] < digits[k]; k--)
                            Swap(ref digits[k - 1], ref digits[k]);

                    currentDigit = 0;

                    for (int j = 0; j < length; j++)
                        currentDigit += digits[j] * (int)Math.Pow(10, j);

                    break;
                }
            }
            return currentDigit;
        }

        private static void Swap(ref int firstNumber, ref int secondNumber)
        {
            int tempNumber;
            tempNumber = firstNumber;
            firstNumber = secondNumber;
            secondNumber = tempNumber;
        }

        /// <summary>
        /// Inserts a number of bits of one number into another.
        /// </summary>
        /// <param name="firstNumber">The number in which we insert.</param>
        /// <param name="secondNumber">Second number.</param>
        /// <param name="startPosition">First bound of range of bits.</param>
        /// <param name="finishPosition">Second bound of range of bits.</param>
        /// <returns>New number.</returns>
        public static int InsertBits(int firstNumber, int secondNumber, int startPosition, int finishPosition)
        {
            if (startPosition < 0 || finishPosition < 0 || startPosition > 31 || finishPosition > 31)
                throw new ArgumentOutOfRangeException("Numbers of bits can't be negarive or greater than 31.");

            int number = 0;

            for (int k = startPosition; k <= finishPosition; k++)
            {
                number += (int)Math.Pow(2, k);
            }

            secondNumber = secondNumber & number;

            number = int.MaxValue - number;
            firstNumber = firstNumber & number;

            number = firstNumber | secondNumber;


            return number;
        }
    }
}
