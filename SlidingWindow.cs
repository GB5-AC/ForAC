using System;
using System.Collections.Generic;

namespace AtCoder_CS_Template.Classes
{
    // スライド最大値・最小値
    internal class SlidingWindow<T>
    {
        readonly int k;                     // ウィンドウ幅
        readonly T[] arr;                   // 走査対象の配列
        readonly LinkedList<int> q = new(); // 処理用両端Queue(配列のインデックスを入れる)
        readonly IComparer<T> cmp;          // 比較方法(optional)
        readonly bool isMax;                // True: 最大値を求める(default, False: 最小値を求める

        public SlidingWindow(T[] arr, int k, bool isMax = true, IComparer<T>? cmp = null)
        {
            this.arr = arr;
            this.k = k;
            this.isMax = isMax;
            this.cmp = cmp ?? Comparer<T>.Default;
        }

        // スライド(次のインデックスを指定)
        // i: キューに追加する走査配列のインデックス
        public void Add(int i)
        {
            while (q.Count > 0 && q.First.Value < i - k + 1)
            {
                q.RemoveFirst();
            }

            while (q.Count > 0)
            {
                int j = q.Last.Value;
                int c = cmp.Compare(arr[j], arr[i]);
                if (isMax ? c <= 0 : c >= 0)
                {
                    q.RemoveLast();
                }
                else
                {
                    break;
                }
            }
            q.AddLast(i);
        }

        // 最大値(最小値)を取得
        public T Top()
        {
            return arr [q.First.Value];
        }
    }
}
