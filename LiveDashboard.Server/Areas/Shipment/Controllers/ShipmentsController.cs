using LiveDashboard.Core.Services;
using LiveDashboard.Client.ViewModels.Shipments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LiveDashboard.Server.Areas.Shipment.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ShipmentsController : Controller
    {

        private readonly IShipmentService _service;

        public ShipmentsController(IShipmentService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var shipments = await _service.GetAsync(10, 0);

            var vms = shipments.Select(ShipmentViewModel.From).ToList();

            return Ok(vms);
        }
    }
}
