namespace NaryHuffman.UnitTests
{
    using System.Collections.Generic;
    using Xunit;

    public class HuffmanTests
    {
        [Fact]
        public void Binary_NoSymbols_ReturnEmpty()
        {
            var huffman = new Huffman(2);

            var codes = huffman.GetCodes(new Dictionary<string, double>());

            Assert.Empty(codes);
        }

        [Fact]
        public void Binary_OneSymbol_ReturnCode()
        {
            var huffman = new Huffman(2);

            var codes = huffman.GetCodes(new Dictionary<string, double> { { "A", 1 } });

            Assert.Equal(1, codes["A"].Length);
        }

        [Fact]
        public void Binary_ThreeSymbols_ReturnMostUsedSymbolWithShortestCode()
        {
            var huffman = new Huffman(2);

            var codes = huffman.GetCodes(new Dictionary<string, double> { { "A", 1 }, { "B", 0.5 }, { "C", 0.5 } });

            Assert.Equal(1, codes["A"].Length);
            Assert.Equal(2, codes["B"].Length);
            Assert.Equal(2, codes["C"].Length);
        }

        [Fact]
        public void Ternary_ThreeSymbols_ReturnShortestCodes()
        {
            var huffman = new Huffman(3);

            var codes = huffman.GetCodes(new Dictionary<string, double> { { "A", 1 }, { "B", 0.5 }, { "C", 0.5 } });

            Assert.Equal(1, codes["A"].Length);
            Assert.Equal(1, codes["B"].Length);
            Assert.Equal(1, codes["C"].Length);
        }

        [Theory]
        [InlineData(3, 2, 3)]
        [InlineData(4, 2, 4)]
        [InlineData(4, 20, 22)]
        public void Nary_NotEnoughSymbols_FillsWithGarbage(int n, int inputSize, int outputSize)
        {
            var symbols = new Dictionary<string, double>();
            for (int i = 0; i < inputSize; ++i)
            {
                symbols[i.ToString()] = 1;
            }

            var huffman = new Huffman(n);
            var codes = huffman.GetCodes(symbols);

            Assert.Equal(outputSize, codes.Count);
        }
    }
}