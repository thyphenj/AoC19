using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _06_UniversalOrbitMap
{
    class Program
    {
        static List<Pair> Pairs = new List<Pair>();

        static void Main(string[] args)
        {
            //------------------------------ Acquire input --------------------
            string[] input = File.ReadAllLines(@"Resources/input.txt");
            foreach (var s in input)
                Pairs.Add(new Pair(s));

            Console.WriteLine("------------------------------ Part 1 ---------------------------");

            foreach (var pair in Pairs.Where(a => a.Left == "COM"))
            {
                string s = NextLevel(1, pair);
            }

            long sum = 0;
            foreach (var pair in Pairs)
            {
                sum += pair.Level;
            }
            Console.WriteLine(sum);
            Console.WriteLine();

            Console.WriteLine("------------------------------ Part 2 ---------------------------");

            int sanLen = 0;
            Pair san = Pairs.Where(a => a.Rite == "SAN").FirstOrDefault();

            bool complete = false;
            while (san.Left != "COM" && !complete)
            {
                int youLen = 0;
                Pair you = Pairs.Where(a => a.Rite == "YOU").FirstOrDefault();

                while (you.Left != "COM" && !complete)
                {
                    if (you.Left == san.Left)
                    {
                        complete = true;
                        Console.WriteLine(youLen + sanLen);
                    }
                    else
                    {
                        youLen++;
                        you = Pairs.Where(a => a.Rite == you.Left).FirstOrDefault();
                    }
                }
                sanLen++;
                san = Pairs.Where(a => a.Rite == san.Left).FirstOrDefault();
            }
        }
        private static string NextLevel(int lev, Pair pair)
        {
            pair.Level = lev;
            string retval = $"lvl{lev.ToString().PadLeft(3)} - {pair}";
            foreach (var pair2 in Pairs.Where(a => a.Left == pair.Rite))
            {
                string s = NextLevel(lev + 1, pair2);
            }
            return retval;
        }
    }
}
