using System.IO;
using System.Text.RegularExpressions;

namespace HW6.Task1
{
    public class FileReader
    {
        public static string[] GetContent(string path)
        {
            if (!IsValid(path)) return null;
            return File.ReadAllLines(path);
        }

        private static bool IsValid(string path)
        {
            StreamReader sr = new StreamReader(path);
            string line = sr.ReadLine();
            if (string.IsNullOrEmpty(line) || !Regex.IsMatch(line, @"\d+,[1-4]")) return false;
            int n = int.Parse(line.Split(',')[0]);
            int ctr = 0;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                ctr++;
                // Покажете, чи вмієте самі створювати регулярні вирази, чи використовуєте готові!
                if (string.IsNullOrEmpty(line) || !Regex.IsMatch(line, @"^\d+,[A-ZА-ЯІЇҐ][a-zа-яіїґ’]+,\d+(?:\.\d{1,3})?(?:,\d+(?:\.\d{1,3})?,\d{2}\.\d{2}\.\d{2}){1,3}$")) return false;
            }
            sr.Close();
            return true;
        }
    }
}
