using IntcodeComputer;
using System.Linq;

Console.WriteLine("--------------------- Part 1 ---------------------------");

var stream = new Stream();
var computer = new IntCode(@"Resources/input.txt", stream);

computer.Run();
stream.Display();

Console.WriteLine();


Console.WriteLine("--------------------- Part 2 ---------------------------");

var program = (from str in File.ReadAllText(@"Resources/input.txt").Split(',')
               select long.Parse(str)).ToList();

program[0] = 2;

stream = new Stream();
computer = new IntCode(program, stream);

computer.Run();

