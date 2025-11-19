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
        []
    }
}