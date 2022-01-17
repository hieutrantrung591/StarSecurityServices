using System;
using System.Collections.Generic;
using System.Linq;
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
    [Authorize(Roles = "Admin")]
    public class ClientServicesController : Controller
    {
        private readonly StarSecurityDBContext _context;

        public ClientServicesController(StarSecurityDBContext context)
        {
            _context = context;
        }

        // GET: Admin/ClientServices
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = Utilities.PAGE_SIZE;
            var lsClientServices = _context.ClientServices
                                .Include(c => c.Client)
                                .Include(c => c.Service)
                                .OrderBy(x => x.Id);

            PagedList<ClientService> models = new PagedList<ClientService>(lsClientServices, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        // GET: Admin/ClientServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientService = await _context.ClientServices
                .Include(c => c.Client)
                .Include(c => c.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientService == null)
            {
                return NotFound();
            }

            return View(clientService);
        }

        // GET: Admin/ClientServices/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name");
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name");
            return View();
        }

        // POST: Admin/ClientServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,ServiceId,CreatedOn,UpdatedOn")] ClientService clientService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name", clientService.ClientId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", clientService.ServiceId);
            return View(clientService);
        }

        // GET: Admin/ClientServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientService = await _context.ClientServices.FindAsync(id);
            if (clientService == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name", clientService.ClientId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", clientService.ServiceId);
            return View(clientService);
        }

        // POST: Admin/ClientServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,ServiceId,CreatedOn,UpdatedOn")] ClientService clientService)
        {
            if (id != clientService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientServiceExists(clientService.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name", clientService.ClientId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", clientService.ServiceId);
            return View(clientService);
        }

        // GET: Admin/ClientServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientService = await _context.ClientServices
                .Include(c => c.Client)
                .Include(c => c.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientService == null)
            {
                return NotFound();
            }

            return View(clientService);
        }

        // POST: Admin/ClientServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientService = await _context.ClientServices.FindAsync(id);
            _context.ClientServices.Remove(clientService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientServiceExists(int id)
        {
            return _context.ClientServices.Any(e => e.Id == id);
        }
    }
}
