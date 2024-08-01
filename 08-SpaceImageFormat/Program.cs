
string line = File.ReadAllText(@"Resources/input.txt");

int layerLen = 25 * 6;
int layerCnt = line.Length / layerLen;

var grid = new Grid();

for (int i = 0; i < layerCnt; i++)
{
    grid.Add(new Layer(line.Substring(i * layerLen, layerLen)));
}

Console.WriteLine("--------------------- Part 1 ---------------------------");
Console.WriteLine(grid.WhiteTimesTrans);
Console.WriteLine();

Console.WriteLine("--------------------- Part 2 ---------------------------");
Console.WriteLine(grid);
