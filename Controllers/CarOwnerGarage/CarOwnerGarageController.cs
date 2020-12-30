using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.Controllers.CarOwnerGarage
{
    public class CarOwnerGarageController : Controller
    {
        public ActionResult CarOwnerGarage() => View();
    }
}
