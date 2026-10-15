using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder_CS_Template.Classes
{
    /// <summary>
    /// 座標圧縮
    /// </summary>
    /// <typeparam name="T"></typeparam>

    // 動きのイメージ
    // 入力例 {6, 10, 6, 2, 1, 20}
    // Values = {1, 2, 6, 10, 20}
    // ValueToIndex = {(1 => 0), (2 => 1), (6 => 2), (10 => 3), (20 => 4)}
    // Compressed = {2, 3, 2, 1, 0, 4}
    // _count = {1, 1, 2, 1, 1}

    internal class CoordinateCompression<T> where T : notnull
    {
        internal readonly T[] Values;                       // 圧縮後の番号 -> 元の値
        internal readonly Dictionary<T, int> ValueToIndex;  // 元の値 -> 圧縮後の番号
        internal readonly int[] Compressed;                 // 元順序に対応した圧縮後の番号
        private int[] _count;                               // 圧縮後の番号毎の出現回数

        internal CoordinateCompression(T[] arr)
        {
            // 値の重複排除とソート
            Values = arr.Distinct().ToArray();
            Array.Sort(Values);

            // 値-圧縮後の番号の辞書を作成
            ValueToIndex = Values.Select((value, i) => (value, i)).ToDictionary(x => x.value, x => x.i);

            // 元の配列の圧縮配列を作成
            Compressed = arr.Select(x => ValueToIndex[x]).ToArray();
        }

        internal int[] Count()
        {
            if (_count == null)
            {
                // まだ出現回数の配列を作成していないとき
                _count = new int[ValueToIndex.Count];
                foreach (var id in Compressed) _count[id]++;
            }
            return _count;
        }
    }
}
