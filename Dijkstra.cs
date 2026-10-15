using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder_CS_Template.Classes
{
    /// <summary>
    /// ダイクストラ法_通常
    /// </summary>
    public class Dijkstra
    {
        private readonly Graph _graph;
        public long[] Dist { get; }
        public bool[] Done { get; }
        public int[] Prev { get; }

        public Dijkstra(Graph graph)
        {
            _graph = graph;
            Dist = new long[graph.NodeCount];   // start点からの最短距離. Max値で初期化される. 到達不能の時はMax値のまま.
            Done = new bool[graph.NodeCount];   // 距離確定済か
            Prev = new int[graph.NodeCount];    // 各点への経路(1つ前の頂点のインデックスが格納される)
        }

        public void Calc(int start)
        {
            if (start < 0 || start >= _graph.NodeCount)
                throw new ArgumentOutOfRangeException(nameof(start));

            Array.Fill(Dist, long.MaxValue);
            Array.Fill(Done, false);
            Array.Fill(Prev, -1);

            var pq = new PriorityQueue<int, long>();
            Dist[start] = 0;
            pq.Enqueue(start, 0);

            while (pq.TryDequeue(out int v, out long currentDist))
            {
                if (Done[v]) continue;
                Done[v] = true;

                foreach (var edge in _graph.GetEdgesFrom(v))
                {
                    if (Done[edge.To]) continue;

                    long nextDist = currentDist + edge.Cost;
                    if (nextDist < Dist[edge.To])
                    {
                        Dist[edge.To] = nextDist;
                        Prev[edge.To] = v;
                        pq.Enqueue(edge.To, nextDist);
                    }
                }
            }
        }

        public List<int> GetPath(int to)
        {
            if (to < 0 || to >= _graph.NodeCount)
                throw new ArgumentOutOfRangeException(nameof(to));

            if (Dist[to] == long.MaxValue)
                return new List<int>();

            var path = new List<int>();
            for (int cur = to; cur != -1; cur = Prev[cur])
            {
                path.Add(cur);
            }
            path.Reverse();
            return path;
        }

        public class Graph
        {
            public List<List<Edge>> Edges { get; }
            public int NodeCount => Edges.Count;

            public Graph(int nodeCount)
            {
                Edges = new List<List<Edge>>(nodeCount);
                for (int i = 0; i < nodeCount; i++)
                {
                    Edges.Add(new List<Edge>());
                }
            }

            public List<Edge> GetEdgesFrom(int from) => Edges[from];

            public void AddEdge(int from, int to, long cost)
            {
                Edges[from].Add(new Edge(to, cost));
            }
        }

        public class Edge
        {
            public int To { get; }
            public long Cost { get; }

            public Edge(int to, long cost)
            {
                To = to;
                Cost = cost;
            }
        }
    }
}
