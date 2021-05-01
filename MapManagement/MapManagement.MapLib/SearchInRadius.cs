using System;
using System.Collections.Generic;

namespace MapManagement.MapLib
{
    public class SearchInRadius
    {
        private Map _map;
        private (double, double) _center;
        private double _radius;
        private (double, double)[] _circlePoints;
        private string _type;

        public SearchInRadius(Map map, double latitude, double longitude, double radius, string type)
        {
            _map = map;
            _center = (latitude, longitude);
            _radius = radius;
            _type = type;
            _circlePoints = new[]
            {
                ((latitude - radius / (Math.Cos(latitude) * 111321.377778)), longitude),
                ((latitude + radius / (Math.Cos(latitude) * 111321.377778)), longitude),
                (latitude, longitude - radius / 111.134861111),
                (latitude, longitude + radius / 111.134861111)
            };
            FindNearest();
        }

        private void SearchTree(Branch current, List<Leaf> leaves)
        {
            if (!CheckInCircle(current.Rect.GetCorner("bot"), current.Rect.GetCorner("top")))
                return;
            if (current.GetNodeType() == "PreBranch")
            {
                foreach (var leaf in current.Childs)
                {
                    leaves.Add((Leaf) leaf);
                }
            }

            for (int i = 0; i < current.Childs.Count; i++)
            {
                SearchTree((Branch) current.Childs[i], leaves);
            }
        }

        public List<Location> FindNearest()
        {
            List<Leaf> temp = new List<Leaf>();
            SearchTree(_map.Root, temp);
            List<Location> result = new List<Location>();
            foreach (var leaf in temp)
            {
                if ((leaf.Location.Type == _type || leaf.Location.Subtype == _type) &&
                    GetDistance(leaf.Location.x, leaf.Location.y, _center.Item1, _center.Item2) <= _radius)
                    result.Add(leaf.Location);
            }

            return result;
        }

        private double GetDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double[] coordsInRadians =
            {
                lat1 * 3.1415 / 180, lon1 * 3.1415 / 180,
                lat2 * 3.1415 / 180, lon2 * 3.1415 / 180
            };

            double a = Math.Pow(Math.Sin((coordsInRadians[2] - coordsInRadians[0]) / 2), 2) +
                       Math.Cos(coordsInRadians[0]) *
                       Math.Cos(coordsInRadians[2]) *
                       Math.Pow(Math.Sin((coordsInRadians[3] - coordsInRadians[1]) / 2), 2);
            return 7922 * Math.Asin(Math.Sqrt(a));
        }

        private bool CheckInCircle((double, double) botCorner, (double, double) topCorner)
        {
            if (GetDistance(botCorner.Item1, botCorner.Item2, _center.Item1, _center.Item2) <= _radius)
                return true;
            if (GetDistance(topCorner.Item1, botCorner.Item2, _center.Item1, _center.Item2) <= _radius)
                return true;
            if (GetDistance(botCorner.Item1, topCorner.Item2, _center.Item1, _center.Item2) <= _radius)
                return true;
            if (GetDistance(topCorner.Item1, topCorner.Item2, _center.Item1, _center.Item2) <= _radius)
                return true;
            foreach (var coordinates in _circlePoints)
            {
                if (coordinates.Item1 >= botCorner.Item1 && coordinates.Item1 <= topCorner.Item1 &&
                    coordinates.Item2 >= botCorner.Item2 && coordinates.Item2 <= topCorner.Item2) return true;
            }

            return false;
        }
    }
}