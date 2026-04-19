using LRUCache;

namespace LRUCacheTest
{
    public class UnitTest1
    {
        [Fact]
        public void LRUCacheTest1()
        {
            LRUCache<int, int> cache = new LRUCache<int, int>(10);

            for (int i = 0; i < 10; i++)
            {
                cache.Put(i, i);
                Assert.True(cache.TryGetValue(i, out int value1));
                Assert.Equal(i, value1);
            }

            cache.Put(10, 10);
            Assert.False(cache.TryGetValue(0, out int value2));// 0 should be evicted

            Assert.False(cache.TryGetValue(11, out int value3)); // 11 doesn't exist
        }
    }
}
