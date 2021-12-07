using System.Collections.Generic;

namespace _07_AmplificationCircuit
{
    public class Streams
    {
        public List<long> Queue = new List<long>();

        public Streams()
        {
        }

        public long Read()
        {
            long retval = 0;
            if (Queue.Count > 0)
            {
                retval = Queue[0];
                Queue.RemoveAt(0);
            }
            return retval;
        }

        public void Write(long value)
        {
            Queue.Add(value);
        }

    }
}
