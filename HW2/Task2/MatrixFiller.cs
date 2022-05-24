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
                    /*if (matrix.GetLength(0) == matrix.GetLength(1)) */DiagonalSnakeFill(ref matrix);/*
                    else Console.WriteLine("Diagonal snake fill mode can't be used with non-square matrix!");*/
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


        private static bool CheckCollision(ref int comparedIndex, int boundary, ref int anotherIndex, ref int cDelta,
            ref int aDelta)
        {
            if (comparedIndex + cDelta != boundary) return false;
            anotherIndex++;
            cDelta *= -1;
            aDelta *= -1;
            return true;
        }
        private static void DiagonalSnakeFill(ref int[,] matrix)
        {
            int counter = 1;
            int columnSize = matrix.GetLength(0);
            int rowSize = matrix.GetLength(1);
            int deltaI = -1, deltaJ = 1;
            int i = 0, j = 0;
            while (counter <= matrix.Length)
            {
                matrix[i, j] = counter++;
                if (!(CheckCollision(ref i, columnSize, ref j, ref deltaI, ref deltaJ) ||
                      CheckCollision(ref j, rowSize, ref i, ref deltaJ, ref deltaI) ||
                      CheckCollision(ref i, -1, ref j, ref deltaI, ref deltaJ) ||
                      CheckCollision(ref j, -1, ref i, ref deltaJ, ref deltaI)))
                {
                    i += deltaI;
                    j += deltaJ;
                }
            }
        }
        
        private static void SpiralSnakeFill(ref int[,] matrix)
        {
            int cellCounter = 1;
            int turnCounter = 0;
            int[] coordinates = {-1, 0};
            while (cellCounter <= matrix.Length)
            {
                for (int ctr = 0; ctr < matrix.GetLength(turnCounter % 2) - (turnCounter + 1) / 2; ctr++)
                {
                    coordinates[turnCounter % 2] += (int) Math.Pow(-1, turnCounter / 2 % 2);
                    matrix[coordinates[0], coordinates[1]] = cellCounter;
                    cellCounter++;
                }
                turnCounter++;
            }
        }
    }
}