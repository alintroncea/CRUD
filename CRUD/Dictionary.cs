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
            Array.Fill(buckets, -1);

            elements = new Element<Tkey, TValue>[dictionarySize];
        }

#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
        public ICollection<Tkey> Keys => throw new NotImplementedException();

        public ICollection<TValue> Values => throw new NotImplementedException();

        public int Count { get; private set; }

        public bool IsReadOnly => throw new NotImplementedException();

        private int FreeIndex { get; set; } = -1;

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
            elements[Count] = new Element<Tkey, TValue>(key, value, buckets[bucketIndex]);
            buckets[bucketIndex] = Count;
            Count++;
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

            for (int index = buckets[GetBucketIndex(key)]; index != -1; index = elements[index].NextIndex)
            {
                if (elements[index].Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
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
            if (!ContainsKey(key))
            {
                return false;
            }

            // calculating the key with GetHashCode
            int bucketValue = buckets[GetBucketIndex(key)];
            var firstBucketElement = elements[bucketValue];

#pragma warning disable RCS1208 // Reduce if nesting.
            if (firstBucketElement.Key.Equals(key))
#pragma warning restore RCS1208 // Reduce if nesting.
            {
                buckets[bucketValue] = firstBucketElement.NextIndex;
                DeleteElement(firstBucketElement);
                firstBucketElement.NextIndex = FreeIndex;
                FreeIndex = bucketValue;
                return true;
            }

            for (int index = buckets[GetBucketIndex(key)]; index != -1; index = elements[index].NextIndex)
            {
                if (elements[index].Key.Equals(key))
                {
                    var elementToBeRemoved = elements[index];
                    DeleteElement(elementToBeRemoved);
                    elementToBeRemoved.NextIndex = FreeIndex;
                    FreeIndex = index;
                    return true;
                }
            }

            return false;
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

        private int GetBucketIndex(Tkey key)
        {
            return Math.Abs(key.GetHashCode() % dictionarySize);
        }

        private void DeleteElement(Element<Tkey, TValue> element)
        {
            element.Key = default;
            element.Value = default;
            element.NextIndex = -1;
        }
    }
}
