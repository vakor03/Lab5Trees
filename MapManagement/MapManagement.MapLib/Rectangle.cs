using System;

namespace MapManagement.MapLib
{
    public class Rectangle
    {
        public double Shape
        {
            get { return (_xMax - _xMin) * (_yMax - _yMin); }
        }

        public double Margin
        {
            get => ((_xMax - _xMin) + (_yMax - _yMin)) * 2;
        }
        
        private double _xMin;
        private double _xMax;
        private double _yMin;
        private double _yMax;
        private int _numbDots;

        public Rectangle(double x1, double x2, double y1, double y2)
        {
            if (x1 < x2)
            {
                _xMin = x1;
                _xMax = x2;
            }
            else
            {
                _xMin = x2;
                _xMax = x1;
            }

            if (y1 < y2)
            {
                _yMin = y1;
                _yMax = y2;
            }
            else
            {
                _yMin = y2;
                _yMax = y1;
            }

            _numbDots = 2;
        }

        public Rectangle()
        {
            _numbDots = 0;
        }

        public Rectangle(double x, double y)
        {
            _xMax = x;
            _xMin = x;
            _yMax = y;
            _yMin = y;
            _numbDots = 1;
        }

        public static double CheckOverlapChange(Rectangle firstRectangle, Rectangle secondRectangle, double xDot,
            double yDot)
        {
            Rectangle[] rectangles = {firstRectangle, secondRectangle};
            double[] overlapChanges = new double[2];
            for (int i = 0; i < 2; i++)
            {
                double xMin = rectangles[i]._xMin;
                double xMax = rectangles[i]._xMax;
                double yMin = rectangles[i]._yMin;
                double yMax = rectangles[i]._yMax;

                double shape1 = CheckOverlapShape(rectangles[i], rectangles[(i + 1) % 2]);

                if (xDot > rectangles[i]._xMax)
                {
                    xMax = xDot;
                }
                else if (xDot < rectangles[i]._xMin)
                {
                    xMin = xDot;
                }


                if (yDot > rectangles[i]._yMax)
                {
                    yMax = yDot;
                }
                else if (yDot < rectangles[i]._yMin)
                {
                    yMin = yDot;
                }

                double shape2 = CheckOverlapShape(new Rectangle(xMin, xMax, yMin, yMax), rectangles[(i + 1) % 2]);

                overlapChanges[i] = shape2 - shape1;
            }

            return overlapChanges[1] - overlapChanges[0];
        }

        public static double CheckOverlapShape(Rectangle rectangle1, Rectangle rectangle2)
        {
            double xMin = Math.Max(rectangle1._xMin, rectangle2._xMin);
            double xMax = Math.Min(rectangle1._xMax, rectangle2._xMax);
            double yMin = Math.Max(rectangle1._yMin, rectangle2._yMin);
            double yMax = Math.Min(rectangle1._yMax, rectangle2._yMax);

            if (rectangle1._xMax <= rectangle2._xMin || rectangle2._xMax <= rectangle1._xMin ||
                rectangle1._yMax <= rectangle2._yMin || rectangle2._yMax <= rectangle1._yMin)
            {
                return 0;
            }

            return new Rectangle(xMin, xMax, yMin, yMax).Shape;
        }

        public static double CheckShapeChange(Rectangle firstRectangle, Rectangle secondRectangle, double xDot,
            double yDot)
        {
            return CheckShapeChange(secondRectangle, xDot, yDot) - CheckShapeChange(firstRectangle, xDot, yDot);
        }

        private static double CheckShapeChange(Rectangle rectangle, double xDot, double yDot)
        {
            double xMin = rectangle._xMin;
            double xMax = rectangle._xMax;
            double yMin = rectangle._yMin;
            double yMax = rectangle._yMax;
            if (xDot > rectangle._xMax)
            {
                xMax = xDot;
            }
            else if (xDot < rectangle._xMin)
            {
                xMin = xDot;
            }

            if (yDot > rectangle._yMax)
            {
                yMax = yDot;
            }
            else if (yDot < rectangle._yMin)
            {
                yMin = yDot;
            }

            double shapeChange = (xMax - xMin) * (yMax - yMin) - rectangle.Shape;
            return shapeChange;
        }

        public void AddDot(double xDot, double yDot)
        {
            if (_numbDots == 0)
            {
                _xMax = xDot;
                _xMin = xDot;
                _yMax = yDot;
                _yMin = yDot;
            }
            else
            {
                if (xDot < _xMin)
                {
                    _xMin = xDot;
                }
                else if (xDot > _xMax)
                {
                    _xMax = xDot;
                }

                if (yDot < _yMin)
                {
                    _yMin = yDot;
                }
                else if (yDot > _yMax)
                {
                    _yMax = yDot;
                }
            }

            _numbDots++;
        }

        public (double, double) GetCorner(string direction)
        {
            return direction == "bot" ? (_yMin, _xMin) : (_yMax, _xMax);
        }
    }
}