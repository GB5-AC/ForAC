using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder_CS_Template.Classes
{
    // 一部不完全

    /// <summary>
    /// 密グラフ用ダイクストラ
    /// </summary>
    public static class DijkstraDense
    {
        /// <summary>
        /// 始点から各頂点への最短移動コストを求める
        /// </summary>
        /// <param name="cost">各辺のコストのジャグ配列</param>
        /// <param name="start">始点のインデックス</param>
        /// <returns>実行後にdistに始点から各頂点への最短移動コストが格納される</returns>
        public static long[] Solve(long[,] cost, int start)
        {
            int n = cost.GetLength(0);
            const long INF = (1L << 62);

            long[] dist = new long[n];
            bool[] used = new bool[n];
            Array.Fill(dist, INF);
            dist[start] = 0;

            for (int iter = 0; iter < n; iter++)
            {
                int u = -1;
                long best = INF;

                for (int i = 0; i < n; i++)
                {
                    if (!used[i] && dist[i] < best)
                    {
                        best = dist[i];
                        u = i;
                    }
                }

                if (u == -1) break;

                used[u] = true;

                long du = dist[u];
                for (int v = 0; v < n; v++)
                {
                    long nd = du + cost[u, v];
                    if (nd < dist[v]) dist[v] = nd;
                }
            }

            return dist;
        }
    }
}
