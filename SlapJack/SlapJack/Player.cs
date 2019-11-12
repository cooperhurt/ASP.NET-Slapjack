using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlapJack
{
    public class Player
    {
        public string Name { get; set; }
        public Deck Hand { get; set; }
        public string connectionID { get; set; }
        public int numCards { get; set; }

        public Player()
        {
            Hand = new Deck();
        }
    }
}
