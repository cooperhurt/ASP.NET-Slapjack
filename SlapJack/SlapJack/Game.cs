using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlapJack
{
    public class Game
    {

        Player player1;
        Player player2;
        private Deck currDeck;
        List<Card> currentPlay;

        int currentTurn;
        bool play1Penalized;
        bool play2penalized;

        Game()
        {
            player1.Name = "";
            player2.Name = "";
            play1Penalized = false;
            play2penalized = false;
            currentTurn = 1;
            currDeck = new Deck();
            currentPlay = new List<Card>();
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


        public string PlayerPlay()
        {
            if (currentTurn % 2 == 1)
            {
                currentTurn++;
                Card removeCard1 = player1.Hand.cards.Dequeue();
                player1.numCards--;
                currentPlay.Add(removeCard1);
                return removeCard1.image;
            }

            currentTurn++;
            Card removeCard = player2.Hand.cards.Dequeue();
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
                currentPlay.Add(curr.Hand.cards.Dequeue());
                curr.numCards--;
            }

        }

        public void Slap()
        {
            //Check sandwhich
            if (currentPlay[0].num == currentPlay[1].num)
            {
                //Determine whos wins add this to the players deck
                AddCards(player1);
            }
            //check 2 of same card
        }

        public void AddCards(Player curr)
        {
            foreach(Card currCard in currentPlay)
            {
                curr.Hand.cards.Enqueue(currCard);
                currentPlay.RemoveAt(0);
                curr.numCards++;
            }
        }

    }
}
