using B_Tree;

namespace BTreeTest
{
    public class UnitTest1
    {
        [Fact]
        public void InsertTest()
        {
            TheBTree<int> bTree = new TheBTree<int>();
            for (int i = 0; i < 100; i++)
            {
                bTree.Insert(i);
                Assert.True(bTree.contains(i));
            }    
        }

        [Fact]
        public void RandomInsertTest()
        {
            TheBTree<int> bTree = new TheBTree<int>();
            for (int i = 0; i < 10; i++)
            {
                int value = Random.Shared.Next();
                bTree.Insert(value);
                Assert.True(bTree.contains(value));
            }
            ;
        }
    }
}
