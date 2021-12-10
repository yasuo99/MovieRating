using Microsoft.AspNetCore.SignalR;
using MoviePage.Models.SignalR;
using MoviePage.Utility.Helper.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Utility.Helper
{
    public class ClientManager<T> : IClientManager<T> where T : Hub
    {

        public Dictionary<string, HashSet<Client>> Clients { get; set; }
        public ClientManager()
        {
            Clients = new Dictionary<string, HashSet<Client>>();
        }

        public void AddNewClient(Client client)
        {
            
        }

        public HashSet<Client> GetClient(Guid accountId)
        {
            throw new NotImplementedException();
        }

        public HashSet<Client> GetClients()
        {
            throw new NotImplementedException();
        }

        public void RemoveClient(string clientId)
        {
            throw new NotImplementedException();
        }

        public void RemoveClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
