using System.IO;
using System.Collections.Generic;
using System;

namespace _03_CrossedWires
{
    class Program
    {
        static void Main(string[] args)
        {
            //------------------------------ Acquire input ------------------------------------
            List<Wire> wires = new List<Wire>();
            string[] input = File.ReadAllLines(@"Resources/input.txt");

            foreach (string str in input)
            {
                wires.Add(new Wire(str));
            }

            //------------------------------ Part 1 ------------------------------------
            System.Console.WriteLine("--------------------- Part 1 ---------------------------");
            {
                int i = 0;

                int? minDistance = null;

                foreach (var pos in wires[0].Positions)
                {
                    Console.Write($"{++i,6} {DateTime.Now}\r");
                    if (i % 1000 == 0)
                        Console.WriteLine();
                    if (wires[1].Positions.Contains(pos))
                    {
                        int distance = Math.Abs(pos.X) + Math.Abs(pos.Y);

                        if (!minDistance.HasValue)
                            minDistance = distance;
                        else if (minDistance > distance)
                            minDistance = distance;
                    }
                }
                System.Console.WriteLine(minDistance);
            }

            //------------------------------ Part 2 ------------------------------------
            System.Console.WriteLine("--------------------- Part 2 ---------------------------");
            {
            }
            System.Console.WriteLine("\n--------------------- END ---------------------------");

        }
    }
}
