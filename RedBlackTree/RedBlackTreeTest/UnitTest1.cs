using RedBlackTree;

namespace RedBlackTreeTest
{
    public class UnitTest1
    {
        [Fact]
        public void SimpleInsertTest()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(1);
            tree.Insert(2);

            Assert.True(tree.Contains(1));
            Assert.True(tree.Contains(2));
        }

        [Fact]
        public void RandomInsertTest()
        {
            RBTree<int> tree = new RBTree<int>();
            List<int> values = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                int value = Random.Shared.Next(1, 100);
                values.Add(value);
                tree.Insert(value);
            }
            foreach (int value in values)
            {
                Assert.True(tree.Contains(value));
            }
        }

        [Fact]
        public void SimpleRemoveTest()
        {
            RBTree<int> tree = new RBTree<int>();
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);

            tree.Remove(2);
            Assert.False(tree.Contains(2));
            Assert.True(tree.Contains(1));
            Assert.True(tree.Contains(3));
        }

        [Fact]
        public void RandomRemoveTest()
        {
            RBTree<int> tree = new RBTree<int>();
            List<int> values = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                int value = Random.Shared.Next(1, 100);
                values.Add(value);
                tree.Insert(value);
            }
            foreach (int value in values)
            {
                tree.Remove(value);
                Assert.False(tree.Contains(value));
            }
        }
    }
}
