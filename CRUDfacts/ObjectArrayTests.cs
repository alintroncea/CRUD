using System;
using Xunit;

namespace CRUD
{
    public class ObjectArrayTests
    {
        ObjectArray objArray = new ObjectArray();


        [Fact]
        public void TestAdd()
        {
            objArray.Add(16);
            objArray.Add(8);
            objArray.Add(3);
            objArray.Add(7);
            objArray.Add(10);
            Assert.Equal("16", objArray[0].ToString());
            Assert.Equal("8", objArray[1].ToString());
            Assert.Equal("3", objArray[2].ToString());
            Assert.Equal("7", objArray[3].ToString());
            Assert.Equal("5", objArray.Count.ToString());

        }
        [Fact]
        public void TestCount()
        {
            objArray.Add(16);
            objArray.Add(8);
            objArray.Add(3);
            objArray.Add(7);         
            Assert.Equal("4", objArray.Count.ToString());
        }
        [Fact]
        public void TestContains()
        {
            objArray.Add(4);
            Assert.True(objArray.Contains(4));
        }

        [Fact]
        public void TestIndexOf()
        {
            objArray.Add(2);
            objArray.Add(4);
            Assert.Equal("0", objArray.IndexOf(2).ToString());
            Assert.Equal("-1", objArray.IndexOf(10).ToString());
        }

        [Fact]
        public void TestInsert()
        {
            objArray.Add(2);
            objArray.Add(4);
            objArray.Add(7);
            objArray.Add(8);
            objArray.Insert(2, 14);
            Assert.Equal("2", objArray[0].ToString());
            Assert.Equal("14", objArray[1].ToString());
            Assert.Equal("4", objArray[2].ToString());
            Assert.Equal("7", objArray[3].ToString());
            Assert.Equal("8", objArray[4].ToString());

        }

        [Fact]
        public void TestClear()
        {
            objArray.Add(2);
            objArray.Add(4);
            objArray.Add(7);
            objArray.Add(8);
            Assert.Equal("4", objArray.Count.ToString());
            objArray.Clear();
            Assert.Equal("0", objArray.Count.ToString());

        }

        [Fact]
        public void TestRemove()
        {
            objArray.Add(2);
            objArray.Add(2);
            objArray.Add(7);
            objArray.Add(8);
            objArray.Remove(2);
            Assert.Equal("7", objArray[1].ToString());

        }

        [Fact]
        public void TestRemoveAt()
        {
            objArray.Add(2);
            objArray.Add(2);
            objArray.Add(7);
            objArray.Add(8);
            objArray.RemoveAt(2);
            Assert.Equal("8", objArray[2].ToString());

        }
    }
}
