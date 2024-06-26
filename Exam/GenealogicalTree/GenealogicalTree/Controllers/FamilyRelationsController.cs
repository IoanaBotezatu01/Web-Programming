using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GenealogicalTree.Data;
using GenealogicalTree.Models;

namespace GenealogicalTree.Controllers
{
    public class FamilyRelationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FamilyRelationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FamilyRelations
        public async Task<IActionResult> Index()
        {
            return View(await _context.FamilyRelations.ToListAsync());
        }

        // GET: FamilyRelations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familyRelations = await _context.FamilyRelations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familyRelations == null)
            {
                return NotFound();
            }

            return View(familyRelations);
        }

        // GET: FamilyRelations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FamilyRelations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Mother,Father")] FamilyRelations familyRelations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(familyRelations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(familyRelations);
        }

        // GET: FamilyRelations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familyRelations = await _context.FamilyRelations.FindAsync(id);
            if (familyRelations == null)
            {
                return NotFound();
            }
            return View(familyRelations);
        }

        // POST: FamilyRelations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Mother,Father")] FamilyRelations familyRelations)
        {
            if (id != familyRelations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(familyRelations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamilyRelationsExists(familyRelations.Id))
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
            return View(familyRelations);
        }

        // GET: FamilyRelations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familyRelations = await _context.FamilyRelations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familyRelations == null)
            {
                return NotFound();
            }

            return View(familyRelations);
        }

        // POST: FamilyRelations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familyRelations = await _context.FamilyRelations.FindAsync(id);
            if (familyRelations != null)
            {
                _context.FamilyRelations.Remove(familyRelations);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamilyRelationsExists(int id)
        {
            return _context.FamilyRelations.Any(e => e.Id == id);
        }
    }
}
