using System.Collections.Generic;

namespace _07_AmplificationCircuit
{
    public class IntCode
    {
        List<long> Memory;
        private int Pointer;
        public bool Stopped;

        public IntCode(List<long> memory)
        {
            Stopped = false;

            Memory = new List<long>();
            foreach (var m in memory)
                Memory.Add(m);

            Pointer = 0;
        }
        public bool Run(Streams streams)
        {
            int param1, param2, param3;

            int instruction = (int)Memory[Pointer];
            int opcode = instruction % 100;

            while (opcode != 99)
            {
                int mode1 = (instruction / 100) % 10;
                int mode2 = (instruction / 1000) % 10;
                int mode3 = (instruction / 10000) % 10;
                switch (opcode)
                {
                    case 1: // -- Add
                        param1 = (int)Memory[Pointer + 1];
                        param2 = (int)Memory[Pointer + 2];
                        param3 = (int)Memory[Pointer + 3];
                        Memory[param3] = ValueAt(mode1, param1) + ValueAt(mode2, param2);
                        Pointer += 4;
                        break;

                    case 2: // -- Mult
                        param1 = (int)Memory[Pointer + 1];
                        param2 = (int)Memory[Pointer + 2];
                        param3 = (int)Memory[Pointer + 3];
                        Memory[param3] = ValueAt(mode1, param1) * ValueAt(mode2, param2);
                        Pointer += 4;
                        break;

                    case 3:
                        param1 = (int)Memory[Pointer + 1];
                        Memory[param1] = streams.Read();
                        Pointer += 2;
                        break;

                    case 4:
                        param1 = (int)Memory[Pointer + 1];
                        streams.Write(ValueAt(mode1, param1));
                        Pointer += 2;
                        break;

                    case 5:
                        param1 = (int)Memory[Pointer + 1];
                        param2 = (int)Memory[Pointer + 2];
                        if (ValueAt(mode1, param1) != 0)
                            Pointer = (int)ValueAt(mode2, param2);
                        else
                            Pointer += 3;
                        break;

                    case 6:
                        param1 = (int)Memory[Pointer + 1];
                        param2 = (int)Memory[Pointer + 2];
                        if (ValueAt(mode1, param1) == 0)
                            Pointer = (int)ValueAt(mode2, param2);
                        else
                            Pointer += 3;
                        break;

                    case 7:
                        param1 = (int)Memory[Pointer + 1];
                        param2 = (int)Memory[Pointer + 2];
                        param3 = (int)Memory[Pointer + 3];
                        if (ValueAt(mode1, param1) < ValueAt(mode2, param2))
                            Memory[param3] = 1;
                        else
                            Memory[param3] = 0;
                        Pointer += 4;
                        break;

                    case 8:
                        param1 = (int)Memory[Pointer + 1];
                        param2 = (int)Memory[Pointer + 2];
                        param3 = (int)Memory[Pointer + 3];
                        if (ValueAt(mode1, param1) == ValueAt(mode2, param2))
                            Memory[param3] = 1;
                        else
                            Memory[param3] = 0;
                        Pointer += 4;
                        break;

                    default:
                        System.Console.WriteLine("*************BUGGER!!");
                        return true;
                }
                instruction = (int)Memory[Pointer];
                opcode = instruction % 100;
            }
            return true;
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
