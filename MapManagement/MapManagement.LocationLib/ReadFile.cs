using System.IO;
using MapManagement.MapLib;

namespace MapManagement.LocationLib
{
    public class ReadFile
    {
        private string _path { get; }
        private Map _map;
        
        public ReadFile(string path, Map map)
        {
            _path = path;
            _map = map;
        }
        public void Read()
        {
            using (StreamReader sr = new StreamReader(new FileStream(_path, FileMode.Open)))
            {
                string line = sr.ReadLine();
                while (line!=null)
                {
                    Location location = new Location(line);
                    _map.AddLocation(location);
                    line = sr.ReadLine();
                }
            }
        }
    }
}