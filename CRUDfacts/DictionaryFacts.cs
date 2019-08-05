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
            Assert.Throws<ArgumentException>(() => dictionary.Add(1, "a"));
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
            Assert.False(dictionary.ContainsKey(1));
            Assert.False(dictionary.ContainsKey(7));
            Assert.Equal(3, dictionary.Count);
            dictionary.Add(17, "f");
            Assert.Equal(4, dictionary.Count);
            Assert.True(dictionary.ContainsKey(17));
        }

        [Fact]
        public void TestClear()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");

            Assert.Equal(3, dictionary.Count);
            dictionary.Clear();
            Assert.False(dictionary.ContainsKey(1));
            Assert.False(dictionary.ContainsKey(2));
            Assert.False(dictionary.ContainsKey(10));
            Assert.Equal(0, dictionary.Count);
        }

        [Fact]

        public void TestKeys()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");

            dictionary.Remove(10);

            var keys = dictionary.Keys;
            Assert.Equal(new int[] { 1, 2 }, keys);
        }

        [Fact]
        public void TestValues()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");

            var values = dictionary.Values;
            Assert.Equal(new string[] { "a", "b", "c" }, values);
        }

        [Fact]
        public void TestEnumerator()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("a", 1);
            dictionary.Add("b", 2);
            dictionary.Add("c", 10);
            dictionary.Add("d", 7);
            dictionary.Remove("b");
            Assert.Equal(new KeyValuePair<string, int>[]
            { new KeyValuePair<string, int>("a", 1),
              new KeyValuePair<string, int>("c", 10),
              new KeyValuePair<string, int>("d", 7),
            },
            dictionary);

        }


        [Fact]
        public void TestEnumerator2()
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            dictionary.Add(1, 3);
            dictionary.Add(2, 7);
            dictionary.Add(10, 4);
            dictionary.Add(7, 9);

            dictionary.Remove(1);
            Assert.Equal(new KeyValuePair<int, int>[]
           { new KeyValuePair<int, int>(2, 7),
              new KeyValuePair<int, int>(10, 4),
              new KeyValuePair<int, int>(7, 9),
           },
           dictionary);


        }
    }
}
