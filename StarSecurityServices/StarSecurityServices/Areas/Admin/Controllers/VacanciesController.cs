using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using StarSecurityServices.Helpers;
using StarSecurityServices.Models;

namespace StarSecurityServices.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VacanciesController : Controller
    {
        private readonly StarSecurityDBContext _context;

        public VacanciesController(StarSecurityDBContext context)
        {
            _context = context;
        }

        // GET: Admin/Vacancies
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = Utilities.PAGE_SIZE;
            var lsVacancies = _context.Vacancies
                                    .Include(v => v.Branch)
                                    .Include(v => v.Department)
                                    .Include(v => v.Job)
                                    .OrderBy(x => x.Id);

            PagedList<Vacancy> models = new PagedList<Vacancy>(lsVacancies, pageNumber, pageSize);

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

            Console.WriteLine(Thread.CurrentThread.CurrentCulture.Name);
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern);
            return View(vacancy);
        }

        // GET: Admin/Vacancies/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Address");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Name");
            return View();
        }

        // POST: Admin/Vacancies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JobId,DepartmentId,Description,Number,Status,BranchId,CreatedOn,UpdatedOn")] Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacancy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Address", vacancy.BranchId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", vacancy.DepartmentId);
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Name", vacancy.JobId);
            return View(vacancy);
        }

        // GET: Admin/Vacancies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancies.FindAsync(id);
            if (vacancy == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Address", vacancy.BranchId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", vacancy.DepartmentId);
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Name", vacancy.JobId);
            return View(vacancy);
        }

        // POST: Admin/Vacancies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JobId,DepartmentId,Description,Number,Status,BranchId,CreatedOn,UpdatedOn")] Vacancy vacancy)
        {
            if (id != vacancy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacancy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacancyExists(vacancy.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Address", vacancy.BranchId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", vacancy.DepartmentId);
            ViewData["JobId"] = new SelectList(_context.Jobs, "Id", "Name", vacancy.JobId);
            return View(vacancy);
        }

        // GET: Admin/Vacancies/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Admin/Vacancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacancy = await _context.Vacancies.FindAsync(id);
            _context.Vacancies.Remove(vacancy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacancyExists(int id)
        {
            return _context.Vacancies.Any(e => e.Id == id);
        }
    }
}
