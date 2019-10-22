using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlapJack
{
    public enum Suits
    {

        Spades = 'S',
        Hearts = 'H',
        Diamonds = 'D',
        Clubs = 'C',
    }
    public enum CardNumber
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 'J',
        Queen = 'Q',
        King = 'K',
        Ace = 'A',
    }
    public class Card
    {
        public Suits Suits { get; set; }
        public CardNumber CardNumber { get; set; }
        public string image { get; set; }

    }
}
