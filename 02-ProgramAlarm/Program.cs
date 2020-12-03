using System.IO;
using System.Collections.Generic;

namespace _02_ProgramAlarm
{
    class Program
    {
        static void Main(string[] args)
        {
            //------------------------------ Acquire input ------------------------------------
            List<long> memory = new List<long>();

            string line = File.ReadAllText(@"Resources/input.txt");
            //            line = "1,9,10,3,2,3,11,0,99,30,40,50";
            foreach (var str in line.Split(new char[] { ',' }))
            {
                memory.Add(long.Parse(str));
            }
            memory[1] = 12;
            memory[2] = 2;

            //------------------------------ Part 1 ------------------------------------
            System.Console.WriteLine("--------------------- Part 1 ---------------------------");
            {
                IntCode computer = new IntCode(memory);

                computer.Run();

                System.Console.WriteLine(memory[0]);
            }
            System.Console.WriteLine();

            //------------------------------ Part 2 ------------------------------------
            System.Console.WriteLine("--------------------- Part 2 ---------------------------");

            System.Console.WriteLine();

            System.Console.WriteLine("--------------------- END ---------------------------");

        }
    }
}
