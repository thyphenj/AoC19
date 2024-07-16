using System.ComponentModel;
using System.Drawing;
using System.Net.Http.Headers;

public class Grid
{

    private int Width;
    private int Height;
    private Cell[,] Raw;
    private Cell[,] Cells;
    private HashSet<int> Angles;

    public Grid(string[] input)
    {
        Width = input[0].Length;
        Height = input.Length;

        Raw = new Cell[Width, Height];
        Cells = new Cell[Width, Height];
        Angles = new HashSet<int>();

        for (int row = 0; row < Height; row++)
            for (int col = 0; col < Width; col++)
            {
                Cells[row, col] = new Cell(row, col, input[row][col] == '#');
                Raw[row, col] = new Cell(row, col, input[row][col] == '#');

                if (!(row == 0 && col == 0) && row <= col)
                {
                    int r = row;
                    int c = col;
                    if (r == 0)
                        Angles.Add(1);
                    else
                    {
                        foreach (var p in new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 }.Where(z => z < Width))
                        {
                            while (r % p == 0 && c % p == 0)
                            {
                                r /= p;
                                c /= p;
                            }
                        }
                        Angles.Add(r * 100 + c);
                    }
                }
            }
    }
    public void Reset()
    {
        for (int row = 0; row < Height; row++)
            for (int col = 0; col < Width; col++)
                Cells[row, col] = new Cell(row, col,Raw[row,col].IsAnAsteroid);
    }

    public int Scan()
    {
        int maxAsteroids = 0;

        for (int row = 0; row < Height; row++)
            for (int col = 0; col < Width; col++)
            {
                if (Cells[row, col].IsAnAsteroid)
                {
                    maxAsteroids = int.Max(maxAsteroids, ScanPerimeter(row, col));
                }
            }
        return maxAsteroids;
    }

    public int ScanPerimeter(int r, int c)
    {
        int retval = 0;

        Reset();

        foreach (var ang in Angles)
        {

            {
                int rOffset = ang / 100;
                int cOffset = ang % 100;

                int row = r + rOffset;
                int col = c + cOffset;
                while (row < Height && col < Width && !Cells[row, col].HasBeenChecked)
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

                if (rOffset != 0)
                {
                    row = r - rOffset;
                    col = c + cOffset;
                    while (row >= 0 && col < Width && !Cells[row, col].HasBeenChecked)
                    {
                        if (Cells[row, col].IsAnAsteroid)
                        {
                            Cells[row, col].HasBeenChecked = true;
                            retval++;
                            break;
                        }
                        row -= rOffset;
                        col += cOffset;
                    }
                }

                if (cOffset != 0)
                {
                    row = r + rOffset;
                    col = c - cOffset;
                    while (row < Height && col >= 0 && !Cells[row, col].HasBeenChecked)
                    {
                        if (Cells[row, col].IsAnAsteroid)
                        {
                            Cells[row, col].HasBeenChecked = true;
                            retval++;
                            break;
                        }
                        row += rOffset;
                        col -= cOffset;
                    }
                }

                if (rOffset != 0 && cOffset != 0)
                {
                    row = r - rOffset;
                    col = c - cOffset;
                    while (row >= 0 && col >= 0 && !Cells[row, col].HasBeenChecked)
                    {
                        if (Cells[row, col].IsAnAsteroid)
                        {
                            Cells[row, col].HasBeenChecked = true;
                            retval++;
                            break;
                        }
                        row -= rOffset;
                        col -= cOffset;
                    }
                }
            }
            {

                int rOffset = ang % 100;
                int cOffset = ang / 100;

                int row = r + rOffset;
                int col = c + cOffset;
                while (row < Height && col < Width && !Cells[row, col].HasBeenChecked)
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

                if (rOffset != 0)
                {
                    row = r - rOffset;
                    col = c + cOffset;
                    while (row >= 0 && col < Width && !Cells[row, col].HasBeenChecked)
                    {
                        if (Cells[row, col].IsAnAsteroid)
                        {
                            Cells[row, col].HasBeenChecked = true;
                            retval++;
                            break;
                        }
                        row -= rOffset;
                        col += cOffset;
                    }
                }

                if (cOffset != 0)
                {
                    row = r + rOffset;
                    col = c - cOffset;
                    while (row < Height && col >= 0 && !Cells[row, col].HasBeenChecked)
                    {
                        if (Cells[row, col].IsAnAsteroid)
                        {
                            Cells[row, col].HasBeenChecked = true;
                            retval++;
                            break;
                        }
                        row += rOffset;
                        col -= cOffset;
                    }
                }

                if (rOffset != 0 && cOffset != 0)
                {
                    row = r - rOffset;
                    col = c - cOffset;
                    while (row >= 0 && col >= 0 && !Cells[row, col].HasBeenChecked)
                    {
                        if (Cells[row, col].IsAnAsteroid)
                        {
                            Cells[row, col].HasBeenChecked = true;
                            retval++;
                            break;
                        }
                        row -= rOffset;
                        col -= cOffset;
                    }
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
