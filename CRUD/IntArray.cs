using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class IntArray
    {
        private const int ArraySize = 4;
        private int counter;
        private int[] array;

        public IntArray()
        {
            counter = 0;
            array = new int[ArraySize];
        }

        public void Add(int element)
            {
            if (counter >= array.Length)
            {
                ResizeArray();
                array[counter] = element;
                counter++;
            }

            array[counter] = element;
            counter++;
        }

        public int Count()
        {
            return array.Length;
        }

        public int Element(int index)
        {
            return array[index];
        }

        public void SetElement(int index, int element)
        {
            array[index] = element;
        }

        public bool Contains(int element)
        {
            return Array.IndexOf(array, element) != -1;
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

        private void ResizeArray()
        {
            int oldLength = array.Length;
            Array.Resize(ref array, array.Length + oldLength);
        }
    }
}