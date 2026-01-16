using HeapTree;

namespace HeapTreeTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(20, 5, 10, 3)]
        public void InsertTest(params int[] numbers)
        {
            var tree = new HeapTree.Tree<int>(10);
            for (int i = 0; i < numbers.Length; i++)
            {
                tree.Insert(numbers[i]);
            }
            Assert.True(ValidateHeap(tree, 0));
        }

        [Theory]
        [InlineData(20, 5, 10, 3)]
        public void PopTest(params int[] numbers)
        {
            var tree = new HeapTree.Tree<int>(10);
            for (int i = 0; i < numbers.Length; i++)
            {
                tree.Insert(numbers[i]);
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                tree.Pop();
                Assert.True(ValidateHeap(tree, 0));
            }
        }

        [Theory]
        [InlineData(new int[] { 7, 4, 3, 6, 2, 1, 5 })]
        [InlineData(new int[] { 7, 0, 0, 0 })]
        [InlineData(new int[] { 6, 27, 58, 26, 61 })]
        [InlineData(new int[] { 85, 60, 69, 92, 28, 23, 85, 11, 17, 1 })]
        public void HeapSortTest(int[] arr)
        {
            int[] temp = new int[arr.Length];
            Array.Copy(arr, temp, arr.Length);

            int[] sorted = Tree<int>.Sort(temp);

            Array.Sort(temp);
            Assert.True(temp.SequenceEqual(sorted));
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
                int[] output = Tree<int>.Sort(og);

                for (int j = 0; j < 9; j++)
                {
                    Assert.True(output[j] <= output[j + 1]);
                }
            }
        }

        // Helper method to validate the heap property
        bool ValidateHeap(HeapTree.Tree<int> tree, int index)
        {
            if (index >= tree.size)
            {
                return true;
            }
            if (2 * index + 1 < tree.size && tree.heap[index] > tree.heap[2 * index + 1])
            {
                return false;
            }
            if (2 * index + 2 < tree.size && tree.heap[index] > tree.heap[2 * index + 2])
            {
                return false;
            }
            return ValidateHeap(tree, 2 * index + 1) && ValidateHeap(tree, 2 * index + 2);
        }

        [Fact]
        public void MoreInsertTest()
        {
            for (int i = 0; i < 100; i++)
            {
                HeapTree.Tree<int> tree = new HeapTree.Tree<int>(5); // This is small to force resizing
                for (int j = 0; j < 100; j++)
                {
                    tree.Insert(new Random().Next(0, 100));
                }
                Assert.True(ValidateHeap(tree, 0));
            }
        }

        [Fact]
        public void MorePopTest()
        {
            for (int i = 0; i < 100; i++)
            {
                HeapTree.Tree<int> tree = new HeapTree.Tree<int>(5);
                for (int j = 0; j < 100; j++)
                {
                    tree.Insert(new Random().Next(0, 100));
                }
                for (int j = 0; j < 100; j++)
                {
                    tree.Pop();
                    Assert.True(ValidateHeap(tree, 0));
                }
            }
        }
    }
}