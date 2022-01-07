using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarSecurityServices.Areas.Customer.Controllers
{
    public class BranchController : Controller
    {
        [Area("Client")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
