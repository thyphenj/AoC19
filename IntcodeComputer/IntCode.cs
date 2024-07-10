using System;
using System.Collections.Generic;
using System.Data;

namespace IntcodeComputer
{
    public class IntCode
    {
        List<long> Memory;
        IStream StreamIn;
        IStream StreamOut;
        public bool Halted = false;
        public bool Pausable = false;
        public bool Paused = false;
        public int RestartPointer;
        public record Param(Mode mode, int location);

        public IntCode(List<long> memory, IStream streamIn = null, IStream streamOut = null, bool pausable = false)
        {
            Memory = new List<long>(memory);

            StreamIn = streamIn;
            StreamOut = streamOut;

            Pausable = pausable;
        }
        public void Run()
        {
            int pointer;
            

            if (Paused)
            { 
                pointer = RestartPointer;
                Paused = false;
            }
            else
                pointer = 0;

            int instruction = (int)Memory[pointer++];
            int opcode = instruction % 100;
            while (!Halted && !Paused)
            {
                Param param1, param2, param3;

                Mode mode1 = (Mode)((instruction / 100) % 10);
                Mode mode2 = (Mode)((instruction / 1000) % 10);
                Mode mode3 = (Mode)((instruction / 10000) % 10);
                switch (opcode)
                {
                    case 1: // -- Add
                        param1 = new Param(mode1, (int)Memory[pointer++]);
                        param2 = new Param(mode2, (int)Memory[pointer++]);
                        param3 = new Param(mode3, (int)Memory[pointer++]);

                        Memory[param3.location] = ValueAt(param1) + ValueAt(param2);

                        break;

                    case 2: // -- Mult
                        param1 = new Param(mode1, (int)Memory[pointer++]);
                        param2 = new Param(mode2, (int)Memory[pointer++]);
                        param3 = new Param(mode3, (int)Memory[pointer++]);

                        Memory[param3.location] = ValueAt(param1) * ValueAt(param2);

                        break;

                    case 3: // -- Read
                        param1 = new Param(mode1, (int)Memory[pointer++]);

                        Memory[param1.location] = StreamIn.Read();

                        break;

                    case 4: // -- Write
                        param1 = new Param(mode1, (int)Memory[pointer++]);

                        StreamOut.Write(ValueAt(param1));

                        Paused = Pausable;

                        break;

                    case 5: // -- jump-if-true
                        param1 = new Param(mode1, (int)Memory[pointer++]);
                        param2 = new Param(mode2, (int)Memory[pointer++]);

                        if (ValueAt(param1) != 0)
                            pointer = (int)ValueAt(param2);

                        break;

                    case 6: // -- jump-if-false
                        param1 = new Param(mode1, (int)Memory[pointer++]);
                        param2 = new Param(mode2, (int)Memory[pointer++]);

                        if (ValueAt(param1) == 0)
                            pointer = (int)ValueAt(param2);

                        break;

                    case 7: // -- LT
                        param1 = new Param(mode1, (int)Memory[pointer++]);
                        param2 = new Param(mode2, (int)Memory[pointer++]);
                        param3 = new Param(mode3, (int)Memory[pointer++]);

                        Memory[param3.location] = (ValueAt(param1) < ValueAt(param2)) ? 1 : 0;

                        break;

                    case 8: // -- EQ
                        param1 = new Param(mode1, (int)Memory[pointer++]);
                        param2 = new Param(mode2, (int)Memory[pointer++]);
                        param3 = new Param(mode3, (int)Memory[pointer++]);

                        Memory[param3.location] = (ValueAt(param1) == ValueAt(param2)) ? 1 : 0;

                        break;

                    case 99 : // -- HALT
                        Halted = true;
                        break;

                    default:
                        throw new Exception("*************BUGGER!!");
                }
                if (Paused)
                {
                    RestartPointer = pointer;
                }
                else if ( !Halted)
                {
                    instruction = (int)Memory[pointer++];
                    opcode = instruction % 100;
                }
            }
        }

        private long ValueAt(Param param)
        {
            switch (param.mode)
            {
                case Mode.POSITION:
                    return Memory[param.location];

                case Mode.IMMEDIATE:
                    return param.location;

                default:
                    throw new Exception($"Mode [{param.mode}] is invalid");

            }
        }

        public long ViewMemoryLocation(int loc)
        {
            return Memory[loc];
        }
    }
}
