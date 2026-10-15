using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtCoder_CS_Template.Classes
{
    // 一部修正推奨らしい

    internal readonly struct ModInt
    {
        public const long Mod = 998244353;

        public long Value { get; }

        public ModInt(long x)
        {
            x %= Mod;
            if (x < 0) x += Mod;
            Value = x;
        }

        public static implicit operator ModInt(long x) { return new ModInt(x); }
        public static explicit operator int(ModInt x) { return (int)x.Value; }
        public static ModInt operator +(ModInt a, ModInt b) => new ModInt(a.Value + b.Value);
        public static ModInt operator -(ModInt a, ModInt b) => new ModInt(a.Value - b.Value);
        public static ModInt operator *(ModInt a, ModInt b) => new ModInt(a.Value * b.Value);
        public static ModInt operator /(ModInt a, ModInt b) => a * b.Inv();
        public static ModInt operator ++(ModInt a) => a + 1;
        public static ModInt operator --(ModInt a) => a - 1;
        public static bool operator <(ModInt a, ModInt b) => a.Value < b.Value;
        public static bool operator >(ModInt a, ModInt b) => a.Value > b.Value;

        public ModInt Pow(long n)
        {
            ModInt res = new ModInt(1);
            ModInt x = this;

            while (n > 0)
            {
                if ((n & 1) == 1) res *= x;
                x *= x;
                n >>= 1;
            }

            return res;
        }

        public static ModInt Factorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }

        public ModInt Inv()
        {
            long x, y;
            long g = ExtendedGcd(Value, Mod, out x, out y);

            if (g != 1)
            {
                throw new ArgumentException("逆元が無い");
            }

            x %= Mod;
            if (x < 0) x += Mod;
            return new ModInt(x);
        }

        private static long ExtendedGcd(long a, long b, out long x , out long y)
        {
            if (b == 0)
            {
                x = 1;
                y = 0;
                return a;
            }
            long g = ExtendedGcd(b, a % b, out long x1, out long y1);
            x = y1;
            y = x1 - (a / b) * y1;
            return g;
        }

        public override string ToString() => Value.ToString();

        public static bool operator ==(ModInt a, ModInt b) => a.Value == b.Value;
        public static bool operator !=(ModInt a, ModInt b) => a.Value != b.Value;

        public override bool Equals(object obj)
        {
            if (obj is ModInt other)
            {
                return Value == other.Value;
            }
            return false;
        }

        public override int GetHashCode() => Value.GetHashCode();
    }

    internal static class ModIntExtentions
    {
        public static ModInt Sum(this IEnumerable<ModInt> source)
        {
            ModInt sum = 0;
            foreach (var x in source)
            {
                sum += x;
            }
            return sum;
        }
    }

    internal static class ModMath
    {
        public static ModInt Max(ModInt a, ModInt b)
        {
            return a > b ? a : b;
        }

        public static ModInt Min(ModInt a, ModInt b)
        {
            return a < b ? a : b;
        }
    }

}
