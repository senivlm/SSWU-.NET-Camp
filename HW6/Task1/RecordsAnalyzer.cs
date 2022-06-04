namespace HW6.Task1
{
    public static class RecordsAnalyzer
    {
        public static string GetPersonWithBiggestDebt(Record[] records)
        {
            int biggestDebtIndex = 0;
            double biggestDebt = GetDebt(records[0]);
            for (int i = 1; i < records.Length; i++)
            {
                double debt = GetDebt(records[i]);
                if (debt > biggestDebt)
                {
                    biggestDebtIndex = i;
                    biggestDebt = debt;
                }
            }

            return records[biggestDebtIndex].Owner;
        }

        public static double GetDebt(Record record)
        {
            double initialReadings = double.Parse(record.InitialReadings);
            double lastReadings = double.Parse(record.MeterReadings[^1].Item1);
            return lastReadings - initialReadings;
        }

        public static int[] GetNullConsumptionFlats(Record[] records)
        {
            int[] nullConsumptionFlats = new int[records.Length];
            int ctr = 0;
            foreach (Record r in records)
            {
                if (GetDebt(r) == 0) nullConsumptionFlats[ctr++] = r.Flat;
            }

            return nullConsumptionFlats[..--ctr];
        }
    }
}