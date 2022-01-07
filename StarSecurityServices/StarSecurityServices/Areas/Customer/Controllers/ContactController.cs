using Microsoft.AspNetCore.Mvc;

namespace StarSecurityServices.Areas.Customer.Controllers
{
    [Area("Client")]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
