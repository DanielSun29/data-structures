using SortedDoublyLinkedList;

namespace SDLLTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(6, 7, 8, 9, 0, 1, 2, 3, 4, 5)]
        public void AddTest(params int[] arr)
        {
            SortedDoublyLinkedList.List<int> list = new SortedDoublyLinkedList.List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                list.Add(arr[i]);
                Assert.True(list.Contains(arr[i]));
                Assert.True(list.IsSorted());
            }
        }

        [Theory]
        [InlineData(6, 7, 8, 9, 0, 1, 2, 3, 4, 5)]
        public void RemoveTest(params int[] arr)
        {
            SortedDoublyLinkedList.List<int> list = new SortedDoublyLinkedList.List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                list.Add(arr[i]);
                Assert.True(list.Contains(arr[i]));
                Assert.True(list.IsSorted());
            }
            for (int i = 0; i < arr.Length; i++)
            {
                list.Remove(arr[i]);
                Assert.False(list.Contains(arr[i]));
            }
        }
    }
}
