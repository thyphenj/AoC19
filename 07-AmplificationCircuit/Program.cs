using System;
using System.Collections.Generic;
using System.IO;
using IntcodeComputer;

namespace _07_AmplificationCircuit
{
    class Program
    {
        static void Main(string[] args)
        {
            //------------------------------ Acquire input ------------------------------------
            List<long> program = new List<long>();
            List<long> memoryA, memoryB, memoryC, memoryD, memoryE;

            string line = File.ReadAllText(@"Resources/input.txt");

            foreach (var str in line.Split(','))
            {
                program.Add(long.Parse(str));
            }

            Console.WriteLine("--------------------- Part 1 ---------------------------");

            long max = 0;

            memoryA = LoadProgram(program);
            memoryB = LoadProgram(program);
            memoryC = LoadProgram(program);
            memoryD = LoadProgram(program);
            memoryE = LoadProgram(program);
            Stream stream;
            for (int a = 0; a < 5; a++)
                for (int b = 0; b < 5; b++) if (b != a)
                        for (int c = 0; c < 5; c++) if (c != a && c != b)
                                for (int d = 0; d < 5; d++) if (d != a && d != b && d != c)
                                        for (int e = 0; e < 5; e++) if (e != a && e != b && e != c && e != d)
                                            {
                                                stream = new Stream();

                                                stream.Seed(a); var ampA = new IntCode(memoryA, stream, stream); ampA.Run();
                                                stream.Seed(b); var ampB = new IntCode(memoryB, stream, stream); ampB.Run();
                                                stream.Seed(c); var ampC = new IntCode(memoryC, stream, stream); ampC.Run();
                                                stream.Seed(d); var ampD = new IntCode(memoryD, stream, stream); ampD.Run();
                                                stream.Seed(e); var ampE = new IntCode(memoryE, stream, stream); ampE.Run();

                                                max = Math.Max(max, stream.Cueue[0]);
                                                // Console.WriteLine($"{a}{b}{c}{d}{e}  ->  {stream.Cueue[0]}");
                                            }
            Console.WriteLine(max);
            Console.WriteLine();

            Console.WriteLine("--------------------- Part 2 ---------------------------");

            max = 0;

            memoryA = LoadProgram(program);
            memoryB = LoadProgram(program);
            memoryC = LoadProgram(program);
            memoryD = LoadProgram(program);
            memoryE = LoadProgram(program);

            for (int a = 5; a < 10; a++)
                for (int b = 5; b < 10; b++) if (b != a)
                        for (int c = 5; c < 10; c++) if (c != a && c != b)
                                for (int d = 5; d < 10; d++) if (d != a && d != b && d != c)
                                        for (int e = 5; e < 10; e++) if (e != a && e != b && e != c && e != d)
                                            {
                                                stream = new Stream();

                                                stream.Seed(a); var ampA = new IntCode(memoryA, stream, stream, true); ampA.Run();
                                                stream.Seed(b); var ampB = new IntCode(memoryB, stream, stream, true); ampB.Run();
                                                stream.Seed(c); var ampC = new IntCode(memoryC, stream, stream, true); ampC.Run();
                                                stream.Seed(d); var ampD = new IntCode(memoryD, stream, stream, true); ampD.Run();
                                                stream.Seed(e); var ampE = new IntCode(memoryE, stream, stream, true); ampE.Run();

                                                max = Math.Max(max, stream.Cueue[0]);
                                                do
                                                {
                                                    ampA.Run();
                                                    ampB.Run();
                                                    ampC.Run();
                                                    ampD.Run();
                                                    ampE.Run();

                                                    max = Math.Max(max, stream.Cueue[0]);

                                                } while (!ampE.Halted);
                                            }
            Console.WriteLine(max);
            Console.WriteLine();

            Console.WriteLine("--------------------- END ---------------------------");
        }
        private static List<long> LoadProgram(List<long> from)
        {
            List<long> retval = new List<long>();
            foreach (var f in from)
                retval.Add(f);

            return (retval);
        }
    }
}
