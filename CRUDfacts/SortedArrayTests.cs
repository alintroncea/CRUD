using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace CRUD
{
    public class SortedListTests
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
        public void TestSettingIndexAtFirstElement()
        {
            sortedArray.Add(3);
            sortedArray.Add(9);
            Assert.Equal("3", sortedArray[0].ToString());
            Assert.Equal("9", sortedArray[1].ToString());
            sortedArray.SetValue(0, 10);
            Assert.Equal("3", sortedArray[0].ToString());
            sortedArray.SetValue(0, 8);
            Assert.Equal("8", sortedArray[0].ToString());
        }

        [Fact]
        public void TestSettingIndexInMiddle()
        {
            sortedArray.Add(7);
            sortedArray.Add(4);
            sortedArray.Add(12);
            Assert.Equal("4", sortedArray[0].ToString());
            Assert.Equal("7", sortedArray[1].ToString());
            Assert.Equal("12", sortedArray[2].ToString());
            sortedArray.SetValue(1, 2);
            Assert.Equal("7", sortedArray[1].ToString());
            sortedArray.SetValue(1, 5);
            Assert.Equal("5", sortedArray[1].ToString());
        }

        [Fact]
        public void TestSettingIndexAtLastElement()
        {
            sortedArray.Add(7);
            sortedArray.Add(4);
            sortedArray.Add(12);
            Assert.Equal("4", sortedArray[0].ToString());
            Assert.Equal("7", sortedArray[1].ToString());
            Assert.Equal("12", sortedArray[2].ToString());
            sortedArray.SetValue(2, 6);
            Assert.Equal("12", sortedArray[2].ToString());
            sortedArray.SetValue(2, 8);
            Assert.Equal("8", sortedArray[2].ToString());
        }

        [Fact]
        public void TestSettingIndexWithOneElement()
        {
            sortedArray.Add(7);         
            Assert.Equal("7", sortedArray[0].ToString());
            sortedArray.SetValue(0, 1);
        }
    }
}
