using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder_CS_Template.Classes
{
    // 外部から指定する要素番号は 0-indexed
    // Query(left, right) は半開区間 [left, right)
    // 内部のツリー配列は 1-indexed だが、利用側では意識しなくてよい
    internal class SegTree<T>
    {
        private readonly T[] node;
        private readonly Func<T, T, T> op;
        private readonly T identity;

        public int DataSize { get; }
        public int LeafSize { get; }

        public SegTree(int dataSize, Func<T, T, T> op, T identity)
        {
            DataSize = dataSize;
            this.op = op;
            this.identity = identity;

            LeafSize = 1;
            while (LeafSize < dataSize) LeafSize <<= 1;

            node = new T[LeafSize * 2];
            Array.Fill(node, identity);
        }

        public SegTree(T[] data, Func<T, T, T> op, T identity)
            : this(data.Length, op, identity)
        {
            for (int i = 0; i < data.Length; i++)
                node[LeafSize + i] = data[i];

            for (int i = LeafSize - 1; i >= 1; i--)
                node[i] = op(node[i * 2], node[i * 2 + 1]);
        }

        public void Update(int index, T value)
        {
            int i = LeafSize + index;
            node[i] = value;

            while (i > 1)
            {
                i >>= 1;
                node[i] = op(node[i * 2], node[i * 2 + 1]);
            }
        }

        public T Get(int index)
        {
            return node[LeafSize + index];
        }

        // [left, right)
        public T Query(int left, int right)
        {
            T resultLeft = identity;
            T resultRight = identity;

            left += LeafSize;
            right += LeafSize;

            while (left < right)
            {
                if ((left & 1) == 1)
                    resultLeft = op(resultLeft, node[left++]);

                if ((right & 1) == 1)
                    resultRight = op(node[--right], resultRight);

                left >>= 1;
                right >>= 1;
            }

            return op(resultLeft, resultRight);
        }

        public T All => node[1];
    }
}
