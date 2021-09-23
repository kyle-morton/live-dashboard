using LiveDashboard.Core.Services;
using LiveDashboard.Client.ViewModels.Shipments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using LiveDashboard.Shared.Domain;

namespace LiveDashboard.Server.Areas.Shipment.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ShipmentController : Controller
    {

        private readonly IShipmentService _service;

        public ShipmentController(IShipmentService service)
        {
            _service = service;
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

        //[HttpPost]
        //[Route("TestCreate")]
        //public async Task<IActionResult> TestCreate()
        //{
        //    var shipment = new LiveDashboard.Shared.Domain.Shipment();
        //    await _service.CreateAsync(shipment);

        //    return Ok();
        //}
    }
}
