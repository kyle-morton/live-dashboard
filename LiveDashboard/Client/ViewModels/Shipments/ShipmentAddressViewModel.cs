using LiveDashboard.Shared.Domain;

namespace LiveDashboard.Client.ViewModels.Shipments
{
    public class ShipmentAddressViewModel
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public static ShipmentAddressViewModel From(ShipmentAddress address)
        {
            return new ShipmentAddressViewModel
            {
                Id = address.Id,
                Label = address.Label
            };
        }
    }
}
