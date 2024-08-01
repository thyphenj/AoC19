using IntcodeComputer;

Console.WriteLine("--------------------- Part 1 ---------------------------");

var stream = new Stream();
var comp = new IntCode(@"Resources/input.txt", stream, true);

while (comp.Run())
    ;

Console.WriteLine(stream.hull.Panels.Count);
Console.WriteLine();

Console.WriteLine("--------------------- Part 2 ---------------------------");

stream = new Stream(1);
comp = new IntCode(@"Resources/input.txt", stream, true);

while (comp.Run())
    ;

stream.hull.PrintCanvas();
