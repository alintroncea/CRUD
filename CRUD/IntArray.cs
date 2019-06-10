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
            this.counter = 0;
            this.array = new int[ArraySize];
        }

        public void Add(int element)
        {
            if (counter >= array.Length)
            {
                ResizeArray();
            }

            array[counter] = element;
            counter++;
        }

        public int Count() => counter;

        public int Element(int index) => array[index];

        public void SetElement(int index, int element) => array[index] = element;

        public bool Contains(int element) => IndexOf(element) != -1;

        public int IndexOf(int element)
        {
            for (int i = 0; i < counter; i++)
            {
                if (array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            ResizeArray();
            for (int i = counter; i >= index; i--)
            {
                array[i] = array[i - 1];
            }

            array[index - 1] = element;
        }

        public void Clear()
        {
            counter = 0;
        }

        public void Remove(int element)
        {
            int index = IndexOf(element);

            RemoveAt(index);

            counter--;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < counter - 1; i++)
            {
                array[i] = array[i + 1];
            }

            counter--;
        }

        private void ResizeArray()
        {
            int oldLength = array.Length;
            Array.Resize(ref array, array.Length + oldLength);
        }
    }
}