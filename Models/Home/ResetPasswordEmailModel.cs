using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.Models.Home
{
    public class ResetPasswordEmailModel
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string ActionUrl { get; set; }
    }
}
