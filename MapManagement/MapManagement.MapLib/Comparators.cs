using System;
using System.Collections.Generic;

namespace MapManagement.MapLib
{
    public class LeafComparerX : IComparer<Leaf>
    {
        public int Compare(Leaf firstLeaf, Leaf secondLeaf)
        {
            if (firstLeaf.Location.x>secondLeaf.Location.x)
            {
                return 1;
            }else if(firstLeaf.Location.x<secondLeaf.Location.x)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
    public class LeafComparerY : IComparer<Leaf>
    {
        public int Compare(Leaf firstLeaf, Leaf secondLeaf)
        {
            if (firstLeaf.Location.y>secondLeaf.Location.y)
            {
                return 1;
            }else if(firstLeaf.Location.y<secondLeaf.Location.y)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}