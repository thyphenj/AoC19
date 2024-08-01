
var grid = new Grid(File.ReadAllLines(@"Resources/input.txt"));

Console.WriteLine("--------------------- Part 1 ---------------------------");

grid.Scan();
Console.WriteLine(grid.MaxAsteroids);
Console.WriteLine();

Console.WriteLine("--------------------- Part 2 ---------------------------");

var twoHundredth = grid.Destroy200(grid.MaxRow, grid.MaxCol);
Console.WriteLine(twoHundredth);

