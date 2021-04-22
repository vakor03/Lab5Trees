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
            // ReadFile readFile = new ReadFile(path, map);
            // readFile.Read();
            // Branch branch = new Branch();
            for (int i = 0; i < 5; i++)
            {
                map.AddLocation(new Location("50,60659;30,45436;shop;car;Авто Масло;;"));
            }
            
            // Console.WriteLine(branch.GetChilds()[0].GetNodeType());
        }
    }
}