using BloomFilter;
namespace BloomFilterTest
{
    public class UnitTest1
    {
        [Fact]
        public void InsertTest()
        {
            BloomFilter<string> bloomFilter = new BloomFilter<string>(1000);
            bloomFilter.Insert("hello");
            bloomFilter.Insert("world");
            Assert.True(bloomFilter.ProbablyContains("hello"));
            Assert.True(bloomFilter.ProbablyContains("world"));
            Assert.False(bloomFilter.ProbablyContains("daniel"));
        }

        [Fact]
        public void InsertTest2()
        {
            BloomFilter<string> bloomFilter = new BloomFilter<string>(1000);
            bloomFilter.Insert("foo");
            bloomFilter.Insert("bar");
            Assert.True(bloomFilter.ProbablyContains("foo"));
            Assert.True(bloomFilter.ProbablyContains("bar"));
            Assert.False(bloomFilter.ProbablyContains("baz"));
        }
    }
}
