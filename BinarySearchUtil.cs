using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder_CS_Template.Classes
{
    // 昇順ソート済みの配列・リストに対する二分探索ユーティリティ
    // すべてのインデックスは0-indexed
    // 計算量：O(log N)（インデックスアクセスがO(1)の場合）
    public static class BinarySearchUtil
    {
        // 指定した値以上の要素が最初に現れるインデックス (指定値が要素の最大値を超える時は要素数を返す)
        public static int LowerBound(IReadOnlyList<int> a, int x)
        {
            int l = 0, r = a.Count;
            while (l < r)
            {
                int m = l + ((r - l) >> 1);
                if (a[m] < x) l = m + 1;
                else r = m;
            }
            return l;
        }

        public static int LowerBound(IReadOnlyList<int> a, long x)
        {
            int l = 0, r = a.Count;
            while (l < r)
            {
                int m = l + ((r - l) >> 1);
                if ((long)a[m] < x) l = m + 1;
                else r = m;
            }
            return l;
        }

        public static int LowerBound(IReadOnlyList<long> a, int x)
        {
            long xl = x;
            int l = 0, r = a.Count;
            while (l < r)
            {
                int m = l + ((r - l) >> 1);
                if (a[m] < xl) l = m + 1;
                else r = m;
            }
            return l;
        }

        public static int LowerBound(IReadOnlyList<long> a, long x)
        {
            int l = 0, r = a.Count;
            while (l < r)
            {
                int m = l + ((r - l) >> 1);
                if (a[m] < x) l = m + 1;
                else r = m;
            }
            return l;
        }

        // 指定した値より大きい要素が最初に現れるインデックス (条件を満たす要素がない場合は要素数を返す)
        public static int UpperBound(IReadOnlyList<int> a, int x)
        {
            int l = 0, r = a.Count;
            while (l < r)
            {
                int m = l + ((r - l) >> 1);
                if (a[m] <= x) l = m + 1;
                else r = m;
            }
            return l;
        }

        public static int UpperBound(IReadOnlyList<int> a, long x)
        {
            int l = 0, r = a.Count;
            while (l < r)
            {
                int m = l + ((r - l) >> 1);
                if ((long)a[m] <= x) l = m + 1;
                else r = m;
            }
            return l;
        }

        public static int UpperBound(IReadOnlyList<long> a, int x)
        {
            long xl = x;
            int l = 0, r = a.Count;
            while (l < r)
            {
                int m = l + ((r - l) >> 1);
                if (a[m] <= xl) l = m + 1;
                else r = m;
            }
            return l;
        }

        public static int UpperBound(IReadOnlyList<long> a, long x)
        {
            int l = 0, r = a.Count;
            while (l < r)
            {
                int m = l + ((r - l) >> 1);
                if (a[m] <= x) l = m + 1;
                else r = m;
            }
            return l;
        }

        // 指定した値以下の最大値があるインデックス
        // (指定値が要素の最小値を下回る時は-1を返す。
        // 最大値が同じ要素が複数ある場合、その最も右側のインデックスを返す。)
        public static int FloorIndex(IReadOnlyList<int> a, int x)
        {
            return UpperBound(a, x) - 1;
        }

        public static int FloorIndex(IReadOnlyList<int> a, long x)
        {
            return UpperBound(a, x) - 1;
        }

        public static int FloorIndex(IReadOnlyList<long> a, int x)
        {
            return UpperBound(a, x) - 1;
        }

        public static int FloorIndex(IReadOnlyList<long> a, long x)
        {
            return UpperBound(a, x) - 1;
        }

        // 指定した値未満の最大値があるインデックス
        // (指定値が要素の最小値以下の時は-1を返す。
        // 最大値が同じ要素が複数ある場合、その最も右側のインデックスを返す。)
        public static int LessThanIndex(IReadOnlyList<int> a, int x)
        {
            return LowerBound(a, x) - 1;
        }

        public static int LessThanIndex(IReadOnlyList<int> a, long x)
        {
            return LowerBound(a, x) - 1;
        }

        public static int LessThanIndex(IReadOnlyList<long> a, int x)
        {
            return LowerBound(a, x) - 1;
        }

        public static int LessThanIndex(IReadOnlyList<long> a, long x)
        {
            return LowerBound(a, x) - 1;
        }

        // 指定した範囲内にある要素の個数 (半開区間 [left, right))
        public static int CountRange(IReadOnlyList<int> a, int left, int right)
        {
            return LowerBound(a, right) - LowerBound(a, left);
        }

        public static int CountRange(IReadOnlyList<int> a, long left, long right)
        {
            return LowerBound(a, right) - LowerBound(a, left);
        }

        public static int CountRange(IReadOnlyList<long> a, int left, int right)
        {
            return LowerBound(a, right) - LowerBound(a, left);
        }

        public static int CountRange(IReadOnlyList<long> a, long left, long right)
        {
            return LowerBound(a, right) - LowerBound(a, left);
        }

        // 指定した範囲内にある要素の個数 (閉区間 [left, right])
        public static int CountRangeClosed(IReadOnlyList<int> a, int left, int right)
        {
            return UpperBound(a, right) - LowerBound(a, left);
        }

        public static int CountRangeClosed(IReadOnlyList<int> a, long left, long right)
        {
            return UpperBound(a, right) - LowerBound(a, left);
        }

        public static int CountRangeClosed(IReadOnlyList<long> a, int left, int right)
        {
            return UpperBound(a, right) - LowerBound(a, left);
        }

        public static int CountRangeClosed(IReadOnlyList<long> a, long left, long right)
        {
            return UpperBound(a, right) - LowerBound(a, left);
        }

        // 指定した値と等しい要素の個数
        public static int CountValue(IReadOnlyList<int> a, int x)
        {
            return UpperBound(a, x) - LowerBound(a, x);
        }

        public static int CountValue(IReadOnlyList<int> a, long x)
        {
            return UpperBound(a, x) - LowerBound(a, x);
        }

        public static int CountValue(IReadOnlyList<long> a, int x)
        {
            return UpperBound(a, x) - LowerBound(a, x);
        }

        public static int CountValue(IReadOnlyList<long> a, long x)
        {
            return UpperBound(a, x) - LowerBound(a, x);
        }
    }
}
