using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlapJack.Pages
{
    public class MyHub : Hub
    {

        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"Connection {Context.ConnectionId} made!");
            await base.OnConnectedAsync();
        }



        // Optionally override what happens when a client disconnects

        public override async Task OnDisconnectedAsync(Exception execption)
        {
            Console.WriteLine($"{Context.ConnectionId} disconnected!");

            await base.OnDisconnectedAsync(execption);

        }
    }
}
