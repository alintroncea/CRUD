using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace CRUD
{
    public class SortedIntArrayTests
    {
        SortedIntArray sortedArray = new SortedIntArray();

        [Fact]
        public void TestAdd()
        {
            sortedArray.Add(1);
            sortedArray.Add(5);
            sortedArray.Add(7);
            sortedArray.Add(3);
            Assert.Equal("1", sortedArray[0].ToString());
            Assert.Equal("3", sortedArray[1].ToString());
            Assert.Equal("5", sortedArray[2].ToString());
            Assert.Equal("7", sortedArray[3].ToString());
        }

        [Fact]
        public void TestInsert()
        {
            sortedArray.Add(1);
            sortedArray.Add(5);
            sortedArray.Add(7);
            Assert.Equal("1", sortedArray[0].ToString());
            Assert.Equal("5", sortedArray[1].ToString());
            Assert.Equal("7", sortedArray[2].ToString());
            sortedArray.Insert(0,-2);
            Assert.Equal("-2", sortedArray[0].ToString());
            Assert.Equal("1", sortedArray[1].ToString());
            Assert.Equal("5", sortedArray[2].ToString());
            Assert.Equal("7", sortedArray[3].ToString());
        }

        [Fact]
        public void TestSettingIndex()
        {
            sortedArray.Add(1);
            sortedArray.Add(5);
            sortedArray.Add(7);
            Assert.Equal("1", sortedArray[0].ToString());
            Assert.Equal("5", sortedArray[1].ToString());
            Assert.Equal("7", sortedArray[2].ToString());
            sortedArray[0] = 4;
            Assert.Equal("4", sortedArray[0].ToString());
            Assert.Equal("5", sortedArray[1].ToString());
            Assert.Equal("7", sortedArray[2].ToString());
            sortedArray[1] = 6;
            Assert.Equal("4", sortedArray[0].ToString());
            Assert.Equal("6", sortedArray[1].ToString());
            Assert.Equal("7", sortedArray[2].ToString());
            sortedArray[2] = 10;
            Assert.Equal("4", sortedArray[0].ToString());
            Assert.Equal("6", sortedArray[1].ToString());
            Assert.Equal("10", sortedArray[2].ToString());
        }
    }
}
