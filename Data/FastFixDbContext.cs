using FastFix2._0.Areas.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FastFix2._0.Data
{
    public class FastFixDbContext : IdentityDbContext<User, Role, string>
    {
        /// <summary>
        /// Context of data for CarRepair companies.
        /// </summary>
        public DbSet<CarRepairUser> carRepairUsers { get; set; }

        public FastFixDbContext(DbContextOptions<FastFixDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
