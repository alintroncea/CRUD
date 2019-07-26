using System;
using System.Collections;
using System.Collections.Generic;

namespace CRUD
{
    public class LinkedList<T> : ICollection<T>
    {
        private readonly LinkedListNode<T> root;

        public LinkedList()
        {
            root = new LinkedListNode<T>(default);
            root.Next = root;
            root.Previous = root;
            root.ChangeOwner(this);
        }

        public int Count { get; private set; }

        public LinkedListNode<T> First
        {
            get
            {
                if (Count == 0)
                {
                    return null;
                }

                return root.Next;
            }
        }

        public LinkedListNode<T> Last
        {
            get
            {
                if (Count == 0)
                {
                    return null;
                }

                return root.Previous;
            }
        }

#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
        public bool IsReadOnly => throw new NotImplementedException();
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations

        public void Add(T item)
        {
            AddLast(item);
        }

        public void AddFirst(T item)
        {
            AddFirst(new LinkedListNode<T>(item));
        }

        public void AddFirst(LinkedListNode<T> newNode)
        {
            AddAfter(root, newNode);
        }

        public void AddLast(T item)
        {
            AddLast(new LinkedListNode<T>(item));
        }

        public void AddLast(LinkedListNode<T> newNode)
        {
            AddBefore(root, newNode);
        }

        public void AddAfter(LinkedListNode<T> node, T nodeToInsert)
        {
            AddAfter(node, new LinkedListNode<T>(nodeToInsert));
        }

        public void AddAfter(LinkedListNode<T> specifiedNode, LinkedListNode<T> nodeToInsert)
        {
            CheckForNullArgument(specifiedNode);
            CheckForNullArgument(nodeToInsert);

            nodeToInsert.ChangeOwner(this);

            nodeToInsert.Previous = specifiedNode;
            nodeToInsert.Next = specifiedNode.Next;
            specifiedNode.Next.Previous = nodeToInsert;
            specifiedNode.Next = nodeToInsert;
            Count++;
        }

        public void AddBefore(LinkedListNode<T> node, T nodeToInsert)
        {
            AddBefore(node, new LinkedListNode<T>(nodeToInsert));
        }

        public void AddBefore(LinkedListNode<T> specifiedNode, LinkedListNode<T> nodeToInsert)
        {
            AddAfter(specifiedNode.Previous, nodeToInsert);
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> node = Find(item);
            CheckForNullArgument(node);
            Remove(node);
            return true;
        }

        public void Remove(LinkedListNode<T> node)
        {
            CheckForNullArgument(node);
            CheckIfNodeBelongsToList(node);
            if (node == root)
            {
                throw new NotSupportedException();
            }

            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
            Count--;
        }

        public void RemoveFirst()
        {
            CheckForInvalidOperationException();
            Remove(root.Next);
        }

        public void RemoveLast()
        {
            CheckForInvalidOperationException();
            Remove(root.Previous);
        }

        public LinkedListNode<T> Find(T item)
        {
            for (var current = root.Next; current != root; current = current.Next)
            {
                if (item.Equals(current.Data))
                {
                    return current;
                }
            }

            return null;
        }

        public LinkedListNode<T> FindLast(T item)
        {
            for (var current = root.Previous; current != root; current = current.Previous)
            {
                if (item.Equals(current.Data))
                {
                    return current;
                }
            }

            return null;
        }

        public void Clear()
        {
            Count = 0;
            root.Next = root;
            root.Previous = root;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
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

        public IEnumerator<T> GetEnumerator()
        {
            for (var current = root.Next; current != root; current = current.Next)
            {
                yield return current.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void CheckForNullArgument(LinkedListNode<T> newNode)
        {
            if (newNode != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(newNode));
        }

        private void CheckForInvalidOperationException()
        {
            if (Count != 0)
            {
                return;
            }

            throw new InvalidOperationException();
        }

        private void CheckIfNodeBelongsToList(LinkedListNode<T> node)
        {
            if (node.List == null)
            {
                throw new InvalidOperationException();
            }

            if (node.List.Equals(this))
            {
                return;
            }

            throw new InvalidOperationException();
        }
    }
}
