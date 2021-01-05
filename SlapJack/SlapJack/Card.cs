using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlapJack
{
    public class Card
    {
        /// <summary>
        /// This is the suit of the card
        /// </summary>
        public string Suits { get; set; }
        /// <summary>
        /// This is the cardnumber of the card
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// This is the actual number of the card
        /// </summary>
        public string num { get; set; }

        /// <summary>
        /// This is the image path of the card
        /// </summary>
        public string image { get; set; }
        
    }
}
