using System;
using MapManagement.MapLib;
using MapManagement.LocationLib;

namespace MapManagement.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"../../../../Locations/Locations.csv";
            Map map = new Map();
            ReadFile readFile = new ReadFile(path, map);
            readFile.Read();
            SearchInRadius searchInRadius = new SearchInRadius(map, 49.72503,31.53035, 15, "shop");
        }
    }
}