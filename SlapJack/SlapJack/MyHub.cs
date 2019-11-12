using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

using SlapJack;

namespace SlapJack.Hubs
{
    public class MyHub : Hub
    {
        public async Task StartGame(string user)
        {
            Game.AddPlayer(user);

            Random rand = new Random();
            int gameNumber = rand.Next(1000, 9999);
            Game.gameID = gameNumber;
        }

        //This will allow the player to join the game
        public async Task JoinGame(string user)
        {
            Game.AddPlayer(user);
            Game.DealHand();
            await Clients.All.SendAsync("updateUserNames", Game.Players);
        }


        //This will allow the user to slap the deck
        public async Task PlayerSlapped(string user)
        {
            Player player = Game.GetPlayerByName(user);
            int outcome = Game.Slap();
            switch (outcome) {
                case  1:
                    Game.TakePile(player);
                    updateAllCards();
                    await Clients.Caller.SendAsync("collectPile");
                    break;
                case  0:
                    break;
                case -1:
                    Game.Penalize(player);
                    updateAllCards();
                    await Clients.Caller.SendAsync("penalized");
                    break;
            }
        }

        //This will all the user to play their card
        public async Task PlayerPlayed(string user)
        {
            Player player = Game.GetPlayerByName(user);
            if (Game.Players[Game.turnIndex] == player)
            {
                bool lost = Game.PlayerPlay(player);
                await updateAllCards();
                if (lost)
                {
                    await Clients.All.SendAsync("updateMessage", Game.getWinner());
                }

            }

        }

        public async Task updateAllCards()
        {
            //The game index will need to be changed, also with the Clients.All this will only work for 1 game
            //Chanage this logic because we need to see if other values are null before we push this or we will get a null point exception
            //may need to test this.

            int numCards = Game.currDeck.cards.Count;
            List<Card> displayedCards = new List<Card>();

            for (int i = 0; i < 5; ++i) {
                if (Game.currDeck.cards.Count > i)
                {
                    displayedCards.Add(Game.currDeck.cards[i]);
                }
                else
                {
                    displayedCards.Add(Game.blankCard);
                }
            }

            await Clients.All.SendAsync("updateCards", displayedCards, Game.Players, Game.turnIndex);
        }
    }
}