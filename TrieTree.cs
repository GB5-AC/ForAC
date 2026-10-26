using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder_CS_Template.Classes
{
    internal class TrieTree
    {
        class Node
        {
            public Dictionary<char, Node> Children = new();
            public bool IsEnd = false;
        }

        private readonly Node root = new();

        // 文字列の追加
        public void Insert(string s)
        {
            Node node = root;
            foreach (char c in s)
            {
                if (!node.Children.ContainsKey(c)) node.Children[c] = new Node();
                node = node.Children[c];
            }
            node.IsEnd = true;
        }

        // 文字列の削除
        public bool Remove(string s)
        {
            return Remove(root, s, 0).removed;
        }

        // 文字列の削除（再帰処理）
        private (bool removed, bool deleteNode) Remove(Node node, string s, int index)
        {
            if (index == s.Length)
            {
                if (!node.IsEnd) return (false, false);

                node.IsEnd = false;
                return (true, node.Children.Count == 0);
            }

            char c = s[index];
            if (!node.Children.TryGetValue(c, out Node? next)) return (false, false);

            var (removed, deleteNode) = Remove(next, s, index + 1);

            if (deleteNode) node.Children.Remove(c);

            return (removed, !node.IsEnd && node.Children.Count == 0);
        }

        // 完全一致検索
        public bool Search(string s)
        {
            Node node = root;
            foreach (char c in s)
            {
                if (!node.Children.TryGetValue(c, out Node? next)) return false;
                node = next;
            }
            return node.IsEnd;
        }

        // 接頭辞検索
        public bool StartsWith(string prefix)
        {
            Node node = root;
            foreach (char c in prefix)
            {
                if (!node.Children.TryGetValue(c, out Node? next)) return false;
                node = next;
            }
            return true;
        }

        // sの部分文字列のうち、Trie木に登録されているものの個数
        // includeWhole: s全体と一致する場合もカウントする
        // countDuplicates: 同じ文字列が複数回出現した場合もそれぞれカウントする
        public int CountSubstrings(
            string s,
            bool includeWhole = true,
            bool countDuplicates = false)
        {
            HashSet<Node> found = new();
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                Node node = root;

                for (int j = i; j < s.Length; j++)
                {
                    if (!node.Children.TryGetValue(s[j], out Node? next))
                        break;

                    node = next;

                    if (!node.IsEnd) continue;

                    // 文字列全体との一致を除外する場合
                    if (!includeWhole && i == 0 && j == s.Length - 1)
                        continue;

                    if (countDuplicates || found.Add(node))
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
