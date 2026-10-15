using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AtCoder_CS_Template.Classes;

namespace AtCoder_CS_Template
{
    class Common
    {   
        // 累乗
        public static long Pow(long a, long b)
        {
            long res = 1;
            while (b > 0)
            {
                if ((b & 1) == 1) res *= a;
                a *= a;
                b >>= 1;
            }
            return res;
        }

        // 階乗
        public static long Factorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }

                // Permutation
        internal static long Perm(int n, int k)
        {
            if (k < 0 || k > n) return 0;
            long res = 1;
            for (int i = 0; i < k; i++)
            {
                res *= (n - i);
            }
            return res;
        }

        // next_permutation
        public static bool NextPermutation<T>(T[] arr, int begin, int end) where T : IComparable
        {
            int left = -1;
            int right = -1;
            for (int i = end; i > begin; i--)
            {
                if (arr[i - 1].CompareTo(arr[i]) < 0)
                {
                    left = i - 1;
                    break;
                }
            }
            if (left == -1)
            {
                return false;
            }
            for (int i = end; i > begin; i--)
            {
                if (arr[i].CompareTo(arr[left]) > 0)
                {
                    right = i;
                    break;
                }
            }
            T tmp = arr[left];
            arr[left] = arr[right];
            arr[right] = tmp;
            left++;
            right = end;
            while (left < right)
            {
                tmp = arr[left];
                arr[left] = arr[right];
                arr[right] = tmp;
                left++;
                right--;
            }
            return true;
        }

        // prev_permutation
        public static bool PrevPermutation<T>(T[] arr, int begin, int end) where T : IComparable
        {
            int left = -1;
            int right = -1;
            for (int i = end; i > begin; i--)
            {
                if (arr[i - 1].CompareTo(arr[i]) > 0)
                {
                    left = i - 1;
                    break;
                }
            }
            if (left == -1)
            {
                return false;
            }
            for (int i = end; i > begin; i--)
            {
                if (arr[i].CompareTo(arr[left]) < 0)
                {
                    right = i;
                    break;
                }
            }
            T tmp = arr[left];
            arr[left] = arr[right];
            arr[right] = tmp;
            left++;
            right = end;
            while (left < right)
            {
                tmp = arr[left];
                arr[left] = arr[right];
                arr[right] = tmp;
                left++;
                right--;
            }
            return true;
        }

        // じゃんけん
        public static char Janken(char a, char b)
        {
            if (a == b) return 'D';
            if ((a == 'G' && b == 'C') || (a == 'C' && b == 'P') || (a == 'P' && b == 'G'))
            {
                return 'A';
            }
            return 'B';
        }

                // 最大公約数(ユークリッドの互除法)
        public static long GCD(long a, long b)
        {
            if (a < b) (a, b) = (b, a);
            if (b == 0) return a;
            return GCD(b, a % b);
        }

        // 最小公倍数
        public static long LCM(long a, long b)
        {
            return a / GCD(a, b) * b;
        }

        // 約数列挙
        public static List<long> Divisors(long n)
        {
            List<long> res = new List<long>();
            for (long i = 1; i * i <= n; i++)
            {
                if (n % i != 0) continue;
                res.Add(i);
                if (n / i != i) res.Add(n / i);
            }
            res.Sort();
            return res;
        }

        // 通分
        public static (long n, long d) ReduceFraction(long numerator, long denominator)
        {
            // 分母0は例外ではなく (1,0) に統一
            if (denominator == 0)
                return (1, 0);

            // 分子0は (0,1) に統一
            if (numerator == 0)
                return (0, 1);

            // 分母は常に正にする（符号は分子側へ寄せる）
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            long g = GCD(Math.Abs(numerator), Math.Abs(denominator));
            return (numerator / g, denominator / g);
        }

                // グリッド問題テンプレート
        static void GridProblem()
        {
            int[] rc = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int r = rc[0];
            int c = rc[1];

            int[] sxsy = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int sx = sxsy[0] - 1;
            int sy = sxsy[1] - 1;

            int[] gxgy = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int gx = gxgy[0] - 1;
            int gy = gxgy[1] - 1;

            string[] grid = new string[r];
            for (int i = 0; i < r; i++) grid[i] = Console.ReadLine();

            int[][] dist = new int[r][];
            for (int i = 0; i < r; i++) dist[i] = Enumerable.Repeat(-1, c).ToArray();
            dist[sx][sy] = 0;

            int[] dx = new int[4] { -1, 0, 1, 0 };
            int[] dy = new int[4] { 0, 1, 0, -1 };

            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((sx, sy));

            while (queue.Count() > 0)
            {
                (int x, int y) = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int xt = x + dx[i];
                    int yt = y + dy[i];

                    if (xt < 0 || xt >= r || yt < 0 || yt >= c) continue;
                    if (grid[xt][yt] == '#') continue;
                    if (dist[xt][yt] != -1) continue;

                    dist[xt][yt] = dist[x][y] + 1;

                    queue.Enqueue((xt, yt));
                }
            }

            Console.WriteLine(dist[gx][gy]);
        }
    }
}
