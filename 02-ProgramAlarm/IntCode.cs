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
            int pointer = 0;
            int instruction = (int)Memory[pointer];
            while (instruction != 99)
            {
                int address1, address2, address3;
                switch (instruction)
                {
                    case 1: // -- Add
                        address1 = (int)Memory[pointer + 1];
                        address2 = (int)Memory[pointer + 2];
                        address3 = (int)Memory[pointer + 3];
                        Memory[address3] = Memory[address1] + Memory[address2];
                        pointer += 4;
                        break;

                    case 2: // -- Mult
                        address1 = (int)Memory[pointer + 1];
                        address2 = (int)Memory[pointer + 2];
                        address3 = (int)Memory[pointer + 3];
                        Memory[address3] = Memory[address1] * Memory[address2];
                        pointer += 4;
                        break;

                    default:
                        System.Console.WriteLine("*************BUGGER!!");
                        return;
                }
                instruction = (int)Memory[pointer];
            }

        }
    }
}
