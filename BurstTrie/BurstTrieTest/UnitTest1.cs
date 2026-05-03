using BurstTrie;

namespace BurstTrieTest
{
    public class UnitTest1
    {
        [Fact]
        public void AddTest()
        {
            TheBurstTrie trie = new TheBurstTrie();
            trie.Add("Hello");
            Assert.True(trie.Contains("Hello"));
        }

        [Fact]
        public void RemoveTest()
        {
            TheBurstTrie trie = new TheBurstTrie();
            trie.Add("Hello");
            Assert.True(trie.Contains("Hello"));
            trie.Add("World");
            Assert.True(trie.Remove("Hello"));
            Assert.False(trie.Contains("Hello"));
            Assert.True(trie.Contains("World"));
        }

        [Fact]
        public void GetAllTest()
        {
            TheBurstTrie trie = new TheBurstTrie();
            trie.Add("Hello");
            trie.Add("World");
            trie.Add("Hi");
            trie.Add("Helloween");

            List<string> allItems = trie.GetAll();
            Assert.True(allItems.Contains("hello"));
            Assert.True(allItems.Contains("world"));
            Assert.True(allItems.Contains("hi"));
            Assert.True(allItems.Contains("helloween"));
        }
    }
}
