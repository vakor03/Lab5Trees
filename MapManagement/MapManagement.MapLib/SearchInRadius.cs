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
            _circlePoints = new (double, double)[4];
            GetCircle();
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
                return;
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
                    GetDistance(leaf.Location.y, leaf.Location.x, _center.Item1, _center.Item2) <= _radius)
                    result.Add(leaf.Location);
            }

            foreach (var location in result)
            {
                Console.WriteLine(location.x + " " + location.y);
            }

            return result;
        }

        public double GetDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double[] grads =
            {
                lat1 * 3.1415925 / 180, lon1 * 3.1415925 / 180,
                lat2 * 3.1415925 / 180, lon2 * 3.1415925 / 180
            };

            double a = Math.Pow(Math.Sin((grads[2] - grads[0]) / 2), 2) +
                       Math.Cos(grads[0]) *
                       Math.Cos(grads[2]) *
                       Math.Pow(Math.Sin((grads[3] - grads[1]) / 2), 2);
            return 12742 * Math.Asin(Math.Sqrt(a));
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

        private void GetCircle()
        {
            double a = Math.Sin(_center.Item1 * 3.1415925 / 180);
            double b = Math.Cos(_center.Item1 * 3.1415925 / 180);
            double c = -2 * Math.Pow(Math.Sin(_radius / 12742), 2) + 1;
            _circlePoints[0] = (2 * Math.Atan((a + Math.Sqrt(a * a + b * b - c * c)) / (b + c)) * 180 / 3.1415925,
                _center.Item2);
            _circlePoints[1] = (2 * Math.Atan((a - Math.Sqrt(a * a + b * b - c * c)) / (b + c)) * 180 / 3.1415925,
                _center.Item2);
            _circlePoints[2] = (_center.Item1, Math.Acos(-1 * (2 * Math.Pow(Math.Sin(_radius / 12742), 2) - 1 +
                                                               Math.Pow(Math.Sin(_center.Item1 * 3.1415925 / 180), 2)) /
                                                         Math.Pow(Math.Cos(_center.Item1 * 3.1415925 / 180), 2)) * 180 /
                3.1415925 + _center.Item2);
            _circlePoints[3] = (_center.Item1, -1 * Math.Acos(-1 * (2 * Math.Pow(Math.Sin(_radius / 12742), 2) - 1 +
                                                                    Math.Pow(Math.Sin(_center.Item1 * 3.1415925 / 180),
                                                                        2)) /
                                                              Math.Pow(Math.Cos(_center.Item1 * 3.1415925 / 180), 2)) *
                180 / 3.1415925 + _center.Item2);
        }
    }
}