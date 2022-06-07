using System;
using System.IO;
using HW5.Task1;

namespace HW5
{
    class Program
    {//Ваш номер 3.
        static void Main(string[] args)
        {
            Task1();
            Console.WriteLine();
            Task2();
        }

        public static void Task1()
        {
            FileReader fr = new FileReader("source.csv");
            int n = fr.fileElementsCount/2;
            int[] source = fr.ReadArray(n);
            int[] res = MergeSort.Sort(source);
            FileWriter.ArrayToFile(res, "result1.csv");
            
            source = fr.ReadArray(fr.fileElementsCount-n);
            res = MergeSort.Sort(source);
            FileWriter.ArrayToFile(res, "result2.csv");
            
            FileWriter.MergeFiles("result1.csv", "result2.csv", "result.csv");
            //Дуже добре, що подбали про знищення файлів
            File.Delete("result1.csv");
            File.Delete("result2.csv");
            fr.Dispose();
        }

        public static void Task2()
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
