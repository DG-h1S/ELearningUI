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
    public class CalendersController : Controller
    {
        private readonly ELearningContext _context;

        public CalendersController(ELearningContext context)
        {
            _context = context;
        }

        // GET: Calenders
        public async Task<IActionResult> Index()
        {
            var eLearningContext = _context.Calenders.Include(c => c.Enrollment).Include(c => c.Program);
            return View(await eLearningContext.ToListAsync());
        }

        // GET: Calenders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Calenders == null)
            {
                return NotFound();
            }

            var calender = await _context.Calenders
                .Include(c => c.Enrollment)
                .Include(c => c.Program)
                .FirstOrDefaultAsync(m => m.CalenderId == id);
            if (calender == null)
            {
                return NotFound();
            }

            return View(calender);
        }

        // GET: Calenders/Create
        public IActionResult Create()
        {
            ViewData["EnrollmentId"] = new SelectList(_context.Enrollments, "EnrollmentId", "EnrollmentId");
            ViewData["ProgramId"] = new SelectList(_context.ProgramTypes, "ProgramId", "ProgramId");
            return View();
        }

        // POST: Calenders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CalenderId,CalenderName,StartDate,EndDate,ProgramId,EnrollmentId")] Calender calender)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calender);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnrollmentId"] = new SelectList(_context.Enrollments, "EnrollmentId", "EnrollmentId", calender.EnrollmentId);
            ViewData["ProgramId"] = new SelectList(_context.ProgramTypes, "ProgramId", "ProgramId", calender.ProgramId);
            return View(calender);
        }

        // GET: Calenders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Calenders == null)
            {
                return NotFound();
            }

            var calender = await _context.Calenders.FindAsync(id);
            if (calender == null)
            {
                return NotFound();
            }
            ViewData["EnrollmentId"] = new SelectList(_context.Enrollments, "EnrollmentId", "EnrollmentId", calender.EnrollmentId);
            ViewData["ProgramId"] = new SelectList(_context.ProgramTypes, "ProgramId", "ProgramId", calender.ProgramId);
            return View(calender);
        }

        // POST: Calenders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CalenderId,CalenderName,StartDate,EndDate,ProgramId,EnrollmentId")] Calender calender)
        {
            if (id != calender.CalenderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calender);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalenderExists(calender.CalenderId))
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
            ViewData["EnrollmentId"] = new SelectList(_context.Enrollments, "EnrollmentId", "EnrollmentId", calender.EnrollmentId);
            ViewData["ProgramId"] = new SelectList(_context.ProgramTypes, "ProgramId", "ProgramId", calender.ProgramId);
            return View(calender);
        }

        // GET: Calenders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Calenders == null)
            {
                return NotFound();
            }

            var calender = await _context.Calenders
                .Include(c => c.Enrollment)
                .Include(c => c.Program)
                .FirstOrDefaultAsync(m => m.CalenderId == id);
            if (calender == null)
            {
                return NotFound();
            }

            return View(calender);
        }

        // POST: Calenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Calenders == null)
            {
                return Problem("Entity set 'ELearningContext.Calenders'  is null.");
            }
            var calender = await _context.Calenders.FindAsync(id);
            if (calender != null)
            {
                _context.Calenders.Remove(calender);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalenderExists(int id)
        {
          return (_context.Calenders?.Any(e => e.CalenderId == id)).GetValueOrDefault();
        }
    }
}
