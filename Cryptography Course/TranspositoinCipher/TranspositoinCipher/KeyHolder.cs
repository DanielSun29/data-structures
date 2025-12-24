namespace TranspositoinCipher
{
    class KeyHolder : IComparable<KeyHolder>
    {
        public char letter { get; set; }
        public int letterNumber { get; set; }
        public int index { get; set; }

        public KeyHolder(char letter, int index)
        {
            this.letter = letter;
            this.letterNumber = (int)letter - 65;
            this.index = index;
        }

        public int CompareTo(KeyHolder other) => letterNumber.CompareTo(other.letterNumber);
    }
}
