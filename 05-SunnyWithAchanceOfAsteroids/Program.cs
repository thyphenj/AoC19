using System;
using System.Collections.Generic;
using System.IO;

namespace _05_SunnyWithAChanceOfAsteroids
{

    class Program
    {
        static void Main(string[] args)
        {
            //------------------------------ Acquire input ------------------------------------
            List<long> program = new List<long>();
            List<long> memory;
            IntCode computer;

            string line = File.ReadAllText(@"Resources/input.txt");

            foreach (var str in line.Split(new char[] { ',' }))
            {
                program.Add(long.Parse(str));
            }

            //------------------------------ Part 1 ------------------------------------
            Console.WriteLine("--------------------- Part 1 ---------------------------");

            memory = LoadProgram(program);

            computer = new IntCode(memory, new Stream(), new Stream());
            computer.Run();

            Console.WriteLine();

            //------------------------------ Part 2 ------------------------------------
            Console.WriteLine("--------------------- Part 2 ---------------------------");

            memory = LoadProgram(program);
            computer = new IntCode(memory, new Stream(), new Stream());
            computer.Run();

            Console.WriteLine();

            Console.WriteLine("--------------------- END ---------------------------");

        }
        private static List<long> LoadProgram(List<long> from)
        {
            List<long> retval = new List<long>();
            foreach (var f in from)
            {
                retval.Add(f);
            }
            return (retval);
        }
    }
}
