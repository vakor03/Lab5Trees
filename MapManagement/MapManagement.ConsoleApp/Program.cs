using MapManagement.MapLib;
using MapManagement.LocationLib;

namespace MapManagement.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Вакор\Desktop\Projects\Lab5Trees\MapManagement\Locations\Locations.csv";
            Map map = new Map();
            ReadFile readFile = new ReadFile(path, map);
            readFile.Read();
            SearchInRadius searchInRadius = new SearchInRadius(map,50.60659, 32, 10, "shop");
        }
    }
}