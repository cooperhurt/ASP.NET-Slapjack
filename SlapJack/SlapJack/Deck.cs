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
            this.cards = new List<Card>();
        }

        public Deck(Boolean tmp)
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
            List<string> suit = new List<string>() { "S", "H", "D", "C" };
            List<string> cardNum = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (string typeSuit in suit)
            {
                foreach (string cardNumber in cardNum)
                {


                    deck.Add(new Card()
                    {

                        Suits = typeSuit,
                        CardNumber = cardNumber,
                        num = cardNumber,
                        image = "img/"  + cardNumber + typeSuit + ".png",
                    }); ;
                }
            }

            int n = deck.Count;
            Random rng = new Random();
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }


            return deck;
        }


    }
}
