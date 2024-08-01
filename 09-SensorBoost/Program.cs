using IntcodeComputer;

Console.WriteLine("--------------------- Part 1 ---------------------------");
var stream = new Stream(1);

var comp = new IntCode(@"Resources/input.txt", stream);

comp.Run();

Console.WriteLine();

Console.WriteLine("--------------------- Part 2 ---------------------------");
stream = new Stream(2);

comp = new IntCode(@"Resources/input.txt", stream);

comp.Run();

