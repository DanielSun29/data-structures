using AVLTree;

namespace AVLTreeTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(5, 2, 4, 6, 8, 10)]
        public void InsertTest(params int[] numbers)
        {
            Tree<int> avltree = new Tree<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                avltree.Insert(numbers[i]);
                Assert.True(avltree.Contains(numbers[i]));
            }
        }

        [Theory]
        [InlineData(5, 2, 4, 6, 8, 10)]
        [InlineData(1, 4, 2)]
        public void RotationTest(params int[] numbers)
        {
            Tree<int> avltree = new Tree<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                avltree.Insert(numbers[i]);
            }
            Assert.True(avltree.IsBalanced());
        }

        [Theory]
        [InlineData(5, 2, 7, 4, 6, 8, 10)]
        public void RemovalTest(params int[] numbers)
        {
            Tree<int> avltree = new Tree<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                avltree.Insert(numbers[i]);
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                Assert.True(avltree.Contains(numbers[i]));
                avltree.Remove(numbers[i]);
                if (avltree.count != 0) Assert.False(avltree.Contains(numbers[i]));
            }
        }

        [Fact]
        public void TestForEverything()
        {
            Tree<int> avltree = new Tree<int>();
            int[] numbers = { 50, 25, 75, 12, 37, 62, 87 };
            for (int i = 0; i < numbers.Length; i++)
            {
                avltree.Insert(numbers[i]);
                Assert.True(avltree.Contains(numbers[i]));
                Assert.True(avltree.IsBalanced());
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                Assert.True(avltree.Contains(numbers[i]));
                avltree.Remove(numbers[i]);
                if (avltree.count != 0)
                {
                    Assert.False(avltree.Contains(numbers[i]));
                }
                Assert.True(avltree.IsBalanced());
            }
        }

        //[Theory]
        //[InlineData(1, 2, 3, 4, 5, 6)]
        //public void LevelOrderTest(params int[] numbers)
        //{
        //    Tree<int> avltree = new Tree<int>();
        //    for (int i = 0; i < numbers.Length; i++)
        //    {
        //        avltree.Insert(numbers[i]);
        //    }
        //    var levelOrder = avltree.LevelOrder();
        //    List<int> expected = new List<int> { 4, 2, 5, 1, 3, 6 };
        //    Assert.Equal(expected, levelOrder);
        //}
    }
}
