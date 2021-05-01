using System;
using System.Collections.Generic;

namespace MapManagement.MapLib
{
    public class SearchInRadius
    {
        private (double, double) _center;
        private double _radius;
        private (double, double)[] _circlePoints;
        
        public SearchInRadius()
        {
            
        }
        
        private void SearchTree(Branch current, List<Node> leaves)
        {
            for (int i = 0; i < current.Childs.Count; i++)
            {
            }
        }

        public List<Location> FindNearest(double latitude, double longitude, double radius, string type)
        {
            var bot = ((latitude - radius / (Math.Cos(latitude) * 111321.377778)), longitude);
            var top = ((latitude + radius / (Math.Cos(latitude) * 111321.377778)), longitude);
            var left = (latitude, longitude - radius / 111.134861111);
            var right = (latitude, longitude + radius / 111.134861111);
            return null;
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

        private bool CheckInCircle()
        {
            
            return false;
        }
    }
}