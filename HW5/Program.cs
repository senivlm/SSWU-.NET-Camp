using System;

namespace HW5
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector v = new Vector(500);
            Random rand = new Random();
            for (int i = 0; i < 500; i++) v[i]=rand.Next(1000);

            Console.WriteLine(v);
            Console.WriteLine();
            Vector newV = v.Sort();
            Console.WriteLine(newV);
        }
    }
}