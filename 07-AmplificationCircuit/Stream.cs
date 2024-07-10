using System.Collections.Generic;
using IntcodeComputer;

namespace _07_AmplificationCircuit
{
    public class Stream : IStream
    {
        public List<long> Cueue = new List<long>();
        public Stream()
        {
        }
        public void Seed(long seed)
        {
            Cueue.Insert(0,seed);
        }
        public long Read()
        {
            long retval = 0;
            if (Cueue.Count > 0)
            {
                retval = Cueue[0];
                Cueue.RemoveAt(0);
            }
            return retval;
        }
        public void Write(long value)
        {
            Cueue.Add(value);
        }

    }
}
