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

            var keys = dictionary.Keys;
            Assert.Equal(new int[] { 1, 2, 10 }, keys);
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
            dictionary.Remove(7);
            Assert.Equal(new KeyValuePair<int, int>[]
           { new KeyValuePair<int, int>(2, 7),
              new KeyValuePair<int, int>(10, 4),
           },
           dictionary);
        }

        [Fact]
        public void TestTryGetValue()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Add(10, "c");

            string value = string.Empty;
            Assert.True(dictionary.TryGetValue(1, out value));
            Assert.Equal("a", value);
            Assert.False(dictionary.TryGetValue(3, out value));
            Assert.Equal(null, value);
        }

        [Fact]
        public void TestTryGetValue2()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("a", 12);
            dictionary.Add("x", 9);
            dictionary.Add("d", 3);

            int value;
            Assert.True(dictionary.TryGetValue("x", out value));
            Assert.Equal(9, value);
            Assert.False(dictionary.TryGetValue("w", out value));
            Assert.Equal(0, value);
        }

        [Fact]
        public void TestCopyTo()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");

            KeyValuePair<int, string>[] array = new KeyValuePair<int, string>[dictionary.Count];
            dictionary.CopyTo(array, 0);

            Assert.Equal(new KeyValuePair<int, string>[]
            {
                new KeyValuePair<int,string>(1,"a"),
                new KeyValuePair<int,string>(2,"b")
            }, array);

        }

        [Fact]
        public void TestCopyTo2()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Remove(1);

            KeyValuePair<int, string>[] array = new KeyValuePair<int, string>[dictionary.Count];
            dictionary.CopyTo(array, 0);

            Assert.Equal(new KeyValuePair<int, string>[]
            {
                new KeyValuePair<int,string>(2,"b")
            }, array);

        }

        [Fact]
        public void TestCopyToNullArray()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Remove(1);

            KeyValuePair<int, string>[] array = null;
            Assert.Throws<ArgumentNullException>(() => dictionary.CopyTo(array, 0));          
        }

        [Fact]
        public void TestCopyToWhenIndexIsLessThan0()
        {

            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary.Remove(1);

            KeyValuePair<int, string>[] array = new KeyValuePair<int, string>[dictionary.Count];
            Assert.Throws<ArgumentOutOfRangeException>(() => dictionary.CopyTo(array, -1));
        }

        [Fact]

        public void TestGetValueByKey()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");

            Assert.Equal("a", dictionary[1]);
            Assert.Equal("b", dictionary[2]);
            Assert.Throws<KeyNotFoundException>(() => dictionary[3]);
        }

        [Fact]

        public void TestSetValue()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "a");
            dictionary.Add(2, "b");
            dictionary[2] = "idk";
            Assert.Equal("a", dictionary[1]);
            Assert.Equal("idk", dictionary[2]);
        }
    }
}
