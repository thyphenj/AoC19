using System.Collections.Generic;
using System.Drawing;

namespace _03_CrossedWires
{
    public class Wire
    {
        public List<Point> Positions;

        public Wire(string str)
        {
            Positions = new List<Point>();

            int x = 0, y = 0;
            int xdelta = 0, ydelta = 0;

            foreach (var s in str.Split(","))
            {
                char direction = s[0];
                switch (direction)
                {
                    case 'U':

                        xdelta = 0;
                        ydelta = 1;
                        break;

                    case 'D':
                        xdelta = 0;
                        ydelta = -1;
                        break;

                    case 'R':
                        xdelta = 1;
                        ydelta = 0;
                        break;

                    case 'L':
                        xdelta = -1;
                        ydelta = 0;
                        break;

                    default:
                        System.Console.WriteLine("*************WHAT!!!!");
                        return;
                }

                int length = int.Parse(s.Substring(1));
                for (int i = 0; i < length; i++)
                {
                    x += xdelta;
                    y += ydelta;
                    Positions.Add(new Point(x, y));
                }
            }
        }
    }
}
