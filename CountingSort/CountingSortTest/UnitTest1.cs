using CountingSort;

namespace CountingSortTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(new int[] { 1, 4, 1, 2, 7, 5, 2 }, new int[] { 1, 1, 2, 2, 4, 5, 7 })]
        [InlineData(new int[] { -1, 4, 1, -2, 7, 5, 2 }, new int[] { -2, -1, 1, 2, 4, 5, 7 })]
        public void IntCountingSortTest1(int[] ints, int[] expected)
        {
            List<int> sorted = new List<int>();
            sorted = TheCountingSort<int>.IntSort(ints.ToList());
            Assert.Equal(expected, sorted);
        }

        [Fact]
        public void CountingSortTest2()
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
            List<KeyValuePair<int, string>> sorted = TheCountingSort<string>.Sort(kvps);
            Assert.Equal(expected.Count, sorted.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Key, sorted[i].Key);
                Assert.Equal(expected[i].Value, sorted[i].Value);
            }
        }
    }
}
