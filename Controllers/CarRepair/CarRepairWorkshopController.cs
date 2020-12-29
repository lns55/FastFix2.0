using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public IActionResult CarRepairWorkshop() => View();
    }
}
