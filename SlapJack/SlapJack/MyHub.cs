using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SlapJack.Hubs
{
    public class MyHub : Hub
    {

        public static Game currentGame;

        public async Task UpdatePlayer(string user)
        {
            currentGame.player2.Name = user;
            //Somehow get the other players name, and pass it into the second paramter
            await Clients.All.SendAsync("updatePlayer", currentGame.player1.Name, currentGame.player2.Name);
            currentGame.DealHand();
        }


        public async Task testFunction(string user)
        {
            //Somehow get the other players name, and pass it into the second paramter
            await Clients.All.SendAsync(createObject(user));
        }

        private string createObject(string user)
        {
            currentGame = new Game(user);
            currentGame.player1.Name = user;

            Random rand = new Random();
            int gameNumber = rand.Next(1000, 9999);
            currentGame.gameID = gameNumber;

            return "";
        }

        //This will start the game instances and return the gameid for reference
        public async Task StartGame(string user)
        {
            await testFunction(user);
        }

        //This will allow the player to join the game
        public async Task joinGame(int gameID, string user)
        {
            currentGame.player2.Name = user;
            await Clients.All.SendAsync("updateUserNames", currentGame.player1.Name, currentGame.player2.Name);
            await updateAllCards();
        }


        //This will allow the user to slap the deck
        public void playerSlapped(string user)
        {
            //Check if there is a valid move

            //Penalize the user (do we want to handle all this in the other function
        }

        //This will all the user to play their card
        public async Task playerPlayed(string user)
        {
            if (currentGame.currentTurn == user)
            {
                currentGame.PlayerPlay(user);
                await updateAllCards();
            }
            else
            {
                await Clients.All.SendAsync("updateMessage", currentGame.currentTurn, "It is not your turn");

            }
        }

        public async Task updateAllCards()
        {
            //The game index will need to be changed, also with the Clients.All this will only work for 1 game
            //Chanage this logic because we need to see if other values are null before we push this or we will get a null point exception
            //may need to test this.

            int numCards = currentGame.currentPlay.Count;
            switch (numCards)
            {
                case 1:
                    await Clients.All.SendAsync("updateCards", currentGame.player1.numCards, currentGame.player1.Name, currentGame.player2.numCards, currentGame.player2.Name,
                                                               "img/gray_back.png", 
                                                               "img/gray_back.png", 
                                                               "img/gray_back.png", 
                                                               "img/gray_back.png",
                                                               currentGame.currentPlay[0].image);
                    break;
                case 2:
                    await Clients.All.SendAsync("updateCards", currentGame.player1.numCards, currentGame.player1.Name, currentGame.player2.numCards, currentGame.player2.Name,
                                                               "img/gray_back.png",
                                                               "img/gray_back.png",
                                                               "img/gray_back.png",
                                                               currentGame.currentPlay[0].image,
                                                               currentGame.currentPlay[1].image);
                    break;
                case 3:
                    await Clients.All.SendAsync("updateCards", currentGame.player1.numCards, currentGame.player1.Name, currentGame.player2.numCards, currentGame.player2.Name,
                                                               "img/gray_back.png",
                                                               "img/gray_back.png",
                                                               currentGame.currentPlay[0].image,
                                                               currentGame.currentPlay[1].image,
                                                               currentGame.currentPlay[2].image);
                    break;
                case 4:
                    await Clients.All.SendAsync("updateCards", currentGame.player1.numCards, currentGame.player1.Name, currentGame.player2.numCards, currentGame.player2.Name,
                                                               "img/gray_back.png",
                                                               currentGame.currentPlay[0].image,
                                                               currentGame.currentPlay[1].image,
                                                               currentGame.currentPlay[2].image,
                                                               currentGame.currentPlay[3].image);
                    break;
                default:
                    await Clients.All.SendAsync("updateCards", currentGame.player1.numCards, currentGame.player1.Name, currentGame.player2.numCards, currentGame.player2.Name,
                                                               currentGame.currentPlay[numCards - 5].image,
                                                               currentGame.currentPlay[numCards - 4].image,
                                                               currentGame.currentPlay[numCards - 3].image,
                                                               currentGame.currentPlay[numCards - 2].image,
                                                               currentGame.currentPlay[numCards - 1].image);
                    break;
            }

        }
    }
}