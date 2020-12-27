using Microsoft.AspNetCore.Identity;

namespace FastFix2._0.Areas.Identity
{
    public class Role : IdentityRole
    {
        public const string Administrator = "Administrators";
        public const string CarOwner = "Car Owners";
        public const string CarRepairUser = "Car Repair Shops";
        public string Description { get; set; }
    }
}
