using System;
using System.Collections.Generic;
using System.IO;

namespace IntcodeComputer
{
    public class IntCode
    {
        public bool Halted = false;

        List<long> Memory;
        IStream StreamIn;
        IStream StreamOut;
        int RelativeBase = 0;
        record Param(Mode mode, int location);
        bool Pausable = false;
        bool Paused = false;
        int RestartPointer;

        public IntCode(List<long> memory, IStream streamIn = null, IStream streamOut = null, bool pausable = false)
        {
            Memory = new List<long>(memory);

            StreamIn = streamIn;
            StreamOut = streamOut;
        }
        public IntCode(string filename, IStream streamIn = null, IStream streamOut = null, bool pausable = false)
        {
            Memory = new List<long>();

            foreach (var n in File.ReadAllText(filename).Split(','))
                Memory.Add(long.Parse(n));

            StreamIn = streamIn;
            StreamOut = streamOut;

            Pausable = pausable;
        }
        public bool Run()
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
                Console.Write($"\n{instruction,6} - ");
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

                        AssignAt(param3, ValueAt(param1) + ValueAt(param2));

                        break;

                    case 2: // -- Mult
                        param1 = new Param(mode1, (int)Memory[pointer++]);
                        param2 = new Param(mode2, (int)Memory[pointer++]);
                        param3 = new Param(mode3, (int)Memory[pointer++]);

                        AssignAt(param3, ValueAt(param1) * ValueAt(param2));

                        break;

                    case 3: // -- Read
                        param1 = new Param(mode1, (int)Memory[pointer++]);

                        AssignAt(param1, StreamIn.Read());

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

                        AssignAt(param3, (ValueAt(param1) < ValueAt(param2)) ? 1 : 0);

                        break;

                    case 8: // -- EQ
                        param1 = new Param(mode1, (int)Memory[pointer++]);
                        param2 = new Param(mode2, (int)Memory[pointer++]);
                        param3 = new Param(mode3, (int)Memory[pointer++]);

                        AssignAt(param3, (ValueAt(param1) == ValueAt(param2)) ? 1 : 0);

                        break;

                    case 9: // -- RelBase
                        param1 = new Param(mode1, (int)Memory[pointer++]);

                        RelativeBase += (int)ValueAt(param1);;

                        break;

                    case 99: // -- HALT
                        Halted = true;
                        break;

                    default:
                        throw new Exception("*************BUGGER!!");
                }
                if (Paused)
                {
                    RestartPointer = pointer;
                }
                else if (!Halted)
                {
                    instruction = (int)Memory[pointer++];
                    opcode = instruction % 100;
                }
            }
            return !Halted;
        }

        private long ValueAt(Param param)
        {
            switch (param.mode)
            {
                case Mode.POSITION:
                    EnsureMemoryExists(param.location);
                    return Memory[param.location];

                case Mode.IMMEDIATE:
                    return param.location;

                case Mode.RELATIVE:
                    EnsureMemoryExists(param.location + RelativeBase);
                    return Memory[param.location + RelativeBase];

                default:
                    throw new Exception($"Mode [{param.mode}] is ValueAt");
            }
        }

        private void AssignAt(Param param, long value)
        {
            switch (param.mode)
            {
                case Mode.POSITION:
                    EnsureMemoryExists(param.location);
                    Memory[param.location] = value;
                    break;

                case Mode.IMMEDIATE:
                    throw new Exception("Can't Assign in immediate mode");

                case Mode.RELATIVE:
                    EnsureMemoryExists(param.location + RelativeBase);
                    Memory[param.location + RelativeBase] = value;
                    break;

                default:
                    throw new Exception($"Mode [{param.mode}] is invalid on AssignAt");
            }
        }

        private void EnsureMemoryExists( int loc )
        {
            while (Memory.Count < loc+1)
                Memory.Add(0);
        }
        public long ViewMemoryLocation(int loc)
        {
            return Memory[loc];
        }
    }
}
