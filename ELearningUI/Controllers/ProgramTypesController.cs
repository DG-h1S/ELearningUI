using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ELearningUI.Models;

namespace ELearningUI.Controllers
{
    public class ProgramTypesController : Controller
    {
        private readonly ELearningContext _context;

        public ProgramTypesController(ELearningContext context)
        {
            _context = context;
        }

        // GET: ProgramTypes
        public async Task<IActionResult> Index()
        {
              return _context.ProgramTypes != null ? 
                          View(await _context.ProgramTypes.ToListAsync()) :
                          Problem("Entity set 'ELearningContext.ProgramTypes'  is null.");
        }

        // GET: ProgramTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProgramTypes == null)
            {
                return NotFound();
            }

            var programType = await _context.ProgramTypes
                .FirstOrDefaultAsync(m => m.ProgramId == id);
            if (programType == null)
            {
                return NotFound();
            }

            return View(programType);
        }

        // GET: ProgramTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgramTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgramId,ProgramName,ProgramCode")] ProgramType programType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programType);
        }

        // GET: ProgramTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProgramTypes == null)
            {
                return NotFound();
            }

            var programType = await _context.ProgramTypes.FindAsync(id);
            if (programType == null)
            {
                return NotFound();
            }
            return View(programType);
        }

        // POST: ProgramTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgramId,ProgramName,ProgramCode")] ProgramType programType)
        {
            if (id != programType.ProgramId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramTypeExists(programType.ProgramId))
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
            return View(programType);
        }

        // GET: ProgramTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProgramTypes == null)
            {
                return NotFound();
            }

            var programType = await _context.ProgramTypes
                .FirstOrDefaultAsync(m => m.ProgramId == id);
            if (programType == null)
            {
                return NotFound();
            }

            return View(programType);
        }

        // POST: ProgramTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProgramTypes == null)
            {
                return Problem("Entity set 'ELearningContext.ProgramTypes'  is null.");
            }
            var programType = await _context.ProgramTypes.FindAsync(id);
            if (programType != null)
            {
                _context.ProgramTypes.Remove(programType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramTypeExists(int id)
        {
          return (_context.ProgramTypes?.Any(e => e.ProgramId == id)).GetValueOrDefault();
        }
    }
}
