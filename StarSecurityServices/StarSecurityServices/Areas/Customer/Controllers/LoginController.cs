using Microsoft.AspNetCore.Mvc;

namespace StarSecurityServices.Areas.Client.Controllers
{
    [Area("Client")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
