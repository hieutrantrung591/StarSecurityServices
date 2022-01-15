using Microsoft.AspNetCore.Mvc;
using StarSecurityServices.Areas.Admin.ViewModels;
using StarSecurityServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarSecurityServices.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly StarSecurityDBContext _context;

        public HomeController(StarSecurityDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            DashboardViewModel viewModel = new DashboardViewModel()
            {
                BranchCount = _context.Branches.Count(),
                ClientCount = _context.Clients.Count(),
                ClientServiceCount = _context.ClientServices.Count(),
                DepartmentCount = _context.Departments.Count(),
                DivisionCount = _context.Divisions.Count(),
                EmployeeCount = _context.Employees.Count(),
                EmployeeRoleCount = _context.EmployeeRoles.Count(),
                JobCount = _context.Jobs.Count(),
                RegionCount = _context.Regions.Count(),
                RoleCount = _context.Roles.Count(),
                ServiceCount = _context.Jobs.Count(),
                VacancyCount = _context.Vacancies.Count()
            };
            return View(viewModel);
        }
    }
}
