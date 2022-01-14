using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarSecurityServices.Areas.Customer.ViewModels;
using StarSecurityServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarSecurityServices.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ServiceController : Controller
    {
        private readonly StarSecurityDBContext _context;

        public ServiceController(StarSecurityDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var serviceList = _context.Services.Include(b => b.Division);
            var divisionList = _context.Divisions;

            ServiceDivisionViewModel serviceDivisionViewModel = new ServiceDivisionViewModel();
            serviceDivisionViewModel.Services = serviceList;
            serviceDivisionViewModel.Divisions = divisionList;

            return View(serviceDivisionViewModel);
        }
    }
}
