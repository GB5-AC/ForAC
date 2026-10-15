using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder_CS_Template.Classes
{
    internal class BIT
    {
        // 1-indexed
        private readonly int size;
        private readonly long[] bit;

        public BIT(int n)
        {
            size = n;
            bit = new long[n + 1];
        }

        // 先頭からi番目までの和
        public long Sum(int i)
        {
            long res = 0;
            while (i > 0)
            {
                res += bit[i];
                i -= i & -i;    // bitで1番右にある1を引いて0にする
            }
            return res;
        }

        // i番目の要素にxを加算する
        public void Add(int i, long x)
        {
            while (i <= size)
            {
                bit[i] += x;
                i += i & -i;    // bitで1番右にある1を引いて0にする
            }
        }

        // 任意区間(lからr)の和
        public long RangeSum(int l, int r)
        {
            return Sum(r) - Sum(l - 1);
        }
    }
}
