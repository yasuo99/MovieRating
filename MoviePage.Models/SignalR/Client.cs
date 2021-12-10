using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Models.SignalR
{
    public class Client
    {
        public string ClientId { get; set; }
        public Guid AccountId { get; set; }
        public int IsWebPlatform { get; set; }
    }
}
