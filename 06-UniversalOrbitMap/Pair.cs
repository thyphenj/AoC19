using System.Collections.Generic;

namespace _06_UniversalOrbitMap
{
    public class Pair
    {
        private string Raw { get; set; }
        public string Left { get; set; }
        public string Rite { get; set; }
        public int Level { get; set; }

        public Pair(string raw)
        {
            Raw = raw;
            string[] both = Raw.Split(')');
            Left = both[0];
            Rite = both[1];
        }
        public override string ToString()
        {
            return ($"{Left} <- {Rite}");
        }
    }
}
