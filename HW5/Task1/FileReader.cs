using System;
using System.IO;

namespace HW5.Task1
{
    public class FileReader : IDisposable
    {
        public int fileElementsCount { get; private set; }
        private string filepath;
        private StreamReader sr;
        
        public bool EndOfStream() => sr.Peek() == -1;
        
        public FileReader(string path)
        {
            filepath = path;
            fileElementsCount = CountElements();
            sr = new StreamReader(filepath);
        }

        private int CountElements()
        {
            sr = new StreamReader(filepath);
            int elementCounter = 0;
            while (sr.Peek() == ',') sr.Read();
            int symbol = sr.Read();
            bool hasElement = symbol!=-1;
            while (symbol != -1)
            {
                if (symbol == ',' && hasElement)
                {
                    elementCounter++;
                    hasElement = false;
                }
                else hasElement = true;
                symbol = sr.Read();
            }

            if (hasElement) elementCounter++;
            sr.Close();
            return elementCounter;
        }

        public int? Read1Element()
        {
            string number = "";
            while (sr.Peek() != -1 && sr.Peek() == ',') sr.Read();
            
            int symbol = sr.Read();
            while (symbol != -1 && symbol != ',')
            {
                number += (char) symbol;
                symbol = sr.Read();
                while (number.Length == 0 && symbol == ',') sr.Read();
            }
            if (number.Length > 0) return int.Parse(number);
            return null;
        }

        public int[] ReadArray(int n)
        {
            int[] array = new int[n];
            for (int i = 0; i < n && !EndOfStream(); i++)
            {
                int v = Read1Element().Value;
                array[i] = v;
            }

            return array;
        }

        public void Dispose()
        {
            sr.Close();
            sr?.Dispose();
        }
    }
}