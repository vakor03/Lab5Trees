using System;
using System.Collections.Generic;
using MapManagement.LocationLib;
using MapManagement.MapLib;

namespace MapManagement.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Location loc1 = new Location("50,60659;30,45436;shop;car;Авто Масло;;");
            Location loc2 = new Location("50,44075;30,55263;leisure;ice_rink;Льодовий клуб «Піонер»;;");
            Branch branch = new Branch();
            branch.AddChild(loc1);
            branch.AddChild(loc2);
            List<Node> childs = branch.GetChilds();
            foreach (var child in childs)
            {
                Console.WriteLine((Leaf)child);
            }
        }
    }
}