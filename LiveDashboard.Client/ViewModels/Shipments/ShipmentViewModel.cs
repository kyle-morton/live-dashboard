using Humanizer;
using LiveDashboard.Client.ViewModels.Shipments;
using LiveDashboard.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiveDashboard.Client.ViewModels.Shipments
{
    public class ShipmentViewModel
    {
        public int Id { get; set; }
        public DateTime? PickupDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public ShipmentAddressViewModel OriginAddress { get; set; }
        public ShipmentAddressViewModel DestinationAddress { get; set; }
        public List<ShipmentItemViewModel> Items { get; set; }
        public ShipmentStatus Status { get; set; }
        public string StatusFormatted => Status.Humanize();
        public ShipmentInvoiceStatus InvoiceStatus { get; set; }
        public string InvoiceStatusFormatted => InvoiceStatus.Humanize();

        public static ShipmentViewModel From(Shipment shipment)
        {
            return new ShipmentViewModel
            {
                Id = shipment.Id,
                PickupDate = shipment.PickupDate,
                DeliveryDate = shipment.DeliverDate,
                OriginAddress = shipment.OriginAddress != null ? ShipmentAddressViewModel.From(shipment.OriginAddress) : null,
                DestinationAddress = shipment.DestinationAddress != null ? ShipmentAddressViewModel.From(shipment.DestinationAddress) : null,
                Items = shipment.Items?.Select(ShipmentItemViewModel.From).ToList(),
                Status = shipment.StatusId,
                InvoiceStatus = shipment.InvoiceStatusId
            };
        }

    }
}
