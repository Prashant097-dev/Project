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
    public class FuturisticApproachesController : Controller
    {
        private readonly CarnationDbContext _context;

        public FuturisticApproachesController(CarnationDbContext context)
        {
            _context = context;
        }

        // GET: FuturisticApproaches
        public async Task<IActionResult> Index()
        {
            var carnationDbContext = _context.FuturisticApproaches.Include(f => f.CategoryTypeNavigation).Include(f => f.CompanyTypeNavigation);
            return View(await carnationDbContext.ToListAsync());
        }

        // GET: FuturisticApproaches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var futuristicApproach = await _context.FuturisticApproaches
                .Include(f => f.CategoryTypeNavigation)
                .Include(f => f.CompanyTypeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (futuristicApproach == null)
            {
                return NotFound();
            }

            return View(futuristicApproach);
        }

        // GET: FuturisticApproaches/Create
        public IActionResult Create()
        {
            ViewData["CategoryType"] = new SelectList(_context.Categories, "Category1", "Category1");
            ViewData["CompanyType"] = new SelectList(_context.Companies, "Name", "Name");
            return View();
        }

        // POST: FuturisticApproaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CompanyType,CategoryType,AddedFeatures")] FuturisticApproach futuristicApproach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(futuristicApproach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryType"] = new SelectList(_context.Categories, "Category1", "Category1", futuristicApproach.CategoryType);
            ViewData["CompanyType"] = new SelectList(_context.Companies, "Name", "Name", futuristicApproach.CompanyType);
            return View(futuristicApproach);
        }

        // GET: FuturisticApproaches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var futuristicApproach = await _context.FuturisticApproaches.FindAsync(id);
            if (futuristicApproach == null)
            {
                return NotFound();
            }
            ViewData["CategoryType"] = new SelectList(_context.Categories, "Category1", "Category1", futuristicApproach.CategoryType);
            ViewData["CompanyType"] = new SelectList(_context.Companies, "Name", "Name", futuristicApproach.CompanyType);
            return View(futuristicApproach);
        }

        // POST: FuturisticApproaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CompanyType,CategoryType,AddedFeatures")] FuturisticApproach futuristicApproach)
        {
            if (id != futuristicApproach.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(futuristicApproach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuturisticApproachExists(futuristicApproach.Id))
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
            ViewData["CategoryType"] = new SelectList(_context.Categories, "Category1", "Category1", futuristicApproach.CategoryType);
            ViewData["CompanyType"] = new SelectList(_context.Companies, "Name", "Name", futuristicApproach.CompanyType);
            return View(futuristicApproach);
        }

        // GET: FuturisticApproaches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var futuristicApproach = await _context.FuturisticApproaches
                .Include(f => f.CategoryTypeNavigation)
                .Include(f => f.CompanyTypeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (futuristicApproach == null)
            {
                return NotFound();
            }

            return View(futuristicApproach);
        }

        // POST: FuturisticApproaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var futuristicApproach = await _context.FuturisticApproaches.FindAsync(id);
            _context.FuturisticApproaches.Remove(futuristicApproach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuturisticApproachExists(int id)
        {
            return _context.FuturisticApproaches.Any(e => e.Id == id);
        }
    }
}
