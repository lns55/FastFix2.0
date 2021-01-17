using FastFix2._0.Areas.Identity;
using FastFix2._0.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var user = _UserManager.GetUserId(User);

            var findUser = _db.Users.Find(user);

            var userCity = findUser.City;

            var app = from a in _db.NewApplications
                      where a.City == userCity
                      select a;

            return View(app.ToList());
        }

        public IActionResult AnswerPage() => View();
    }
}

