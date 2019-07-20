using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class List<T> : IList<T>
    {
        protected const int ListSize = 5;
        protected const int ResizeLength = 2;
        private bool isReadOnlyHasBeenModified;
        private bool isReadOnly;
        private int counter;
        private T[] classList;

        public List()
        {
            counter = 0;
            classList = new T[ListSize];
        }

        public int Count => counter;

        public bool IsReadOnly
        {
            get => isReadOnly;

            set
                {
                if (isReadOnlyHasBeenModified)
                {
                    throw new UnauthorizedAccessException("the list is read only");
                }

                isReadOnly = value;
                isReadOnlyHasBeenModified = true;
            }
        }

        public virtual T this[int index]
        {
            get
            {
                CheckForOutOfBoundsException(index);

                return classList[index];
            }

            set
            {
                CheckForReadOnly();
                CheckForOutOfBoundsException(index);
                classList[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return classList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual void Add(T item)
        {
            CheckForReadOnly();
            if (counter >= classList.Length)
            {
                ResizeArray();
            }

            classList[counter] = item;
            counter++;
        }

        public bool Contains(T item) => IndexOf(item) != -1;

        public int IndexOf(T item)
        {
            for (int i = 0; i < counter; i++)
            {
                if (classList[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, T item)
        {
            CheckForReadOnly();
            CheckForOutOfBoundsException(index);
            index++;
            ResizeArray();
            for (int i = counter; i >= index; i--)
            {
                classList[i] = classList[i - 1];
            }

            classList[index - 1] = item;
        }

        public void Clear()
        {
            CheckForReadOnly();
            counter = 0;
        }

        public void RemoveAt(int index)
        {
            CheckForReadOnly();
            CheckForOutOfBoundsException(index);
            for (int i = index; i < counter - 1; i++)
            {
                classList[i] = classList[i + 1];
            }

            counter--;
        }

        public bool Remove(T item)
        {
            RemoveAt(IndexOf(item));
            return Contains(item) && IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            CheckForOutOfBoundsException(arrayIndex);

            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), " array is null");
            }

            if (Count > array.Length)
            {
                throw new ArgumentException(array.Length + " number of list elements are greater than array length");
            }

            int j = arrayIndex;
            for (int i = 0; i < array.Length; i++)
            {
                array.SetValue(classList[i], j);
                j++;
            }
        }

        protected void ResizeArray()
        {
            Array.Resize(ref classList, classList.Length * ResizeLength);
        }

        private void CheckForOutOfBoundsException(int index)
        {
            if (index >= 0 && index <= Count)
            {
                return;
            }

            throw new ArgumentOutOfRangeException(index + "this index is out of bounds");
        }

        private void CheckForReadOnly()
            {
            if (!IsReadOnly)
            {
                return;
            }

            throw new UnauthorizedAccessException("the list is read only");
        }
    }
}