using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SlapJack.Pages
{
    public class playGameModel : PageModel
    {

        public void OnGet()
        {

        }
    }


    public class Player
    {
        public string Name { get; set; }
        public Deck Hand { get; set; }
    }

    public static class Extensions
    {
        public static void Enqueue(this Queue<Card> cards, Queue<Card> newCards)
        {
            foreach (var card in newCards)
            {
                cards.Enqueue(card);
            }
        }
    }

    public class Deck : Card
    {
        public List<Card> cards = new List<Card>();

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
                    }) ;
                }
            }

            return deck;        
        }
    }

   
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