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
    public class ProductMerchantsController : Controller
    {
        private readonly CarnationDbContext _context;

        public ProductMerchantsController(CarnationDbContext context)
        {
            _context = context;
        }

        // GET: ProductMerchants
        public async Task<IActionResult> Index()
        {
            var carnationDbContext = _context.ProductMerchants.Include(p => p.CategoryNavigation).Include(p => p.CompanyNavigation).Include(p => p.Merchant);
            return View(await carnationDbContext.ToListAsync());
        }

        // GET: ProductMerchants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMerchant = await _context.ProductMerchants
                .Include(p => p.CategoryNavigation)
                .Include(p => p.CompanyNavigation)
                .Include(p => p.Merchant)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productMerchant == null)
            {
                return NotFound();
            }

            return View(productMerchant);
        }

        // GET: ProductMerchants/Create
        public IActionResult Create()
        {
            ViewData["Category"] = new SelectList(_context.Categories, "Category1", "Category1");
            ViewData["Company"] = new SelectList(_context.Companies, "Name", "Name");
            ViewData["MerchantId"] = new SelectList(_context.Merchants, "MerchantId", "Address");
            return View();
        }

        // POST: ProductMerchants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,MerchantId,Name,Company,ModelNumber,Category,Price,DateOfManufacturing,Colour,Description,EngineType,MileageKmpl,CentralLocking,BrakesType,RearSuspension")] ProductMerchant productMerchant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productMerchant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Category"] = new SelectList(_context.Categories, "Category1", "Category1", productMerchant.Category);
            ViewData["Company"] = new SelectList(_context.Companies, "Name", "Name", productMerchant.Company);
            ViewData["MerchantId"] = new SelectList(_context.Merchants, "MerchantId", "Address", productMerchant.MerchantId);
            return View(productMerchant);
        }

        // GET: ProductMerchants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMerchant = await _context.ProductMerchants.FindAsync(id);
            if (productMerchant == null)
            {
                return NotFound();
            }
            ViewData["Category"] = new SelectList(_context.Categories, "Category1", "Category1", productMerchant.Category);
            ViewData["Company"] = new SelectList(_context.Companies, "Name", "Name", productMerchant.Company);
            ViewData["MerchantId"] = new SelectList(_context.Merchants, "MerchantId", "Address", productMerchant.MerchantId);
            return View(productMerchant);
        }

        // POST: ProductMerchants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,MerchantId,Name,Company,ModelNumber,Category,Price,DateOfManufacturing,Colour,Description,EngineType,MileageKmpl,CentralLocking,BrakesType,RearSuspension")] ProductMerchant productMerchant)
        {
            if (id != productMerchant.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productMerchant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductMerchantExists(productMerchant.ProductId))
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
            ViewData["Category"] = new SelectList(_context.Categories, "Category1", "Category1", productMerchant.Category);
            ViewData["Company"] = new SelectList(_context.Companies, "Name", "Name", productMerchant.Company);
            ViewData["MerchantId"] = new SelectList(_context.Merchants, "MerchantId", "Address", productMerchant.MerchantId);
            return View(productMerchant);
        }

        // GET: ProductMerchants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productMerchant = await _context.ProductMerchants
                .Include(p => p.CategoryNavigation)
                .Include(p => p.CompanyNavigation)
                .Include(p => p.Merchant)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productMerchant == null)
            {
                return NotFound();
            }

            return View(productMerchant);
        }

        // POST: ProductMerchants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productMerchant = await _context.ProductMerchants.FindAsync(id);
            _context.ProductMerchants.Remove(productMerchant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductMerchantExists(int id)
        {
            return _context.ProductMerchants.Any(e => e.ProductId == id);
        }
    }
}
