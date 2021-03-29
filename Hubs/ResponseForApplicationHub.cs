using FastFix2._0.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.Hubs
{
    public class ResponseForApplicationHub : Hub
    {
        private readonly FastFixDbContext _db;

        public ResponseForApplicationHub(FastFixDbContext context)
        {
            _db = context;
        }

        public async Task Answer(string message, int price)
        { 
            var getId = from b in _db.AnswersForApps
                        where message == b.Message
                        select b.Id;

            var Id = getId.ToString();

            var getUser = from u in _db.NewApplications
                          where Id == u.Id.ToString()
                          select u.UserId;

            var userId = getUser.ToString();

            await Task.Delay(500);
            await Clients.User(userId).SendAsync("Answer", message, price);
        }
    }
}
