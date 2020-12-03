using System.IO;
using System.Collections.Generic;

namespace _02_ProgramAlarm
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
                memory[1] = 12; // -- noun
                memory[2] = 2;  // -- verb

                IntCode computer = new IntCode(memory);

                computer.Run();

                System.Console.WriteLine(memory[0]);
            }
            System.Console.WriteLine();

            //------------------------------ Part 2 ------------------------------------
            System.Console.WriteLine("--------------------- Part 2 ---------------------------");
            {
                long target = 19690720;

                for (int noun = 0; noun < 100; noun++)
                {
                    for (int verb = 0; verb < 100; verb++)
                    {
                        memory = Reset(program);
                        memory[1] = noun;
                        memory[2] = verb;

                        IntCode computer = new IntCode(memory);

                        computer.Run();
                        if (memory[0] == target)
                            System.Console.WriteLine($"{noun,2} {verb,2}");
                    }
                }
            }
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
