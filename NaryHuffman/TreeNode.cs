namespace NaryHuffman
{
    using System.Collections.Generic;
    using System.Linq;

    public class TreeNode
    {
        public TreeNode(string symbol, double frequency)
        {
            IsLeaf = true;
            Symbol = symbol;
            Frequency = frequency;
        }

        public TreeNode(IList<TreeNode> children)
        {
            IsLeaf = false;
            Frequency = children.Sum(x => x.Frequency);
            Children = children;
        }

        public double Frequency { get; set; }
        public string Symbol { get; set; }
        public bool IsLeaf { get; set; }
        public IList<TreeNode> Children { get; set; }
    }
}