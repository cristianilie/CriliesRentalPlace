using System;
using CriliesRentalPlaceWeb.Areas.Identity.Data;
using CriliesRentalPlaceWeb.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CriliesRentalPlaceWeb.Areas.Identity.IdentityHostingStartup))]
namespace CriliesRentalPlaceWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CriliesRentalPlaceWebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CriliesRentalPlaceWebContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<CriliesRentalPlaceWebContext>();
            });
        }
    }
}