using Microsoft.AspNetCore.Mvc;

namespace StarSecurityServices.Areas.Customer.Controllers
{
    public class CareerwithusController : Controller
    {
        [Area("Customer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
