using System;
using System.Collections.Generic;
using System.Linq;

namespace MapManagement.MapLib
{
    public class Branch : Node
    {
        public Rectangle Rect
        {
            get => _rectangle;
            // set { _rectangle = value; }
        }

        public double RectangleShape => _rectangle.Shape;
        private static int _maxChild = 10;
        private static int _minChild = 4;
        private List<Node> _childs;
        private Branch _mother;
        private Rectangle _rectangle;

        public Branch(List<Node> childs, Branch mother, Rectangle rectangle)
        {
            _childs = childs;
            _mother = mother;
            _rectangle = rectangle;
        }

        public Branch()
        {
            _childs = new List<Node>();
        }

        public Branch(Branch mother, Rectangle rectangle)
        {
            _mother = mother;
            _rectangle = rectangle;
        }

        public override string GetNodeType()
        {
            if (_childs.Count == 0 || _childs[0].GetNodeType() == "Leaf")
            {
                return "PreBranch";
            }

            return "Branch";
        }

        public List<Node> GetChilds()
        {
            return _childs;
        }

        public void RefindShape(double x, double y)
        {
            if (_rectangle == null)
            {
                InitRectangle(x, y);
            }
            else
            {
                Rect.AddDot(x, y);
            }
        }

        public void AddChild(Location location)
        {
            AddChild(new Leaf(this, location));
        }

        public void AddChild(Node node)
        {
            _childs.Add(node);
            if (_childs.Count > _maxChild)
            {
                DivideBranch();
            }
        }

        public void DivideBranch()
        {
            char axis = ChooseSplitAxis();
            Leaf[] sortedLeaf = GetChilds().Select(node => (Leaf) node).ToArray();
            if (axis == 'x')
            {
                Array.Sort(sortedLeaf, new LeafComparerX());
            }
            else
            {
                Array.Sort(sortedLeaf, new LeafComparerY());
            }

            int splitIndex = ChooseSplitIndex(sortedLeaf);
            Branch firstChild = new Branch();
            Branch secondChild = new Branch();
            for (int i = 0; i < sortedLeaf.Length; i++)
            {
                if (i<splitIndex)
                {
                    firstChild.AddChild(sortedLeaf[i]);
                }
                else
                {
                    secondChild.AddChild(sortedLeaf[i]);
                }
            }

            _childs = new List<Node> {firstChild, secondChild};
        }

        private void InitRectangle(double x, double y)
        {
            _rectangle = new Rectangle(x, x, y, y);
        }

        private char ChooseSplitAxis()
        {
            if (MinMarginDiv(new LeafComparerX()) < MinMarginDiv(new LeafComparerY()))
            {
                return 'x';
            }
            else
            {
                return 'y';
            }
        }

        private int ChooseSplitIndex(Leaf[] sortedLeaf)
        {
            int k = _maxChild - 2 * _minChild + 2;
            double[] overlapShapes = new double[k];
            double[] shapes = new double[k];
            for (int i = 1; i <= k; i++)
            {
                Rectangle rectangle1 = new Rectangle();
                Rectangle rectangle2 = new Rectangle();
                for (int j = 0; j < sortedLeaf.Length; j++)
                {
                    if (j < _minChild - 1 + i)
                    {
                        rectangle1.AddDot(sortedLeaf[j].Location.x, sortedLeaf[j].Location.y);
                    }
                    else
                    {
                        rectangle2.AddDot(sortedLeaf[j].Location.x, sortedLeaf[j].Location.y);
                    }
                }

                overlapShapes[i - 1] = Rectangle.CheckOverlapShape(rectangle1, rectangle2);
                shapes[i - 1] = rectangle1.Shape + rectangle2.Shape;
            }

            (double minOverlap, int splitIndex) = MinOfArray(overlapShapes);
            int repeatedMinOverlap = 0;
            for (int i = 0; i < overlapShapes.Length; i++)
            {
                if (overlapShapes[i] == minOverlap)
                {
                    repeatedMinOverlap++;
                }
            }

            if (repeatedMinOverlap == 1)
            {
                return splitIndex + _minChild;
            }
            else
            {
                (_, splitIndex) = MinOfArray(shapes);
                return splitIndex + _minChild;
            }
        }

        private double MinMarginDiv(IComparer<Leaf> comparer)
        {
            int k = _maxChild - 2 * _minChild + 2;
            Leaf[] sorted = GetChilds().Select(node => (Leaf) node).ToArray();
            Array.Sort(sorted, comparer);
            double[] S = new double[k];
            for (int i = 1; i <= k; i++)
            {
                Rectangle rectangle1 = new Rectangle();
                Rectangle rectangle2 = new Rectangle();
                for (int j = 0; j < sorted.Length; j++)
                {
                    if (j < _minChild - 1 + i)
                    {
                        rectangle1.AddDot(sorted[j].Location.x, sorted[j].Location.y);
                    }
                    else
                    {
                        rectangle2.AddDot(sorted[j].Location.x, sorted[j].Location.y);
                    }
                }

                S[i - 1] = rectangle1.Margin + rectangle2.Margin;
            }

            (double result, _) = MinOfArray(S);
            return result;
        }

        private (double, int) MinOfArray(double[] array)
        {
            double min = array[0];
            int minId = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    minId = i;
                }
            }

            return (min, minId);
        }
    }
}