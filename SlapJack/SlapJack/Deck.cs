using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlapJack
{

    
    public class Deck : Card
    {
        public List<Card> cards { get; set; }
        

        public Deck()
        {
            this.cards = CreateDeck();
        }

        public void addCard(Card currCard)
        {
            cards.Add(currCard);
        }

        public static List<Card> CreateDeck()
        {
            List<Card> deck = new List<Card>();
            foreach (CardNumber num in Enum.GetValues(typeof(CardNumber)))
            {
                foreach (Suits suit in Enum.GetValues(typeof(Suits)))
                {
                    deck.Add(new Card()
                    {
                        Suits = suit,
                        CardNumber = num,
                        image = "img/" + suit.ToString() + "/" + num.ToString(),
                    });
                }
            }
            //Random rnd = new Random();
            //deck.Sort((a, b) => 1 - 2 * rnd.Next(0, 100));

            return deck;
        }
    }
}
