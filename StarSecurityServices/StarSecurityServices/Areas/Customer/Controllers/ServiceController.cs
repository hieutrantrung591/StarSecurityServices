using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarSecurityServices.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ServiceDetails()
        {
            return View();
        }
    }
}
