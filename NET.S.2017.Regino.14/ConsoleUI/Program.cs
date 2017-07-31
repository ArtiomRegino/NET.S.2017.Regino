using System;
using System.Text;
using CustomSet;
using GenericMatrix;

namespace ConsoleUI
{
    class Program
    {
        static void Main()
        {
            int[][] myArr = new int[2][];
            myArr[0] = new int[2];
            myArr[1] = new int[2];
            int[,] arr = new int[2,2];
            arr[0, 0] = 1;
            arr[0, 1] = 2;
            arr[1, 0] = 1;
            arr[1, 1] = 2;
            SquareMatrix<int> matrix = new SquareMatrix<int>(arr);
            
        }
    }
}
