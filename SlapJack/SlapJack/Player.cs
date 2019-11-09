﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlapJack
{
    public class Player : IUserIdProvider
    {
        public string Name { get; set; }
        public Deck Hand { get; set; }
        public string connectionID { get; set; }

        public Player()
        {
            Hand = new Deck();
        }

        public string GetUserId(HubConnectionContext connection)
        {
            return Name;
        }
    }
}
