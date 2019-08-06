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
        private bool isReadOnly;
        private bool isReadOnlyHasBeenModified;

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
                int counter = 0;
                Tkey[] tkeys = new Tkey[Count];
                foreach (var current in this)
                {
                    tkeys[counter++] = current.Key;
                }

                return tkeys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                int counter = 0;
                TValue[] tvalues = new TValue[Count];
                foreach (var current in this)
                {
                    tvalues[counter++] = current.Value;
                }

                return tvalues;
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly
        {
            get => isReadOnly;

            set
            {
                if (isReadOnlyHasBeenModified)
                {
                    throw new NotSupportedException("the list is read only");
                }

                isReadOnly = value;
                isReadOnlyHasBeenModified = true;
            }
        }

        public TValue this[Tkey key]
        {
            get
            {
                CheckIfKeyIsNull(key);
                int index = FindElementByKey(key, out int previous);
                if (index == -1)
                {
                    throw new KeyNotFoundException();
                }

                return elements[index].Value;
            }

            set
            {
                CheckIfKeyIsNull(key);
                CheckForReadOnly();
                int index = FindElementByKey(key, out int previous);

                if (index == -1)
                {
                    throw new KeyNotFoundException();
                }

                elements[index].Value = value;
            }
        }

        public void Add(Tkey key, TValue value)
        {
            CheckForReadOnly();
            CheckIfKeyIsNull(key);
            if (ContainsKey(key))
            {
                throw new ArgumentException("Key already exists");
            }

            int bucketIndex = GetBucketIndex(key);
            int index = FindFreeIndex();

            Count++;
            elements[index] = new Element<Tkey, TValue>(key, value, buckets[bucketIndex]);
            buckets[bucketIndex] = index;
        }

        public void Add(KeyValuePair<Tkey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            CheckForReadOnly();
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
            CheckForReadOnly();
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            int j = arrayIndex;
            foreach (var current in this)
            {
                array.SetValue(current, j);
                j++;
            }
        }

        public bool Remove(Tkey key)
        {
            CheckForReadOnly();
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
            CheckIfKeyIsNull(key);
            int index = FindElementByKey(key, out int previous);
            if (index == -1)
            {
                value = default;
                return false;
            }

            value = elements[index].Value;
            return true;
        }

        public IEnumerator<KeyValuePair<Tkey, TValue>> GetEnumerator()
        {
            int freeCount = 0;
            for (int i = 0; i < Count + freeCount; i++)
            {
                if (!IsFree(i))
                {
                    yield return new KeyValuePair<Tkey, TValue>(elements[i].Key, elements[i].Value);
                }
                else
                {
                    freeCount++;
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

        private bool IsFree(int index)
        {
            for (int i = freeIndex; i != -1; i = elements[i].NextIndex)
            {
                if (i == index)
                {
                    return true;
                }
            }

            return false;
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

        private void CheckForReadOnly()
        {
            if (!IsReadOnly)
            {
                return;
            }

            throw new NotSupportedException("the list is read only");
        }
    }
}
