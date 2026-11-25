using System;
using System.Collections.Generic;

namespace AtCoder_CS_Template.Classes
{
    // トポロジカルソート（BFS版 / Kahn法）
    // 有向グラフを対象とする
    // 頂点番号は0-indexed
    // 計算量：O(V + E)
    // 空間計算量：O(V)（入力グラフを除く）
    internal static class TopologicalSort
    {
        // トポロジカルソートを行う
        // 戻り値：DAGであればtrue、閉路があればfalse
        // order：トポロジカルソートの結果
        // falseの場合、orderには処理できた頂点のみが格納される
        internal static bool Sort(List<int>[] graph, out List<int> order)
        {
            int n = graph.Length;

            // 各頂点の入次数を求める
            int[] indegree = new int[n];

            for (int v = 0; v < n; v++)
            {
                foreach (int to in graph[v])
                {
                    indegree[to]++;
                }
            }

            // 入次数0の頂点をQueueに格納する
            Queue<int> q = new();

            for (int v = 0; v < n; v++)
            {
                if (indegree[v] == 0)
                {
                    q.Enqueue(v);
                }
            }

            // トポロジカルソート
            order = new List<int>(n);

            while (q.Count > 0)
            {
                int v = q.Dequeue();
                order.Add(v);

                foreach (int to in graph[v])
                {
                    indegree[to]--;

                    if (indegree[to] == 0)
                    {
                        q.Enqueue(to);
                    }
                }
            }

            // 全頂点を処理できたか否かでDAG判定
            return order.Count == n;
        }

        // DAGであるか否かを判定する
        internal static bool IsDAG(List<int>[] graph)
        {
            return Sort(graph, out _);
        }
    }
}
