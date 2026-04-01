using RadixSort;

namespace RadixSortTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(new int[] { 170, 45, 75, 90, 802, 24, 2, 66 }, new int[] { 2, 24, 45, 66, 75, 90, 170, 802 })]
        // Negatives test case
        [InlineData(new int[] { -170, 45, -75, 90, -802, 24, 2, -66 }, new int[] { -802, -170, -75, -66, 2, 24, 45, 90 })]
        // Duplicates test case
        [InlineData(new int[] { 170, 45, 75, 90, 802, 24, 2, 66, 45 }, new int[] { 2, 24, 45, 45, 66, 75, 90, 170, 802 })]
        public void IntRadixSortTest(int[] ints, int[] expected)
        {
            List<int> sorted = new List<int>();
            sorted = TheRadixSort<int>.IntSort(ints.ToList());
            Assert.Equal(expected, sorted);
        }

        [Fact]
        public void RadixSortTest1()
        {
            List<KeyValuePair<int, string>> kvps =
            [
                new KeyValuePair<int, string>(1, "one"),
                new KeyValuePair<int, string>(4, "four"),
                new KeyValuePair<int, string>(1, "uno"),
                new KeyValuePair<int, string>(2, "two"),
                new KeyValuePair<int, string>(7, "seven"),
                new KeyValuePair<int, string>(5, "five"),
                new KeyValuePair<int, string>(2, "dos")
            ];
            List<KeyValuePair<int, string>> expected =
            [
                new KeyValuePair<int, string>(1, "one"),
                new KeyValuePair<int, string>(1, "uno"),
                new KeyValuePair<int, string>(2, "two"),
                new KeyValuePair<int, string>(2, "dos"),
                new KeyValuePair<int, string>(4, "four"),
                new KeyValuePair<int, string>(5, "five"),
                new KeyValuePair<int, string>(7, "seven")
            ];
            List<KeyValuePair<int, string>> sorted = TheRadixSort<string>.Sort(kvps);
            Assert.Equal(expected.Count, sorted.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Key, sorted[i].Key);
                Assert.Equal(expected[i].Value, sorted[i].Value);
            }
        }

        [Fact]
        public void RadixSortTest2()
        {
            List<KeyValuePair<int, string>> kvps =
            [
                new KeyValuePair<int, string>(-1, "n-one"),
                new KeyValuePair<int, string>(-4, "n-four"),
                new KeyValuePair<int, string>(-1, "n-uno"),
                new KeyValuePair<int, string>(-2, "n-two"),
                new KeyValuePair<int, string>(-7, "n-seven"),
                new KeyValuePair<int, string>(-5, "n-five"),
                new KeyValuePair<int, string>(-2, "n-dos")
            ];
            List<KeyValuePair<int, string>> expected =
            [
                new KeyValuePair<int, string>(-7, "n-seven"),
                new KeyValuePair<int, string>(-5, "n-five"),
                new KeyValuePair<int, string>(-4, "n-four"),
                new KeyValuePair<int, string>(-2, "n-two"),
                new KeyValuePair<int, string>(-2, "n-dos"),
                new KeyValuePair<int, string>(-1, "n-one"),
                new KeyValuePair<int, string>(-1, "n-uno")
            ];
            List<KeyValuePair<int, string>> sorted = TheRadixSort<string>.Sort(kvps);
            Assert.Equal(expected.Count, sorted.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Key, sorted[i].Key);
                Assert.Equal(expected[i].Value, sorted[i].Value);
            }
        }

        [Fact]
        public void RadixSortWithDifferentBaseTest()
        {
            List<KeyValuePair<int, string>> kvps =
            [
                new KeyValuePair<int, string>(1, "one"),
                new KeyValuePair<int, string>(4, "four"),
                new KeyValuePair<int, string>(1, "uno"),
                new KeyValuePair<int, string>(2, "two"),
                new KeyValuePair<int, string>(7, "seven"),
                new KeyValuePair<int, string>(5, "five"),
                new KeyValuePair<int, string>(2, "dos")
            ];
            List<KeyValuePair<int, string>> expected =
            [
                new KeyValuePair<int, string>(1, "one"),
                new KeyValuePair<int, string>(1, "uno"),
                new KeyValuePair<int, string>(2, "two"),
                new KeyValuePair<int, string>(2, "dos"),
                new KeyValuePair<int, string>(4, "four"),
                new KeyValuePair<int, string>(5, "five"),
                new KeyValuePair<int, string>(7, "seven")
            ];
            List<KeyValuePair<int, string>> sorted = TheRadixSort<string>.VarBaseSort(kvps, 6);
            Assert.Equal(expected.Count, sorted.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Key, sorted[i].Key);
                Assert.Equal(expected[i].Value, sorted[i].Value);
            }
        }
    }
}
