using Microsoft.AspNetCore.SignalR;
using MoviePage.Models.SignalR;
using MoviePage.Utility.Helper.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.SignalRHub
{
    public class NotificationHub : Hub
    {
        private readonly IClientManager<NotificationHub> _clientManager;

        public NotificationHub(IClientManager<NotificationHub> clientManager)
        {
            _clientManager = clientManager;
        }
        public override Task OnConnectedAsync()
        {
            var client = new Client
            {
                ClientId = Context.ConnectionId,
                AccountId = Guid.NewGuid()
            };
            _clientManager.AddNewClient(client);
            Console.WriteLine("New connect");
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine("Just disconnected");
            return base.OnDisconnectedAsync(exception);
        }
    }
}
