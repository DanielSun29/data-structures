using BucketSort;

namespace BucketSortTest
{
    public class UnitTest1
    {
        [Fact]
        public void BucketSortTest()
        {
            List<KeyValuePair<int, string>> kvps = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1, "one"),
                new KeyValuePair<int, string>(4, "four"),
                new KeyValuePair<int, string>(1, "uno"),
                new KeyValuePair<int, string>(2, "two"),
                new KeyValuePair<int, string>(7, "seven"),
                new KeyValuePair<int, string>(5, "five"),
                new KeyValuePair<int, string>(2, "dos")
            };
            List<KeyValuePair<int, string>> expected = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1, "one"),
                new KeyValuePair<int, string>(1, "uno"),
                new KeyValuePair<int, string>(2, "two"),
                new KeyValuePair<int, string>(2, "dos"),
                new KeyValuePair<int, string>(4, "four"),
                new KeyValuePair<int, string>(5, "five"),
                new KeyValuePair<int, string>(7, "seven")
            };
            List<KeyValuePair<int, string>> sorted = TheBucketSort<string>.Sort(kvps);
            Assert.Equal(expected.Count, sorted.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Key, sorted[i].Key);
                Assert.Equal(expected[i].Value, sorted[i].Value);
            }
        }
    }
}
