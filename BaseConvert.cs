using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder_CS_Template.Classes
{
    internal static class BaseConvert
    {
        /// <summary>
        /// n進数の基数を変更して別のm進数に変換する
        /// </summary>
        /// <param name="s">A進数の文字列</param>
        /// <param name="fromBase">変換前の基数</param>
        /// <param name="toBase">変換後の基数. 2～36を想定.</param>
        /// <returns></returns>
        public static string ConvertBaseFast(string s, int fromBase, int toBase)
        {
            // 10進(long)に変換
            long value = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int d = CharToDigit(s[i]);
                value = value * fromBase + d;
            }

            if (value == 0) return "0";

            // 10進(long) → B進文字列
            char[] buf = new char[64];
            int pos = buf.Length;

            while (value > 0)
            {
                long rem = value % toBase;
                value /= toBase;
                buf[--pos] = DigitToChar((int)rem);
            }

            return new string(buf, pos, buf.Length - pos);
        }

        // '0'〜'9','A'〜'Z','a'〜'z' を 0〜35 に変換
        private static int CharToDigit(char c)
        {
            if ((uint)(c - '0') < 10u) return c - '0';
            if ((uint)(c - 'A') < 26u) return c - 'A' + 10;
            if ((uint)(c - 'a') < 26u) return c - 'a' + 10;
            return 0;
        }

        // 0〜35 を '0'〜'9','a'〜'z' に変換（出力は小文字）
        private static char DigitToChar(int d)
        {
            if (d < 10) return (char)('0' + d);
            return (char)('a' + (d - 10));
        }
    }
}
