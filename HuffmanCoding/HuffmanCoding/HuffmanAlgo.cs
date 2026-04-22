using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace HuffmanCoding
{
    public class HuffmanAlgo
    {
        PriorityQueue<Node, int> priorityQueue;

        Dictionary<char, int> frequencies;

        Node Tree;

        public HuffmanAlgo(string text)
        {
            priorityQueue = new PriorityQueue<Node, int>();
            frequencies = new Dictionary<char, int>();
            frequencies = GetFrequencies(text);
        }

        private Dictionary<char, int> GetFrequencies(string input)
        {
            Dictionary<char, int> frequencies = new Dictionary<char, int>();
            foreach (char c in input)
            {
                if (frequencies.ContainsKey(c))
                {
                    frequencies[c]++;
                }
                else
                {
                    frequencies[c] = 1;
                }
            }
            return frequencies;
        }

        public Dictionary<char, byte[]> BuildHuffmanTree(Dictionary<char, int> frequencies) // Builds the huffman tree and generates the huffman codes for each character in the input string
        {
            foreach (var kvp in frequencies)
            {
                priorityQueue.Enqueue(new Node(kvp.Key, kvp.Value), kvp.Value);
            }
            while (priorityQueue.Count > 1)
            {
                var left = priorityQueue.Dequeue();
                var right = priorityQueue.Dequeue();
                var mergedNode = new Node('\0', left.Frequency + right.Frequency)
                {
                    Left = left,
                    Right = right
                };
                priorityQueue.Enqueue(mergedNode, mergedNode.Frequency);
            }
            var root = priorityQueue.Dequeue();

            Tree = root;

            var huffmanCodes = GenerateHuffmanCodes(root, new List<byte>());
            return huffmanCodes;
        }

        private Dictionary<char, byte[]> GenerateHuffmanCodes(Node node, List<byte> currentCode) // recursive function to generate huffman codes with a tree
        {
            var huffmanCodes = new Dictionary<char, byte[]>();
            if (node.Left == null && node.Right == null)
            {
                huffmanCodes[node.Character] = currentCode.ToArray();
                return huffmanCodes;
            }
            if (node.Left != null)
            {
                List<byte> leftCode = [.. currentCode, 0]; // everything from currentCode + 0 for left
                foreach (var kvp in GenerateHuffmanCodes(node.Left, leftCode))
                {
                    huffmanCodes[kvp.Key] = kvp.Value;
                }
            }
            if (node.Right != null)
            {
                List<byte> rightCode = [.. currentCode, 1];
                foreach (var kvp in GenerateHuffmanCodes(node.Right, rightCode))
                {
                    huffmanCodes[kvp.Key] = kvp.Value;
                }
            }
            return huffmanCodes;
        }

        // Encoding and Decoding

        public byte[] Encode(string input) => Encode(input, BuildHuffmanTree(GetFrequencies(input)));
        private byte[] Encode(string input, Dictionary<char, byte[]> huffmanCodes)
        {
            List<byte> encodedData = new List<byte>();
            foreach (char c in input)
            {
                if (huffmanCodes.TryGetValue(c, out byte[] code))
                {
                    encodedData.AddRange(code);
                }
                else
                {
                    throw new Exception("Char not in dictionary");
                }
            }
            return encodedData.ToArray();
        }

        public string Decode(byte[] encodedData) => Decode(encodedData, BuildHuffmanTree(frequencies));
        public string Decode(byte[] encodedData, Dictionary<char, byte[]> huffmanCodes)
        {
            StringBuilder decodedString = new StringBuilder();
            List<byte> currentCode = encodedData.ToList();
            Node curr = Tree;
            foreach (var c in currentCode)
            {
                if (c == 0)
                {
                    curr = curr.Left;
                }
                else
                {
                    curr = curr.Right;
                }
                if (curr.Left is null && curr.Right is null)
                {
                    decodedString.Append(curr.Character);
                    curr = Tree;
                }
            }

            return decodedString.ToString();
        }
    }
}
