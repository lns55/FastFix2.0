using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFix2._0.Data;
using Microsoft.AspNetCore.SignalR;


namespace FastFix2._0.Hubs
{
    public class ResponseForApplicationHub : Hub
    {
        private readonly FastFixDbContext _db;

        public ResponseForApplicationHub(FastFixDbContext context)
        {
            _db = context;
        }

        public async Task Send(string issue, string car , string date, string description)
        {
            var appId = from a in _db.NewApplications
                        where a.Description == description
                        select a.Id;

            await Task.Delay(300);
            await Clients.All.SendAsync("Send", issue, car, date, description, appId);
        }
    }
}
