using Microsoft.AspNetCore.Mvc;

namespace LiveDashboard.Server.Areas.Shipment.Controllers
{
    public class ShipmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
