using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectWebAppDBFirst.Models;

namespace ProjectWebAppDBFirst.Controllers
{
    public class ServiceCentersController : Controller
    {
        private readonly CarnationDbContext _context;

        public ServiceCentersController(CarnationDbContext context)
        {
            _context = context;
        }

        // GET: ServiceCenters
        public async Task<IActionResult> Index()
        {
            var carnationDbContext = _context.ServiceCenters.Include(s => s.CategoryTypeNavigation).Include(s => s.CompanyTypeNavigation);
            return View(await carnationDbContext.ToListAsync());
        }

        // GET: ServiceCenters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceCenter = await _context.ServiceCenters
                .Include(s => s.CategoryTypeNavigation)
                .Include(s => s.CompanyTypeNavigation)
                .FirstOrDefaultAsync(m => m.ServiceCenterId == id);
            if (serviceCenter == null)
            {
                return NotFound();
            }

            return View(serviceCenter);
        }

        // GET: ServiceCenters/Create
        public IActionResult Create()
        {
            ViewData["CategoryType"] = new SelectList(_context.Categories, "Category1", "Category1");
            ViewData["CompanyType"] = new SelectList(_context.Companies, "Name", "Name");
            return View();
        }

        // POST: ServiceCenters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceCenterId,Name,CompanyType,Location,CategoryType,ContactNumber,Timings,CertifiedBy")] ServiceCenter serviceCenter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceCenter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryType"] = new SelectList(_context.Categories, "Category1", "Category1", serviceCenter.CategoryType);
            ViewData["CompanyType"] = new SelectList(_context.Companies, "Name", "Name", serviceCenter.CompanyType);
            return View(serviceCenter);
        }

        // GET: ServiceCenters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceCenter = await _context.ServiceCenters.FindAsync(id);
            if (serviceCenter == null)
            {
                return NotFound();
            }
            ViewData["CategoryType"] = new SelectList(_context.Categories, "Category1", "Category1", serviceCenter.CategoryType);
            ViewData["CompanyType"] = new SelectList(_context.Companies, "Name", "Name", serviceCenter.CompanyType);
            return View(serviceCenter);
        }

        // POST: ServiceCenters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceCenterId,Name,CompanyType,Location,CategoryType,ContactNumber,Timings,CertifiedBy")] ServiceCenter serviceCenter)
        {
            if (id != serviceCenter.ServiceCenterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceCenter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceCenterExists(serviceCenter.ServiceCenterId))
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
            ViewData["CategoryType"] = new SelectList(_context.Categories, "Category1", "Category1", serviceCenter.CategoryType);
            ViewData["CompanyType"] = new SelectList(_context.Companies, "Name", "Name", serviceCenter.CompanyType);
            return View(serviceCenter);
        }

        // GET: ServiceCenters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceCenter = await _context.ServiceCenters
                .Include(s => s.CategoryTypeNavigation)
                .Include(s => s.CompanyTypeNavigation)
                .FirstOrDefaultAsync(m => m.ServiceCenterId == id);
            if (serviceCenter == null)
            {
                return NotFound();
            }

            return View(serviceCenter);
        }

        // POST: ServiceCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceCenter = await _context.ServiceCenters.FindAsync(id);
            _context.ServiceCenters.Remove(serviceCenter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceCenterExists(int id)
        {
            return _context.ServiceCenters.Any(e => e.ServiceCenterId == id);
        }
    }
}
