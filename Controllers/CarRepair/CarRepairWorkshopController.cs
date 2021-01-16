using FastFix2._0.Areas.Identity;
using FastFix2._0.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.Controllers
{
    /// <summary>
    /// After car repair company fill out form with their data, they will get into this controller(their Private Cabinet).
    /// </summary>

    public class CarRepairWorkshopController : Controller
    {

        private readonly FastFixDbContext _db;
        private readonly UserManager<User> _UserManager;

        public CarRepairWorkshopController(FastFixDbContext context, UserManager<User> userManager) 
        {
            _db = context;
            _UserManager = userManager;
        }

        public IActionResult CarRepairWorkshop()
        {
            //var userId = _UserManager.GetUserId(User);

            //var user = from u in _db.carRepairUsers
            //           where u.UserId == userId
            //           select u;

            //var userCity = from uc in _db.carRepairUsers
            //               select user;

            //var appCity = from a in _db.NewApplications
            //              select a.City;



            var CarRepUser = from user in _db.Users
                             join carRep in _db.carRepairUsers
                             on user.Id equals
                                carRep.UserId
                             where user.Id == carRep.UserId
                             select carRep.City.Single();


            var app = from a in _db.NewApplications
                      where a.City == CarRepUser.ToString()
                      select a;

            //var user = _db.carRepairUsers
            //    .Where(u => u.City.Any())
            //    .SelectMany(u);

            //var app = _db.NewApplications
            //    .Where(n => n.City.Any());

            //var result = _db.NewApplications
            //    .SelectMany(user == app);


            return View(app.ToList());
        }
    }
}
