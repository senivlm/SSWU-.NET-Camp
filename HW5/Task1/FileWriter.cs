using System.IO;

namespace HW5.Task1
{
    public static class FileWriter
    {// Прошу продемонструвати код на занятті!!!
        public static void ArrayToFile(int[] source, string dest)
        {
            if (!File.Exists(dest)) using (File.Create(dest)) {}
            StreamWriter sw = new StreamWriter(dest, false);
            for (int i = 0; i < source.Length; i++)
            {
                sw.Write(source[i]);
                if (i<source.Length-1) sw.Write(",");
            }

            sw.Close();
        }
        
        public static void MergeFiles(string source1, string source2, string destination)
        {
            FileReader fr1 = new FileReader(source1);
            FileReader fr2 = new FileReader(source2);
            StreamWriter sw = new StreamWriter(destination, false);
            int? i = fr1.Read1Element();
            int? j = fr2.Read1Element();
            
            

            while (!(i is null) && !(j is null))
            {
                if (i <= j)
                {
                    sw.Write(i);
                    i = fr1.Read1Element();
                    if (!(i is null)) sw.Write(",");
                }
                else
                {
                    sw.Write(j);
                    j = fr2.Read1Element();
                    if (!(j is null)) sw.Write(",");
                }
            }

            while (!(i is null))
            {
                sw.Write(","+i);
                i = fr1.Read1Element();
            }

            while (!(j is null))
            {
                sw.Write(","+j);
                j = fr2.Read1Element();
            }
            sw.Close();
            fr1.Dispose();
            fr2.Dispose();
        }
    }
}
