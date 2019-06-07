using System;
using Xunit;

namespace CRUD
{
    public class IntArrayTests
    {
        IntArray intArray = new IntArray();


        [Fact]
        public void TestAdd()
        {
            intArray.Add(17);
            Assert.Equal("17", intArray.array[0].ToString());
        }

        [Fact]
        public void TestCount()
        {
            intArray.Add(1);
            intArray.Add(1);
            intArray.Add(1);
            Assert.Equal("3", intArray.Count().ToString());
        }

        [Fact]
        public void TestElementReturn()
        {
            intArray.Add(2);
            intArray.Add(3);
            Assert.Equal("3", intArray.array[1].ToString());
        }

        [Fact]
        public void TestElementSet()
        {
            intArray.Add(1);
            intArray.Add(2);
            intArray.Add(3);
            intArray.Add(4);
            Assert.Equal("4", intArray.array[3].ToString());
            intArray.SetElement(3, 0);
            Assert.Equal("0", intArray.array[3].ToString());

        }

        [Fact]
        public void TestContain()
        {
            intArray.Add(1);
            intArray.Add(2);
            intArray.Add(3);
            intArray.Add(4);
            Assert.True(intArray.Contains(2));
            Assert.False(intArray.Contains(6));
        }

        [Fact]
        public void TestIndexOf()
        {
            intArray.Add(1);
            intArray.Add(2);
            intArray.Add(3);
            intArray.Add(4);
            Assert.Equal("0", intArray.IndexOf(1).ToString());
            Assert.Equal("-1", intArray.IndexOf(9).ToString());

        }

        [Fact]
        public void TestInsert()
        {
            intArray.Add(1);
            intArray.Add(2);
            intArray.Add(3);
            intArray.Add(4);
            intArray.Insert(1, 5);
            Assert.Equal("5", intArray.array[0].ToString());
        }

        [Fact]
        public void TestClear()
        {
            intArray.Add(1);
            intArray.Add(2);
            intArray.Add(3);
            intArray.Add(4);
            intArray.Clear();
            Assert.Equal("0", intArray.array.Length.ToString());

        }

        [Fact]
        public void TestRemove()
        {
            intArray.Add(1);
            intArray.Add(1);
            intArray.Add(1);
            intArray.Add(1);
            intArray.Remove(1);
            Assert.Equal("1", intArray.array[0].ToString());

        }

        [Fact]
        public void TestRemoveAt()
        {
            intArray.Add(1);
            intArray.Add(2);
            intArray.Add(3);
            intArray.Add(4);
            intArray.RemoveAt(1);
            Assert.Equal("3", intArray.array[1].ToString());

        }
    }
}
