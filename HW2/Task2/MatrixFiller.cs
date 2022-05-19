using System;

namespace HW2.Task2
{
    public static class MatrixFiller
    {
        public static void FillMatrix(ref int[,] matrix, string mode)
        {
            switch (mode)
            {
                case "v":
                    VerticalSnakeFill(ref matrix);
                    return;
                case "d":
                    if (matrix.GetLength(0) == matrix.GetLength(1)) DiagonalSnakeFill(ref matrix);
                    else Console.WriteLine("Diagonal snake fill mode can't be used with non-square matrix!");
                    return;
                case "s":
                    SpiralSnakeFill(ref matrix);
                    return;
                default:
                    Console.WriteLine("Incorrect mode!");
                    break;
            }
        }

        private static void VerticalSnakeFill(ref int[,] matrix)
        {
            int counter = 1;
            int subtractor = matrix.GetLength(0)-1;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    matrix[(int)(j%2*subtractor+i*Math.Pow(-1, j)), j] = counter;
                    counter++;
                }
            }
        }
        
        private static void DiagonalSnakeFill(ref int[,] matrix)
        {
            
        }
        
        private static void SpiralSnakeFill(ref int[,] matrix)
        {
            
        }
    }
}