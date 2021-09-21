using LiveDashboard.Core.Data;
using LiveDashboard.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveDashboard.Core.Services
{
    public interface IShipmentService
    {
        Task<List<Shipment>> GetAsync(int take, int skip);
        Task<Shipment> GetAsync(int id);
        Task<Shipment> CreateAsync(Shipment shipment);
        Task<Shipment> UpdateAsync(Shipment shipment);
    }

    public class ShipmentService : IShipmentService
    {

        private readonly DashboardDbContext _context;

        public ShipmentService(DashboardDbContext context)
        {
            _context = context;
        }

        public async Task<List<Shipment>> GetAsync(int take, int skip)
        {
            return await _context.Shipments
                .Include(s => s.Items)
                .Include(s => s.OriginAddress)
                .Include(s => s.DestinationAddress)
                .ToListAsync();
        }

        public async Task<Shipment> GetAsync(int id)
        {
            return await _context.Shipments
                .Include(s => s.Items)
                .Include(s => s.OriginAddress)
                .Include(s => s.DestinationAddress)
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Shipment> CreateAsync(Shipment shipment)
        {
            await _context.Shipments.AddAsync(shipment);
            await _context.SaveChangesAsync();
            return shipment;
        }

        public async Task<Shipment> UpdateAsync(Shipment shipment)
        {
            throw new System.NotImplementedException();
        }
    }
}
