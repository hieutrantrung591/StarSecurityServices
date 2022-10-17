using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using StarSecurityServices.Helpers;
using StarSecurityServices.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace StarSecurityServices.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CareerwithusController : Controller
    {
        private readonly StarSecurityDBContext _context;

        public CareerwithusController(StarSecurityDBContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString, int? page)
        {
            ViewData["CurrentFilter"] = searchString;

            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = Utilities.PAGE_SIZE;
            List<Vacancy> lsVacancies = new List<Vacancy>();

            if (!String.IsNullOrEmpty(searchString))
            {
                lsVacancies = _context.Vacancies
                                    .AsNoTracking().Where(x => x.Job.Name == searchString.Trim())
                                    .Include(v => v.Branch)
                                    .Include(v => v.Department)
                                    .Include(v => v.Job)
                                    .OrderBy(x => x.Id)
                                    .ToList();
            }
            else
            {
                lsVacancies = _context.Vacancies
                                    .AsNoTracking()
                                    .Include(v => v.Branch)
                                    .Include(v => v.Department)
                                    .Include(v => v.Job)
                                    .OrderBy(x => x.Id)
                                    .ToList();
            }

            PagedList<Vacancy> models = new PagedList<Vacancy>(lsVacancies.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/Vacancies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancies
                .Include(v => v.Branch)
                .Include(v => v.Department)
                .Include(v => v.Job)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancy == null)
            {
                return NotFound();
            }

            return View(vacancy);
        }
    }
}
