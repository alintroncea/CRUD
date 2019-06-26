using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
#pragma warning disable CA1710 // Identifiers should have correct suffix
    public class SortedIntArray : ObjectArray
#pragma warning restore CA1710 // Identifiers should have correct suffix
    {
        public SortedIntArray()
        {
        }

        public override void Add(object element)
        {
            base.Add(element);
            SortArray();
        }

        public override void Insert(int index, object element)
        {
            if (Count == 0 || (int)this[index] <= (int)element)
            {
                return;
            }

            base.Insert(index, element);
        }

        private void SortArray()
        {
            for (int i = 0; i < Count; i++)
            {
                for (int j = Count - 1; j > i; j--)
                {
                    if ((int)this[j] < (int)this[j - 1])
                    {
                        var temp = this[j];
                        this[j] = this[j - 1];
                        this[j - 1] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
