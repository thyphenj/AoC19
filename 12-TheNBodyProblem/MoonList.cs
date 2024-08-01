using System.ComponentModel.DataAnnotations;

public class MoonList
{
    Moon[] Moons;
    Moon[] Zeros;
    long[] Matches;

    private static List<(int a, int b)> Pairs = [(0, 1), (0, 2), (0, 3), (1, 2), (1, 3), (2, 3)];

    public MoonList(string filename)
    {
        Moons = new Moon[4];
        Zeros = new Moon[4];
        Matches = new long[4];

        var lines = File.ReadAllLines(filename);
        int i = 0;
        foreach (var line in lines)
        {
            Moons[i] = new Moon(line);
            Zeros[i] = new Moon(line);
            i++;
        }
    }

    public long Part1(int iterations, int interval)
    {
        long energy = 0;
        Display(0, interval);
        for (int step = 0; step < iterations; step++)
        {
            ApplyGravity();
            Display(step + 1, interval);
            energy = CalculateEnergy();
        }
        return energy;
    }
    public long Part2()
    {
        long steps = 0;
        do
        {
            ApplyGravity();
            CheckForZero(++steps);
            if ( steps%10000 == 0)
                Console.Write($"After {steps} step" + (steps == 1 ? "" : "s") + "\r");

        }
        while (Matches.Where(z => z == 0).Any());

        Console.WriteLine();

        return steps;
    }
    public void Display(long stepNumber, int interval)
    {
        if (stepNumber % interval == 0)
        {
            Console.WriteLine($"After {stepNumber} step" + (stepNumber == 1 ? "" : "s"));
            for (int i = 0; i < 4; i++)
            {
                var m = Moons[i];
                Console.Write("Pos=<");
                Console.Write($"x={m.PosX,3}, y={m.PosY,3}, z={m.PosZ,3}");
                Console.Write(">, Vel=<");
                Console.Write($"x={m.VelX,3}, y={m.VelY,3}, z={m.VelZ,3}");
                Console.WriteLine(">");
            }
            Console.WriteLine();
        }
    }

    private void CheckForZero(long steps)
    {
        for (var i = 0; i < 4; i++)
        {
            if (Matches[i] != 0) continue;

            if (Moons[i].VelX == 0
             && Moons[i].VelY == 0
             && Moons[i].VelZ == 0)
                if (Moons[i].PosX == Zeros[i].PosX
                 && Moons[i].PosY == Zeros[i].PosY
                 && Moons[i].PosZ == Zeros[i].PosZ)
                {
                    Matches[i] = steps;
                    Display(steps, 1);
                }
        }
    }

    private long CalculateEnergy()
    {
        long retval = 0;
        foreach (var moon in Moons)
        {
            retval += (Math.Abs(moon.PosX) + Math.Abs(moon.PosY) + Math.Abs(moon.PosZ))
                * (Math.Abs(moon.VelX) + Math.Abs(moon.VelY) + Math.Abs(moon.VelZ));
        }
        return retval;
    }

      public void ApplyGravity()
    {
        foreach (var pair in Pairs)
        {
            var a = Moons[pair.a];
            var b = Moons[pair.b];

            if (a.PosX != b.PosX)
            {
                a.VelX += (a.PosX < b.PosX) ? 1 : -1;
                b.VelX -= (a.PosX < b.PosX) ? 1 : -1;
            }
            if (a.PosY != b.PosY)
            {
                a.VelY += (a.PosY < b.PosY) ? 1 : -1;
                b.VelY -= (a.PosY < b.PosY) ? 1 : -1;
            }
            if (a.PosZ != b.PosZ)
            {
                a.VelZ += (a.PosZ < b.PosZ) ? 1 : -1;
                b.VelZ -= (a.PosZ < b.PosZ) ? 1 : -1;
            }
        }
        foreach (var moon in Moons)
        {
            moon.PosX += moon.VelX;
            moon.PosY += moon.VelY;
            moon.PosZ += moon.VelZ;
        }
    }
    public override string ToString()
    {
        string retval = "";

        foreach (var m in Moons)
        {
            retval += m.ToString();
            retval += "\n";
        }

        return retval + "\n";
    }
}
