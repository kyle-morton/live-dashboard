using System;
using System.Collections.Generic;

namespace LiveDashboard.Shared.Domain
{
    public class Shipment : EntityBase
    {
        public ShipmentStatus StatusId { get; set; }
        public ShipmentInvoiceStatus InvoiceStatusId { get; set; }
        public DateTime? PickupDate { get; set; }
        public DateTime? DeliverDate { get; set; }
        public ShipmentAddress OriginAddress { get; set; }
        public ShipmentAddress DestinationAddress { get; set; }
        public List<ShipmentItem> Items { get; set; }
    }
}
