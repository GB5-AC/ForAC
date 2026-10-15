using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoder_CS_Template.Classes
{
    internal static class MergeSort
    {
        internal static T[] Sort<T>(T[] arr) where T : IComparable
        {
            if (arr.Length <= 1) return arr;

            int len = arr.Length;
            int mid = len / 2;

            T[] left = new T[mid];
            T[] right = new T[len - mid];

            Array.Copy(arr, 0, left, 0, mid);
            Array.Copy(arr, mid, right, 0, arr.Length - mid);

            left = Sort(left);
            right = Sort(right);

            return Merge(left, right);
        }

        static private T[] Merge<T>(T[] left, T[] right) where T : IComparable
        {
            T[] res = new T[left.Length + right.Length];
            int i = 0, j = 0;
            int idx = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i].CompareTo(right[j]) <= 0)
                {
                    res[idx] = left[i];
                    i++;
                }
                else
                {
                    res[idx] = right[j];
                    j++;
                }
                idx++;
            }

            if (i < left.Length)
            {
                int remain = left.Length - i;
                Array.Copy(left, i, res, idx, remain);
                idx += remain;
            }

            if (j < right.Length)
            {
                int remain = right.Length - j;
                Array.Copy(right, j, res, idx, remain);
            }

            return res;
        }
    }
}
