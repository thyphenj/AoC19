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
            Console.Write("Enter 1 for part 1 or 5 for part 2 :- ");
            return long.Parse(Console.ReadLine());
        }
        public void Write(long value)
        {
            Console.WriteLine(value);
        }
    }
}
