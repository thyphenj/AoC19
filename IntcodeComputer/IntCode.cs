using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace IntcodeComputer
{
    public class IntCode
    {
        public bool Halted = false;

        List<long> Memory;
        IStream StreamIn;
        IStream StreamOut;
        private int RelativeBase = 0;
        private record Param(Mode TheMode, long TheParam);
        private bool Pausable = false;
        private bool Paused = false;
        private int RestartPointer;

        public IntCode(List<long> memory, IStream streamIn, IStream streamOut, bool pausable = false)
        {
            Memory = new List<long>(memory);

            StreamIn = streamIn;
            StreamOut = streamOut;

            Pausable = pausable;
        }

        public IntCode(string filename, IStream streamIn, IStream streamOut, bool pausable = false)
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
            // -- re-entry or start from scratch

            int ip = Paused ? RestartPointer : 0;

            Halted = false;
            Paused = false;
            while (!Halted && !Paused)
            {
                long instruction = Memory[ip++];
                int opcode = (int)(instruction % 100);

                Mode mode1 = (Mode)((instruction / 100) % 10);
                Mode mode2 = (Mode)((instruction / 1000) % 10);
                Mode mode3 = (Mode)((instruction / 10000) % 10);

                Param param1, param2, param3;

                switch (opcode)
                {
                    case 1: // -- Add
                        param1 = new Param(mode1, Memory[ip++]);
                        param2 = new Param(mode2, Memory[ip++]);
                        param3 = new Param(mode3, Memory[ip++]);

                        AssignAt(param3, ValueAt(param1) + ValueAt(param2));

                        break;

                    case 2: // -- Mult
                        param1 = new Param(mode1, Memory[ip++]);
                        param2 = new Param(mode2, Memory[ip++]);
                        param3 = new Param(mode3, Memory[ip++]);

                        AssignAt(param3, ValueAt(param1) * ValueAt(param2));

                        break;

                    case 3: // -- Read
                        param1 = new Param(mode1, Memory[ip++]);

                        AssignAt(param1, StreamIn.Read());

                        break;

                    case 4: // -- Write
                        param1 = new Param(mode1, Memory[ip++]);

                        StreamOut.Write(ValueAt(param1));

                        Paused = Pausable;

                        break;

                    case 5: // -- jump-if-true
                        param1 = new Param(mode1, Memory[ip++]);
                        param2 = new Param(mode2, Memory[ip++]);

                        if (ValueAt(param1) != 0)
                            ip = (int)ValueAt(param2);

                        break;

                    case 6: // -- jump-if-false
                        param1 = new Param(mode1, Memory[ip++]);
                        param2 = new Param(mode2, Memory[ip++]);

                        if (ValueAt(param1) == 0)
                            ip = (int)ValueAt(param2);

                        break;

                    case 7: // -- LT
                        param1 = new Param(mode1, Memory[ip++]);
                        param2 = new Param(mode2, Memory[ip++]);
                        param3 = new Param(mode3, Memory[ip++]);

                        AssignAt(param3, (ValueAt(param1) < ValueAt(param2)) ? 1 : 0);

                        break;

                    case 8: // -- EQ
                        param1 = new Param(mode1, Memory[ip++]);
                        param2 = new Param(mode2, Memory[ip++]);
                        param3 = new Param(mode3, Memory[ip++]);

                        AssignAt(param3, (ValueAt(param1) == ValueAt(param2)) ? 1 : 0);

                        break;

                    case 9: // -- RelBase
                        param1 = new Param(mode1, (int)Memory[ip++]);

                        RelativeBase += (int)ValueAt(param1); ;

                        break;

                    case 99: // -- HALT
                        Halted = true;
                        break;

                    default:
                        throw new Exception("*************BUGGER!!");
                }
                if (Paused)
                    RestartPointer = ip;
            }
            return !Halted;
        }

        private long ValueAt(Param param)
        {
            switch (param.TheMode)
            {
                case Mode.POSITION:
                    EnsureMemoryExists((int)param.TheParam);
                    return Memory[(int)param.TheParam];

                case Mode.IMMEDIATE:
                    return param.TheParam;

                case Mode.RELATIVE:
                    EnsureMemoryExists((int)param.TheParam + RelativeBase);
                    return Memory[(int)param.TheParam + RelativeBase];

                default:
                    throw new Exception($"Mode [{param.TheMode}] is ValueAt");
            }
        }

        private void AssignAt(Param param, long value)
        {
            switch (param.TheMode)
            {
                case Mode.POSITION:
                    EnsureMemoryExists((int)param.TheParam);
                    Memory[(int)param.TheParam] = value;
                    break;

                case Mode.IMMEDIATE:
                    throw new Exception("Can't Assign in immediate mode");

                case Mode.RELATIVE:
                    EnsureMemoryExists((int)param.TheParam + RelativeBase);
                    Memory[(int)param.TheParam + RelativeBase] = value;
                    break;

                default:
                    throw new Exception($"Mode [{param.TheMode}] is invalid on AssignAt");
            }
        }

        private void EnsureMemoryExists(int loc)
        {
            while (Memory.Count < loc + 1)
                Memory.Add(0);
        }
        public long ViewMemoryLocation(int loc)
        {
            return Memory[loc];
        }
    }
}
