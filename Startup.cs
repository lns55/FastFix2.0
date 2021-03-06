using FastFix2._0.Areas.Identity;
using FastFix2._0.Data;
using FastFix2._0.Hubs;
using FastFix2._0.Infrastructure.Interfaces;
using FastFix2._0.Infrastructure.Services.InSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace FastFix2._0
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region DB Options
            services.AddDbContext<FastFixDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            #endregion

            #region Identity Options

            services.AddIdentity<User, Role>(opt => { })
                .AddEntityFrameworkStores<FastFixDbContext>()
                .AddRoles<Role>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opt =>
            {
#if DEBUG
                opt.Password.RequiredLength = 3;
                opt.Password.RequireDigit = false;
                opt.Password.RequiredUniqueChars = 3;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;

                opt.User.RequireUniqueEmail = false;

#endif

#if RELEASE
                opt.Password.RequiredLength = 6;
                opt.Password.RequireDigit = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredUniqueChars = 3;

                opt.User.RequireUniqueEmail = true;
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

                opt.Lockout.AllowedForNewUsers = false;
                opt.Lockout.MaxFailedAccessAttempts = 15;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
#endif
            });

            #endregion

            #region Cookie Options

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "FastFix-Cookies";
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(7);

                opt.LoginPath = "/Home/Index";
                opt.LogoutPath = "/Home/Logout";
                opt.AccessDeniedPath = "/Home/AccessDenied";

                opt.SlidingExpiration = true;
            });

            #endregion

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddScoped<ICarRepairData, SqlCarRepairData>();
            services.AddScoped<IApp, SqlApp>();

            services.AddSignalR();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<NewApplicationHub>("/CarRepairWorkshop");
                endpoints.MapHub<NewApplicationHub>("/New");
                endpoints.MapHub<ResponseForApplicationHub>("/AnswerPage");
                endpoints.MapHub<ResponseForApplicationHub>("/Waiting");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
