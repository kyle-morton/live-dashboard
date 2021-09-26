using LiveDashboard.Shared.Domain;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveDashboard.Server.Hubs
{
    public class ShipmentHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task UpdateStatus(int shipmentId, ShipmentStatus statusId)
        {
            await Clients.All.SendAsync("ReceiveStatusUpdate", shipmentId, statusId);
        }

    }
}
