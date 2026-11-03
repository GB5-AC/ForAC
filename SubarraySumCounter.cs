using System.Collections.Generic;

namespace AtCoder_CS_Template.Classes
{
    // 連続部分配列の区間和に関する区間数カウント
    internal class SubarraySumCounter
    {
        // 配列arrの連続部分区間の要素の合計が指定値kとなる区間数を返す
        // 配列の要素はすべて1以上であること
        internal static long CountExactly_Positive(long[] arr, long k)
        {
            if (k <= 0) return 0;

            int l = 0;
            long total = 0;
            long res = 0;

            for (int r = 0; r < arr.Length; r++)
            {
                total += arr[r];

                while (total > k)
                {
                    total -= arr[l];
                    l++;
                }

                if (total == k) res++;
            }

            return res;
        }

        // 配列arrの連続部分区間の要素の合計が指定値kとなる区間数を返す
        // 配列の要素はすべて0以上であること
        // CountExactly_NonNegative_AtMost()と同じことをしているが尺取法による実装
        internal static long CountExactly_NonNegative(long[] arr, long k)
        {
            if (k < 0) return 0;

            int l = 0;
            long total = 0;
            long zeroCount = 0;
            long res = 0;

            if (k == 0)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == 0)
                    {
                        res += ++zeroCount;
                    }
                    else
                    {
                        zeroCount = 0;
                    }
                }

                return res;
            }

            // K > 0 のとき
            for (int r = 0; r < arr.Length; r++)
            {
                total += arr[r];

                if (total > k)
                {
                    zeroCount = 0;
                    while (total > k)
                    {
                        total -= arr[l];
                        l++;
                    }
                }

                if (total == k)
                {
                    while (l <= r && arr[l] == 0)
                    {
                        zeroCount++;
                        l++;
                    }
                    res += zeroCount + 1;
                }
            }

            return res;
        }

        // 配列arrの連続部分区間の要素の合計が指定値kとなる区間数を返す
        // 配列の要素はすべて0以上であること
        // CountAtMost_NonNegative()を利用
        // CountExactly_NonNegative()と同じことをしているがCountAtMost_NonNegative()を利用した実装
        internal static long CountExactly_NonNegative_AtMost(long[] arr, long k)
        {
            return CountAtMost_NonNegative(arr, k) - CountAtMost_NonNegative(arr, k - 1);
        }

        // 配列arrの連続部分区間の要素の合計が指定値k以下となる区間数を返す
        // 配列の要素はすべて0以上であること
        internal static long CountAtMost_NonNegative(long[] arr, long k)
        {
            if (k < 0) return 0;

            int l = 0;
            long total = 0;
            long res = 0;

            for (int r = 0; r < arr.Length; r++)
            {
                total += arr[r];

                while (total > k)
                {
                    total -= arr[l];
                    l++;
                }

                res += r - l + 1;
            }

            return res;
        }
        
        // 配列arrの連続部分区間の要素の合計が指定値kとなる区間数を返す
        // 配列の要素はすべて整数であること(負数も許容)
        // 累積和と辞書を利用した実装
        internal static long CountExactly_PrefixSum(long[] arr, long k)
        {
            Dictionary<long, long> cumCnt = new();
            cumCnt[0] = 1;
            long res = 0;
            long cum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                cum += arr[i];
                res += cumCnt.GetValueOrDefault(cum - k, 0);
                cumCnt[cum] = cumCnt.GetValueOrDefault(cum, 0) + 1;
            }

            return res;
        }

    }
}
