using LiveDashboard.Shared.Domain;

namespace LiveDashboard.Client.ViewModels.Shipments
{
    public class ShipmentItemViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public static ShipmentItemViewModel From(ShipmentItem item)
        {
            return new ShipmentItemViewModel
            {
                Id = item.Id,
                Description = item.Description
            };
        }
    }
}
