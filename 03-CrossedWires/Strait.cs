using System.Drawing;
using System;

namespace _03_CrossedWires
{
    public class Strait
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int XDir { get; set; }
        public int YDir { get; set; }
        public int Length { get; set; }
        public long PreLength { get; set; }

        private string Raw { get; set; }

        public Strait(string s, int x, int y, long preLength)
        {
            Raw = s;
            X = x;
            Y = y;
            PreLength = preLength;
            XDir = Xdelta(s[0]);
            YDir = Ydelta(s[0]);
            Length = int.Parse(s.Substring(1));
        }

        public bool Crosses(Strait that, out int manhattan, out long steps)
        {
            manhattan = 0;
            steps = 0;

            // Ignore origin
            if (this.X == that.X && this.Y == that.Y && this.X == 0 && this.Y == 0)
                return false;

            // Can't cross if in same direction!
            if (Math.Abs(this.XDir) == Math.Abs(that.XDir))
                return false;

            if (this.XDir != 0 && IsBetween(that.X, this.X, this.X + this.Length * this.XDir))
            {
                if (that.YDir != 0 && IsBetween(this.Y, that.Y, that.Y + that.Length * that.YDir))
                {
                    manhattan = Math.Abs(that.X) + Math.Abs(this.Y);
                    steps = this.PreLength + this.XDir * (that.X - this.X);
                    steps += that.PreLength + that.YDir * (this.Y - that.Y);
                    return true;
                }
            }
            if (this.YDir != 0 && IsBetween(that.Y, this.Y, this.Y + this.Length * this.YDir))
            {
                if (that.XDir != 0 && IsBetween(this.X, that.X, that.X + that.Length * that.XDir))
                {
                    manhattan = Math.Abs(this.X) + Math.Abs(that.Y);
                    steps = this.PreLength + this.YDir * (that.Y - this.Y);
                    steps += that.PreLength + that.XDir * (this.X - that.X);
                    return true;
                }
            }

            return false;
        }

        public static int Xdelta(char d)
        {
            return d switch { 'L' => -1, 'R' => +1, _ => 0 };
        }

        public static int Ydelta(char d)
        {
            return d switch { 'D' => -1, 'U' => +1, _ => 0 };
        }

        private bool IsBetween(int a, int val1, int val2)
        {
            if (val1 < val2)
                return val1 <= a && a <= val2;
            else
                return val2 <= a && a <= val1;

        }

    }
}