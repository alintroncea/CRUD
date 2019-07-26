using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class LinkedListNode<T>
    {
        private LinkedList<T> list;

        public LinkedListNode(T item)
        {
            Data = item;
        }

        public T Data { get; set; }

        public LinkedList<T> List => list;

        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode<T> Previous { get; set; }

        public void ChangeOwner(LinkedList<T> list)
        {
            this.list = list;
        }
    }
}
