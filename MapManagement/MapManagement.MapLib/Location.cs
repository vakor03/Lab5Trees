using System;

namespace MapManagement.MapLib
{
    public class Location
    {
        //Longitude == x
        //Latitude == y
        public double y => _latitude;
        public double x => _longitude;
        private double _latitude;
        private double _longitude;
        private string _type;
        private string _subtype;
        private string _name;
        private string _address;


        public Location(string inputString)
        {
            string[] inputInfo = inputString.Split(';');
            _latitude = Double.Parse(inputInfo[0]);
            _longitude = Double.Parse(inputInfo[1]);
            _type = inputInfo[2];
            _subtype = inputInfo[3];
            _name = inputInfo[4];
            _address = inputInfo[5];
        }

        public override string ToString()
        {
            return $"latitude is {_latitude}\n" +
                   $"longitude is {_longitude}\n" +
                   $"type: {_type}, subtype: {_subtype}\n" +
                   $"name: {_name}\n" +
                   $"address: {_address}";
        }
    }
}