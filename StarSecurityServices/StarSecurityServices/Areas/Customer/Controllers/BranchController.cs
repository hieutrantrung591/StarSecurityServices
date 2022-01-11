using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index()
        {
            var starSecurityDBContext = _context.Branches.Include(b => b.Region);
            return View(await starSecurityDBContext.ToListAsync());
        }
    }
}
