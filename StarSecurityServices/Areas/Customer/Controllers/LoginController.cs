using Microsoft.AspNetCore.Mvc;

namespace StarSecurityServices.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
