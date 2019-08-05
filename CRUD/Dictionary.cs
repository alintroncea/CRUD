using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
#pragma warning disable CA1715 // Identifiers should have correct prefix
    public class Dictionary<Tkey, TValue> : IDictionary<Tkey, TValue>
#pragma warning restore CA1715 // Identifiers should have correct prefix
    {
        private readonly Element<Tkey, TValue>[] elements;
        private readonly int dictionarySize = 5;
        private readonly int[] buckets;
        private int freeIndex = -1;

        public Dictionary()
        {
            buckets = new int[dictionarySize];
            Array.Fill(buckets, -1);
            elements = new Element<Tkey, TValue>[dictionarySize];
        }

        public ICollection<Tkey> Keys
        {
            get
            {
                Tkey[] tkeys = new Tkey[Count];
                for (int i = 0; i < Count; i++)
                {
                    tkeys[i] = elements[i].Key;
                }

                return tkeys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                TValue[] tvalues = new TValue[Count];
                for (int i = 0; i < Count; i++)
                {
                    tvalues[i] = elements[i].Value;
                }

                return tvalues;
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly => true;

#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
        public TValue this[Tkey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations

        public void Add(Tkey key, TValue value)
        {
            CheckIfKeyIsNull(key);
            if (ContainsKey(key))
            {
                throw new ArgumentException("Key already exists");
            }

            int bucketIndex = GetBucketIndex(key);
            int index = FindFreeIndex();

            Count++;
            elements[index] = new Element<Tkey, TValue>(key, value, buckets[bucketIndex]);
            elements[index].IsRemoved = false;
            buckets[bucketIndex] = index;
        }

        public void Add(KeyValuePair<Tkey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Count = 0;
            Array.Fill(buckets, -1);
        }

        public bool Contains(KeyValuePair<Tkey, TValue> item)
        {
            return ContainsKey(item.Key);
        }

        public bool ContainsKey(Tkey key)
        {
            CheckIfKeyIsNull(key);
            return FindElementByKey(key, out int previous) != -1;
        }

        public void CopyTo(KeyValuePair<Tkey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Tkey key)
        {
            var index = FindElementByKey(key, out int previousElementIndex);
            if (index == -1)
            {
                return false;
            }

            DeleteElement(index, previousElementIndex, GetBucketIndex(key));
            return true;
        }

        public bool Remove(KeyValuePair<Tkey, TValue> item)
        {
            return Remove(item.Key);
        }

        public bool TryGetValue(Tkey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<Tkey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i]?.IsRemoved == false)
                {
                    yield return new KeyValuePair<Tkey, TValue>(elements[i].Key, elements[i].Value);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void CheckIfKeyIsNull(Tkey key)
        {
            if (key != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(key));
        }

        private int GetBucketIndex(Tkey key)
        {
            return Math.Abs(key.GetHashCode() % dictionarySize);
        }

        private void DeleteElement(int index, int previousElementIndex, int bucketIndex)
        {
            var element = elements[index];
            if (index == previousElementIndex)
            {
                buckets[bucketIndex] = element.NextIndex;
            }
            else
            {
                elements[previousElementIndex].NextIndex = element.NextIndex;
            }

            element.Key = default;
            element.Value = default;
            element.NextIndex = freeIndex;
            element.IsRemoved = true;
            freeIndex = index;
            Count--;
        }

        private int FindFreeIndex()
        {
            if (freeIndex == -1)
            {
                return Count;
            }

            var index = freeIndex;
            freeIndex = elements[freeIndex].NextIndex;

            return index;
        }

        private int FindElementByKey(Tkey key, out int previousElementIndex)
        {
            int bucketIndex = GetBucketIndex(key);

            previousElementIndex = buckets[bucketIndex];

            for (int index = buckets[bucketIndex]; index != -1; index = elements[index].NextIndex)
            {
                if (elements[index].Key.Equals(key))
                {
                    return index;
                }

                previousElementIndex = index;
            }

            return -1;
        }
    }
}
