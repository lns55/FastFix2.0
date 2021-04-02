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

        public async Task Answer(string Message, int Price)
        { 
            var getId = from b in _db.AnswersForApps
                        where Message == b.Message
                        select b.AppID;

            var Id = getId.First();
            
            var getUser = from u in _db.NewApplications
                          where Id == u.Id
                          select u.UserId;

            var userId = getUser.First();

            var getUserName = _db.Users.Find(userId);

            var UserName = getUserName.UserName;

            var getapp = _db.NewApplications.Find(Id);

            var issueTitle = getapp.IssueTitle;

            await Task.Delay(500);
            await Clients.User(UserName).SendAsync("Answer", issueTitle, Message, Price);
        }
    }
}
