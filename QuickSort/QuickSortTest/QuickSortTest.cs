using Microsoft.VisualStudio.TestPlatform.Utilities;
using QuickSort;

namespace TheQuickSortTesting
{
    public class QuickSortTest
    {
        [Theory]
        [InlineData(new int[] { 7, 4, 3, 6, 2, 1, 5})]
        [InlineData(new int[] { 7, 0, 0, 0})]
        [InlineData(new int[] { 6, 27, 58, 26, 61})]
        public void LomutoSortTest(int[] arr)
        {
            int[] temp = new int[arr.Length];
            Array.Copy(arr, temp, arr.Length);

            TheQuickSort<int>.LomutoSort(arr, 0, arr.Length - 1);

            Array.Sort(temp);
            Assert.True(temp.SequenceEqual(arr));
        }

        [Theory]
        [InlineData(new int[] { 7, 4, 3, 6, 2, 1, 5 })]
        [InlineData(new int[] { 7, 0, 0, 0 })]
        [InlineData(new int[] { 6, 27, 58, 26, 61 })]
        [InlineData(new int[] { 85, 60, 69, 92, 28, 23, 85, 11, 17, 1})]
        public void HoareSortTest(int[] arr)
        {
            int[] temp = new int[arr.Length];
            Array.Copy(arr, temp, arr.Length);

            TheQuickSort<int>.HoareSort(arr, 0, arr.Length - 1);

            Array.Sort(temp);
            Assert.True(temp.SequenceEqual(arr));
        }

        [Fact]
        public void StressTest()
        {
            for (int i = 0; i < 100; i++)
            {
                int[] og = new int[10];
                for (int j = 0; j < 10; j++)
                {
                    og[j] = Random.Shared.Next(0, 100);
                }
                int[] output = new int[10];
                Array.Copy(og, output, og.Length);
                TheQuickSort<int>.HoareSort(output, 0, 9);

                for (int j = 0; j < 9; j++)
                {
                    Assert.True(output[j] <= output[j+1]);
                }
            }
        }
    }
}