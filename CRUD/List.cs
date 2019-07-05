using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
#pragma warning disable CA1710 // Identifiers should have correct suffix
    public class List<T> : IEnumerable<T>
#pragma warning restore CA1710 // Identifiers should have correct suffix
    {
        protected const int ArraySize = 5;
        protected const int ResizeLength = 2;
        private int counter;
        private T[] array;

        public List()
        {
            counter = 0;
            array = new T[ArraySize];
        }

        public int Count => counter;

        public virtual T this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual void Add(T element)
        {
            if (counter >= array.Length)
            {
                ResizeArray();
            }

            array[counter] = element;
            counter++;
        }

        public bool Contains(T element) => IndexOf(element) != -1;

        public int IndexOf(T element)
        {
            for (int i = 0; i < counter; i++)
            {
                if (array[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, T element)
        {
            index++;
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

        public void Remove(T element)
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

        protected void ResizeArray()
        {
            Array.Resize(ref array, array.Length * ResizeLength);
        }
    }
}