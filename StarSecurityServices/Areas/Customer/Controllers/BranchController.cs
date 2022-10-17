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
    public class BranchController : Controller
    {
        private readonly StarSecurityDBContext _context;

        public BranchController(StarSecurityDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var branchList = _context.Branches.Include(b => b.Region);
            var regionList = _context.Regions;

            BranchRegionViewModel branchRegionViewModel = new BranchRegionViewModel();
            branchRegionViewModel.Branches = branchList;
            branchRegionViewModel.Regions = regionList;

            return View(branchRegionViewModel);
        }
    }
}
