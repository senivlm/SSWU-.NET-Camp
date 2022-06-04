using System;
using HW6.Task1;
using HW6.Task2;

namespace HW6
{
    class Program
    {
        static void Main()
        {
            Task1();
        }

        static void Task2()
        {
            TextProcessor.AnalyzeText("Source.txt");
        }

        static void Task1()
        {
            string[] content = FileReader.GetContent("Source.csv");
            Record[] records = RecordsFactory.GetRecords(content);
            Console.WriteLine("A person with the biggest debt: "+RecordsAnalyzer.GetPersonWithBiggestDebt(records));
            int[] nullConsumptionFlats = RecordsAnalyzer.GetNullConsumptionFlats(records);
            if (nullConsumptionFlats.Length==0) Console.WriteLine("There are no flats with null consumption");
            else
            {
                Console.Write("Flats with null consumption: ");
                Console.Write(nullConsumptionFlats[0]);
                for (int i = 1; i < nullConsumptionFlats.Length; i++) Console.Write(", "+nullConsumptionFlats[i]);
                Console.WriteLine();
            }
        }
    }
}