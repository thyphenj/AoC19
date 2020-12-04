using System;

namespace _04_SecureContainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "145852-616942";

            int lo = int.Parse(input.Substring(0, 6));
            int hi = int.Parse(input.Substring(7, 6));

            int part1 = 0, part2 = 0;

            for (int pw = lo; pw <= hi; pw++)
            {
                string num = pw.ToString();
                bool isAscending = true;
                bool hasAdjacent = false;
                bool foundPair = false;

                num = '_' + num + "_";

                for (int i = 0; i < 5; i++)
                {
                    if (num[i + 1] > num[i + 2])
                        isAscending = false;
                    if (num[i + 1] == num[i + 2])
                        hasAdjacent = true;
                    if (num[i] != num[i + 1] && num[i + 1] == num[i + 2] && num[i + 2] != num[i + 3])
                        foundPair = true;
                }

                if (isAscending && hasAdjacent)
                {
                    part1++;
                    if (foundPair)
                        part2++;
                }
            }
            Console.WriteLine("------------------------ Part 1 ---------------------------");
            Console.WriteLine(part1);
            Console.WriteLine();
            Console.WriteLine("------------------------ Part 2 ---------------------------");
            Console.WriteLine(part2);
            Console.WriteLine();

        }
    }
}
