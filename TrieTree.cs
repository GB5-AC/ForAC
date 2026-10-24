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
    }
}
