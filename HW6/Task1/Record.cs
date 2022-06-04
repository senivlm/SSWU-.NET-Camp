
using System;
using System.Data.SqlTypes;

namespace HW6.Task1
{
    public class Record : INullable
    {
        public int Flat { get; private set; }
        public string Owner { get; private set; }
        public int Quarter { get; private set; }
        public string InitialReadings;
        public (string, DateTime)[] MeterReadings = new (string, DateTime)[3];

        public Record(int quarter, string sourceLine)
        {
            Quarter = quarter;
            string[] data = sourceLine.Split(',', StringSplitOptions.RemoveEmptyEntries);
            Flat = int.Parse(data[0]);
            Owner = data[1];
            InitialReadings = data[2];
            for (int i = 4; i < data.Length; i += 2)
            {
                if (DateTime.TryParseExact(data[i], "dd.MM.yy", null, System.Globalization.DateTimeStyles.None,
                        out DateTime date))
                {
                    MeterReadings[i / 2 - 2] = (data[i - 1], date);
                }
                else
                {
                    IsNull = true;
                    break;
                }
            }

            if (!IsNull)
            {
                double readings = double.Parse(InitialReadings);
                DateTime readingDate = new DateTime();
                for (int i = 0; i < MeterReadings.Length; i++)
                {
                    double nextReadings = double.Parse(MeterReadings[i].Item1);
                    DateTime nextDate = MeterReadings[i].Item2;
                    if (nextReadings < readings || nextDate < readingDate || nextDate.Month-1/4!=Quarter-1)
                    {
                        IsNull = true;
                        break;
                    }

                    readings = nextReadings;
                    readingDate = nextDate;
                }
            }
        }

        public bool IsNull { get; }
    }
}