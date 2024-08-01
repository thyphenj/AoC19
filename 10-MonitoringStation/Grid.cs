public class Grid
{
    private int Width;
    private int Height;
    private Cell[,] Raw;
    private Cell[,] Cells;
    private AngleList Angles;

        public int MaxAsteroids ;
        public int MaxRow ;
        public int MaxCol ;

    public Grid(string[] input)
    {
        Width = input[0].Length;
        Height = input.Length;

        Raw = new Cell[Width, Height];
        Cells = new Cell[Width, Height];

        Angles = new AngleList(Width, Height);

        for (int row = 0; row < Height; row++)
            for (int col = 0; col < Width; col++)
                Raw[row, col] = new Cell(row, col, input[row][col] == '#');

        // foreach (var ang in Angles)
        //     Console.WriteLine(ang);

        // Console.WriteLine();

    }
    public void Reset()
    {
        for (int row = 0; row < Height; row++)
            for (int col = 0; col < Width; col++)
                Cells[row, col] = new Cell(row, col, Raw[row, col].IsAnAsteroid);
    }

    public void Scan()
    {
        MaxAsteroids = 0;
        MaxRow = 0;
        MaxCol = 0;

        for (int row = 0; row < Height; row++)
            for (int col = 0; col < Width; col++)
            {
                Reset();

                if (Cells[row, col].IsAnAsteroid)
                {
                    var numAsteroids = ScanPerimeter(row, col);
                    if (numAsteroids > MaxAsteroids)
                    {
                        MaxAsteroids = int.Max(MaxAsteroids, numAsteroids);
                        MaxRow = row;
                        MaxCol = col;
                    }
                }
            }
    }
    public int Destroy200(int r, int c)
    {
        int row;
        int col;

        int hits = 0;

        while (true)
        {
            foreach (var ang in Angles)
            {
                row = r + ang.RowOffset;
                col = c + ang.ColOffset;

                while (IsLocationInsideGrid(row, col))
                {
                    if (Cells[row, col].IsAnAsteroid)
                    {
                        hits++;
                        if (hits == 200)
                            return col * 100 + row;
                        else
                            Cells[row, col].IsAnAsteroid = false;
                        break;
                    }
                    row += ang.RowOffset;
                    col += ang.ColOffset;
                }
            }
            System.Console.WriteLine();
        }
    }
    private bool IsLocationInsideGrid(int row, int col)
    {
        return (row >= 0 && col >= 0 && row < Height && col < Width);
    }
    public int ScanPerimeter(int r, int c)
    {
        int retval = 0;

        foreach (var ang in Angles)
        {
            {
                int rOffset = ang.RowOffset;
                int cOffset = ang.ColOffset;

                int row = r + rOffset;
                int col = c + cOffset;
                while (IsLocationInsideGrid(row, col) && !Cells[row, col].HasBeenChecked)
                {
                    if (Cells[row, col].IsAnAsteroid)
                    {
                        Cells[row, col].HasBeenChecked = true;
                        retval++;
                        break;
                    }
                    row += rOffset;
                    col += cOffset;
                }
            }
        }
        return retval;
    }

    private List<int> GetPrimeFactors(int row)
    {
        if (row == 0)
            return new List<int>();

        var retval = new List<int>();
        string str = "";
        foreach (var p in new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 })
        {
            if (row % p == 0)
            {
                retval.Add(p);
                str += ($"{p,2} ");
            }
        }
        return retval;
    }
    public override string ToString()
    {
        string retval = "";
        for (int row = 0; row < Height; row++)
        {
            for (int col = 0; col < Width; col++)
            {
                retval += Cells[row, col].ToString();
            }
            retval += "\n";
        }

        return retval; ;
    }
}
