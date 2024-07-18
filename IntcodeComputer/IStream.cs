namespace IntcodeComputer
{
    public interface IStream
    {
        long Read();

        void Write(long value);
    }
}
