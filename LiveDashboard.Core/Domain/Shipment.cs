using System;
using System.Collections.Generic;

namespace LiveDashboard.Core.Domain
{
    public class Shipment : EntityBase
    {
        public DateTime? PickupDate { get; set; }
        public DateTime? DeliverDate { get; set; }
        public ShipmentAddress OriginAddress { get; set; }
        public ShipmentAddress DestinationAddress { get; set; }
        public List<ShipmentItem> Items { get; set; }
    }
}
