using MergeSort;

namespace TheMergeSortTesting
{
    public class MergeSortTest
    {
        [Theory]
        [InlineData(new int[]{1, 3, 5, 7}, new int[] { 2, 4, 6, 8 })]
        public void MergeTest(int[] left, int[] right)
        {
            var correctOrder = left.Concat(right).ToArray();
            Array.Sort(correctOrder);

            var testList = TheMergeSort<int>.Merge(left.ToList(), right.ToList());
            Assert.Equal(correctOrder, testList);
        }


        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 1, 2, 3, 4 }, new int[] { 5, 6, 7, 8 })]
        public void SplitTest(int[] numbers, int[] correctLeft, int[] correctRight)
        {
            var result = TheMergeSort<int>.Split(numbers.ToList());
            Assert.Equal(result.Right, correctRight.ToList());
            Assert.Equal(result.Left, correctLeft.ToList());
        }

        [Theory]
        [InlineData(new int[] { 1, 3, 5, 4, 6, 8, 2, 7 })]
        public void SortTest(int[] numbers)
        {
            var result = TheMergeSort<int>.Sort(numbers.ToList());
           
            List<int> correctOrder =numbers.ToList();
            correctOrder.Sort();
            Assert.Equal(result, correctOrder);
        }

        [Fact]
        public void StressTest()
        {
            for (int i = 0; i < 100; i++)
            {
                List<int> list = new List<int>();
                for (int j = 0; j < 100; j++)
                {
                    list.Add(Random.Shared.Next(0, 100));
                }
                var sorted=TheMergeSort<int>.Sort(list);
                list.Sort();
                Assert.Equal(sorted, list);
            }
        }
    }
}