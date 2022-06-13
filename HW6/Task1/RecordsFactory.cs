using System;
using System.Collections.Generic;

namespace HW6.Task1
{
    public class RecordsFactory
    {// На мій погляд краще мати один контент, який перетворює в один запис. Більш мобільно і працює для великих файлів.
        Але технічно добре. 
        public static Record[] GetRecords(string[] fileContent)
        {
            int quarter = Int32.Parse(fileContent[0].Split(',')[1]);
            Record[] records = new Record[fileContent.Length-1];
            int i;
            for (i = 0; i < fileContent.Length - 1; i++)
            {
                records[i] = new Record(quarter, fileContent[i + 1]);
                // Поясніть! Перервати не хотіли цикл?
                if (records[i].IsNull) i--;
            } 
            return records[..(i-1)];
        }
    }
}
