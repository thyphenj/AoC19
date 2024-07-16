    using IntcodeComputer;
    
    public class Stream : IStream
    {
        public Stream()
        {
        }
        public long Read()
        {
            Console.Write("> ");
            string retval = Console.ReadLine()??"";
            return long.Parse(retval);
        }
        public void Write(long value)
        {
            Console.WriteLine(value);
        }

    }

