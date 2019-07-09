using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class SortedList<T> : List<T>
        where T : IComparable<T>
    {
        public SortedList()
        {
        }

        public override void Add(T element)
        {
            base.Add(element);
            SortList();
        }

        public override void Insert(int index, T element)
        {
            if (Count == 0 || this[index].CompareTo(element) == -1)
            {
                return;
            }

            base.Insert(index, element);
        }

        public void SetValue(int index, T value)
        {
            if (index == 0 && this[index + 1].CompareTo(value) < 0)
            {
                return;
            }

            if (index == Count - 1 && this[index - 1].CompareTo(value) > 0)
            {
                return;
            }
            else if (index != 0 && index != Count - 1 && (this[index - 1].CompareTo(value) > 0 || this[index + 1].CompareTo(value) < 0))
            {
                    return;
            }

            this[index] = value;
        }

        private void SortList()
        {
            bool swaped = true;
            while (swaped)
            {
                swaped = false;
                for (int j = 1; j < Count; j++)
                {
                    if (this[j].CompareTo(this[j - 1]) == -1)
                    {
                        var temp = this[j];
                        this[j] = this[j - 1];
                        this[j - 1] = temp;
                        swaped = true;
                    }
                }
            }
        }
    }
}
