using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder_CS_Template.Classes
{
    public static class BinarySearchUtil
    {
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
