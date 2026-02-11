namespace Tries
{
    public class Trie
    {
        public Node root;
        public void Clear()
        {
            root = null;
        }// Delete all data in the Trie

        public void Insert(string word)
        {
            if (root == null)
            {
                root = new Node(word[0]);
            }
            Node currentNode = root;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (!currentNode.Children.ContainsKey(c))
                {
                    currentNode.Children[c] = new Node(c);
                }
                currentNode = currentNode.Children[c];
            }
            currentNode.IsWord = true;
        }// Add a word to the Trie   

        public Node SearchNode(string prefix)
        {
            Node currentNode = root;
            for (int i = 0; i < prefix.Length; i++)
            {
                char c = prefix[i];
                if (!currentNode.Children.ContainsKey(c))
                {
                    return null;
                }
                currentNode = currentNode.Children[c];
            }
            return currentNode;
        }// Find the node at the end of this prefix. Use this function WHENEVER you need to find a node.

        public bool Contains(string word)
        {
            if (root == null)
            {
                return false;
            }
            Node node = SearchNode(word);
            return null != node && node.IsWord;
        }// Return if a given word exists (use SearchNode)

        public List<string> GetAllMatchingPrefix(string prefix)
        {
            Node node = SearchNode(prefix);

            List<string> words = new List<string>();

            if (node != null)
            {
                GetAllWords(node, prefix, words);
            }

            return words;
        }// Get every word after a given prefix

        private void GetAllWords(Node node, string prefix, List<string> words)
        {
            if (node.IsWord)
            {
                words.Add(prefix);
            }
            foreach (var child in node.Children)
            {
                GetAllWords(child.Value, prefix + child.Key, words);
            }
        }

        public bool Remove(string word)
        {
            if (root == null)
            {
                return false;
            }
            Node node = SearchNode(word);
            if (node != null && node.IsWord)
            {
                node.IsWord = false;
                root = ClearExtraNodes(root);
                return true;
            }
            return false;
        }// Remove a given word if it exists, and return if you found it

        /// <summary>
        /// Clears out any nodes that are no longer needed after a word is removed. If a node has no children and is not a word, it can be removed.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Node ClearExtraNodes(Node node)
        {
            if (node == null)
            {
                return null;
            }
            if (node.Children.Count == 0 && !node.IsWord)
            {
                return null;
            }
            foreach (var child in node.Children)
            {
                node.Children[child.Key] = ClearExtraNodes(child.Value);
            }
            return node;
        }
    }
}
