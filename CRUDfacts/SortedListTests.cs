using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace CRUD
{
    public class SortedListTests
    {
 
        [Fact]
        public void TestAdd()
        {
            SortedList<int> sortedList = new SortedList<int>();

            sortedList.Add(1);
            sortedList.Add(5);
            sortedList.Add(7);
            sortedList.Add(3);
            Assert.Equal("1", sortedList[0].ToString());
            Assert.Equal("3", sortedList[1].ToString());
            Assert.Equal("5", sortedList[2].ToString());
            Assert.Equal("7", sortedList[3].ToString());
        }

        [Fact]
        public void TestInsert()
        {
            SortedList<int> sortedList = new SortedList<int>();
            sortedList.Add(1);
            sortedList.Add(5);
            sortedList.Add(7);
            Assert.Equal("1", sortedList[0].ToString());
            Assert.Equal("5", sortedList[1].ToString());
            Assert.Equal("7", sortedList[2].ToString());
            sortedList.Insert(0,-2);
            Assert.Equal("-2", sortedList[0].ToString());
            Assert.Equal("1", sortedList[1].ToString());
            Assert.Equal("5", sortedList[2].ToString());
            Assert.Equal("7", sortedList[3].ToString());
        }

        [Fact]
        public void TestSettingIndexAtFirstElement()
        {
            SortedList<int> sortedList = new SortedList<int>();
            sortedList.Add(3);
            sortedList.Add(9);
            Assert.Equal("3", sortedList[0].ToString());
            Assert.Equal("9", sortedList[1].ToString());
            sortedList.SetValue(0, 10);
            Assert.Equal("3", sortedList[0].ToString());
            sortedList.SetValue(0, 8);
            Assert.Equal("8", sortedList[0].ToString());
        }

        [Fact]
        public void TestSettingIndexInMiddle()
        {
            SortedList<int> sortedList = new SortedList<int>();
            sortedList.Add(7);
            sortedList.Add(4);
            sortedList.Add(12);
            Assert.Equal("4", sortedList[0].ToString());
            Assert.Equal("7", sortedList[1].ToString());
            Assert.Equal("12", sortedList[2].ToString());
            sortedList.SetValue(1, 2);
            Assert.Equal("7", sortedList[1].ToString());
            sortedList.SetValue(1, 5);
            Assert.Equal("5", sortedList[1].ToString());
        }

        [Fact]
        public void TestSettingIndexAtLastElement()
        {
            SortedList<int> sortedList = new SortedList<int>();
            sortedList.Add(7);
            sortedList.Add(4);
            sortedList.Add(12);
            Assert.Equal("4", sortedList[0].ToString());
            Assert.Equal("7", sortedList[1].ToString());
            Assert.Equal("12", sortedList[2].ToString());
            sortedList.SetValue(2, 6);
            Assert.Equal("12", sortedList[2].ToString());
            sortedList.SetValue(2, 8);
            Assert.Equal("8", sortedList[2].ToString());
        }

        [Fact]
        public void TestSettingIndexWithOneElement()
        {
            SortedList<int> sortedList = new SortedList<int>();
            sortedList.Add(7);         
            Assert.Equal("7", sortedList[0].ToString());
            sortedList.SetValue(0, 1);
        }
    }
}
