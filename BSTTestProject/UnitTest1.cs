using BST;

namespace BSTTestProject
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(2, 4, 6, 8, 10)]
        public void InsertTest(params int[] numbers)
        {
            BST<int> bst = new BST<int>(5);
            for (int i = 0; i < numbers.Length; i++)
            {
                bst.Insert(numbers[i]);
                Assert.True(bst.Contains(numbers[i]));
            }
        }

        [Theory]
        [InlineData(2, 4, 6, 8, 10)]
        public void ContainsTest(params int[] numbers)
        {
            BST<int> bst = new BST<int>(5);
            for (int i = 0; i < numbers.Length; i++)
            {
                bst.Insert(numbers[i]);
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                Assert.True(bst.Contains(numbers[i]));
            }
            Assert.False(bst.Contains(100)); // Test for a number not in the BST
        }

        [Theory]
        [InlineData(2, 4, 6, 8, 10)]
        public void NullInsertTest(params int[] numbers)
        {
            BST<string> bst = new BST<string>("5");
            foreach (var number in numbers)
            {
                bst.Insert(number.ToString());
            }
            Assert.Throws<ArgumentNullException>(() => bst.Insert(null));
        }

        [Theory]
        [InlineData(2, 4, 6, 8, 10)]
        public void CountTest(params int[] numbers)
        {
            BST<int> bst = new BST<int>(5);
            for (int i = 0; i < numbers.Length; i++)
            {
                bst.Insert(numbers[i]);
            }
            Assert.Equal(numbers.Length + 1, bst.count); // +1 for the root node
        }

        [Theory]
        [InlineData(2, 4, 6, 8, 10)]
        public void InOrderTraversalTest(params int[] numbers)
        {
            BST<int> bst = new BST<int>(5);
            for (int i = 0; i < numbers.Length; i++)
            {
                bst.Insert(numbers[i]);
            }
            var traversalResult = bst.InOrder();
            var expected = new List<int>(numbers);
            expected.Add(5); // Adding the root value
            expected.Sort();
            Assert.Equal(expected, traversalResult);
        }

        [Theory]
        [InlineData(new int[] { 5,2,6,4,8,10},2, 4, 6, 8, 10)]
        public void LevelOrderTraversalTest(int[] correctOrder,params int[] numbers)
        {
            BST<int> bst = new BST<int>(5);
            for (int i = 0; i < numbers.Length; i++)
            {
                bst.Insert(numbers[i]);
            }
            var traversalResult = bst.LevelOrder();
            Assert.Equal(correctOrder, traversalResult);
        }
    }
}