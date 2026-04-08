using HashMap;

namespace HashMapTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("key1", "value1")]
        public void TestAddAndGetValue(string key, string value)
        {
            var hashMap = new TheHashMap<string, string>();
            hashMap[key] = value; // Using the indexer to add a key-value pair
            Assert.Equal(value, hashMap[key]); // Using the indexer to retrieve the value
        }

        [Theory]
        [InlineData("key1")]
        public void TestRemove(string key)
        {
            var hashMap = new TheHashMap<string, string>();
            hashMap[key] = "value";
            Assert.True(hashMap.Remove(key)); // Using the Remove method to remove the key-value pair
            Assert.Throws<KeyNotFoundException>(() => hashMap.GetValue(key)); // Ensure the key is removed
        }

        [Fact]
        public void ReHashTest()
        {
            var hashMap = new TheHashMap<int, string>();
            for (int i = 0; i < 20; i++) // Adding more than initial capacity to trigger rehashing
            {
                hashMap[i] = $"value{i}";
            }
            for (int i = 0; i < 20; i++)
            {
                Assert.Equal($"value{i}", hashMap[i]); // Ensure all values are still accessible after rehashing
            }
        }
    }
}
