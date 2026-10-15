using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder_CS_Template.Classes
{
    // 一部修正が必要らしい

    internal static class PrimeNumber
    {
        internal static int ceil = 10_000_000;
        internal static int[] lpf;
        internal static List<int> primes = new();

        // 線形篩・最小素因数
        internal static void Calc_LinearSieve()
        {
            lpf = Enumerable.Range(0, ceil + 1).ToArray();

            for (int x = 2; x <= ceil; x++)
            {
                if (lpf[x] == x) primes.Add(x);     // 値が更新されていなければ素数
                foreach (var p in primes)
                {
                    if ((long)p * x > ceil || p > lpf[x]) break;
                    lpf[p * x] = p;                 // 最小素因数を更新
                }
            }
        }

        internal static Dictionary<long, int> PrimeFactorize(long n)
        {
            // 事前に Calc_LinearSieve() を1回実行した後で利用すること
            Dictionary<long, int> res = new();
            while (n > 1)
            {
                int p = lpf[n];
                int cnt = 0;
                
                while (n % p == 0)
                {
                    n /= p;
                    cnt++;
                }
                res[p] = cnt;
            }

            return res;
        }

        // エラトステネスのふるい
        // // 引数n以下の素数のリストを返す
        internal static List<int> EratosthenesList(int n)
        {
            List<bool> isPrime = EratosthenesTF(n);
            List<int> ret = new List<int>();
            for (int i = 2; i <= n; i++)
            {
                if (isPrime[i])
                {
                    ret.Add(i);
                }
            }
            return ret;
        }

        // // 0 - n までの数のインデックス毎に素数か否かのTrue/Falseのリストを返す
        internal static List<bool> EratosthenesTF(int n)
        {
            List<bool> isPrime = Enumerable.Repeat(true, n + 1).ToList();
            isPrime[0] = isPrime[1] = false;
            for (int i = 2; i * i <= n; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }
            return isPrime;
        }
    }
}
