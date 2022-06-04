using System;
using System.IO;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace HW6.Task2
{
    public static class TextProcessor
    {
        public static void AnalyzeText(string path)
        {
            StreamReader sr = new StreamReader(path);
            StreamWriter sw = new StreamWriter("Result.txt", false);
            string source = "";
            while (!sr.EndOfStream)
            {
                source += sr.ReadLine();
                string[] sentences = source.Split('.', StringSplitOptions.None);
                for (int i = 0; i < sentences.Length - 1; i++)
                {
                    string correctedSentence = Regex.Replace(sentences[i], " +", " ");
                    sw.WriteLine(correctedSentence.Trim()+".");
                    var matches = Regex.Matches(correctedSentence, "([A-Za-zА-Яа-яіїґІЇҐ’]+)");
                    string[] words = new string[matches.Count];
                    for (int j = 0; j < matches.Count; j++)
                    {
                        words[j] = matches[j].Groups[1].Value;
                    }

                    if (words.Length == 0) continue;
                    Console.WriteLine($"The shortest: {GetShortest(words)}, the longest: {GetLongest(words)}");
                }

                source = sentences[^1];
            }

            string lastSentence = Regex.Replace(source, " *", " ");
            sw.WriteLine(lastSentence);
            var _matches = Regex.Matches(lastSentence, "(A-Za-zА-Яа-я)");
            string[] _words = new string[_matches.Count];
            for (int j = 0; j < _matches.Count; j++)
            {
                _words[j] = _matches[j].Groups[1].Value;
            }

            if (_words.Length > 0)
            {
                Console.WriteLine($"The shortest: {GetShortest(_words)}, the longest: {GetLongest(_words)}");
            }
            sw.Close();
            sr.Close();
        }

        private static string GetShortest(string[] words)
        {
            if (words is null || words.Length == 0) return null;
            int shortestIndex = 0;
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i].Length < words[shortestIndex].Length)
                {
                    shortestIndex = i;
                }
            }
            return words[shortestIndex];
        }
        
        private static string GetLongest(string[] words)
        {
            if (words is null || words.Length == 0) return null;
            int longestIndex = 0;
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i].Length > words[longestIndex].Length)
                {
                    longestIndex = i;
                }
            }
            return words[longestIndex];
        }
    }
}