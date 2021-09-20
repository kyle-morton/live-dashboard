using LiveDashboard.Client.ViewModels.Shipments;
using LiveDashboard.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiveDashboard.Shared.ViewModels.Shipments
{
    public class ShipmentViewModel
    {
        public int Id { get; set; }
        public DateTime? PickupDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public ShipmentAddressViewModel OriginAddress { get; set; }
        public ShipmentAddressViewModel DestinationAddress { get; set; }
        public List<ShipmentItemViewModel> Items { get; set; }

        public static ShipmentViewModel From(Shipment shipment)
        {
            return new ShipmentViewModel
            {
                Id = shipment.Id,
                PickupDate = shipment.PickupDate,
                DeliveryDate = shipment.DeliverDate,
                OriginAddress = shipment.OriginAddress != null ? ShipmentAddressViewModel.From(shipment.OriginAddress) : null,
                DestinationAddress = shipment.DestinationAddress != null ? ShipmentAddressViewModel.From(shipment.DestinationAddress) : null,
                Items = shipment.Items?.Select(ShipmentItemViewModel.From).ToList()
            };
        }

    }
}
