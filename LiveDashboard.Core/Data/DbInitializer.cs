using LiveDashboard.Core.Identity;
using LiveDashboard.Shared.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveDashboard.Core.Data
{
    public class DbInitializer
    {

        public static async Task Initialize(DashboardDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            await SeedUsers(context, userManager, roleManager);
            await SeedShipments(context);

            context.SaveChanges();
        }


        private static async Task SeedUsers(DashboardDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!context.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole { Name = DashboardRole.Admin });
            }

            if (!context.Users.Any())
            {
                // seed users
                var kyle = new ApplicationUser
                {
                    UserName = "mkmorton91@gmail.com",
                    Email = "mkmorton91@gmail.com",
                    EmailConfirmed = true,
                    //IsEnabled = true
                };
                await userManager.CreateAsync(kyle, "Admin123!");

                // seed user roles
                await userManager.AddToRoleAsync(kyle, DashboardRole.Admin);
            }
        }

        private static async Task SeedShipments(DashboardDbContext context)
        {
            if (context.Shipments.Any())
            {
                return;
            }

            var user = await context.Users.FirstOrDefaultAsync();

            await context.Shipments.AddAsync(new Shipment
            {
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CreatedByAspNetUserId = user.Id,
                ModifiedByAspNetUserId = user.Id,
                PickupDate = DateTime.Now.AddDays(1).Date,
                DeliverDate = DateTime.Now.AddDays(5).Date,
                OriginAddress = new ShipmentAddress { Label = "Little Rock, AR 72201" },
                DestinationAddress = new ShipmentAddress { Label = "Memphis, TN 22211" },
                Items = new List<ShipmentItem>
                {
                    new ShipmentItem { Description = "20 Pallets" },
                    new ShipmentItem { Description = "5 Drums" }
                }
            });

            await context.Shipments.AddAsync(new Shipment
            {
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CreatedByAspNetUserId = user.Id,
                ModifiedByAspNetUserId = user.Id,
                PickupDate = DateTime.Now.AddDays(4).Date,
                DeliverDate = DateTime.Now.AddDays(5).Date,
                OriginAddress = new ShipmentAddress { Label = "Fort Smith, AR 78022" },
                DestinationAddress = new ShipmentAddress { Label = "Memphis, TN 22211" },
                Items = new List<ShipmentItem>
                {
                    new ShipmentItem { Description = "1 Pallet" }
                }
            });

            await context.Shipments.AddAsync(new Shipment
            {
                CreateDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CreatedByAspNetUserId = user.Id,
                ModifiedByAspNetUserId = user.Id,
                PickupDate = DateTime.Now.AddDays(1).Date,
                DeliverDate = DateTime.Now.AddDays(2).Date,
                OriginAddress = new ShipmentAddress { Label = "Paragould, AR 78022" },
                DestinationAddress = new ShipmentAddress { Label = "Memphis, TN 22211" },
                Items = new List<ShipmentItem>
                {
                    new ShipmentItem { Description = "10 Pallets" },
                    new ShipmentItem { Description = "15 Drums" },
                    new ShipmentItem { Description = "10 Boxes" }
                }
            });

            await context.SaveChangesAsync();
        }


    }
}
