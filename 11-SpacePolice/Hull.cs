public class Hull
{
    public Dictionary<(int, int), Panel> Panels;

    private int X;
    private int Y;
    private Direction Dirn;
    private int MinX;
    private int MaxX;
    private int MinY;
    private int MaxY;

    public Hull(int initColour = 0)
    {
        X = 0;
        Y = 0;
        Dirn = Direction.up;
        Panels = new Dictionary<(int, int), Panel>
        {
            {(X, Y), new Panel(initColour)}
        };

        MinX = 0;
        MaxX = 0;
        MinY = 0;
        MaxY = 0;
    }

    internal long GetCurrentColour()
    {
        return Panels[(X, Y)].Colour;
    }

    internal void SetCurrentColour(long colour)
    {
        Panels[(X, Y)].Colour = colour;
    }

    internal void MoveTo(long turn)
    {
        
        // Console.WriteLine($"{X,3},{Y,3} is " + (Panels[(X,Y)].Colour == 0 ? "black" : "white"));

        if (turn == 0)
            Dirn = (Direction)(((int)Dirn + 3) % 4);
        else
            Dirn = (Direction)(((int)Dirn + 1) % 4);

        switch (Dirn)
        {
            case Direction.up:
                Y--;
                if (Y < MinY)
                    MinY = Y;
                break;

            case Direction.down:
                Y++;
                if (Y > MaxY)
                    MaxY = Y;
                break;

            case Direction.left:
                X--;
                if (X < MinX)
                    MinX = X;
                break;

            case Direction.right:
                X++;
                if (X > MaxX)
                    MaxX = X;
                break;
        }

        if (!Panels.ContainsKey((X, Y)))
            Panels.Add((X, Y), new Panel(0));

    }

    internal void PrintCanvas()
    {
        for (int Y = MinY; Y <= MaxY; Y++)
        {
            for (int X = MinX; X <= MaxX; X++)
            {
                if (!Panels.ContainsKey((X, Y)))
                    Console.Write(" ");
                else
                    Console.Write(Panels[(X, Y)]);
            }
            Console.WriteLine();
        }
    }
}
