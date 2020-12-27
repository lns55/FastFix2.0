using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.Controllers
{
    public class CarRepairWorkshopController : Controller
    {
        public IActionResult CarRepairWorkshop() => View();
    }
}
