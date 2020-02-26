using System;
using System.Collections.Generic;
using System.Linq;
using TriangleMan.API.Model;

namespace TriangleMan.API.Services
{
    public interface IImageService
    {
        Triangle FindTriangle(Point p1, Point p2, Point p3);
        Triangle FindTriangle(string row, int col);
    }

    public class ImageService : IImageService
    {
        private enum TriangleOrientation
        {
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight
        }
   
        public const int NUM_ROWS = 6;
        public const int NUM_COLS = 12;
        public const int SIDE_LENGTH = 10;
      
        private static readonly Dictionary<string, int> _rowForLetter;
        private static readonly Dictionary<int, string> _letterForRow;

        static ImageService()
        {
            List<string> allLowers = new List<string>(26);
            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                allLowers.Add(letter.ToString());
            }
            //these 2 maps are for translating from letter indexes
            //to row number (1-based index) and back. if we need
            //to add more letters, we can just expand these dicts.
            _rowForLetter = new Dictionary<string, int>(NUM_ROWS);
            _letterForRow = new Dictionary<int, string>(NUM_COLS);
            for (int a = 0; a < NUM_ROWS; a++)
            {
                _rowForLetter.Add(allLowers[a], a+1);
                _letterForRow.Add(a+1, allLowers[a]);
            }
        }

        public ImageService()
        { }

        public Triangle FindTriangle(Point p1, Point p2, Point p3)
        {
            List<Point> vertices = new List<Point> { p1, p2, p3 };
            if (!ValidatePoints(vertices))
            {
                throw new ArgumentException("Supplied points do not describe a valid triangle.");
            }

            //find the row
            int rownum = vertices.Select(v => v.Top).Max() / SIDE_LENGTH;

            //find the column by determing which vertex is the right angle (v90).
            //if the points are sorted left to right + top to bottom (the direction
            //of the hypotenuse), then v90 will always be the 2nd point.
            vertices.Sort(new LeftRightTopBottomPointComparer());
            Point v90 = vertices[1];
            Point[] others = new[] { vertices[0], vertices[2] };
            var orientation = GetOrientation(v90, others);
            int colnum = 0;
            // once we have the orientation and the 90-degree point,
            // we can infer which column it's in
            if (orientation == TriangleOrientation.TopRight)
            {
                colnum = (v90.Left * 2) / SIDE_LENGTH;
            }
            else //not worrying about the other 2 orientations in thie exercise
            {
                colnum = (v90.Left * 2 ) / SIDE_LENGTH + 1;
            }
            
            return new Triangle(vertices, _letterForRow[rownum], colnum);

        }

        public Triangle FindTriangle(string row, int col)
        {   
            string lowerRow = row.ToLower();
            if (col > NUM_COLS || col < 1)
            {
                throw new ArgumentException("Invalid value for argument 'col'");
            }
            if (!_rowForLetter.ContainsKey(lowerRow))
            {
                throw new ArgumentException("Invalid value for argument 'row'");
            }

            int rowNum = _rowForLetter[lowerRow];
            //for the \ orientation of the triangle, odd-number columns
            // have v90 bottom-left, evens have it top-right
            int gridCol = col / 2;
            Point v90;
            Point upperLeft;
            Point lowerRight;
            // create the 90-degree vertex, and calculate the
            // other 2 based on that.
            if (col % 2 == 0)
            {
                v90 = new Point((rowNum - 1) * SIDE_LENGTH, gridCol * SIDE_LENGTH);
                upperLeft = new Point(v90.Top, v90.Left - SIDE_LENGTH);
                lowerRight =new Point(v90.Top + SIDE_LENGTH, v90.Left);

            }
            else
            {
                v90 = new Point(rowNum * SIDE_LENGTH, gridCol * SIDE_LENGTH);
                upperLeft = new Point(v90.Top - SIDE_LENGTH, v90.Left);
                lowerRight = new Point(v90.Top, v90.Left + SIDE_LENGTH);
            }

            var vertices = new List<Point> { v90, upperLeft, lowerRight };
            return new Triangle(vertices, row, col);
        }

        private TriangleOrientation GetOrientation(Point rightAngleVertex, Point[] others)
        {
            //Orientation meaning which direction is the right-angle vertex pointing
            int maxLeft = others.Select(p => p.Left).Max();
            int maxTop = others.Select(p => p.Top).Max();
            int minLeft = others.Select(p => p.Left).Min();
            int minTop = others.Select(p => p.Top).Min();
            // how about some ugly conditional code...
            if (rightAngleVertex.Left >= maxLeft && rightAngleVertex.Top <= minTop)
            {
                return TriangleOrientation.TopRight;
            }
            else if (rightAngleVertex.Left <= minLeft && rightAngleVertex.Top <= minTop)
            {
                return TriangleOrientation.TopLeft;
            }
            else if (rightAngleVertex.Left >= maxLeft && rightAngleVertex.Top >= maxTop)
            {
                return TriangleOrientation.BottomRight;
            }
            else// if (rightAngleVertex.Left <= minLeft && rightAngleVertex.Top >= maxTop)
            {
                return TriangleOrientation.BottomLeft;
            }


        }

        private bool ValidatePoints(List<Point> points)
        {
            //do some basic validation to ensure that the Points
            //make up something resembling our triangle

            if (points.Count != 3)
            {
                return false;
            }

            //verify that each value is a multiple of SIDE_LENGTH
            foreach (Point p in points)
            {
                if (null == p)
                {
                    return false;
                }
                if (p.Top % SIDE_LENGTH != 0 || p.Left % SIDE_LENGTH != 0)
                {
                    return false;
                }
            }

            //verify there are no duplicates
            if (points[0] == points[1] || points[1] == points[2] || points[0] == points[2])
            {
                return false;
            }

            //verify that none of the straight sides are longer than SIDE_LENGTH
            int minX = points.Select(v => v.Left).Min();
            int maxX = points.Select(v => v.Left).Max();
            int minY = points.Select(v => v.Top).Min();
            int maxY = points.Select(v => v.Top).Max();

            if (maxX - minX > SIDE_LENGTH || maxY - minY > SIDE_LENGTH)
            {
                return false;
            }

            //verify that none of the points are out of bounds
            int maxLeft = NUM_COLS * SIDE_LENGTH;
            int maxTop = NUM_ROWS * SIDE_LENGTH;
            if (minX < 0 || minY < 0)
            {
                return false;
            }
            if (maxX > maxLeft || maxY > maxTop)
            {
                return false;
            }

            //everything's fine
            return true;
        }


    }
}