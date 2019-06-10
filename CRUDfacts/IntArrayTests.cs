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
            intArray.Add(16);
            intArray.Add(8);
            intArray.Add(3);
            intArray.Add(7);
            intArray.Add(24);
            Assert.Equal("16", intArray.Element(0).ToString());
            Assert.Equal("8", intArray.Element(1).ToString());
            Assert.Equal("3", intArray.Element(2).ToString());
            Assert.Equal("7", intArray.Element(3).ToString());
            Assert.Equal("24", intArray.Element(4).ToString());
            Assert.Equal("8", intArray.Count().ToString());
        }
        [Fact]
        public void TestCount()
        {
            intArray.Add(16);
            intArray.Add(8);
            intArray.Add(3);
            intArray.Add(7);         
            Assert.Equal("4", intArray.Count().ToString());
        }

        [Fact]
        public void TestGetElement()
        {
            intArray.Add(16);
            Assert.Equal("16", intArray.Element(0).ToString());
        }

        [Fact]
        public void TestSetElement()
        {
            intArray.SetElement(2,9);
            Assert.Equal("9", intArray.Element(2).ToString());
        }


        [Fact]
        public void TestContains()
        {
            Assert.False(intArray.Contains(4));
            intArray.Add(4);
            Assert.True(intArray.Contains(4));
        }

        [Fact]
        public void TestIndexOf()
        {
            intArray.Add(2);
            intArray.Add(4);
            Assert.Equal("0", intArray.IndexOf(2).ToString());
            Assert.Equal("1", intArray.IndexOf(4).ToString());
        }

        [Fact]
        public void TestInsert()
        {
            intArray.Add(2);
            intArray.Add(4);
            intArray.Add(7);
            intArray.Add(8);
            intArray.Insert(2,14);
            Assert.Equal("14", intArray.Element(1).ToString());
            Assert.Equal("4", intArray.Element(2).ToString());

        }

        [Fact]
        public void TestClear()
        {
            intArray.Add(2);
            intArray.Add(4);
            intArray.Add(7);
            intArray.Add(8);
            Assert.Equal("4", intArray.Count().ToString());
            intArray.Clear();
            Assert.Equal("0", intArray.Count().ToString());

        }

        [Fact]
        public void TestRemove()
        {
            intArray.Add(2);
            intArray.Add(2);
            intArray.Add(7);
            intArray.Add(8);
            intArray.Remove(2);
            Assert.Equal("7", intArray.Element(1).ToString());

        }

        [Fact]
        public void TestRemoveAt()
        {
            intArray.Add(2);
            intArray.Add(2);
            intArray.Add(7);
            intArray.Add(8);
            intArray.RemoveAt(2);
            Assert.Equal("8", intArray.Element(2).ToString());

        }
    }
}
