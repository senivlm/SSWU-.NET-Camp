using System;
using System.IO;

namespace HW6.Task1
{
    public static class ReportWriter
    {
        private static string[] Months =
        { "Січень", "Лютий", "Березень", "Квітень", "Травень", "Червень",
            "Липень", "Серпень", "Вересень", "Жовтень", "Листопад", "Грудень"};
        
        public static void WriteSingleReport(int quarter, Record record, double cost)
        {
            string filename = $"{record.Owner}_{quarter}.txt";
            if (!File.Exists(filename)) using (File.Create(filename)) {}
            StreamWriter sw = new StreamWriter(filename, false);
            sw.WriteLine($"Шановний {record.Owner}(кв.{record.Flat}),\nПросимо вас сплатити {Math.Round(RecordsAnalyzer.GetDebt(record) * cost, 3)}грн за спожиту у {quarter} кварталі електроенергію.");
            sw.WriteLine("Початкові показники: "+record.InitialReadings);
            sw.WriteLine(" № | Місяць   | Показники  | Спожита електроенергія (кВт) | Вартість");
            for (int i = 0; i < record.MeterReadings.Length; i++)
                sw.WriteLine(
                    $" {i+1} | {Months[quarter * 3 + i],-8} | {record.MeterReadings[i].Item1,-10} | {Math.Round(double.Parse(record.MeterReadings[i].Item1) - double.Parse(i == 0 ? record.InitialReadings : record.MeterReadings[i - 1].Item1), 3),-28} | {Math.Round((double.Parse(record.MeterReadings[i].Item1) - double.Parse(i == 0 ? record.InitialReadings : record.MeterReadings[i - 1].Item1))*cost, 3)}");
            
        }
        
    }
}