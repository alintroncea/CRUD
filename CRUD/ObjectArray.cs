using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
#pragma warning disable CA1710 // Identifiers should have correct suffix
    public class ObjectArray : IEnumerable
#pragma warning restore CA1710 // Identifiers should have correct suffix
    {
        protected const int ArraySize = 5;
        protected const int ResizeLength = 2;
        private int counter;
        private object[] array;

        public ObjectArray()
        {
            counter = 0;
            array = new object[ArraySize];
        }

        public int Count => counter;

        public object this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return array.GetEnumerator();
        }

        public ObjectEnumerator GetEnumerator()
        {
            return new ObjectEnumerator(array);
        }

        public virtual void Add(object element)
        {
            if (counter >= array.Length)
            {
                ResizeArray();
            }

            array[counter] = element;
            counter++;
        }

        public bool Contains(object element) => IndexOf(element) != -1;

        public int IndexOf(object element)
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

        public virtual void Insert(int index, object element)
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

        public void Remove(object element)
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

        public class ObjectEnumerator : IEnumerator
        {
            private readonly object[] objArray;

            private int position = -1;

            public ObjectEnumerator(object[] array)
            {
                objArray = array;
            }

            public object Current
            {
                get
                {
                    return objArray[position];
                }
            }

            public bool MoveNext()
            {
                position++;
                return position < objArray.Length;
            }

            public void Reset()
            {
                position = -1;
            }
        }
    }
}