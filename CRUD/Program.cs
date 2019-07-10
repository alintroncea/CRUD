using System;
using System.Collections;
using System.Collections.Generic;

namespace CRUD
{
    class Program
    {
        static void Main()
        {
            List<int> newList = new List<int>();
#pragma warning disable S109 // Magic numbers should not be used
            newList.Add(2);
#pragma warning restore S109 // Magic numbers should not be used
            newList.Add(1);

            foreach (int i in newList)
{
                Console.WriteLine(i);
            }

            int[] array = new int[newList.Count];

#pragma warning disable S109 // Magic numbers should not be used
            newList.CopyTo(array, 0);
#pragma warning restore S109 // Magic numbers should not be used

            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
        }
    }
}
