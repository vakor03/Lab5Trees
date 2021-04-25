
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

        // [DataRow(0,3,0,3,2,2, 0)]
        // [DataRow(0,3,0,3,-1,2, 3)]
        // [DataRow(0,3,0,3,4,2, 3)]
        // [DataRow(0,3,0,3,2,4, 3)]
        // [DataRow(0,3,0,3,4,4, 7)]
        // [DataTestMethod]
        // public void CheckShapeChangeTest(double xMin, double xMax, double yMin, double yMax, double xDot, double yDot, double expected)
        // {
        //     Rectangle rectangle = new Rectangle(xMin, xMax, yMin, yMax);
        //
        //     double actual = Rectangle.CheckShapeChange(rectangle,rectangle,xDot,yDot);
        //     
        //     Assert.AreEqual(expected,actual);
        // }
        
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

        
        [TestMethod]
        public void RectangleInitNullTest()
        {
            Branch branch = new Branch();
            Assert.AreEqual(null, branch.Rect);
        }
        
        [DataRow(0,0,0,0,0)]
        [DataRow(1,0,1,0,0)]
        [DataRow(1,0,2,0,0)]
        [DataTestMethod]
         public void RectangleInitTest(double x1, double y1, double x2, double y2, double expected)
         {
             Branch branch = new Branch();
             branch.RefindShape(x1, y1);
             branch.RefindShape(x2, y2);
             Assert.AreEqual(new Rectangle(x1,x2,y1,y2).Shape,branch.Rect.Shape,expected);
         }
    
        [DataRow(0,0,2,2,0)]
        [DataRow(0,0,0,2,4)]
        [DataRow(0,2,0,2,8)]
        [DataTestMethod]
        public void MarginTest(double x1,double x2, double y1, double y2, double expected)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.AddDot(x1,y1);
            rectangle.AddDot(x2,y2);
            Assert.AreEqual(expected, rectangle.Margin);
        }
        
        
    }
}