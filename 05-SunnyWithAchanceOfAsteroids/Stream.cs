using System;
using IntcodeComputer;

namespace _05_SunnyWithAChanceOfAsteroids
{
    public  class Stream : IStream
    {
        private int SystemID;
        public Stream(int systemID)
        {
            SystemID = systemID;
        }
        public long Read() => SystemID;
        public void Write(long value)
        {
            Console.WriteLine(value);
        }
    }
}
