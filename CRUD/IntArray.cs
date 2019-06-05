using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class IntArray
    {
        int[] array;

        public IntArray()
        {
            array = new int[] { 1, 2, 3, 4 };
        }

        public void Add(int element)
        {          
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = element;        
        }

        public int Count()
        {
            return array.Length;
        }

        public int Element(int index)
        {
            return Array.IndexOf(array, index);
        }

        public void SetElement(int index, int element)
        {
            array[index] = element;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                    return true;
            }
            return false;
        }
        public int IndexOf(int element)
        {
            return Array.IndexOf(array, element);
        }

        public void Insert(int index, int element)
        {
            for (int i = array.Length - 1; i >= index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index - 1] = element;
        }

        public void Clear()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }

        public void Remove(int element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    array[i] = 0;
                    break;
                }

            }
        }

        public void RemoveAt(int index)
        {
            array[index] = 0;
        }

        public int[] GetArray()
        {
            return array;
        }

        public void ReadArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Index :" +i+ " value :" + array[i]);
            }
        }

    }
}
