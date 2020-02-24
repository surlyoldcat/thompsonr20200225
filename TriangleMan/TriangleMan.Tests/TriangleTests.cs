using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TriangleMan.API;
using TriangleMan.API.Model;

namespace TriangleMan.Tests
{
    [TestFixture(Category = "Triangle Functionality Tests")]
    public class TriangleTests
    {

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
            Image im = new Image();
            var actual = im.FindTriangle(a, b, c);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestGetValidTriangleByRowCol_Odd()
        {
            Image im = new Image();
            Triangle actual = im.FindTriangle("B", 5);

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
            Image im = new Image();
            Triangle actual = im.FindTriangle("d", 6);

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
            Image im = new Image();
            Assert.Throws<ArgumentException>(() =>
            {
                var res = im.FindTriangle("l", 300);
            });
        }

        [Test]
        public void TestGetTriangleByCoordsOutOfBounds()
        {
            Image im = new Image();
            Point a = new Point(10, 9433);
            Point b = new Point(100, 100);
            Point c = new Point(20, 30);
            Assert.Throws<ArgumentException>(() =>
            {
                var res = im.FindTriangle(a, b, c);
            });
        }

        [Test]
        public void TestNegativeRowCol()
        {
            Image im = new Image();
            Assert.Throws<ArgumentException>(() =>
            {
                var res = im.FindTriangle("l", -40);
            });

        }

        [Test]
        public void TestNegativeCoords()
        {
            Image im = new Image();
            Point a = new Point(10, -9433);
            Point b = new Point(100, 100);
            Point c = new Point(-20, -30);
            Assert.Throws<ArgumentException>(() =>
            {
                var res = im.FindTriangle(a, b, c);
            });
        }

        [Test]
        public void TestCoordinatesWithDuplicate()
        {
            Image im = new Image();
            Point a = new Point(20, 20);
            Point b = new Point(10, 20);
            Point c = new Point(20, 20);
            Assert.Throws<ArgumentException>(() =>
            {
                var res = im.FindTriangle(a, b, c);
            });
        }

        [Test]
        public void TestCoordinatesWithNullPoint()
        {
            Image im = new Image();
            Point a = new Point(20, 20);
            Point b = null;
            Point c = new Point(10, 20);
            Assert.Throws<ArgumentException>(() =>
            {
                var res = im.FindTriangle(a, b, c);
            });
        }

    }
}
