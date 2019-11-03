using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SlapJack.Hubs
{
    public class MyHub : Hub
    {
        //Do we want this in here or in the game class? Game class makes more sense
        //As a side note maybe a "Logic" class would make more sense and then call the game class once we verified the input
        public List<Game> games;


        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task UpdatePlayer(string user)
        {
            string player1;
            //Somehow get the other players name, and pass it into the second paramter
            await Clients.All.SendAsync("updatePlayer", user);
        }

        //This will start the game instances and return the gameid for reference
        public void StartGame(string user)
        {
            Game createGame = new Game(user);
            Random rand = new Random();
            int gameNumber = rand.Next(1000, 9999);
            createGame.gameID = gameNumber;
            games.Add(createGame);
            //Create some function to update the user with the gameID for the other user to join
        }

        //This will allow the player to join the game
        public void joinGame(int gameID, string user)
        {
            Boolean added = false;

            foreach(Game curr in games)
            {
                if(curr.gameID == gameID)
                {
                    curr.playerJoined(user);
                    added = true;
                    break;
                }
            }
            //Check to see if the game exists

            //Game doesn't Exist let the user know
            if (!added)
            {
                //Send alert method to only that user
            }
            //Game exist join the game let both users know
        }

        //This will allow the user to slap the deck
        public void playerSlapped(string user)
        {
            //Check if there is a valid move

            //Penalize the user (do we want to handle all this in the other function
        }

        //This will all the user to play their card
        public void playerPlayed(string user)
        {
            //Check if it's the players turn, play the card
        }

        public async Task updateAllCards()
        {
            //The game index will need to be changed, also with the Clients.All this will only work for 1 game
            await Clients.All.SendAsync("updateCards", games[0].currentPlay[0],
                                                       games[0].currentPlay[1], 
                                                       games[0].currentPlay[2], 
                                                       games[0].currentPlay[3], 
                                                       games[0].currentPlay[4]);
        }
    }
}
