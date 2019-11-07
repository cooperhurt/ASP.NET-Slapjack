using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlapJack
{
    public class Game
    {
        public int gameID { get; set; }

        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public Deck currDeck { get; set; }

        public string currentTurn { get; set; }

        public List<Card> currentPlay { get; set; }


        
        public static Game curr;

        public Game(string user)
        {
            player1 = new Player();
            player2 = new Player();
            currDeck = new Deck(true);
            currentPlay = new List<Card>();
            player1.Name = user;
            player1.connectionID = "";
            currentTurn = player1.Name;

            player2.Name = "";
            player2.connectionID = "";

        }


        public void playerJoined(string user)
        {
            player2.Name = user;
            player2.connectionID = "";
            StartGame();
        }

        public void StartGame()
        {
            DealHand();
        }


        public void DealHand()
        {
            int num = 0;
            foreach (var card in currDeck.cards)
            {
                if (num % 2 == 0)
                {
                    player1.Hand.addCard(card);
                    num++;
                }
                else
                {
                    player2.Hand.addCard(card);
                    num++;
                }
            }
            player1.numCards = player1.Hand.cards.Count;
            player2.numCards = player2.Hand.cards.Count;
        }


        //Switch currnent Turn to "user", but also identify whos turn it is
        public string PlayerPlay(string user)
        {
            if (user == player1.Name)
            {
                Card removeCard1 = player1.Hand.cards[0];
                player1.Hand.cards.RemoveAt(0);
                player1.numCards--;
                currentPlay.Add(removeCard1);
                currentTurn = player2.Name;
                return removeCard1.image;
            }
            Card removeCard = player2.Hand.cards[0];
            player2.Hand.cards.RemoveAt(0);
            player2.numCards--;
            currentPlay.Add(removeCard);
            currentTurn = player1.Name;
            return removeCard.image;
        }

        public void CheckFaceCard(string user)
        {
            if (user == player1.Name )
            {
                if (currentPlay[0].num == "10" || currentPlay[0].num == "J" || currentPlay[0].num == "Q" || currentPlay[0].num == "K" || currentPlay[0].num == "A")
                {
                    switch (currentPlay[0].num)
                    {
                        case "10":
                            PlayCards(1, player1);
                            break;
                        case "J":
                            PlayCards(2, player1);
                            break;
                        case "Q":
                            PlayCards(3, player1);
                            break;
                        case "K":
                            PlayCards(4, player1);
                            break;
                        default:
                            PlayCards(5, player1);
                            break;
                    }
                    currentTurn = player2.Name;
                }
                return;
            }

            if (currentPlay[0].num == "10" || currentPlay[0].num == "J" || currentPlay[0].num == "Q" || currentPlay[0].num == "K" || currentPlay[0].num == "A")
            {
                switch (currentPlay[0].num)
                {
                    case "10":
                        PlayCards(1, player1);
                        break;
                    case "J":
                        PlayCards(2, player1);
                        break;
                    case "Q":
                        PlayCards(3, player1);
                        break;
                    case "K":
                        PlayCards(4, player1);
                        break;
                    default:
                        PlayCards(5, player1);
                        break;
                }
                currentTurn = player1.Name;
            }
            return;

        }

        public void PlayCards(int numCards, Player curr)
        {
            for (int i = 0; i < numCards; i++)
            {
                currentPlay.Add(curr.Hand.cards[0]);
                curr.Hand.cards.RemoveAt(0);
                curr.numCards--;
            }

        }

        public void Slap()
        {
            Boolean validSlap = false;
            //Check sandwhich
            if (currentPlay[0].num == currentPlay[1].num)
            {
                //Determine whos wins add this to the players deck
                AddCards(player1);
                validSlap = true;
            }
            //check 2 of same card
        }

        public void AddCards(Player curr)
        {
            foreach(Card currCard in currentPlay)
            {
                curr.Hand.cards.Add(currCard);
                currentPlay.RemoveAt(0);
                curr.numCards++;
            }
        }

    }
}
