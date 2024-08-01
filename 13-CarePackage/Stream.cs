using System.IO.Compression;
using IntcodeComputer;
using Microsoft.VisualBasic;

public class Stream : IStream
{
    int next, x, y, score;
    public List<Cell> grid = new List<Cell>();

    public Stream()
    {
        next = 0;
    }

    public long Read()
    {
        Display();
        Console.WriteLine(score);

        return 0;
    }

    public void Write(long value)
    {
        if (next == 0)
        {
            x = (int)value;
            next = 1;
        }
        else if (next == 1)
        {
            y = (int)value;
            next = 2;
        }
        else
        {
            if (x >= 0)
                grid.Add(new Cell(x, y, (int)value));
            else
            {
                score = (int)value;
            }
            next = 0;
        }
    }
    public void Display()
    {
        long width = grid.Max(x => x.X) + 1;
        long height = grid.Max(y => y.Y) + 1;
        var array = new char[width, height];
        foreach (var pos in grid)
        {
            array[pos.X, pos.Y] = pos.Z;
        }
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Console.Write(array[x, y]);
            }
            Console.WriteLine();
        }
    }
}

