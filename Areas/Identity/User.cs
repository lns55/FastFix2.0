using Microsoft.AspNetCore.Identity;

namespace FastFix2._0.Areas.Identity
{
    public class User : IdentityUser
    {
        public string Description { get; set; }
    }
}
