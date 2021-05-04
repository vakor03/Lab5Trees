using System;
using System.Collections.Generic;
using MapManagement.MapLib;
using MapManagement.LocationLib;

namespace MapManagement.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = TextResources.Path;
            Map map = new Map();
            ReadFile readFile = new ReadFile(path, map);
            readFile.Read();
            
            Console.WriteLine(TextResources.InputCoordsRequest);
            string coords = Console.ReadLine();
            double latitude = Convert.ToDouble(coords.Split(';')[0]);
            double longitude = Convert.ToDouble(coords.Split(';')[1]);

            Console.WriteLine(TextResources.RadiusRequest);
            double radius = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine(TextResources.LocTypeRequest);
            string type = Console.ReadLine();
            if (type == "-")
            {
                type = default;
            }
            
            SearchInRadius searchInRadius = new SearchInRadius(map, latitude,longitude, radius, type);
            List<Location> locations = searchInRadius.FindNearest();
            for (int i = 0; i < locations.Count; i++)
            {
                Console.WriteLine($"{i+1}. {locations[i]}");
            }
        }
    }
}