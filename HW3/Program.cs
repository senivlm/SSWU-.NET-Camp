using System;

namespace HW3
{
    static class Program
    {
        internal static void Main()
        {
            Vector v = new Vector(10);
            v.RandomInitialization(1, 25);
            Console.WriteLine(v);
            QuickSort.Sort(v, 0, v.Length);
            Console.WriteLine(v);
            v.Shuffle();
            Console.WriteLine(v);
            v.Shuffle();
            Console.WriteLine(v);
            v.Shuffle();
            Console.WriteLine(v);
            v.Shuffle();
            Console.WriteLine(v);
            v.Reverse();
            Console.WriteLine(v);
            for(int i = 0; i < 12625; i++) v.Push(i);
            for(int i = 0; i < 12624; i++) v.Pop();
            Console.WriteLine(v);
            v.PopByIndex(0);
            Console.WriteLine(v);
            Console.WriteLine();
            
            Matrix matrix = new Matrix(5, 5);
            matrix.DiagonalSnakeFill(Matrix.Modes.StartRight);
            Console.WriteLine(matrix);
            matrix.DiagonalSnakeFill(Matrix.Modes.StartDown);
            Console.WriteLine(matrix);
        }
    }
}