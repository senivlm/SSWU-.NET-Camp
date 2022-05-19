using System;
using HW2.Task2;

namespace HW2
{
    class Program
    {
        static void Main()
        {
            int[,] matrix = new int[7, 5];
            MatrixFiller.FillMatrix(ref matrix, "v");
            PrintMatrix(matrix, "Vertical snake fill:");
            
            matrix = new int[7, 7];
            MatrixFiller.FillMatrix(ref matrix, "d");
            PrintMatrix(matrix, "Diagonal snake fill:");
            
            matrix = new int[5, 7];
            MatrixFiller.FillMatrix(ref matrix, "s");
            PrintMatrix(matrix, "Spiral snake fill:");
        }

        private static void PrintMatrix(int[,] matr, string title = null)
        {
            if (title is not null) Console.WriteLine(title);
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1) - 1; j++)
                {
                    Console.Write($"{matr[i,j], 3:D0},");
                }
                Console.WriteLine($"{matr[i,matr.GetLength(1)-1], 3:D0}");
            }
            Console.WriteLine();
        }
    }
}