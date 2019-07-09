using System;
using System.Collections;
using System.Collections.Generic;

namespace CRUD
{
    class Program
    {
        static void Main()
        {
            SortedList<int> sortedList = new SortedList<int>();
#pragma warning disable S109 // Magic numbers should not be used
            sortedList.Add(9);
            sortedList.Add(5);
            sortedList.Add(7);
            sortedList.Add(3);
#pragma warning restore S109 // Magic numbers should not be used

            foreach (int i in sortedList)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("----------------");
#pragma warning disable S109 // Magic numbers should not be used
            sortedList.SetValue(1, 7);
#pragma warning restore S109 // Magic numbers should not be used

            foreach (int i in sortedList)
            {
                Console.WriteLine(i);
            }
        }
    }
}
