using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.Controllers.CarOwnerGarage
{
    /// <summary>
    /// Controller for CarOwners personal area.
    /// </summary>
    public class CarOwnerGarageController : Controller
    {
        /// <summary>
        /// Returns View of CarOwners personal area.
        /// </summary>
        public ActionResult CarOwnerGarage() => View();
    }
}
