using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

using SlapJack;

namespace SlapJack.Hubs
{
    public class MyHub : Hub
    {
        public async Task StartGame(string user)
        {
            Random rand = new Random();

            if (Game.Players.Count > 1) {
                int gameNumber1 = rand.Next(1000, 9999);
                Game.StartNewGame(user, gameNumber1);
                return;
            }
            Game.AddPlayer(user);

            int gameNumber = rand.Next(1000, 9999);
            Game.gameID = gameNumber;
        }

        //This will allow the player to join the game
        public async Task JoinGame(string user)
        {
            Game.AddPlayer(user);
            Game.DealHand();
            await Clients.All.SendAsync("updateUserNames", Game.Players);
            updateAllCards();
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
                    await Clients.All.SendAsync("collectPile", player.Name);
                    break;
                case  0:
                    break;
                case -1:
                    Game.Penalize(player);
                    updateAllCards();
                    await Clients.All.SendAsync("penalized", player.Name);
                    break;
            }
        }

        //This will all the user to play their card
        public async Task PlayerPlayed(string user)
        {
            Player player = Game.GetPlayerByName(user);
            if (Game.Players[Game.turnIndex] == player)
            {
                Player winner = Game.PlayerPlay(player);
                //Check Game.FaceCardPlayed for a boolean if a card was played, then check Game.TurnCounter to check what card it is. 0 = Jack, 1 = Queen, 2 = King, 3 = Ace
                if(Game.FaceCardPlayed){ //Only sends the task if the card played was a face card
                    String player2;
                    if (player.Name != Game.Players[0].Name)
                        player2 = Game.Players[0].Name;
                    else
                        player2 = Game.Players[1].Name;
                    
                    await Clients.All.SendAsync("updateFacePlayed", player.Name, player2, Game.TurnCounter);
                }
                if (Game.PileWon){
                    await Clients.All.SendAsync("updateStatus", Game.PileWinner + " won the pile with a face card!");
                    Game.PileWon = false;
                }
                await updateAllCards();

                if (winner != null)
                {
                    await Clients.All.SendAsync("WeHaveAWinner", winner);
                }
                if (Game.swapDeck)
                {
                    updateAllCards();
                    Thread.Sleep(1000);
                    Game.testFunction();
                    updateAllCards();
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