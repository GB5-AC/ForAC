using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder_CS_Template.Classes
{
    internal static class Util
    {
        // グリッドの右90度回転(string[])
        static string[] Rotate90(string[] input)
        {
            int h = input.Length;
            int w = input[0].Length;
            string[] res = new string[w];
            for (int i = 0; i < w; i++)
            {
                char[] row = new char[h];
                for (int j = 0; j < h; j++)
                {
                    row[j] = input[h - 1 - j][i];
                }
                res[i] = new string(row);
            }
            return res;
        }

        // グリッドの点対象回転(string[])
        static string[] Rotate180(string[] input)
        {
            int h = input.Length;
            int w = input[0].Length;
            string[] res = new string[h];
            for (int i = 0; i < h; i++)
            {
                char[] row = new char[w];
                for (int j = 0; j < w; j++)
                {
                    row[j] = input[h - 1 - i][w - 1 - j];
                }
                res[i] = new string(row);
            }
            return res;
        }

        // グリッドの左90度回転(string[])
        static string[] Rotate270(string[] input)
        {
            int h = input.Length;
            int w = input[0].Length;
            string[] res = new string[w];
            for (int i = 0; i < w; i++)
            {
                char[] row = new char[h];
                for (int j = 0; j < h; j++)
                {
                    row[j] = input[j][w - 1 - i];
                }
                res[i] = new string(row);
            }
            return res;
        }

        // グリッドの左右反転(string[])
        static string[] FlipHorizontal(string[] input)
        {
            int h = input.Length;
            int w = input[0].Length;
            string[] res = new string[h];
            for (int i = 0; i < h; i++)
            {
                char[] row = new char[w];
                for (int j = 0; j < w; j++)
                {
                    row[j] = input[i][w - 1 - j];
                }
                res[i] = new string(row);
            }
            return res;
        }

        // グリッドの上下反転(string[])
        static string[] FlipVertical(string[] input)
        {
            int h = input.Length;
            int w = input[0].Length;
            string[] res = new string[h];
            for (int i = 0; i < h; i++)
            {
                char[] row = new char[w];
                for (int j = 0; j < w; j++)
                {
                    row[j] = input[h - 1 - i][j];
                }
                res[i] = new string(row);
            }
            return res;
        }

        // グリッドの転置(string[])
        static string[] Transpose(string[] input)
        {
            int h = input.Length;
            int w = input[0].Length;
            string[] res = new string[w];
            for (int i = 0; i < w; i++)
            {
                char[] row = new char[h];
                for (int j = 0; j < h; j++)
                {
                    row[j] = input[j][i];
                }
                res[i] = new string(row);
            }
            return res;
        }

        // グリッドの副対角線反転(左下と右上の対角で反転)(string[])
        static string[] AntiTranspose(string[] input)
        {
            int h = input.Length;
            int w = input[0].Length;
            string[] res = new string[w];
            for (int i = 0; i < w; i++)
            {
                char[] row = new char[h];
                for (int j = 0; j < h; j++)
                {
                    row[j] = input[h - 1 - j][w - 1 - i];
                }
                res[i] = new string(row);
            }
            return res;
        }

        // グリッドの外周余白を削除(string[])
        static string[] TrimGrid(string[] input, char empty = '.')
        {
            int h = input.Length;
            int w = input[0].Length;
            int top = h; int btm = -1;
            int left = w; int right = -1;
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (input[i][j] != '.')
                    {
                        top = Math.Min(top, i);
                        btm = Math.Max(btm, i);
                        left = Math.Min(left, j);
                        right = Math.Max(right, j);
                    }
                }
            }
            if (btm == -1) return Array.Empty<string>();    // 全て空なら空配列を返す

            string[] res = new string[btm - top + 1];
            for (int i = top; i <= btm; i++)
            {
                res[i - top] = input[i].Substring(left, right - left + 1);
            }

            return res;
        }

        // 転倒数を求める(不連続値の配列、値の重複も許容)
        static long CountInversions(int[] arr)
        {
            if (arr.Length == 0) return 0;

            // 座標圧縮
            int[] sorted = arr.Distinct().OrderBy(x => x).ToArray();

            Dictionary<int, int> rank = new();
            for (int i = 0; i < sorted.Length; i++) rank[sorted[i]] = i + 1;

            // ここからBIT(1-indexed)
            int size = sorted.Length;
            long[] bit = new long[size + 1];

            long Sum(int index)
            {
                long result = 0;
                while (index > 0)
                {
                    result += bit[index];
                    index -= index & -index;
                }
                return result;
            }

            void Add(int index)
            {
                while (index <= size)
                {
                    bit[index]++;
                    index += index & -index;
                }
            }

            // 結果集計
            long res = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int index = rank[arr[i]];
                res += i - Sum(index);
                Add(index);
            }

            return res;
        }

        // 区間マージ（離散値・連続値対応／重複する区間をマージ）
        // 使い方
        // 元の区間を(開始値, 終了値)のタプルを、配列またはListとする引数として、
        // MergeIntervals() を呼び出す。
        // 例)
        // (double l, double r)[] input = { (5.0, 7.0), (1.2, 2.5), (4.3, 8.0), (8.0, 10.5) };
        // List<(double l, double r)> result = MergeIntervals(input);
        // result = { (1.2, 2.5), (4.3, 10.5) }
        // 注意事項：引数として渡される元の配列またはList自体がソートされる

        // // 引数を配列で受け取る
        static List<(T l, T r)> MergeIntervals<T>((T l, T r)[] ranges) where T : IComparable<T>
        {
            Array.Sort(ranges);
            return MergeIntervalsCore(ranges);
        }

        // // 引数をリストで受け取る
        static List<(T l, T r)> MergeIntervals<T>(List<(T l, T r)> ranges) where T : IComparable<T>
        {
            ranges.Sort();
            return MergeIntervalsCore(ranges);
        }

        // // 共通処理部
        static List<(T l, T r)> MergeIntervalsCore<T>(IReadOnlyList<(T l, T r)> ranges) where T : IComparable<T>
        {
            List<(T l, T r)> res = new();
            if (ranges.Count == 0) return res;
            T left = ranges[0].l;
            T right = ranges[0].r;
            for (int i = 1; i < ranges.Count; i++)
            {
                if (right.CompareTo(ranges[i].l) < 0)
                {
                    res.Add((left, right));
                    left = ranges[i].l;
                    right = ranges[i].r;
                }
                else if (right.CompareTo(ranges[i].r) < 0)
                {
                    right = ranges[i].r;
                }
            }
            res.Add((left, right));
            return res;
        }

        // 区間マージ（離散値用／隣接する区間もマージ）
        // 使い方
        // 元の区間を(開始値, 終了値)のタプルを、配列またはListとする引数として、
        // MergeAdjacentIntervals() を呼び出す。
        // 例)
        // (int l, int r)[] input = { (5, 7), (1, 2), (4, 6), (8, 10) };
        // List<(int l, int r)> result = MergeAdjacentIntervals(input);
        // result = { (1, 2), (4, 10) }
        // 注意事項：引数として渡される元の配列またはList自体がソートされる

        // // 引数を配列で受け取る
        static List<(T l, T r)> MergeAdjacentIntervals<T>((T l, T r)[] ranges) where T : IBinaryInteger<T>
        {
            Array.Sort(ranges);
            return MergeAdjacentIntervalsCore(ranges);
        }

        // // 引数をリストで受け取る
        static List<(T l, T r)> MergeAdjacentIntervals<T>(List<(T l, T r)> ranges) where T : IBinaryInteger<T>
        {
            ranges.Sort();
            return MergeAdjacentIntervalsCore(ranges);
        }

        // // 共通処理部
        static List<(T l, T r)> MergeAdjacentIntervalsCore<T>(IReadOnlyList<(T l, T r)> ranges) where T : IBinaryInteger<T>
        {
            List<(T l, T r)> res = new();
            if (ranges.Count == 0) return res;
            T left = ranges[0].l;
            T right = ranges[0].r; 
            for (int i = 1; i < ranges.Count; i++)
            {
                // ranges[i].l が T.MinValueでも正しくなるために条件を2つに分けている
                if (right < ranges[i].l && right != ranges[i].l - T.One)
                {
                    res.Add((left, right));
                    left = ranges[i].l;
                    right = ranges[i].r;
                }
                else
                {
                    right = T.Max(right, ranges[i].r);
                }
            }
            res.Add((left, right));
            return res;
        } 

    }
}
