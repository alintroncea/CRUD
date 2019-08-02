using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CRUD
{
    public class DictionaryFacts
    {
        [Fact]
        public void TestAdd()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");

            Assert.True(dictionary.ContainsKey(1));
            Assert.True(dictionary.ContainsKey(2));
            Assert.True(dictionary.ContainsKey(10));
            Assert.True(dictionary.ContainsKey(7));
            Assert.True(dictionary.ContainsKey(12));
            Assert.False(dictionary.ContainsKey(5));
            Assert.Throws<ArgumentException>(() => dictionary.Add(1,"a"));
        }

        [Fact]
        public void TestRemove()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");
            dictionary.Add(7, "d");
            dictionary.Add(12, "e");

            Assert.True(dictionary.Remove(1));
            Assert.True(dictionary.Remove(7));
        }
    }
}
