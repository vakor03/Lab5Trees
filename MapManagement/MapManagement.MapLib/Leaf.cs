using MapManagement.LocationLib;

namespace MapManagement.MapLib
{
    public class Leaf : Node
    {
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
    }
}