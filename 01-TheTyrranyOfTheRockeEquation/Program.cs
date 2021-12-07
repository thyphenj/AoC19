using System.IO;
using System.Collections.Generic;

namespace _01_RocketEquation
{
    class Program
    {
        static void Main(string[] args)
        {
            //------------------------------ Acquire input ------------------------------------
            List<long> masses = new List<long>();

            foreach (string line in File.ReadLines(@"Resources/input.txt"))
            {
                masses.Add(long.Parse(line));
            }

            //------------------------------ Part 1 ------------------------------------
            System.Console.WriteLine("--------------------- Part 1 ---------------------------");
            {
                long sum = 0;
                foreach (var mass in masses)
                {
                    sum += (mass / 3) - 2;
                }
                System.Console.WriteLine(sum);
            }
            System.Console.WriteLine();

            //------------------------------ Part 2 ------------------------------------
            System.Console.WriteLine("--------------------- Part 2 ---------------------------");
            {
                long sumAllFuel = 0;

                foreach (var mass in masses)
                {
                    long fuelForModule = 0;
                    long fuel = (mass / 3) - 2;
                    while (fuel > 0)
                    {
                        fuelForModule += fuel;
                        fuel = (fuel / 3) - 2;
                    }
                    sumAllFuel += fuelForModule;
                }
                System.Console.WriteLine(sumAllFuel);
            }
            System.Console.WriteLine();

            System.Console.WriteLine("--------------------- END ---------------------------");

        }
    }
}
