using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class Element<TKey, TValue>
    {
        public Element(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public int NextIndex { get; set; } = -1;
    }
}
