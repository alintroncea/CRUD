using System;
using System.Text;
using Xunit;

namespace CRUD
{
    public class LinkedListFacts
    {
        [Fact]
        public void NewLinkedListIsEmpty()
        {
            LinkedList<int> list = new LinkedList<int>();
            Assert.Empty(list);
        }

        [Fact]
        public void AddLastThrowsArgumentExceptionForNullNode()
        {
            LinkedList<int> list = new LinkedList<int>
            {
                3,5,4
            };
            Assert.Throws<ArgumentNullException>(() => list.AddLast(null));
        }

        [Fact]
        public void AddToLinkedList()
        {
            LinkedList<int> intList = new LinkedList<int>
            {
                3,5,4
            };
            Assert.Equal(new int[] { 3, 5, 4 }, intList);

            LinkedList<string> stringList = new LinkedList<string>
            {
                "Car", "Bike", "Boat"
            };
            Assert.Equal(new string[] { "Car", "Bike", "Boat" }, stringList);
        }


        [Fact]
        public void AddFirstToList()
        {
            LinkedList<int> intList = new LinkedList<int>
            {
                3,5,4
            };
            intList.AddFirst(8);
            Assert.Equal(new int[] { 8, 3, 5, 4 }, intList);

            LinkedList<string> stringList = new LinkedList<string>
            {
                "Car", "Bike", "Boat"
            };

            stringList.AddFirst("Train");

            Assert.Equal(new string[] { "Train", "Car", "Bike", "Boat" }, stringList);
        }

        [Fact]
        public void AddAfterToList()
        {
            LinkedList<int> intList = new LinkedList<int>
            {
                3,5,4
            };
            LinkedListNode<int> intSpecifiedNode = intList.Find(5);
            intList.AddAfter(intSpecifiedNode, 8);
            Assert.Equal(new int[] { 3, 5, 8, 4 }, intList);

            LinkedList<string> stringList = new LinkedList<string>
            {
                "Car", "Bike", "Boat"
            };

            LinkedListNode<string> stringSpecifiedNode = stringList.Find("Boat");
            stringList.AddAfter(stringSpecifiedNode, "Train");
            Assert.Equal(new string[] { "Car", "Bike", "Boat", "Train" }, stringList);

        }

        [Fact]
        public void AddBeforeToList()
        {
            LinkedList<int> intList = new LinkedList<int>
            {
                3,5,4
            };
            LinkedListNode<int> intSpecifiedNode = intList.Find(3);
            intList.AddBefore(intSpecifiedNode, 8);
            Assert.Equal(new int[] { 8, 3, 5, 4 }, intList);

            LinkedList<string> stringList = new LinkedList<string>
            {
                "Car", "Bike", "Boat"
            };

            LinkedListNode<string> stringSpecifiedNode = stringList.Find("Boat");
            stringList.AddBefore(stringSpecifiedNode, "Train");
            Assert.Equal(new string[] { "Car", "Bike", "Train", "Boat" }, stringList);
        }

        [Fact]
        public void TestCount()
        {
            LinkedList<int> intList = new LinkedList<int>
            {
                3,5,4,9,8,3
            };
            Assert.Equal(6, intList.Count);
            intList.AddFirst(7);
            Assert.Equal(7, intList.Count);
        }

        [Fact]
        public void TestRemoveOnIntList()
        {
            LinkedList<int> intList = new LinkedList<int>
            {
                3,5,4,9,8,3
            };
            intList.Remove(3);

            Assert.Equal(new int[] { 5, 4, 9, 8, 3 }, intList);

            intList = new LinkedList<int>
            {
               1
            };

            intList.Remove(1);

            Assert.Empty(intList);
        }

        [Fact]
        public void TestRemoveOnStringList()
        {
            LinkedList<string> stringList = new LinkedList<string>
            {
                "Car", "Bike", "Boat"
            };
            Assert.Equal(3, stringList.Count);
            stringList.Remove("Bike");
            Assert.Equal(2, stringList.Count);
            Assert.Equal(new string[] { "Car", "Boat" }, stringList);
        }


        [Fact]
        public void TestRemoveException()
        {
            LinkedList<string> stringList = new LinkedList<string>
            {
                "Car", "Bike", "Boat"
            };

            Assert.False(stringList.Remove("Truck"));
        }

        [Fact]
        public void TestRemoveFirst()
        {
            LinkedList<string> stringList = new LinkedList<string>();

            Assert.Throws<InvalidOperationException>(() => stringList.RemoveFirst());

            stringList.Add("Train");
            stringList.Add("Motorbike");
            stringList.Add("Skateboard");

            Assert.Equal(3, stringList.Count);
            Assert.Equal(new string[] { "Train", "Motorbike", "Skateboard" }, stringList);
            stringList.RemoveFirst();
            Assert.Equal(2, stringList.Count);
            Assert.Equal(new string[] { "Motorbike", "Skateboard" }, stringList);
        }

        [Fact]
        public void TestRemoveLast()
        {
            LinkedList<string> stringList = new LinkedList<string>();

            Assert.Throws<InvalidOperationException>(() => stringList.RemoveLast());

            stringList.Add("Train");
            stringList.Add("Motorbike");
            stringList.Add("Skateboard");

            Assert.Equal(3, stringList.Count);
            Assert.Equal(new string[] { "Train", "Motorbike", "Skateboard" }, stringList);
            stringList.RemoveLast();
            Assert.Equal(2, stringList.Count);
            Assert.Equal(new string[] { "Train", "Motorbike"}, stringList);
        }
    }
}
