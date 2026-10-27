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
        public readonly struct Point : IComparable<Point>
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

            // 偏角による比較
            public int CompareTo(Point other)
            {
                return CompareAngle(this, other);
            }
        }

        // 2次元ベクトルの内積
        public static long Dot(Point a, Point b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        // z要素を0とする3次元ベクトルの外積（z成分）
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

        // 偏角による比較（正のX軸から反時計回り）
        // 原点は他のすべての点より前に配置
        // 同じ偏角の場合は原点からの距離が近い順
        public static int CompareAngle(Point a, Point b)
        {
            bool zeroA = a.X == 0 && a.Y == 0;
            bool zeroB = b.X == 0 && b.Y == 0;

            if (zeroA || zeroB)
            {
                if (zeroA && zeroB) return 0;
                return zeroA ? -1 : 1;
            }

            bool upperA = a.Y > 0 || (a.Y == 0 && a.X > 0);
            bool upperB = b.Y > 0 || (b.Y == 0 && b.X > 0);

            if (upperA != upperB) return upperA ? -1 : 1;

            long cross = Cross(a, b);

            if (cross > 0) return -1;
            if (cross < 0) return 1;

            // 同じ偏角の場合は距離で比較
            // 平方距離の計算によるオーバーフローを避けるため、
            // 同じ方向にある点の非ゼロ座標の絶対値で比較
            if (a.X != 0)
            {
                return a.X.CompareTo(b.X) * (a.X > 0 ? 1 : -1);
            }
            else
            {
                return a.Y.CompareTo(b.Y) * (a.Y > 0 ? 1 : -1);
            }
        }
    }
}
