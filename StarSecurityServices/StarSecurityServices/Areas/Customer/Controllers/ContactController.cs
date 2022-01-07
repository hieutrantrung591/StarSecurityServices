using Microsoft.AspNetCore.Mvc;

namespace StarSecurityServices.Areas.Client.Controllers
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
