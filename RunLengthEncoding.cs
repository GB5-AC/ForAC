using System.Collections.Generic;

namespace AtCoder_CS_Template.Classes
{
    public class RLE
    {
        public List<int> original;
        public List<int> sorted;
        public List<int> values = new List<int>();
        public List<int> length = new List<int>();

        public RLE(IEnumerable<int> list)
        {
            original = new List<int>(list);
            sorted = new List<int>(original);
            sorted.Sort();
            Solve();
        }

        private void Solve()
        {
            int last = sorted[0];
            int len = 1;
            for (int i = 1; i < sorted.Count; i++)
            {
                if (sorted[i] != last)
                {
                    values.Add(last);
                    length.Add(len);
                    last = sorted[i];
                    len = 1;
                }
                else
                {
                    len++;
                }
            }
            values.Add(last);
            length.Add(len);
        }

        public void Reverse()
        {
            values.Reverse();
            length.Reverse();
        }
    }


    public class RLE_OLD
    {
        public List<int> original;
        public List<int> sorted;
        public List<int> values = new List<int>();
        public List<int> length = new List<int>();

        public RLE_OLD(IEnumerable<int> list)
        {
            original = new List<int>(list);
            sorted = new List<int>(original);
            sorted.Sort();
            Solve();
        }

        private void Solve()
        {
            int last = sorted[0];
            int len = 1;
            for (int i = 1; i < sorted.Count; i++)
            {
                if (sorted[i] != last)
                {
                    values.Add(last);
                    length.Add(len);
                    last = sorted[i];
                    len = 1;
                }
                else
                {
                    len++;
                }
            }
            values.Add(last);
            length.Add(len);
        }

        public void Reverse()
        {
            values.Reverse();
            length.Reverse();
        }
    }
}
