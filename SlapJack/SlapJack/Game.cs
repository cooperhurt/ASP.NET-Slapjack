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

        int currentTurn;
        bool play1Penalized;
        bool play2penalized;

        Game()
        {
            player1.Name = "";
            player2.Name = "";
            play1Penalized = false;
            play2penalized = false;
            currDeck = new Deck();
        }

        public void StartGame()
        {
            DealHand();
        }

        public void DealHand()
        {
            int num = 0;
            foreach(var card in currDeck.currentCard)
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
        }

        public string player1Play(int num)
        {
            return player1.Hand.currentCard.Dequeue().image;
        }

        public string player1Play(int num)
        {
            return player2.Hand.currentCard.Dequeue().image;
        }
        public void Player1Join(string name)
        {
            this.player1.Name = name;
        }

        public void Player2Join(string name)
        {
            this.player2.Name = name;
        }


    }
}
