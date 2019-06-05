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
            Assert.Equal("17", intArray.GetArray()[4].ToString());
        }

        [Fact]
        public void TestCount()
        {            
            Assert.Equal("4", intArray.Count().ToString());
        }

        [Fact]
        public void TestElementReturn()
        {
            Assert.Equal("2", intArray.GetArray()[1].ToString());
        }

        [Fact]
        public void TestElementSet()
        {
            intArray.SetElement(1,9);
            Assert.Equal("9", intArray.GetArray()[1].ToString());
        }

        [Fact]
        public void TestContain()
        {
            
            Assert.False(intArray.Contains(0));
            Assert.True(intArray.Contains(4));
        }

        [Fact]
        public void TestIndexOf()
        {

            Assert.Equal("-1", intArray.IndexOf(9).ToString());
            Assert.Equal("2", intArray.IndexOf(3).ToString());
        }

        [Fact]
        public void TestInsert()
        {
            intArray.Insert(3,8);
            Assert.Equal("8", intArray.GetArray()[2].ToString());
            Assert.Equal("3", intArray.GetArray()[3].ToString());
          
        }

        [Fact]
        public void TestClear()
        {
            intArray.Clear();
            Assert.Equal("0", intArray.GetArray()[1].ToString());
            Assert.Equal("0", intArray.GetArray()[3].ToString());

        }

        [Fact]
        public void TestRemove()
        {
            intArray.Remove(1);
            Assert.Equal("0", intArray.GetArray()[0].ToString());
           

        }

        [Fact]
        public void TestRemoveAt()
        {
            intArray.RemoveAt(3);
            Assert.Equal("0", intArray.GetArray()[3].ToString());


        }
    }
}
