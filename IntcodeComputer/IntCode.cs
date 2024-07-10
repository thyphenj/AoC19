using System;
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
            Memory = new List<long>(memory);

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
                Mode mode1 = (Mode)((instruction / 100) % 10);
                Mode mode2 = (Mode)((instruction / 1000) % 10);
                Mode mode3 = (Mode)((instruction / 10000) % 10);
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

                    case 3: // -- Read
                        param1 = (int)Memory[pointer + 1];
                        Memory[param1] = StreamIn.Read();
                        pointer += 2;
                        break;

                    case 4: // -- Write
                        param1 = (int)Memory[pointer + 1];
                        StreamOut.Write(ValueAt(mode1, param1));
                        pointer += 2;
                        break;

                    case 5: // -- jump-if-true
                        param1 = (int)Memory[pointer + 1];
                        param2 = (int)Memory[pointer + 2];
                        if (ValueAt(mode1, param1) != 0)
                            pointer = (int)ValueAt(mode2, param2);
                        else
                            pointer += 3;
                        break;

                    case 6: // -- jump-if-false
                        param1 = (int)Memory[pointer + 1];
                        param2 = (int)Memory[pointer + 2];
                        if (ValueAt(mode1, param1) == 0)
                            pointer = (int)ValueAt(mode2, param2);
                        else
                            pointer += 3;
                        break;

                    case 7: // -- LT
                        param1 = (int)Memory[pointer + 1];
                        param2 = (int)Memory[pointer + 2];
                        param3 = (int)Memory[pointer + 3];
                        if (ValueAt(mode1, param1) < ValueAt(mode2, param2))
                            Memory[param3] = 1;
                        else
                            Memory[param3] = 0;
                        pointer += 4;
                        break;

                    case 8: // -- EQ
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
                        throw new Exception("*************BUGGER!!");
                }
                instruction = (int)Memory[pointer];
                opcode = instruction % 100;
            }
        }

        private long ValueAt(Mode mode, int location)
        {
            switch (mode)
            {
                case Mode.POSITION:
                    return Memory[location];

                case Mode.IMMEDIATE:
                    return location;

                default:
                    return 99;

            }
        }

        public long ViewMemoryLocation ( int loc)
        {
            return Memory[loc];
        }
    }
}
