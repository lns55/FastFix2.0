using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace FastFix2._0.Hubs
{
    public class ResponseForApplicationHub : Hub
    {
        public async Task Send(string issue, string car, string date, string description)
        {
            await Clients.All.SendAsync("Send", issue, car, date, description);
        }
    }
}
