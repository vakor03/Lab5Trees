using System;

namespace MapManagement.MapLib
{
    public class Leaf : Node
    {
        public Location Location
        {
            get => _location;
        }

        private Branch _mother;
        private Location _location;

        public Leaf(Branch mother, Location location)
        {
            _mother = mother;
            _location = location;
        }

        public override string ToString()
        {
            return _location.ToString();
        }

        public override string GetNodeType()
        {
            return "Leaf";
        }
    }
}