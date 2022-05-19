using System;
using System.Collections.Generic;

namespace HW1
{
    internal static class Program
    {
        static void Main()
        {
            Product prod1 = new Product("Apple", 5, 0.075);
            Product prod2 = new Product("Milk", 21.5, 0.95);
            List<Buy> shoppingList = new List<Buy>() { new Buy(prod1, 5), new Buy(prod2, 1)};
            foreach (Buy position in shoppingList)
            {
                Console.WriteLine(Check.GetInfo(position)+"\n");
            }
        }
    }
}