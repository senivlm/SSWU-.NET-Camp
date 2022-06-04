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
            
        }
    }
}