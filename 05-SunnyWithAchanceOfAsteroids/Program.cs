using System;
using System.Collections.Generic;
using System.IO;
using IntcodeComputer;

namespace _05_SunnyWithAChanceOfAsteroids
{
    class Program
    {
        static List<long> ReadIntcodeFile (string filename)
        {
            List<long> retval = new List<long>();

            string line = File.ReadAllText(filename);

            foreach (var str in line.Split(new char[] { ',' }))
            {
                retval.Add(long.Parse(str));
            }
            return retval;
        }
        static void Main(string[] args)
        {
            IntCode computer;
            List<long> program = ReadIntcodeFile (@"Resources/input.txt");

            Console.WriteLine("--------------------- Part 1 ---------------------------");

            computer = new IntCode(program, new Stream(), new Stream());
            computer.Run();

            Console.WriteLine();

            Console.WriteLine("--------------------- Part 2 ---------------------------");

            computer = new IntCode(program, new Stream(), new Stream());
            computer.Run();

            Console.WriteLine();

            Console.WriteLine("--------------------- END ---------------------------");

        }
        private static List<long> LoadProgram(List<long> from)
        {
            List<long> retval = new List<long>(from);
            //foreach (var f in from)
            //{
            //    retval.Add(f);
            //}
            return (retval);
        }
    }
}
