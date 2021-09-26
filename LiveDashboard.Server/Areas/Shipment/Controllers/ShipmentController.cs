using LiveDashboard.Core.Services;
using LiveDashboard.Client.ViewModels.Shipments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using LiveDashboard.Shared.Domain;
using LiveDashboard.Server.Hubs;
using Microsoft.AspNetCore.SignalR;
using System.IO;

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
        [Route("Status")]
        public async Task<IActionResult> UpdateStatus(ShipmentUpdateModel model)
        {
            await _shipmentHubContext.Clients.All.SendAsync("ReceiveStatusUpdate", model.ShipmentId, model.StatusId);
            return Ok();
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("InvoiceStatus")]
        public async Task<IActionResult> UpdateInvoiceStatus(ShipmentUpdateModel model)
        {
            await _shipmentHubContext.Clients.All.SendAsync("ReceiveInvoiceStatusUpdate", model.ShipmentId, model.InvoiceStatusId);
            return Ok();
        }

        public class ShipmentUpdateModel
        {
            public int ShipmentId { get; set; }
            public ShipmentStatus StatusId { get; set; }
            public ShipmentInvoiceStatus InvoiceStatusId { get; set; }
        }
    }
}
