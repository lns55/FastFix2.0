using FastFix2._0.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FastFix2._0.Areas.Identity
{
    /// <summary>
    /// Model for User.
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// If returns true it means that user wants to register as CarRepair Company.
        /// </summary>
        public bool IsCarRepair { get; set; }
        public List<NewApplications> NewApplications { get; set; }
    }
}
