using System;
using System.Collections.Generic;
using System.Linq;

namespace MapManagement.MapLib
{
    public class Branch : Node
    {
        public Rectangle Rectangle
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
                Rectangle.AddDot(x, y);
            }
        }

        public void AddChild(Location location)
        {
            _childs.Add(new Leaf(this, location));
            if (_childs.Count > _maxChild)
            {
                DivideBranch();
            }
        }

        public void AddChild(Node node)
        {
            _childs.Add(node);
        }

        private void DivideBranch()
        {
            char axis = ChooseSplitAxis();
            
        }

        private void InitRectangle(double x, double y)
        {
            _rectangle = new Rectangle(x, x, y, y);
        }

        private char ChooseSplitAxis()
        {
            if (FindMinMarginOdDivision(new LeafComparerX())<FindMinMarginOdDivision(new LeafComparerY()))
            {
               return 'x'; 
            }
            else
            {
                return 'y';
            }
            
        }

        private double FindMinMarginOdDivision(IComparer<Leaf> comparer)
        {
            int k = _maxChild - 2 * _minChild + 2;
            Leaf[] sorted = GetChilds().Select(node => (Leaf) node).ToArray();
            Array.Sort(sorted, comparer);
            double[] S = new double[2 * k];
            for (int i = 1; i <= k; i++)
            {
                Rectangle rectangle1 = new Rectangle();
                Rectangle rectangle2 = new Rectangle();
                for (int j = 0; j < _minChild - 1 + k; j++)
                {
                    rectangle1.AddDot(sorted[j].Location.x, sorted[j].Location.y);
                }

                for (int j = _minChild - 1 + k; j < sorted.Length; j++)
                {
                    rectangle2.AddDot(sorted[j].Location.x, sorted[j].Location.y);
                }

                S[i - 1] = rectangle1.Margin + rectangle2.Margin;
            }

            for (int i = 1; i <= k; i++)
            {
                Rectangle rectangle1 = new Rectangle();
                Rectangle rectangle2 = new Rectangle();
                for (int j = 0; j < _minChild - 1 + k; j++)
                {
                    rectangle1.AddDot(sorted[_maxChild - 1 - j].Location.x, sorted[_maxChild - 1 - j].Location.y);
                }

                for (int j = _minChild - 1 + k; j < sorted.Length; j++)
                {
                    rectangle2.AddDot(sorted[_maxChild - 1 - j].Location.x, sorted[_maxChild - 1 - j].Location.y);
                }

                S[k + i - 1] = rectangle1.Margin + rectangle2.Margin;
            }

            double MinOfArray(double[] array)
            {
                double min = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < min)
                    {
                        min = array[i];
                    }
                }

                return min;
            }

            return MinOfArray(S);
        }
    }
}