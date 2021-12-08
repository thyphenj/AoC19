using System.Collections.Generic;

namespace IntcodeComputer
{
    public class IntCode
    {
        List<long> Memory;
        IStream StreamIn;
        IStream StreamOut;

        public IntCode(List<long> memory, IStream streamIn=null, IStream streamOut=null)
        {
            Memory = memory;
            StreamIn = streamIn;
            StreamOut = streamOut;
        }
        public void Run()
        {
            int param1, param2, param3;

            int pointer = 0;
            int instruction = (int)Memory[pointer];
            int opcode = instruction % 100;
            while (opcode != 99)
            {
                int mode1 = (instruction / 100) % 10;
                int mode2 = (instruction / 1000) % 10;
                int mode3 = (instruction / 10000) % 10;
                switch (opcode)
                {
                    case 1: // -- Add
                        param1 = (int)Memory[pointer + 1];
                        param2 = (int)Memory[pointer + 2];
                        param3 = (int)Memory[pointer + 3];
                        Memory[param3] = ValueAt(mode1, param1) + ValueAt(mode2, param2);
                        pointer += 4;
                        break;

                    case 2: // -- Mult
                        param1 = (int)Memory[pointer + 1];
                        param2 = (int)Memory[pointer + 2];
                        param3 = (int)Memory[pointer + 3];
                        Memory[param3] = ValueAt(mode1, param1) * ValueAt(mode2, param2);
                        pointer += 4;
                        break;

                    case 3:
                        param1 = (int)Memory[pointer + 1];
                        Memory[param1] = StreamIn.Read();
                        pointer += 2;
                        break;

                    case 4:
                        param1 = (int)Memory[pointer + 1];
                        StreamOut.Write(ValueAt(mode1, param1));
                        pointer += 2;
                        break;

                    case 5:
                        param1 = (int)Memory[pointer + 1];
                        param2 = (int)Memory[pointer + 2];
                        if (ValueAt(mode1, param1) != 0)
                            pointer = (int)ValueAt(mode2, param2);
                        else
                            pointer += 3;
                        break;

                    case 6:
                        param1 = (int)Memory[pointer + 1];
                        param2 = (int)Memory[pointer + 2];
                        if (ValueAt(mode1, param1) == 0)
                            pointer = (int)ValueAt(mode2, param2);
                        else
                            pointer += 3;
                        break;

                    case 7:
                        param1 = (int)Memory[pointer + 1];
                        param2 = (int)Memory[pointer + 2];
                        param3 = (int)Memory[pointer + 3];
                        if (ValueAt(mode1, param1) < ValueAt(mode2, param2))
                            Memory[param3] = 1;
                        else
                            Memory[param3] = 0;
                        pointer += 4;
                        break;

                    case 8:
                        param1 = (int)Memory[pointer + 1];
                        param2 = (int)Memory[pointer + 2];
                        param3 = (int)Memory[pointer + 3];
                        if (ValueAt(mode1, param1) == ValueAt(mode2, param2))
                            Memory[param3] = 1;
                        else
                            Memory[param3] = 0;
                        pointer += 4;
                        break;

                    default:
                        System.Console.WriteLine("*************BUGGER!!");
                        return;
                }
                instruction = (int)Memory[pointer];
                opcode = instruction % 100;
            }
        }

        private long ValueAt(int mode, int location)
        {
            switch (mode)
            {
                case 0:
                    return Memory[location];

                case 1:
                    return location;

                default:
                    return 99;

            }
        }

    }
}
