using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder_CS_Template.Classes
{
    internal class BridgeFinder
    {
        private readonly List<(int to, int id)>[] graph;

        public BridgeFinder(int n)
        {
            graph = new List<(int, int)>[n];
            for (int i = 0; i < n; i++) graph[i] = new();
        }

        // 辺の追加（0-indexed）
        public void AddEdge(int u, int v, int id)
        {
            graph[u].Add((v, id));
            graph[v].Add((u, id));
        }

        // 橋となる辺のIDを返す
        public List<int> GetBridges()
        {
            int n = graph.Length;
            int[] ord = new int[n];
            int[] low = new int[n];
            int[] parent = new int[n];
            int[] parentEdge = new int[n];
            int[] next = new int[n];

            Array.Fill(ord, -1);
            Array.Fill(parent, -1);
            Array.Fill(parentEdge, -1);

            int timer = 0;
            List<int> bridges = new();
            Stack<int> stack = new();

            for (int s = 0; s < n; s++)
            {
                if (ord[s] != -1) continue;

                ord[s] = low[s] = timer++;
                stack.Push(s);

                while (stack.Count > 0)
                {
                    int v = stack.Peek();

                    if (next[v] < graph[v].Count)
                    {
                        var (to, id) = graph[v][next[v]++];

                        if (id == parentEdge[v]) continue;

                        if (ord[to] == -1)
                        {
                            parent[to] = v;
                            parentEdge[to] = id;
                            ord[to] = low[to] = timer++;
                            stack.Push(to);
                        }
                        else
                        {
                            low[v] = Math.Min(low[v], ord[to]);
                        }
                    }
                    else
                    {
                        stack.Pop();

                        int p = parent[v];
                        if (p == -1) continue;

                        low[p] = Math.Min(low[p], low[v]);

                        if (low[v] > ord[p])
                            bridges.Add(parentEdge[v]);
                    }
                }
            }

            return bridges;
        }
    }
}
