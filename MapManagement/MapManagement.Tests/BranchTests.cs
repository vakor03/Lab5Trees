using System;
using System.Collections.Generic;
using System.Linq;
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
            map.AddLocation(new Location("2;1;;;;;"));
            map.AddLocation(new Location("2;4;;;;;"));
            map.AddLocation(new Location("3;2;;;;;"));
            map.AddLocation(new Location("5;5;;;;;"));
            map.AddLocation(new Location("2;8;;;;;"));
            map.AddLocation(new Location("7;10;;;;;"));
            map.AddLocation(new Location("4;12;;;;;"));
            map.AddLocation(new Location("5;13;;;;;"));
            map.AddLocation(new Location("6;14;;;;;"));
            map.AddLocation(new Location("7;15;;;;;"));
            map.AddLocation(new Location("6;12;;;;;"));
        
            
            //Assert.AreEqual(axis,5);
           
            
        }
    }
}