using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder_CS_Template.Classes
{

    /// <summary>
    /// 転倒数を求める
    /// </summary>

    // 使い方
    // int[] arr = { 6, 3, 2, 5, 4, 1 };
    // long ans = InversionNumber.Calc(arr);

    internal static class InversionNumber
    {
        // compress = true : 任意の整数配列を座標圧縮して計算
        // compress = false: すべての値が1以上、配列長以下の配列を想定
        internal static long Calc(int[] arr, bool compress = true)
        {
            int[] data = arr;

            if (compress)
            {
                CoordinateCompression<int> cc = new(arr);
                data = cc.Compressed;
            }

            BIT bit = new(data.Length);
            long res = 0;
            for (int i = 0; i < data.Length; i++)
            {
                int index = compress ? data[i] + 1 : data[i];

                res += i - bit.Sum(index); 
                bit.Add(index, 1);
            }
            return res;
        }
    }
}
