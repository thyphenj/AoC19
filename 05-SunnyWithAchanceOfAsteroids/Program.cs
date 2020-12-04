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

            string line = File.ReadAllText(@"Resources/input.txt");
            foreach (var str in line.Split(new char[] { ',' }))
            {
                program.Add(long.Parse(str));
            }

            //------------------------------ Part 1 ------------------------------------
            System.Console.WriteLine("--------------------- Part 1 ---------------------------");
            {
                memory = Reset(program);

                IntCode computer = new IntCode(memory, new Stream(), new Stream());

                computer.Run();
            }
            System.Console.WriteLine();

            //------------------------------ Part 2 ------------------------------------
            System.Console.WriteLine("--------------------- Part 2 ---------------------------");

            System.Console.WriteLine();

            System.Console.WriteLine("--------------------- END ---------------------------");

        }
        private static List<long> Reset(List<long> from)
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
