using IntcodeComputer;

// -- Part 1 ----------------------
{
    // var stream = new Stream();
    // var comp = new IntCode(@"Resources/input.txt", stream, stream, true );

    // while ( comp.Run())
    //     ;

    // Console.WriteLine(stream.hull.Panels.Count);
}
// -- Part 2 ----------------------
{
    var stream = new Stream(1);
    var comp = new IntCode(@"Resources/input.txt", stream, stream, true);

    while (comp.Run())
        ;

    stream.hull.PrintCanvas();

    Console.WriteLine(stream.hull.Panels.Count);
}