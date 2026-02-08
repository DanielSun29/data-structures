namespace SkipListTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, 4, 2, 3, 5, 6, 8, 7, 9)]
        public void InsertTest(params int[] arr)
        {
            SkipList.SkipList<int> list = new SkipList.SkipList<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                list.Insert(arr[i]);
                Assert.True(list.Contains(arr[i]));
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.True(list.Contains(arr[i]));
            }
        }

        [Theory]
        [InlineData(1, 4, 2, 3, 5, 6, 8, 7, 9)]
        public void RemoveTest(params int[] arr)
        {
            SkipList.SkipList<int> list = new SkipList.SkipList<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                list.Insert(arr[i]);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.True(list.Contains(arr[i]));
            }
            for (int i = 0; i < arr.Length; i++)
            {
                list.Remove(arr[i]);
                Assert.False(list.Contains(arr[i]));
            }
        }
    }
}