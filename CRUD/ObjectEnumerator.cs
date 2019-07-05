using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class ObjectEnumerator : IEnumerator
    {
        private readonly object[] objectArray;
        readonly int counter;
        int position = -1;

        public ObjectEnumerator(object[] objectArray, int counter)
        {
            this.objectArray = objectArray;
            this.counter = counter;
        }

        public object Current
        {
            get
            {
                return objectArray[position];
            }
        }

        public bool MoveNext()
        {
            if (position < counter)
            {
                position++;
            }

            return position < counter;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
