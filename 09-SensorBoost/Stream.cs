    using IntcodeComputer;
    
    public class Stream : IStream
    {
        private long TestMode;
        public Stream(long testMode)
        {
            TestMode = testMode;
        }
        public long Read()
        {
            return TestMode;
        }
        public void Write(long value)
        {
            Console.WriteLine(value);
        }

    }

