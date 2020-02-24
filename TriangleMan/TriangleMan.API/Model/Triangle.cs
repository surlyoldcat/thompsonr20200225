using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace TriangleMan.API.Model
{
    public class Triangle : IEquatable<Triangle>
    {

        public List<Point> Vertices { get; }
        public string Row { get; }
        public int Column { get; }

        public Triangle(IEnumerable<Point> points, string row, int col)
        {
            Vertices = points.ToList();
            if (Vertices.Count != 3)
            {
                throw new ArgumentException("Cannot construct a triangle without exactly 3 points.");
            }
            Row = row.ToLower();
            Column = col;
        }


        public Triangle(Point p1, Point p2, Point p3, string row, int col)
            :this(new List<Point> { p1, p2, p3}, row, col)
        {
        }

        public override string ToString()
        {
            return $"Grid:{Row}{Column} {Vertices[0]}{Vertices[1]}{Vertices[2]}";
        }

        #region Equality implementation- needed for testing
        public bool Equals([AllowNull] Triangle t)
        {
            if (Object.ReferenceEquals(t, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, t))
            {
                return true;
            }
            if (t.Row != this.Row || t.Column != this.Column)
            {
                return false;
            }
            foreach (Point p in this.Vertices)
            {
                //i'm ignoring order, for convenience
                if (!t.Vertices.Contains(p))
                {
                    return false;
                }
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Triangle);
        }

        public override int GetHashCode()
        {
            //note, this will throw if the vertices are not populated,
            //but that situation shouldn't happen
            return (Vertices[0], Vertices[1], Vertices[2]).GetHashCode();
        }

        public static bool operator ==(Triangle left, Triangle right)
        {
            if (Object.ReferenceEquals(left, null))
            {
                return Object.ReferenceEquals(right, null);
            }
            return left.Equals(right);
        }

        public static bool operator !=(Triangle left, Triangle right)
        {
            return !(left == right);
        }
        #endregion
    }
}
