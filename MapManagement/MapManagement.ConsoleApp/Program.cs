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
            SearchInRadius searchInRadius = new SearchInRadius(map, 49.09041722987555, 33.88874450078899, 15, "shop");
            Console.WriteLine(searchInRadius.GetDistance(50.07864482238561, 3.9358324874128527, 50.07992910667653, 3.7950748153514158));
        }
    }
}