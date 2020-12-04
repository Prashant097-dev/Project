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
    public class NewUsersController : Controller
    {
        private readonly CarnationDbContext _context;

        public NewUsersController(CarnationDbContext context)
        {
            _context = context;
        }

        // GET: NewUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.NewUsers.ToListAsync());
        }

        // GET: NewUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newUser = await _context.NewUsers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (newUser == null)
            {
                return NotFound();
            }

            return View(newUser);
        }

        // GET: NewUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserPassword,Name,Email,Age,Address,UserPin,UserLocation,DateOfBirth,ContactNumber")] NewUser newUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newUser);
        }

        // GET: NewUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newUser = await _context.NewUsers.FindAsync(id);
            if (newUser == null)
            {
                return NotFound();
            }
            return View(newUser);
        }

        // POST: NewUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserPassword,Name,Email,Age,Address,UserPin,UserLocation,DateOfBirth,ContactNumber")] NewUser newUser)
        {
            if (id != newUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewUserExists(newUser.UserId))
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
            return View(newUser);
        }

        // GET: NewUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newUser = await _context.NewUsers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (newUser == null)
            {
                return NotFound();
            }

            return View(newUser);
        }

        // POST: NewUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newUser = await _context.NewUsers.FindAsync(id);
            _context.NewUsers.Remove(newUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewUserExists(int id)
        {
            return _context.NewUsers.Any(e => e.UserId == id);
        }
    }
}
