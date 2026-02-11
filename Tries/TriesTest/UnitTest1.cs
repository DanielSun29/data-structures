namespace TriesTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("cat", "car", "dog")]
        public void SearchTest(params string[] words)
        {
            Tries.Trie trie = new Tries.Trie();
            foreach (string word in words)
            {
                trie.Insert(word);
            }
            foreach (string word in words)
            {
                Assert.True(trie.Contains(word));
            }
            Assert.False(trie.Contains("Bobby"));
            foreach (string word in words)
            {
                trie.Remove(word);
            }
            foreach (string word in words)
            {
                Assert.False(trie.Contains(word));
            }
        }

        [Theory]
        [InlineData("cat", "car", "dog")]
        public void AddTest(params string[] words)
        {
            Tries.Trie trie = new Tries.Trie();
            foreach (string word in words)
            {
                trie.Insert(word);
            }
            foreach (string word in words)
            {
                Assert.True(trie.Contains(word));
            }
        }

        [Theory]
        [InlineData("cat", "car", "dog")]
        public void GetAllMatchingPrefixTest(params string[] words)
        {
            Tries.Trie trie = new Tries.Trie();
            foreach (string word in words)
            {
                trie.Insert(word);
            }
            List<string> matchingPrefix = trie.GetAllMatchingPrefix("ca");
            Assert.Contains("cat", matchingPrefix);
            Assert.Contains("car", matchingPrefix);
            Assert.DoesNotContain("dog", matchingPrefix);
        }

        [Theory]
        [InlineData("cat", "car", "dog")]
        public void RemoveTest(params string[] words)
        {
            Tries.Trie trie = new Tries.Trie();
            foreach (string word in words)
            {
                trie.Insert(word);
            }
            foreach (string word in words)
            {
                trie.Remove(word);
            }
            foreach (string word in words)
            {
                Assert.False(trie.Contains(word));
            }
        }

        [Theory]
        [InlineData("cat", "car", "dog")]
        public void ClearTest(params string[] words)
        {
            Tries.Trie trie = new Tries.Trie();
            foreach (string word in words)
            {
                trie.Insert(word);
            }
            trie.Clear();
            foreach (string word in words)
            {
                Assert.False(trie.Contains(word));
            }
        }
    }
}
