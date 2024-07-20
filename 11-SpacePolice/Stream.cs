using IntcodeComputer;

public class Stream : IStream
{
    public Hull hull;

    private bool HasBeenPainted;

    public Stream(int initColor = 0)
    {
        hull = new Hull(initColor);
        HasBeenPainted = false;
    }

    public long Read()
    {
        long col = hull.GetCurrentColour();
        return col;
    }

    public void Write(long value)
    {
        if (!HasBeenPainted)
        {
            hull.SetCurrentColour(value);
            HasBeenPainted = true;
        }
        else
        {
            hull.MoveTo(value);
            HasBeenPainted = false;
        }
    }

}

