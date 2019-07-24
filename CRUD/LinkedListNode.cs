using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T item)
        {
            Data = item;
        }

        public T Data { get; set; }

        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode<T> Previous { get; set; }
    }
}
