using System;
using Xunit;

namespace CRUD
{
    public class ListTests
    {
       
        [Fact]
        public void TestAdd()
        {
            var myList = new List<int>();

            myList.Add(16);
            myList.Add(8);
            myList.Add(3);
            myList.Add(7);
            myList.Add(10);
            Assert.Equal("16", myList[0].ToString());
            Assert.Equal("8", myList[1].ToString());
            Assert.Equal("3", myList[2].ToString());
            Assert.Equal("7", myList[3].ToString());
            Assert.Equal("5", myList.Count.ToString());

        }
        [Fact]
        public void TestCount()
        {
            var myList = new List<int>();

            myList.Add(16);
            myList.Add(8);
            myList.Add(3);
            myList.Add(7);         
            Assert.Equal("4", myList.Count.ToString());
        }
        [Fact]
        public void TestContains()
        {
            var myList = new List<string>();
            myList.Add("alin");
            Assert.True(myList.Contains("alin"));
        }

        [Fact]
        public void TestIndexOf()
        {
            var myList = new List<int>();

            myList.Add(2);
            myList.Add(4);
            Assert.Equal("0", myList.IndexOf(2).ToString());
            Assert.Equal("-1", myList.IndexOf(10).ToString());
        }

        [Fact]
        public void TestInsert()
        {
            var myList = new List<int>();

            myList.Add(2);
            myList.Add(4);
            myList.Add(7);
            myList.Add(8);
            myList.Insert(0, 14);
            Assert.Equal("14", myList[0].ToString());
            Assert.Equal("2", myList[1].ToString());
            Assert.Equal("4", myList[2].ToString());
            Assert.Equal("7", myList[3].ToString());
            Assert.Equal("8", myList[4].ToString());

        }

        [Fact]
        public void TestClear()
        {
            var myList = new List<int>();

            myList.Add(2);
            myList.Add(4);
            myList.Add(7);
            myList.Add(8);
            Assert.Equal("4", myList.Count.ToString());
            myList.Clear();
            Assert.Equal("0", myList.Count.ToString());

        }

        [Fact]
        public void TestRemove()
        {
            var myList = new List<int>();

            myList.Add(2);
            myList.Add(2);
            myList.Add(7);
            myList.Add(8);
            myList.Remove(2);
            Assert.Equal("7", myList[1].ToString());

        }

        [Fact]
        public void TestRemoveAt()
        {
            var myList = new List<int>();

            myList.Add(2);
            myList.Add(2);
            myList.Add(7);
            myList.Add(8);
            myList.RemoveAt(2);
            Assert.Equal("8", myList[2].ToString());

        }

        [Fact]
        public void TestEnumerable()
        {
            var myList = new List<int> { 1, 2, 4, 6 };
            Assert.Equal("1", myList[0].ToString());
            Assert.Equal("2", myList[1].ToString());
            Assert.Equal("4", myList[2].ToString());
            Assert.Equal("6", myList[3].ToString());

        }

        [Fact]
        public void TestEnumerator()
        {
            var myList = new List<int> { 9, 3, 4, 6 };

            var enumerator = myList.GetEnumerator();

            var done = enumerator.MoveNext();
            done = enumerator.MoveNext();
            done = enumerator.MoveNext();
            done = enumerator.MoveNext();
            done = enumerator.MoveNext();
        }

        [Fact]
        public void TestCopyTo()
        {
            var myList = new List<int> { 9, 3, 4, 6 };

            int[] array = new int[myList.Count];
            myList.CopyTo(array, 0);

            Assert.Equal("9", array[0].ToString());
            Assert.Equal("3", array[1].ToString());
            Assert.Equal("4", array[2].ToString());
            Assert.Equal("6", array[3].ToString());
        }

        [Fact]
        public void TestCopyTo2()
        {
            var myList = new List<string> { "alin", "mihai", "alex", "pedro" };

            string[] array = new string[myList.Count];
            myList.CopyTo(array, 0);

            Assert.Equal("alin", array[0].ToString());
            Assert.Equal("mihai", array[1].ToString());
            Assert.Equal("alex", array[2].ToString());
            Assert.Equal("pedro", array[3].ToString());
        }
    }
}
