using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.Controllers.CarOwnerGarage.MyApplications
{
    public class MyApplicationsController : Controller
    {
        public IActionResult New() => View();
        public IActionResult Active() => View();
        public IActionResult Waiting() => View();
        public IActionResult Completed() => View();
    }
}
