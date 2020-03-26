namespace NaryHuffman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var huffman = new Huffman(4);

            var enzymes = new Dictionary<string, double>
            {
                { "Alanine", 7.4 },
                { "Arginine", 4.2 },
                { "Asparagine", 4.4 },
                { "Aspartic Acid", 5.9 },
                { "Cystine", 3.3 },
                { "Glutamic Acid", 5.8 },
                { "Glutamine", 3.7 },
                { "Glycine", 7.4 },
                { "Histidine", 2.9 },
                { "Isoleucine", 3.8 },
                { "Leucine", 7.5 },
                { "Lysine", 7.2 },
                { "Methionine", 1.8 },
                { "Phenylalanine", 4 },
                { "Proline", 5 },
                { "Serine", 8 },
                { "Threonine", 6.2 },
                { "Tryptophan", 1.3 },
                { "Tyrosine", 3.3 },
                { "Valine", 6.8 },
                { "Stop codons", 0.1 },
            };

            var codes = huffman.GetCodes(enzymes);

            double averageCodeLength = codes.Sum(x => x.Value.Length * enzymes[x.Key]) / enzymes.Values.Sum();
            double compressionRate = (3 - averageCodeLength) / 3;

            foreach (var code in codes.OrderBy(x => x.Value))
            {
                Console.WriteLine($"{code.Key}\t{code.Value}");
            }

            Console.WriteLine($"Weighted avg. length: {averageCodeLength}, compressions rate: {compressionRate}");
        }
    }
}