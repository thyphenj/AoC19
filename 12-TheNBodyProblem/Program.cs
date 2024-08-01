var testing = true;

if (testing)
{
    Console.WriteLine("--------------------- Part 1 ---------------------------");

    var moons = new MoonList(@"Resources/test.txt");
    Console.WriteLine(moons.Part1(100,10));

    Console.WriteLine("--------------------- Part 2 ---------------------------");

    moons = new MoonList(@"Resources/test.txt");
    Console.WriteLine(moons.Part2());
}
else
{
    Console.WriteLine("--------------------- Part 1 ---------------------------");

    var moons = new MoonList(@"Resources/input.txt");
    Console.WriteLine(moons.Part2());

    Console.WriteLine("--------------------- Part 2 ---------------------------");

    moons = new MoonList(@"Resources/input.txt");
    Console.WriteLine(moons.Part2());
}



