namespace NaryHuffman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Huffman
    {
        private readonly int n;
        private Queue<TreeNode> queue1 = new Queue<TreeNode>();
        private Queue<TreeNode> queue2 = new Queue<TreeNode>();
        private IDictionary<string, string> codes = new Dictionary<string, string>();

        public Huffman(int n)
        {
            this.n = n;
        }

        public IDictionary<string, string> GetCodes(IDictionary<string, double> symbolsAndFrequencies)
        {
            if (!symbolsAndFrequencies.Any())
            {
                return new Dictionary<string, string>();
            }

            if (symbolsAndFrequencies.Count == 1)
            {
                return symbolsAndFrequencies.ToDictionary(x => x.Key, x => "0");
            }

            while (n > 2 && symbolsAndFrequencies.Count % (n - 1) != 1)
            {
                symbolsAndFrequencies.Add(Guid.NewGuid().ToString(), 0);
            }

            foreach (var pair in symbolsAndFrequencies.OrderBy(x => x.Value))
            {
                var leaf = new TreeNode(pair.Key, pair.Value);
                queue1.Enqueue(leaf);
            }

            while (queue1.Count + queue2.Count > 1)
            {
                var smallests = new List<TreeNode>();
                for (int i = 0; i < n; ++i)
                {
                    smallests.Add(GetSmallestNode());
                }

                var parent = new TreeNode(smallests);
                queue2.Enqueue(parent);
            }

            var root = GetSmallestNode();

            GenerateCodeFromTree(root, string.Empty);
            return codes;
        }

        private void GenerateCodeFromTree(TreeNode node, string path)
        {
            if (node.IsLeaf)
            {
                codes[node.Symbol] = path;
            }
            else
            {
                for (int i = 0; i < node.Children.Count; ++i)
                {
                    GenerateCodeFromTree(node.Children[i], path + i);
                }
            }
        }

        private TreeNode GetSmallestNode()
        {
            TreeNode x;
            if (queue1.Any() && queue2.Any())
            {
                if (queue1.Peek().Frequency < queue2.Peek().Frequency)
                {
                    x = queue1.Dequeue();
                }
                else
                {
                    x = queue2.Dequeue();
                }
            }
            else if (queue1.Any())
            {
                x = queue1.Dequeue();
            }
            else
            {
                x = queue2.Dequeue();
            }

            return x;
        }
    }
}