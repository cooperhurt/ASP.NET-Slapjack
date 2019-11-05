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
        public List<Card> currentPlay { get; set; }


        int currentTurn;

        
        public static Game curr;

        public Game(string user)
        {
            player1 = new Player();
            player2 = new Player();
            currDeck = new Deck();
            currentPlay = new List<Card>();
            player1.Name = user;
            player1.connectionID = "";

            player2.Name = "";
            player2.connectionID = "";

            currentTurn = 1;
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
        public string PlayerPlay()
        {
            if (currentTurn % 2 == 1)
            {
                currentTurn++;
                Card removeCard1 = player1.Hand.cards[0];
                player1.Hand.cards.RemoveAt(0);
                player1.numCards--;
                currentPlay.Add(removeCard1);
                return removeCard1.image;
            }

            currentTurn++;
            Card removeCard = player2.Hand.cards[0];
            player2.Hand.cards.RemoveAt(0);
            player2.numCards--;
            currentPlay.Add(removeCard);
            return removeCard.image;
        }

        public void CheckFaceCard()
        {
            if (currentTurn - 1 % 2 == 1)
            {
                if ((int)currentPlay[0].num >= 11)
                {
                    switch ((int)currentPlay[0].num)
                    {
                        case 11:
                            PlayCards(1, player1);
                            break;
                        case 12:
                            PlayCards(2, player1);
                            break;
                        case 13:
                            PlayCards(3, player1);
                            break;
                        default:
                            PlayCards(4, player1);
                            break;
                    }
                }
            }

            switch ((int)currentPlay[0].num)
            {
                case 11:
                    PlayCards(1, player2);
                    break;
                case 12:
                    PlayCards(2, player2);
                    break;
                case 13:
                    PlayCards(3, player2);
                    break;
                default:
                    PlayCards(4, player2);
                    break;
            }

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
