using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class IntArray
    {
        private const int ArraySize = 4;
        private const int ResizeLength = 2;
        private int counter;
        private int[] array;

        public IntArray()
        {
            this.counter = 0;
            this.array = new int[ArraySize];
        }

        public int Count => counter;

        public int this[int index]
        {
            get => array[index];
            set => array[index] = value;
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
            RemoveAt(IndexOf(element));
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
            Array.Resize(ref array, array.Length * ResizeLength);
        }
    }
}