using System;
using System.IO;

namespace _03_CrossedWires
{
    class Program
    {
        static void Main(string[] args)
        {
            //------------------------------ Acquire input ------------------------------------
            string[] input = File.ReadAllLines(@"Resources/input.txt");

            var wire1 = new Wire(input[0]);
            var wire2 = new Wire(input[1]);

            bool isManhattanSeeded = false;
            bool isStepsSeeded = false;
            int minManhattan = 0;
            long minSteps = 0;

            foreach (var strait1 in wire1.Straits)
            {
                foreach (var strait2 in wire2.Straits)
                {
                    if (strait1.Crosses(strait2, out int manhattan, out long steps))
                    {
                        if (!isManhattanSeeded || minManhattan > manhattan)
                        {
                            isManhattanSeeded = true;
                            minManhattan = manhattan;
                        }
                        if (!isStepsSeeded || minSteps > steps)
                        {
                            isStepsSeeded = true;
                            minSteps = steps;
                        }
                    }
                }
            }
            System.Console.WriteLine("--------------------- Part 1 ---------------------------");
            Console.WriteLine(minManhattan);

            System.Console.WriteLine("--------------------- Part 2 ---------------------------");
            Console.WriteLine(minSteps);

            System.Console.WriteLine("\n--------------------- END ---------------------------");
        }
    }
}
