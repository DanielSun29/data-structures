using HuffmanCoding;

namespace HuffmanCodingTest
{
    public class UnitTest1
    {
        [Fact]
        public void HuffmanCodingTest1()
        {
            string input = "hello huffman";
            HuffmanAlgo algo = new HuffmanAlgo(input);
            byte[] encodedData = algo.Encode(input);
            string decodedData = algo.Decode(encodedData);
            Assert.Equal(input, decodedData);
        }

        [Fact]
        public void HuffmanCodingTest2()
        {
            string input = "Historically speaking, computers used something known as ASCII (American Standard Code for Information Interchange) which uses numbers to represent characters. ASCII uses 7 bits (128 total values) to represent a range of useful characters such as the alphabet, numeric digits, special characters, and so on. More modern encodings use more bits (like 8, 16, or even 32), but the basic idea still stands: we can use numbers to represent characters.";
            HuffmanAlgo algo = new HuffmanAlgo(input);
            byte[] encodedData = algo.Encode(input);
            string decodedData = algo.Decode(encodedData);
            Assert.Equal(input, decodedData);
        }
    }
}
