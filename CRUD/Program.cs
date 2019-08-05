using System;
using System.Collections;
using System.Collections.Generic;

namespace CRUD
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("a", 1);
#pragma warning disable S109 // Magic numbers should not be used
            dictionary.Add("b", 2);
            dictionary.Add("c", 10);
            dictionary.Add("d", 7);
            dictionary.Remove("b");
#pragma warning restore S109 // Magic numbers should not be used

            foreach (var element in dictionary)
            {
                Console.WriteLine(element.Key + "" + element.Value);
            }
        }
    }
}
