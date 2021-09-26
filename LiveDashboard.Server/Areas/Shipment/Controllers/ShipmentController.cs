using LiveDashboard.Core.Services;
using LiveDashboard.Client.ViewModels.Shipments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using LiveDashboard.Shared.Domain;
using LiveDashboard.Server.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace LiveDashboard.Server.Areas.Shipment.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ShipmentController : Controller
    {

        private readonly IShipmentService _service;
        private readonly IHubContext<ShipmentHub> _shipmentHubContext;

        public ShipmentController(IShipmentService service, IHubContext<ShipmentHub> hubContext)
        {
            _service = service;
            _shipmentHubContext = hubContext;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var shipments = await _service.GetAsync(10, 0);

            var vm = IndexViewModel.From(shipments);

            return Ok(vm);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Filter()
        {
            var shipments = await _service.GetAsync(10, 0);
            var vms = shipments.Select(ShipmentViewModel.From).ToList();

            return Ok(vms);
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("TestUpdate")]
        public async Task<IActionResult> TestUpdate()
        {
            await _shipmentHubContext.Clients.All.SendAsync("ReceiveStatusUpdate", 1, ShipmentStatus.ArrivedAtDelivery);
            return Ok();
        }
    }
}
