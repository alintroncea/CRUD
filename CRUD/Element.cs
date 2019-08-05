using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class Element<TKey, TValue>
    {
        public Element(TKey key, TValue value, int next = -1)
        {
            Key = key;
            Value = value;
            NextIndex = next;
        }

        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public int NextIndex { get; set; }

        public bool IsRemoved { get; set; }
    }
}
