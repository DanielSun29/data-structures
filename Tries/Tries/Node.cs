using System;
using System.Collections.Generic;
using System.Text;

namespace Tries
{
    public class Node
    {
        public char Letter { get; private set; } // The letter of the current node
        public Dictionary<char, Node> Children { get; private set; } // All known continuations from the current letter in the current prefix keyed off their beginning letters
        public bool IsWord { get; set; } // Whether or not the current node is at the end of a word

        public Node(char c)
        {
            Children = new Dictionary<char, Node>();
            Letter = c;
            IsWord = false;
        }
    }
}
