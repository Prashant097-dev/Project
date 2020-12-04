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
    public class ProductUsersController : Controller
    {
        private readonly CarnationDbContext _context;

        public ProductUsersController(CarnationDbContext context)
        {
            _context = context;
        }

        // GET: ProductUsers
        public async Task<IActionResult> Index()
        {
            var carnationDbContext = _context.ProductUsers.Include(p => p.CategoryNavigation).Include(p => p.CompanyNavigation);
            return View(await carnationDbContext.ToListAsync());
        }

        // GET: ProductUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productUser = await _context.ProductUsers
                .Include(p => p.CategoryNavigation)
                .Include(p => p.CompanyNavigation)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productUser == null)
            {
                return NotFound();
            }

            return View(productUser);
        }

        // GET: ProductUsers/Create
        public IActionResult Create()
        {
            ViewData["Category"] = new SelectList(_context.Categories, "Category1", "Category1");
            ViewData["Company"] = new SelectList(_context.Companies, "Name", "Name");
            return View();
        }

        // POST: ProductUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,Company,Category,Price,DateOfManufacturing,Colour,Description,EngineType,MileageKmpl,CentralLocking,BrakesType,RearSuspension")] ProductUser productUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Category"] = new SelectList(_context.Categories, "Category1", "Category1", productUser.Category);
            ViewData["Company"] = new SelectList(_context.Companies, "Name", "Name", productUser.Company);
            return View(productUser);
        }

        // GET: ProductUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productUser = await _context.ProductUsers.FindAsync(id);
            if (productUser == null)
            {
                return NotFound();
            }
            ViewData["Category"] = new SelectList(_context.Categories, "Category1", "Category1", productUser.Category);
            ViewData["Company"] = new SelectList(_context.Companies, "Name", "Name", productUser.Company);
            return View(productUser);
        }

        // POST: ProductUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Company,Category,Price,DateOfManufacturing,Colour,Description,EngineType,MileageKmpl,CentralLocking,BrakesType,RearSuspension")] ProductUser productUser)
        {
            if (id != productUser.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductUserExists(productUser.ProductId))
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
            ViewData["Category"] = new SelectList(_context.Categories, "Category1", "Category1", productUser.Category);
            ViewData["Company"] = new SelectList(_context.Companies, "Name", "Name", productUser.Company);
            return View(productUser);
        }

        // GET: ProductUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productUser = await _context.ProductUsers
                .Include(p => p.CategoryNavigation)
                .Include(p => p.CompanyNavigation)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productUser == null)
            {
                return NotFound();
            }

            return View(productUser);
        }

        // POST: ProductUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productUser = await _context.ProductUsers.FindAsync(id);
            _context.ProductUsers.Remove(productUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductUserExists(int id)
        {
            return _context.ProductUsers.Any(e => e.ProductId == id);
        }
    }
}
