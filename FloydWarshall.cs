using System;
using System.Linq;

namespace AtCoder_CS_Template.Classes
{
    // 一部不完全

    internal class FloydWarshall
    {
        const long e16 = 10000000000000000L;
        public long[][] dist;


        public FloydWarshall(int numOfNode)
        {
            dist = new long[numOfNode][];
            for (int i = 0; i < numOfNode; i++)
            {
                dist[i] = Enumerable.Repeat(e16, numOfNode).ToArray();
                dist[i][i] = 0;
            }
        }

        public void Calc()
        {
            for (int k = 0; k < dist.Length; k++)
            {
                for (int i = 0; i < dist.Length; i++)
                {
                    for (int j = 0; j < dist.Length; j++)
                    {
                        dist[i][j] = Math.Min(dist[i][j], dist[i][k] + dist[k][j]);
                    }
                }
            }
        }
    }
}
