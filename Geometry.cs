using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder_CS_Template.Classes
{
    static class Geometry
    {
        // 2次元平面上の点座標 または ベクトル
        public readonly struct Point
        {
            public long X { get; }
            public long Y { get; }

            public Point(long x, long y)
            {
                X = x;
                Y = y;
            }

            public static Point operator +(Point a, Point b)
            {
                return new Point(a.X + b.X, a.Y + b.Y);
            }

            public static Point operator -(Point a, Point b)
            {
                return new Point(a.X - b.X, a.Y - b.Y);
            }

            public static Point operator *(Point p, long k)
            {
                return new Point(p.X * k, p.Y * k);
            }

            public static Point operator *(long k, Point p)
            {
                return p * k;
            }
        }

        // 2次元ベクトルの内積
        public static long Dot(Point a, Point b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        // z要素を0とする3次元ベクトルの外積
        public static long Cross(Point a, Point b)
        {
            return a.X * b.Y - a.Y * b.X;
        }

        // 2点を結ぶ2直線の平行判定
        public static bool IsParallel(Point a, Point b, Point c, Point d)
        {
            return Cross(b - a, d - c) == 0;
        }

        // 2点を結ぶ2直線の垂直判定 
        public static bool IsPerpendicular(Point a, Point b, Point c, Point d)
        {
            return Dot(b - a, d - c) == 0;
        }

        // 点pが直線ab上にあるか判定
        public static bool IsPointOnLine(Point p, Point a, Point b)
        {
            Point ab = b - a;

            if (ab.X == 0 && ab.Y == 0)
            {
                return p.X == a.X && p.Y == a.Y;
            }

            return Cross(ab, p - a) == 0;
        }
    }
}
