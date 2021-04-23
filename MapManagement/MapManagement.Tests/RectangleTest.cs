
using MapManagement.MapLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapManagement.Tests
{
    [TestClass]
    public class RectangleTest
    {
        [TestMethod]
        public void ShapeTest()
        {
            Rectangle rectangle = new Rectangle(1, 2, 0, 3);
            
            double expectedShape = 3;
            double actualShape = rectangle.Shape;
            
            Assert.AreEqual(expectedShape,actualShape);
        }

        [DataRow(0,3,0,3,2,2, 0)]
        [DataRow(0,3,0,3,-1,2, 3)]
        [DataRow(0,3,0,3,4,2, 3)]
        [DataRow(0,3,0,3,2,4, 3)]
        [DataRow(0,3,0,3,4,4, 7)]
        [DataTestMethod]
        public void CheckShapeChangeTest(double xMin, double xMax, double yMin, double yMax, double xDot, double yDot, double expected)
        {
            Rectangle rectangle = new Rectangle(xMin, xMax, yMin, yMax);

            double actual = Rectangle.CheckShapeChange(rectangle,xDot,yDot);
            
            Assert.AreEqual(expected,actual);
        }
        
        [DataRow(7,2,0)]
        [DataRow(9,2,-2)]
        [DataRow(9,4,-5)]
        [DataRow(5,2,2)]
        [DataTestMethod]
        public void CheckOverlapChangeTest(double xDot,double yDot, double expected)
        {
            Rectangle rectangle1 = new Rectangle(0, 8, 0, 3);
            
            Rectangle rectangle2 = new Rectangle(6, 13, 1, 7);

            double actual = Rectangle.CheckOverlapChange(rectangle1, rectangle2, xDot, yDot);
            
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void CheckOverlapShapeTest()
        {
            Rectangle rectangle1 = new Rectangle(0, 8, 0, 3);
            
            Rectangle rectangle2 = new Rectangle(6, 13, 1, 7);

            double actual = Rectangle.CheckOverlapShape(rectangle1, rectangle2);
            double expected = Rectangle.CheckOverlapShape(rectangle2, rectangle1);
            
            Assert.AreEqual(expected,actual,4);
        }
        
        
    }
}