using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    public class Move
    {
        public string Name { get; set; }
        public string Index { get; set; }
        public List<Move> WinsAgainst { get; set; }
        public int Uses { get; set; }

        public Move(string name, string index)
        {
            Name = name;
            Index = index;
            WinsAgainst = new List<Move>();
            Uses = 0;
        }
    }
}
