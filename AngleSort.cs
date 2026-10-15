using System;

namespace AtCoder_CS_Template.Classes
{
    internal class AngleSort : IComparable<AngleSort>
    {
        public long x { get; }
        public long y { get; }

        public bool quad12 { get; }     // 第1象限か第2象限か？(0 <= a < pi)

        public AngleSort(long x, long y)
        {
            this.x = x; this.y = y;
            quad12 = y > 0 || (y == 0 && x > 0);
        }

        public int CompareTo(AngleSort? other)
        {
            if (other == null) return 1;

            if (this.quad12 != other.quad12)
            {
                return this.quad12 ? -1 : 1;
            }

            long cross_1 = x * other.y;
            long cross_2 = y * other.x;

            if (cross_1 > cross_2)
            {
                return -1;
            }
            else if (cross_1 < cross_2)
            {
                return 1;
            }

            return 0;
        }
    }
}
