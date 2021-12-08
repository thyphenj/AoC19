using System;
using IntcodeComputer;

namespace _05_SunnyWithAChanceOfAsteroids
{
    public  class Stream : IStream
    {
        public Stream()
        {
        }
        public long Read()
        {
            Console.Write("Enter 1 for part 1 (or 2 for part 2) :- ");
            if (Console.ReadLine() == "1")
                return 1;
            else
                return 5;
        }
        public void Write(long value)
        {
            Console.WriteLine(value);
        }
    }
}
