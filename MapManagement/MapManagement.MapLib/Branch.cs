using System.Collections.Generic;

namespace MapManagement.MapLib
{
    public class Branch : Node
    {
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

        public void AddChild(Location location)
        {
            _childs.Add(new Leaf(this, location));
            if (_childs.Count>_maxChild)
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
            List<Node> childs = new List<Node>(_childs);
            _childs = new List<Node>();
            for (int i = 0; i < 2; i++)
            {
                Branch childBranch = new Branch(this, _rectangle);
                for (int j = 0; j < _maxChild/2; j++)
                {
                    childBranch.AddChild(childs[j]);
                }
                _childs.Add(childBranch);
            }
        }

        public override string GetNodeType()
        {
            return "Branch";
        }

        public List<Node> GetChilds()
        {
            return _childs;
        }
    }
}