using IntcodeComputer;

var stream = new Stream();

var comp = new IntCode(@"Resources/input.txt", stream, stream );

comp.Run();

Console.WriteLine();


