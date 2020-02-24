using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace TriangleMan.API.Model
{
    public class Point : IEquatable<Point>
    {
        public int Top { get; }
        public int Left { get; }

        public Point(int top, int left)
        {
            Top = top;
            Left = left;
        }

        public override string ToString()
        {
            return $"({Top},{Left})";
        }

        #region Equality implementation- Needed for testing
        public bool Equals([AllowNull] Point p)
        {
            if (Object.ReferenceEquals(p, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, p))
            {
                return true;
            }
            //if we need to worry about derived types, add a type check

            return p.Top == this.Top && p.Left == this.Left;
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Point);
        }

        public override int GetHashCode()
        {
            return (Top, Left).GetHashCode();
        }

        public static bool operator ==(Point left, Point right)
        {
            if (Object.ReferenceEquals(left, null))
            {
                return Object.ReferenceEquals(right, null);
            }
            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }
        #endregion
    }

    /// <summary>
    /// This comparer implementation will sort Points from
    /// top-left (0,0) to bottom-right(5,5)
    /// </summary>
    public class LeftRightTopBottomPointComparer : IComparer<Point>
    {
        public int Compare([AllowNull] Point x, [AllowNull] Point y)
        {
            if (null == x && null == y)
            {
                throw new ArgumentNullException("Both Points may not be null.");
            }
            if (null == x)
            {
                return -1;
            }
            if (null == y)
            {
                return 1;
            }
            if (x.Top == y.Top)
            {
                return x.Left - y.Left;
            }
            else
            {
                return x.Top - y.Top;
            }
            
        }
    }

}
