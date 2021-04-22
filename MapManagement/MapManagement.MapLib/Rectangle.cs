namespace MapManagement.MapLib
{
    public class Rectangle
    {
        private double _xMin;
        private double _xMax;
        private double _yMin;
        private double _yMax;
        public double Shape { get; set; }

        public Rectangle()
        {
        }

        public static double CheckOverlapChange(Rectangle firstRectangle, Rectangle secondRectangle, double xDot, double yDot)
        {
            return 0;
        }
        
        public static double CheckShapeChange(Rectangle firstRectangle, Rectangle secondRectangle, double xDot, double yDot)
        {
            return 0;
        }
    }
}