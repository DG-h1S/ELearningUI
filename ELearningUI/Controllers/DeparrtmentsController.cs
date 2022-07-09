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
    public class DeparrtmentsController : Controller
    {
        private readonly ELearningContext _context;

        public DeparrtmentsController(ELearningContext context)
        {
            _context = context;
        }

        // GET: Deparrtments
        public async Task<IActionResult> Index()
        {
            var eLearningContext = _context.Deparrtments.Include(d => d.Program);
            return View(await eLearningContext.ToListAsync());
        }

        // GET: Deparrtments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Deparrtments == null)
            {
                return NotFound();
            }

            var deparrtment = await _context.Deparrtments
                .Include(d => d.Program)
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (deparrtment == null)
            {
                return NotFound();
            }

            return View(deparrtment);
        }

        // GET: Deparrtments/Create
        public IActionResult Create()
        {
            ViewData["ProgramId"] = new SelectList(_context.ProgramTypes, "ProgramId", "ProgramId");
            return View();
        }

        // POST: Deparrtments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentId,DepartmentCode,DepartmentName,TotalCourse,TotalCreditHr,ProgramId")] Deparrtment deparrtment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deparrtment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProgramId"] = new SelectList(_context.ProgramTypes, "ProgramId", "ProgramId", deparrtment.ProgramId);
            return View(deparrtment);
        }

        // GET: Deparrtments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Deparrtments == null)
            {
                return NotFound();
            }

            var deparrtment = await _context.Deparrtments.FindAsync(id);
            if (deparrtment == null)
            {
                return NotFound();
            }
            ViewData["ProgramId"] = new SelectList(_context.ProgramTypes, "ProgramId", "ProgramId", deparrtment.ProgramId);
            return View(deparrtment);
        }

        // POST: Deparrtments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentId,DepartmentCode,DepartmentName,TotalCourse,TotalCreditHr,ProgramId")] Deparrtment deparrtment)
        {
            if (id != deparrtment.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deparrtment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeparrtmentExists(deparrtment.DepartmentId))
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
            ViewData["ProgramId"] = new SelectList(_context.ProgramTypes, "ProgramId", "ProgramId", deparrtment.ProgramId);
            return View(deparrtment);
        }

        // GET: Deparrtments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Deparrtments == null)
            {
                return NotFound();
            }

            var deparrtment = await _context.Deparrtments
                .Include(d => d.Program)
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (deparrtment == null)
            {
                return NotFound();
            }

            return View(deparrtment);
        }

        // POST: Deparrtments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Deparrtments == null)
            {
                return Problem("Entity set 'ELearningContext.Deparrtments'  is null.");
            }
            var deparrtment = await _context.Deparrtments.FindAsync(id);
            if (deparrtment != null)
            {
                _context.Deparrtments.Remove(deparrtment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeparrtmentExists(int id)
        {
          return (_context.Deparrtments?.Any(e => e.DepartmentId == id)).GetValueOrDefault();
        }
    }
}
