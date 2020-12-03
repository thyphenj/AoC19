using System.Collections.Generic;
namespace _02_ProgramAlarm
{
    public class IntCode
    {
        List<long> Memory;

        public IntCode(List<long> memory)
        {
            Memory = memory;
        }

        public void Run()
        {
            int sp = 0;
            while (Memory[sp] != 99)
            {
                int oper1, oper2, oper3;
                switch (Memory[sp])
                {
                    case 1: // -- Add
                        oper1 = (int)Memory[sp + 1];
                        oper2 = (int)Memory[sp + 2];
                        oper3 = (int)Memory[sp + 3];
                        Memory[oper3] = Memory[oper1] + Memory[oper2];
                        sp += 4;
                        break;

                    case 2: // -- Mult
                        oper1 = (int)Memory[sp + 1];
                        oper2 = (int)Memory[sp + 2];
                        oper3 = (int)Memory[sp + 3];
                        Memory[oper3] = Memory[oper1] * Memory[oper2];
                        sp += 4;
                        break;

                    default:
                        System.Console.WriteLine("*************BUGGER!!");
                        break;
                }
            }

        }
    }
}
