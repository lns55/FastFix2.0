using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastFix2._0.Areas.Identity;
using FastFix2._0.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;


namespace FastFix2._0.Hubs
{
    public class NewApplicationHub : Hub
    {
        private readonly FastFixDbContext _db;

        public NewApplicationHub(FastFixDbContext context)
        {
            _db = context;
        }

        public async Task Send(string issue, string car, string city, string date, string description)
        {
            var appId = from a in _db.NewApplications
                        where a.Description == description
                        select a.Id;

            var userId = from u in _db.NewApplications
                         where u.UserId == appId.ToString()
                         select u.UserId;

            //Need to do sorting by city and type of work. Leaving that tries here...hope you will find a better way...21.03.2021
            //var sortByCity = from r in _db.carRepairUsers
            //                 where r.City == city
            //                 select r.UserId.ToString();

            //var userID = sortByCity.ToList();

            await Task.Delay(500);
            await Clients.All.SendAsync("Send", issue, car, date, description, appId, userId);
        }
    }
}
