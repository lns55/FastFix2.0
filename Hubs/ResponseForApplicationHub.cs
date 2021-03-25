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

        public async Task Answer(string issueTitle, string message, int price)
        {

            var getId = from u in _db.NewApplications
                         where issueTitle == u.IssueTitle
                         select u.UserId;

            var userId = getId.ToString();

            await Clients.User(userId).SendAsync("Answer", issueTitle, message, price);
        }
    }
}
