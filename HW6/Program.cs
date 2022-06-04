/*using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;*/
using System;
using System.Net.Mime;
using System.Text.RegularExpressions;
using HW6.Task2;

namespace HW6
{
    class Program
    {
        static void Main(string[] args)
        {
            Task2();
        }

        static void Task2()
        {
            TextProcessor.AnalyzeText("Source.txt");
        }
    }
}