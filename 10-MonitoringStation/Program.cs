internal class Program
{
    private static void Main()
    {
        string[] input = File.ReadAllLines(@"Resources/input.txt");

        Grid grid = new Grid(input);

        Console.WriteLine(grid);
        Console.WriteLine();
        Console.WriteLine( grid.Scan());
        Console.WriteLine();

        Console.WriteLine(grid);
    }
}