using IdentityServer4.EntityFramework.Options;
using LiveDashboard.Core.Domain;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LiveDashboard.Core.Data
{
    public class DashboardDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DashboardDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentAddress> ShipmentAddresses { get; set; }
        public DbSet<ShipmentItem> ShipmentItems { get; set; }
    }
}
