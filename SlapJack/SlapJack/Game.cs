﻿using System;
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

        Game()
        {
            player1.Name = "";
            player2.Name = "";
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
                if(num % 2 == 0)
                {
                    player1.Hand.addCard(card);
                }
                player2.Hand.addCard(card);
            }
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
