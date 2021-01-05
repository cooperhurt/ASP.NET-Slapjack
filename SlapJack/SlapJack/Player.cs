using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlapJack
{
    public class Player : IUserIdProvider
    {
        /// <summary>
        /// This is a players name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This is a deck that the player has
        /// </summary>
        public Deck Hand { get; set; }

        /// <summary>
        /// This is the connectionID of the user's connection
        /// </summary>
        public string connectionID { get; set; }

        /// <summary>
        /// This will create a hand for the player
        /// </summary>
        public Player()
        {
            Hand = new Deck();
        }

        public Player(string name)
        {
            Hand = new Deck();
            Name = name;
        }

        /// <summary>
        /// This wiill return the connection id
        /// </summary>
        /// <param name="connection">This is the conneciton id for the user</param>
        /// <returns></returns>
        public string GetUserId(HubConnectionContext connection)
        {
            return Name;
        }
    }
}
