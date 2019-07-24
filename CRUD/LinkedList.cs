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
        }

        public int Count { get; private set; }

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
            try
            {
                Remove(new LinkedListNode<T>(item));
            }
            catch (ArgumentNullException)
            {
                return false;
            }

            return true;
        }

        public void Remove(LinkedListNode<T> node)
        {
            CheckForNullArgument(node);
            LinkedListNode<T> nodeToBeRemoved = Find(node.Data);
            CheckForNullArgument(nodeToBeRemoved);

            nodeToBeRemoved.Previous.Next = nodeToBeRemoved.Next;
            nodeToBeRemoved.Next.Previous = nodeToBeRemoved.Previous;
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

        public LinkedListNode<T> Find(T specifiedNode)
        {
            for (var current = root.Next; current != root; current = current.Next)
            {
                if (specifiedNode.Equals(current.Data))
                {
                    return current;
                }
            }

            return null;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
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
    }
}
