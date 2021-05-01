using System.Collections.Generic;

namespace MapManagement.MapLib
{
    public class LeafComparerX : IComparer<Leaf>
    {
        public int Compare(Leaf firstLeaf, Leaf secondLeaf)
        {
            return firstLeaf.Location.x.CompareTo(secondLeaf.Location.x);
        }
    }

    public class LeafComparerY : IComparer<Leaf>
    {
        public int Compare(Leaf firstLeaf, Leaf secondLeaf)
        {
            return firstLeaf.Location.y.CompareTo(secondLeaf.Location.y);
        }
    }
}