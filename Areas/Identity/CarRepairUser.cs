using FastFix2._0.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FastFix2._0.Areas.Identity
{   
    /// <summary>
    /// Model of CarRepair Companies. Intended for second step of registration.
    /// </summary>
    public class CarRepairUser
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CoName { get; set; }
        public string City { get; set; }
        public string CoAdress { get; set; }
        public string CoPhoneNumber { get; set; }
        public string CoEmail { get; set; }
        public string TypeOfWork { get; set; }
       
    }
}
