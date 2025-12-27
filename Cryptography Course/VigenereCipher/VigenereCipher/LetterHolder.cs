namespace VigenereCipher
{
    class LetterHolder : IComparable<LetterHolder>
    {
        public char letter { get; set; }
        public int letterNumber { get; set; }
        public int index { get; set; }

        public LetterHolder(char letter, int index)
        {
            this.letter = letter;
            this.letterNumber = (int)letter - 65;
            this.index = index;
        }

        public int CompareTo(LetterHolder other) => letterNumber.CompareTo(other.letterNumber);
    }
}
