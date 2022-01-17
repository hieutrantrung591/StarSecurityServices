using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarSecurityServices.Areas.Admin.ViewModels;
using StarSecurityServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StarSecurityServices.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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
                JobCount = _context.Jobs.Count(),
                RegionCount = _context.Regions.Count(),
                RoleCount = _context.Roles.Count(),
                ServiceCount = _context.Jobs.Count(),
                VacancyCount = _context.Vacancies.Count()
            };
            return View(viewModel);
        }

        // GET: Admin/Login
        [HttpGet]
        [AllowAnonymous]
        [Route("login.html", Name = "Login")]
        public IActionResult Login(string returnUrl = null)
        {
            var employeeId = HttpContext.Session.GetString("EmployeeId");
            if (employeeId != null)
            {
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login.html", Name = "Login")]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee employee = _context.Employees
                        .Include(p => p.Role)
                        .SingleOrDefault(p => p.Email.ToLower() == model.Email.ToLower().Trim());

                    if (employee == null)
                    {
                        ViewBag.Error = "Login info is incorrect";
                        return View(model);
                    }

                    string password = Extensions.HashMD5.GetMD5(model.Password.Trim());
                    if (employee.Password.Trim() != password)
                    {
                        ViewBag.Error = "Login info is incorrect";
                        return View(model);
                    }

                    // Login Success
                    // Identity
                    // Save Session
                    HttpContext.Session.SetString("EmployeeId", employee.Id.ToString());
                    HttpContext.Session.SetString("EmployeeName", employee.Name);

                    var employeeClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, employee.Name),
                        new Claim(ClaimTypes.Email, employee.Email),
                        new Claim("EmployeeId", employee.Id.ToString()),
                        new Claim("RoleId", employee.RoleId.ToString()),
                        new Claim(ClaimTypes.Role, employee.Role.Name)
                    };

                    var grandmaIdentity = new ClaimsIdentity(employeeClaims, "Employee Identity");
                    var employeePrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                    await HttpContext.SignInAsync(employeePrincipal);

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
            }
            catch
            {
                return RedirectToAction("Login", "Home", new { Area = "Admin" });
            }
            return RedirectToAction("Login", "Home", new { Area = "Admin" });
        }

        [Route("logout.html", Name = "Logout")]
        public IActionResult Logout()
        {
            try
            {
                HttpContext.SignOutAsync();
                HttpContext.Session.Remove("EmployeeId");
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }               
        }
    }
}
