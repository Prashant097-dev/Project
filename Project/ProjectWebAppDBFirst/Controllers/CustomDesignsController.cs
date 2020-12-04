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
    public class CustomDesignsController : Controller
    {
        private readonly CarnationDbContext _context;

        public CustomDesignsController(CarnationDbContext context)
        {
            _context = context;
        }

        // GET: CustomDesigns
        public async Task<IActionResult> Index()
        {
            var carnationDbContext = _context.CustomDesigns.Include(c => c.CategoryTypeNavigation).Include(c => c.CompanyTypeNavigation);
            return View(await carnationDbContext.ToListAsync());
        }

        // GET: CustomDesigns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customDesign = await _context.CustomDesigns
                .Include(c => c.CategoryTypeNavigation)
                .Include(c => c.CompanyTypeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customDesign == null)
            {
                return NotFound();
            }

            return View(customDesign);
        }

        // GET: CustomDesigns/Create
        public IActionResult Create()
        {
            ViewData["CategoryType"] = new SelectList(_context.Categories, "Category1", "Category1");
            ViewData["CompanyType"] = new SelectList(_context.Companies, "Name", "Name");
            return View();
        }

        // POST: CustomDesigns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CompanyType,CategoryType,Description")] CustomDesign customDesign)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customDesign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryType"] = new SelectList(_context.Categories, "Category1", "Category1", customDesign.CategoryType);
            ViewData["CompanyType"] = new SelectList(_context.Companies, "Name", "Name", customDesign.CompanyType);
            return View(customDesign);
        }

        // GET: CustomDesigns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customDesign = await _context.CustomDesigns.FindAsync(id);
            if (customDesign == null)
            {
                return NotFound();
            }
            ViewData["CategoryType"] = new SelectList(_context.Categories, "Category1", "Category1", customDesign.CategoryType);
            ViewData["CompanyType"] = new SelectList(_context.Companies, "Name", "Name", customDesign.CompanyType);
            return View(customDesign);
        }

        // POST: CustomDesigns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CompanyType,CategoryType,Description")] CustomDesign customDesign)
        {
            if (id != customDesign.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customDesign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomDesignExists(customDesign.Id))
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
            ViewData["CategoryType"] = new SelectList(_context.Categories, "Category1", "Category1", customDesign.CategoryType);
            ViewData["CompanyType"] = new SelectList(_context.Companies, "Name", "Name", customDesign.CompanyType);
            return View(customDesign);
        }

        // GET: CustomDesigns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customDesign = await _context.CustomDesigns
                .Include(c => c.CategoryTypeNavigation)
                .Include(c => c.CompanyTypeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customDesign == null)
            {
                return NotFound();
            }

            return View(customDesign);
        }

        // POST: CustomDesigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customDesign = await _context.CustomDesigns.FindAsync(id);
            _context.CustomDesigns.Remove(customDesign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomDesignExists(int id)
        {
            return _context.CustomDesigns.Any(e => e.Id == id);
        }
    }
}
