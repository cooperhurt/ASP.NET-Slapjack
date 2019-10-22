using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlapJack
{

    
    public class Deck : Card
    {
        public Queue<Card> cards = new Queue<Card>();
        
        public Queue<Card> currentCard { get; set; }

        public Deck()
        {
            this.cards = CreateDeck();
        }

        public void addCard(Card currCard)
        {
            currentCard.Enqueue(currCard);
        }

        public static Queue<Card> CreateDeck()
        {
            Queue<Card> deck = new Queue<Card>();
            foreach (CardNumber num in Enum.GetValues(typeof(CardNumber)))
            {
                foreach (Suits suit in Enum.GetValues(typeof(Suits)))
                {
                    deck.Enqueue(new Card()
                    {
                        Suits = suit,
                        CardNumber = num,
                        image = "img/" + suit.ToString() + "/" + num.ToString(),
                    });
                }
            }

            return deck;
        }
    }
}
