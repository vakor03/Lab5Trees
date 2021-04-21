using System;

namespace MapManagement.LocationLib
{
    public class Location
    {
        private double _latitude;
        private double _longitude;
        private string _type;
        private string _subtype;
        private string _name;
        private string _address;

        public double Latitude => _latitude;
        public double Longitude => _longitude;

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