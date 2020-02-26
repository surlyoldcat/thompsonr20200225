using System;
using System.Collections.Generic;
using NUnit.Framework;
using TriangleMan.API;
using TriangleMan.API.Model;

namespace TriangleMan.Tests
{
    [TestFixture(Category = "Core Tests")]
    public class CoreTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPointEquals()
        {
            Point a = new Point(1, 4);
            Point b = new Point(1, 4);
            Assert.IsTrue(a == b);
        }

        [Test]
        public void TestPointNotEquals()
        {
            Point a = new Point(1, 4);
            Point b = new Point(2, 5);
            Assert.IsTrue(a != b);
        }

        [Test]
        public void TestTriangleEquals()
        {
            var points1 = new List<Point>()
            {
                new Point(0,0),
                new Point(0,1),
                new Point(1,0)
            };
            var row1 = "a";
            var col1 = 1;
            Triangle t1 = new Triangle(points1, row1, col1);

            var points2 = new List<Point>()
            {
                new Point(0,0),
                new Point(0,1),
                new Point(1,0)
            };
            var row2 = "a";
            var col2 = 1;
            Triangle t2 = new Triangle(points2, row2, col2);

            Assert.AreEqual(t1, t2);

        }

        [Test]
        public void TestTriangleNotEquals()
        {
            var points1 = new List<Point>()
            {
                new Point(0,0),
                new Point(0,1),
                new Point(1,0)
            };
            var row1 = "a";
            var col1 = 1;
            Triangle t1 = new Triangle(points1, row1, col1);

            var points2 = new List<Point>()
            {
                new Point(2,2),
                new Point(1,2),
                new Point(2,3)
            };
            var row2 = "b";
            var col2 = 4;
            Triangle t2 = new Triangle(points2, row2, col2);

            Assert.AreNotEqual(t1, t2);
        }


        [Test]
        public void TestPointSimpleSorting()
        {
            Point pTop = new Point(1, 1);
            Point pMid = new Point(3, 1);
            Point pBot = new Point(8, 1);

            var ps = new List<Point> { pMid, pBot, pTop };
            ps.Sort(new LeftRightTopBottomPointComparer());

            Assert.IsTrue(pTop == ps[0]);
            Assert.IsTrue(pMid == ps[1]);
        }


    }
}