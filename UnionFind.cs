using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder_CS_Template.Classes
{
    public class UnionFind
    {


    }

    /// <summary>
    /// Union-Find 簡易版
    /// ノード番号はインデックスに対応する.
    /// ノード番号は0から始まり番号の抜けは無し
    /// </summary>
    public class UnionFindLight
    {
        public List<int> parent = new List<int>();
        public List<int> rank = new List<int>();
        public List<int> size = new List<int>();

        public UnionFindLight(int n)
        {
            parent = Enumerable.Repeat(-1, n).ToList();
            rank = Enumerable.Repeat(0, n).ToList();
            size = Enumerable.Repeat(1, n).ToList();
        }

        public int Root(int i)
        {
            if (parent[i] == -1) return i;
            return parent[i] = Root(parent[i]);
        }

        public bool IsSame(int x, int y)
        {
            return Root(x) == Root(y);
        }

        public bool Unite(int x, int y)
        {
            int rx = Root(x);
            int ry = Root(y);
            if (rx == ry) return false;
            if (rank[rx] < rank[ry])
            {
                (rx, ry) = (ry, rx);
            }
            parent[ry] = rx;
            if (rank[rx] == rank[ry]) rank[rx]++;
            size[rx] += size[ry];
            return true;
        }

        public int MySize(int x)
        {
            return size[Root(x)];
        }

        public int NumOfRoot()
        {
            int ret = 0;
            int n = parent.Count();
            for (int i = 0; i < n; i++)
            {
                if (parent[i] == -1) ret++;
            }
            return ret;
        }
    }
}
