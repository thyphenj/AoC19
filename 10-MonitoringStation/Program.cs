internal class Program
{
    private static void Main()
    {
        string[] input = File.ReadAllLines(@"Resources/input.txt");

        Grid grid = new Grid(input);

        var maxAsteroids = grid.Scan();
        Console.WriteLine(maxAsteroids);

        var twoHundredth = grid.Destroy200(maxAsteroids.Item1, maxAsteroids.Item2);
        Console.WriteLine(twoHundredth);
    }
}