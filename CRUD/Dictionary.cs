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

        public Dictionary()
        {
            buckets = new int[dictionarySize];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = -1;
            }

            elements = new Element<Tkey, TValue>[dictionarySize];
        }

#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
        public ICollection<Tkey> Keys => throw new NotImplementedException();

        public ICollection<TValue> Values => throw new NotImplementedException();

        public int Count { get; private set; }

        public bool IsReadOnly => throw new NotImplementedException();

        public TValue this[Tkey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
        public void Add(Tkey key, TValue value)
        {
            CheckIfKeyIsNull(key);
            if (ContainsKey(key))
            {
                throw new ArgumentException("Key already exists");
            }

            int bucketIndex = Math.Abs(key.GetHashCode() % dictionarySize);
            if (buckets[bucketIndex] != -1)
            {
                int bucketValue = buckets[bucketIndex];
                var newElement = new Element<Tkey, TValue>(key, value);
                newElement.NextIndex = bucketValue;
                buckets[bucketIndex] = Count;
                elements[Count] = newElement;
                Count++;
            }
            else
            {
                buckets[bucketIndex] = Count;
                elements[Count] = new Element<Tkey, TValue>(key, value);
                Count++;
            }
        }

        public Element<Tkey, TValue>[] ShowElements()
        {
            return elements;
        }

        public void ShowBuckets()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                Console.WriteLine(buckets[i]);
            }
        }

        public void Add(KeyValuePair<Tkey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<Tkey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(Tkey key)
        {
            CheckIfKeyIsNull(key);

            // calculating the key with GetHashCode
            int bucketIndex = Math.Abs(key.GetHashCode() % dictionarySize);
            int bucketValue = buckets[bucketIndex];
            if (bucketValue == -1)
            {
                // if bucket value is -1 from the start return false
                return false;
            }

            var currentElement = elements[bucketValue];
            bool result = currentElement.Key.Equals(key);

            // checking nextIndex values if isnt -1
            while (!currentElement.Key.Equals(-1) && currentElement.NextIndex != -1)
            {
                currentElement = elements[currentElement.NextIndex];
                if (currentElement.Key.Equals(key))
                {
                    result = true;

                    // updating the result if the key is found
                }
            }

            return result;
        }

        public void CopyTo(KeyValuePair<Tkey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<Tkey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Tkey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<Tkey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(Tkey key, out TValue value)
        {
            throw new NotImplementedException();
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
    }
}
