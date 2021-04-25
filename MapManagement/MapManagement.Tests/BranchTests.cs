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
            Branch branch = new Branch();
            branch.AddChild(new Location("2;1;;;;;"));
            branch.AddChild(new Location("2;4;;;;;"));
            branch.AddChild(new Location("3;2;;;;;"));
            branch.AddChild(new Location("5;5;;;;;"));
            branch.AddChild(new Location("2;8;;;;;"));
            branch.AddChild(new Location("7;10;;;;;"));
            branch.AddChild(new Location("4;12;;;;;"));
            branch.AddChild(new Location("5;13;;;;;"));
            branch.AddChild(new Location("6;14;;;;;"));
            branch.AddChild(new Location("7;15;;;;;"));

            double S = branch.FindMinMarginOdDivision(new LeafComparerX());
            Assert.AreEqual(S,36);
            
        }
    }
}