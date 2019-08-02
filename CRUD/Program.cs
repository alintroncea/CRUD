using System;
using System.Collections;
using System.Collections.Generic;

namespace CRUD
{
    class Program
    {
        static void Main()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "a");
#pragma warning disable S109 // Magic numbers should not be used
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");
            dictionary.ShowBuckets();
            var elements = dictionary.ShowElements();
            Console.WriteLine("Elements Before removing:");
#pragma warning disable S1192 // String literals should not be duplicated
            Console.WriteLine("Key: " + elements[0].Key + " Value: " + elements[0].Value + " Next index: " + elements[0].NextIndex);
#pragma warning restore S1192 // String literals should not be duplicated
            Console.WriteLine("Key: " + elements[1].Key + " Value: " + elements[1].Value + " Next index: " + elements[1].NextIndex);
            Console.WriteLine("Key: " + elements[2].Key + " Value: " + elements[2].Value + " Next index: " + elements[2].NextIndex);
            Console.WriteLine("Key: " + elements[3].Key + " Value: " + elements[3].Value + " Next index: " + elements[3].NextIndex);
            Console.WriteLine("Key: " + elements[4].Key + " Value: " + elements[4].Value + " Next index: " + elements[4].NextIndex);
            dictionary.Remove(7);
            Console.WriteLine("====================================");
            Console.WriteLine("Elements after removing:");
#pragma warning disable S1192 // String literals should not be duplicated
            Console.WriteLine("Key: " + elements[0].Key + " Value: " + elements[0].Value + " Next index: " + elements[0].NextIndex);
#pragma warning restore S1192 // String literals should not be duplicated
            Console.WriteLine("Key: " + elements[1].Key + " Value: " + elements[1].Value + " Next index: " + elements[1].NextIndex);
            Console.WriteLine("Key: " + elements[2].Key + " Value: " + elements[2].Value + " Next index: " + elements[2].NextIndex);
            Console.WriteLine("Key: " + elements[3].Key + " Value: " + elements[3].Value + " Next index: " + elements[3].NextIndex);
            Console.WriteLine("Key: " + elements[4].Key + " Value: " + elements[4].Value + " Next index: " + elements[4].NextIndex);
            dictionary.Remove(1);
            Console.WriteLine("====================================");
            Console.WriteLine("Elements after removing:");
#pragma warning disable S1192 // String literals should not be duplicated
            Console.WriteLine("Key: " + elements[0].Key + " Value: " + elements[0].Value + " Next index: " + elements[0].NextIndex);
#pragma warning restore S1192 // String literals should not be duplicated
            Console.WriteLine("Key: " + elements[1].Key + " Value: " + elements[1].Value + " Next index: " + elements[1].NextIndex);
            Console.WriteLine("Key: " + elements[2].Key + " Value: " + elements[2].Value + " Next index: " + elements[2].NextIndex);
            Console.WriteLine("Key: " + elements[3].Key + " Value: " + elements[3].Value + " Next index: " + elements[3].NextIndex);
            Console.WriteLine("Key: " + elements[4].Key + " Value: " + elements[4].Value + " Next index: " + elements[4].NextIndex);
            Console.WriteLine("====================================");
#pragma warning restore S109 // Magic numbers should not be used
        }
    }
}
