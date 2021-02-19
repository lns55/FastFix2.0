using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace FastFix2._0.Hubs
{
    public class ResponseForApplicationHub : Hub
    {
        public async Task SendAnswer(string UserName, string Date, string Comment, int Price)
        {
            await Clients.All.SendAsync("ReceiveAnswer", UserName, Date, Comment, Price);
        }
    }
}
