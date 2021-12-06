using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UParking.Areas.Identity.Data;
using UParking.Data;

[assembly: HostingStartup(typeof(UParking.Areas.Identity.IdentityHostingStartup))]
namespace UParking.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UParkingContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UParkingContextConnection")));

                services.AddDefaultIdentity<UParkingUser>(options =>
                { 
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<UParkingContext>();
            });
        }
    }
}