using Microsoft.AspNetCore.SignalR;
using MoviePage.Models.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Utility.Helper.Abstractions
{
    public interface IClientManager<T> where T: Hub
    {
        Dictionary<string,HashSet<Client>> Clients { get; set; }
        /// <summary>
        /// Get all clients connected to hub
        /// </summary>
        /// <returns></returns>
        HashSet<Client> GetClients();
        /// <summary>
        /// Get all client of individual user
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        HashSet<Client> GetClient(Guid accountId);
        /// <summary>
        /// Add new client
        /// </summary>
        /// <param name="client"></param>
        void AddNewClient(Client client);
        /// <summary>
        /// Remove specify client
        /// </summary>
        /// <param name="clientId"></param>
        void RemoveClient(string clientId);
        /// <summary>
        /// Remove specific client
        /// </summary>
        /// <param name="client"></param>
        void RemoveClient(Client client);

    }
}
