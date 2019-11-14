using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlapJack
{
    public static class Game
    {
        /// <summary>
        /// This is the game ID for the current game object
        /// </summary>
        public static int gameID { get; set; }

        /// <summary>
        /// This is a list of the players that are playing the game
        /// </summary>
        public static List<Player> Players = new List<Player>();

        /// <summary>
        /// This is the deck that the players are currently adding to
        /// </summary>
        public static  Deck currDeck = new Deck(true);

        /// <summary>
        /// The index that points out which players turn it is.
        /// </summary>
        public static  int turnIndex = 0;
        /// <summary>
        /// Counts the number of turns left before the previous players takes the pile
        /// </summary>
        public static  int TurnCounter = -1;

        /// <summary>
        /// Tells whether the current pile has been claimed or not. Only changes to true on positive slap.
        /// </summary>
        public static  bool CardsClaimed = false;

        /// <summary>
        /// This is a blank card image
        /// </summary>
        public static  Card blankCard = new Card()
        {
            image = "img/gray_back.png"
        };


        public static Boolean FaceCardPlayed { get; set; }
        public static String PileWinner { get; set; }

        public static Boolean PileWon { get; set; }

        /// <summary>
        /// This will get the players name
        /// </summary>
        /// <param name="name">This is the object that we want the name for</param>
        ///<returns>A players name</returns>
        ///
        public static  Player GetPlayerByName(string name) {
            foreach (Player player in Players) {
                if (name == player.Name) {
                    return player;
                }
            }
            return null;
        }

        /// <summary>
        /// This will add a player to the game
        /// </summary>
        /// <param name="user">This is the name of the player who wants to join the game</param>
        public static  void AddPlayer(string user)
        {
            Player newPlayer = new Player()
            {
                Name = user,
                connectionID = "",
            };
            Players.Add(newPlayer);
        }


        /// <summary>
        /// This will deal the hands to the player
        /// </summary>
        public static  void DealHand()
        {
            int deskSize = currDeck.cards.Count() / Players.Count();
            //Split deck evenly
            foreach (Player player in Players) {
                player.Hand.cards.AddRange(currDeck.cards.Take(deskSize).ToList());
                currDeck.cards = currDeck.cards.Skip(deskSize).ToList();
            }
            //Hand out remaining cards
            if (currDeck.cards.Count() > 0) {
                for (int i = 0; i < currDeck.cards.Count(); ++i) {
                    Players[i].Hand.cards.Add(currDeck.cards[0]);
                    currDeck.cards = currDeck.cards.Skip(1).ToList();
                }
            }
        }

        /// <summary>
        /// This will change the turn for the player
        /// </summary>
        public static  void ChangeTurn() {
            if (!(++turnIndex < Players.Count()))
            {
                turnIndex = 0;
            }
        }

        /// <summary>
        /// This will give the middle deck to the player
        /// </summary>
        /// <param name="player">This is the player that we need to add the cards to</param>
        public static  void TakePile(Player player) {
            player.Hand.cards.AddRange(currDeck.cards);
            currDeck.cards.RemoveAll( c => true);
            turnIndex = Players.IndexOf(player);
            TurnCounter = -1;
        }

        /// <summary>
        /// This is the method that will play the card for the player
        /// </summary>
        /// <param name="player">The player who played the card</param>
        /// <returns>IF the play actually happened.</returns>
        public static  bool PlayerPlay(Player player)
        {
            if (player.Hand.cards.Any())
            {
                CardsClaimed = false;
                Card playedCard = player.Hand.cards[0];
                player.Hand.cards.RemoveAt(0);
                currDeck.cards.Insert(0, playedCard);

                if ((FaceCardPlayed = CheckFaceCard(playedCard)) || TurnCounter < 0)
                {
                    ChangeTurn();
                }
                else if (TurnCounter == 0)
                {
                    turnIndex = ((turnIndex - 1) == -1) ? Players.Count() - 1 : turnIndex - 1;
                    TakePile(Players[turnIndex]);
                    PileWinner = Players[turnIndex].Name;
                    PileWon = true;

                }
                else
                    --TurnCounter;
               
                return true;
            }
            return false;
        }

        /// <summary>
        /// This will determine the winner of the game
        /// </summary>
        /// <returns>The winner of the game</returns>
        public static  Player getWinner()
        {
            foreach (Player curr in Players)
            {
                if (curr.Hand.cards.Count() == 0)
                    continue;
                return curr;

            }
            return new Player();
        }

        /// <summary>
        /// This will check if there is a face card that was played.
        /// </summary>
        /// <param name="card">The card that was palyed</param>
        /// <returns>A Boolean if it is a face card or not</returns>
        public static  bool CheckFaceCard(Card card)
        {
            bool isFaceCard = false;
            switch (card.num)
            {
                case "J":
                    TurnCounter = 0;
                    isFaceCard = true;
                    break;
                case "Q":
                    TurnCounter = 1;
                    isFaceCard = true;
                    break;
                case "K":
                    TurnCounter = 2;
                    isFaceCard = true;
                    break;
                case "A":
                    TurnCounter = 3;
                    isFaceCard = true;
                    break;
                default:
                    break;
            }
            return isFaceCard;
        }

        /// <summary>
        /// Returns whether the individual won the cards
        /// </summary>
        /// <returns>1 take the pot, 0 no change, -1 penalize</returns>
        public static  int Slap()
        {
            if (!CardsClaimed && currDeck.cards.Count() >= 2 && currDeck.cards[0].CardNumber == currDeck.cards[1].CardNumber)
                return  1;
            else if (!CardsClaimed && currDeck.cards.Count() >= 2 && currDeck.cards[0].CardNumber == currDeck.cards[2].CardNumber)
                return 1;
            else if (CardsClaimed && currDeck.cards.Count() >= 2) 
                return  0;
            else 
                return -1;
        }

        public static  void Penalize(Player player) {
            for (int i = 0;i < player.Hand.cards.Count() && i < 3; ++i) {
                currDeck.cards.Insert(currDeck.cards.Count() / 2, player.Hand.cards[0]);
                player.Hand.cards.RemoveAt(0);
            }
        }
    }
}
