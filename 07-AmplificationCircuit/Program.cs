using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using IntcodeComputer;

namespace _07_AmplificationCircuit
{
    class Program
    {
        static void Main(string[] args)
        {
            //------------------------------ Acquire input ------------------------------------
            List<long> program = new List<long>();
            List<long> memoryA, memoryB, memoryC, memoryD, memoryE;
            IntCode ampA, ampB, ampC, ampD, ampE;

            string line = File.ReadAllText(@"Resources/input.txt");

            foreach (var str in line.Split(new char[] { ',' }))
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

            ampA = new IntCode(memoryA);
            ampB = new IntCode(memoryB);
            ampC = new IntCode(memoryC);
            ampD = new IntCode(memoryD);
            ampE = new IntCode(memoryE);

            for (int a = 0; a < 5; a++)
                for (int b = 0; b < 5; b++) if (b != a)
                        for (int c = 0; c < 5; c++) if (c != a && c != b)
                                for (int d = 0; d < 5; d++) if (d != a && d != b && d != c)
                                        for (int e = 0; e < 5; e++) if (e != a && e != b && e != c && e != d)
                                            {
                                                Streams streams = new Streams();

                                                streams.Queue.Insert(0, a); ampA.Run(streams); //Console.WriteLine(ampA.Stopped);
                                                streams.Queue.Insert(0, b); ampB.Run(streams);
                                                streams.Queue.Insert(0, c); ampC.Run(streams);
                                                streams.Queue.Insert(0, d); ampD.Run(streams);
                                                streams.Queue.Insert(0, e); ampE.Run(streams);

                                                if (streams.Queue[0] > max)
                                                    max = streams.Queue[0];
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

            ampA = new IntCode(memoryA);
            ampB = new IntCode(memoryB);
            ampC = new IntCode(memoryC);
            ampD = new IntCode(memoryD);
            ampE = new IntCode(memoryE);

            for (int a = 0; a < 5; a++)
                for (int b = 0; b < 5; b++) if (b != a)
                        for (int c = 0; c < 5; c++) if (c != a && c != b)
                                for (int d = 0; d < 5; d++) if (d != a && d != b && d != c)
                                        for (int e = 0; e < 5; e++) if (e != a && e != b && e != c && e != d)
                                            {
                                                do
                                                {
                                                    Streams streams = new Streams();

                                                    streams.Queue.Insert(0, a + 5); ampA.Run(streams);
                                                    streams.Queue.Insert(0, b + 5); ampB.Run(streams);
                                                    streams.Queue.Insert(0, c + 5); ampC.Run(streams);
                                                    streams.Queue.Insert(0, d + 5); ampD.Run(streams);
                                                    streams.Queue.Insert(0, e + 5); ampE.Run(streams);

                                                    if (streams.Queue[0] > max)
                                                        max = streams.Queue[0];
                                                } while (!ampE.Stopped);
                                                Console.WriteLine("-- next--");
                                            }
            Console.WriteLine(max);
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
        //public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        //{
        //    return k == 0 ? new[] { new T[0] } :
        //      elements.SelectMany((e, i) => elements
        //            .Skip(i + 1)
        //            .Combinations(k - 1)
        //            .Select(c => (new[] { e })
        //            .Concat(c)));
        //}
    }
}
