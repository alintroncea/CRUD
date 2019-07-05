using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
#pragma warning disable CA1710 // Identifiers should have correct suffix
    public class SortedIntArray : List<int>
#pragma warning restore CA1710 // Identifiers should have correct suffix
    {
        public SortedIntArray()
        {
        }

        public override void Add(int element)
        {
            base.Add(element);
            SortArray();
        }

        public override void Insert(int index, int element)
        {
            if (Count == 0 || this[index] <= element)
            {
                return;
            }

            base.Insert(index, element);
        }

        public void SetValue(int index, int value)
        {
            if (!IsInOrder(index, value))
            {
                return;
            }

            this[index] = value;
        }

        private bool IsInOrder(int index, int value)
        {
            return TryGetValue(index - 1, int.MinValue) <= value && value <= TryGetValue(index + 1, int.MaxValue);
        }

        private int TryGetValue(int index, int defaultValue)
        {
            return index >= 0 && index < Count ? this[index] : defaultValue;
        }

        private void SortArray()
        {
            bool swaped = true;
            while (swaped)
            {
                swaped = false;
                for (int j = 1; j < Count; j++)
                {
                    if (this[j] < this[j - 1])
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
