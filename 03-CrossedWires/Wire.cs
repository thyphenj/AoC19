using System.Collections.Generic;

namespace _03_CrossedWires
{
    public class Wire
    {
        public List<Strait> Straits;

        public Wire(string str)
        {
            Straits = new List<Strait>();

            int x = 0, y = 0;
            long preLength = 0;

            foreach (var s in str.Split(","))
            {
                Straits.Add(new Strait(s, x, y, preLength));

                int length = int.Parse(s.Substring(1));

                x += length * Strait.Xdelta(s[0]);
                y += length * Strait.Ydelta(s[0]);
                preLength += length;
            }
        }
    }
}
