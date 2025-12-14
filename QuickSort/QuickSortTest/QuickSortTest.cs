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
                int[] og = new int[100];
                for (int j = 0; j < 100; j++)
                {
                    og[j] = Random.Shared.Next(0, 100);
                }
                int[] output = new int[100];
                Array.Copy(og, output, og.Length);
                TheQuickSort<int>.LomutoSort(output, 0, 99);

                for (int j = 0; j < 99; j++)
                {
                    Assert.True(output[j] <= output[j+1]);
                }
            }
        }
    }
}