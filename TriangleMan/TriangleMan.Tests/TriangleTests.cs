using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TriangleMan.API;
using TriangleMan.API.Model;
using TriangleMan.API.Services;

namespace TriangleMan.Tests
{
    [TestFixture(Category = "Triangle Functionality Tests")]
    public class TriangleTests
    {
        private IImageService Service {get;set;}

        [OneTimeSetUp]
        public void Init()
        {
            Service = new ImageService();
        }

        [Test]
        public void TestPointsAreInvalidTriangle()
        {
            Point a = new Point(10, 10);
            Point b = new Point(10, 20);
            Point c = new Point(20, 50);

            Assert.Throws<ArgumentException>(() =>
            {
                var result = Service.FindTriangle(a, b, c);
            });

            Point p1 = new Point(1, 5);
            Point p2 = new Point(20, 20);
            Point p3 = new Point(20, 13);
            Assert.Throws<ArgumentException>(() =>
            {
                var x = Service.FindTriangle(p1, p2, p3);
            });
        }

        [Test]
        public void TestGetValidTriangleByCoords()
        {
            var points = new List<Point>()
            {
                new Point(20, 20),
                new Point(20, 30),
                new Point(10, 20)
            };
            var row = "b";
            var col = 5;
            Triangle expected = new Triangle(points, row, col);

            var a = new Point(20, 20);
            var b = new Point(10, 20);
            var c = new Point(20, 30);
            
            var actual = Service.FindTriangle(a, b, c);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGetValidTriangleByRowCol_Odd()
        {
            
            Triangle actual = Service.FindTriangle("B", 5);

            var points = new List<Point>()
            {
                new Point(20, 20),
                new Point(20, 30),
                new Point(10, 20)
            };
            var r = "b";
            var c = 5;
            Triangle expected = new Triangle(points, r, c);
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void TestGetValidTriangleByRowCol_Even()
        {
            
            Triangle actual = Service.FindTriangle("d", 6);

            var points = new List<Point>()
            {
                new Point(30, 30),
                new Point(30, 20),
                new Point(40, 30)
            };
            var r = "d";
            var c = 6;
            Triangle expected = new Triangle(points, r, c);
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void TestGetTriangleByRowColOutOfBounds()
        {
            
            Assert.Throws<ArgumentException>(() =>
            {
                var res = Service.FindTriangle("l", 300);
            });
        }

        [Test]
        public void TestGetTriangleByCoordsOutOfBounds()
        {
            
            Point a = new Point(10, 9433);
            Point b = new Point(100, 100);
            Point c = new Point(20, 30);
            Assert.Throws<ArgumentException>(() =>
            {
                var res = Service.FindTriangle(a, b, c);
            });
        }

        [Test]
        public void TestNegativeRowCol()
        {
            
            Assert.Throws<ArgumentException>(() =>
            {
                var res = Service.FindTriangle("l", -40);
            });

        }

        [Test]
        public void TestNegativeCoords()
        {
            
            Point a = new Point(10, -9433);
            Point b = new Point(100, 100);
            Point c = new Point(-20, -30);
            Assert.Throws<ArgumentException>(() =>
            {
                var res = Service.FindTriangle(a, b, c);
            });
        }

        [Test]
        public void TestCoordinatesWithDuplicate()
        {
            
            Point a = new Point(20, 20);
            Point b = new Point(10, 20);
            Point c = new Point(20, 20);
            Assert.Throws<ArgumentException>(() =>
            {
                var res = Service.FindTriangle(a, b, c);
            });
        }

        [Test]
        public void TestCoordinatesWithNullPoint()
        {
            
            Point a = new Point(20, 20);
            Point b = null;
            Point c = new Point(10, 20);
            Assert.Throws<ArgumentException>(() =>
            {
                var res = Service.FindTriangle(a, b, c);
            });
        }

        [Test]
        public void TestRowColEdge()
        {
            string row = "g";
            int col = 13;
            Assert.Throws<ArgumentException>(() => 
            {
                var res = Service.FindTriangle(row, col);
            });

            row = "f";
            col = 12;
            Assert.DoesNotThrow(() =>
            {
                var res2 = Service.FindTriangle(row, col);
            });
        }

        [Test]
        public void TestCoordsEdge()
        {
            int maxLeft = 120;
            int maxTop = 60;
            Point a = new Point(maxTop + 10, maxLeft);
            Point b = new Point(maxTop, maxLeft);
            Point c = new Point(maxTop, maxLeft+10);

            Assert.Throws<ArgumentException>(() =>
            {
                var r = Service.FindTriangle(a, b, c);
            });

            Point d = new Point(maxTop, maxLeft);
            Point e = new Point(maxTop - 10, maxLeft);
            Point f = new Point(maxTop - 10, maxLeft - 10);
            Assert.DoesNotThrow(() =>
            {
                var r = Service.FindTriangle(d, e, f);
            });
        }
    }
}
