using System;
using System.Collections.Generic;

namespace HW6.Task1
{
    public class RecordsFactory
    {
        public static Record[] GetRecords(string[] fileContent)
        {
            int quarter = Int32.Parse(fileContent[0].Split(',')[1]);
            Record[] records = new Record[fileContent.Length-1];
            for (int i = 0; i < fileContent.Length - 1; i++)
            {
                records[i] = new Record(quarter, fileContent[i + 1]);
                if (records[i].IsNull) i--;
            } 
            return records;
        }
    }
}