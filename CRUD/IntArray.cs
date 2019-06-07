using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class IntArray
    {
        public int[] array;

        public IntArray()
        {
            array = new int[0];
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
            if (Array.IndexOf(array, element) != -1)
                return true;
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
            array = new int[0];
        }

        public void Remove(int element)
        {
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    index = i;
                    break;
                }

            }
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            Array.Resize(ref array, array.Length - 1);


        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            Array.Resize(ref array, array.Length - 1);
        }
    }

}

