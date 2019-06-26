using System;

namespace CRUD
{
    class Program
    {
        static void Main()
        {
#pragma warning disable RCS1124 // Inline local variable.
            ObjectArray objectArray = new ObjectArray { 1, 2 };
#pragma warning restore RCS1124 // Inline local variable.

            foreach (object obj in objectArray)
            {
                Console.WriteLine(obj);
            }
        }
    }
}
