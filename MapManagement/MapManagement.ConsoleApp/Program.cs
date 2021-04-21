using System;
using System.Collections.Generic;
using System.Linq;
using MapManagement.LocationLib;
using MapManagement.MapLib;

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
        }
    }
}