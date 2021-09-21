using LiveDashboard.Shared.Domain;
using LiveDashboard.Client.ViewModels.Shipments;
using System.Collections.Generic;
using System.Linq;

namespace LiveDashboard.Client.ViewModels.Shipments
{
    public class IndexViewModel
    {
        public List<ShipmentViewModel> Shipments { get; set; }

        public static IndexViewModel From(List<Shipment> shipments)
        {
            return new IndexViewModel
            {
                Shipments = shipments?.Select(ShipmentViewModel.From).ToList()
            };
        }
    }
}
