using System;
using H5ServersideAni.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(H5ServersideAni.Areas.Identity.IdentityHostingStartup))]
namespace H5ServersideAni.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<H5ServersideAniContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("H5ServersideAniContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<H5ServersideAniContext>();

                services.AddAuthorization(options =>
                {
                    options.AddPolicy("RequireAuthenticatedUser", policy => {
                        policy.RequireAuthenticatedUser();
                    });
                    options.AddPolicy("RequireAdminUser", policy => {
                        policy.RequireRole("Admin");
                    });
                });
            });
        }
    }
}