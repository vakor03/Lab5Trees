using System;
using System.Linq;
using MapManagement.LocationLib;
using MapManagement.MapLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MapManagement.Tests
{
    [TestClass]
    public class BranchTests
    {
        [TestMethod]
        public void LeafCompareXTest()
        {
            Branch branch = new Branch();
            branch.AddChild(new Location("50,60659;32;shop;car;Авто Масло;;"));
            branch.AddChild(new Location("49,60659;31;shop;car;Авто Масло;;"));
            branch.AddChild(new Location("49,60659;33;shop;car;Авто Масло;;"));
            branch.AddChild(new Location("49,60659;34;shop;car;Авто Масло;;"));
            var a = branch.GetChilds().Select(a=> (Leaf)a).ToArray();
            Array.Sort(a,new LeafComparerX());
            Assert.AreEqual(a[0].Location.x,31);
        }
        
        [TestMethod]
        public void LeafCompareYTest()
        {
            Branch branch = new Branch();
            branch.AddChild(new Location("48;32;shop;car;Авто Масло;;"));
            branch.AddChild(new Location("49;31;shop;car;Авто Масло;;"));
            branch.AddChild(new Location("51;33;shop;car;Авто Масло;;"));
            branch.AddChild(new Location("17;34;shop;car;Авто Масло;;"));
            var a = branch.GetChilds().Select(a=> (Leaf)a).ToArray();
            Array.Sort(a,new LeafComparerY());
            Assert.AreEqual(a[0].Location.x,34);
        }

        
        [TestMethod]
        public void MinMarginTest()
        {
            Map map = new Map();
            string path = @"C:\Users\Вакор\Desktop\Projects\Lab5Trees\MapManagement\Locations\Locations.csv";
            ReadFile readFile = new ReadFile(path, map);
            readFile.Read();


        }
    }
}