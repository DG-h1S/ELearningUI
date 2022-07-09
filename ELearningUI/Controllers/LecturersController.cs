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
    public class LecturersController : Controller
    {
        private readonly ELearningContext _context;

        public LecturersController(ELearningContext context)
        {
            _context = context;
        }

        // GET: Lecturers
        public async Task<IActionResult> Index()
        {
            var eLearningContext = _context.Lecturers.Include(l => l.Department).Include(l => l.Enrollment).Include(l => l.Program).Include(l => l.Status);
            return View(await eLearningContext.ToListAsync());
        }

        // GET: Lecturers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lecturers == null)
            {
                return NotFound();
            }

            var lecturer = await _context.Lecturers
                .Include(l => l.Department)
                .Include(l => l.Enrollment)
                .Include(l => l.Program)
                .Include(l => l.Status)
                .FirstOrDefaultAsync(m => m.LecturerId == id);
            if (lecturer == null)
            {
                return NotFound();
            }

            return View(lecturer);
        }

        // GET: Lecturers/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Deparrtments, "DepartmentId", "DepartmentId");
            ViewData["EnrollmentId"] = new SelectList(_context.Enrollments, "EnrollmentId", "EnrollmentId");
            ViewData["ProgramId"] = new SelectList(_context.ProgramTypes, "ProgramId", "ProgramId");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId");
            return View();
        }

        // POST: Lecturers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LecturerId,Name,Fname,Gfname,Uname,Gender,Password,Address,Email,ProgramId,DepartmentId,EnrollmentId,StatusId")] Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lecturer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Deparrtments, "DepartmentId", "DepartmentId", lecturer.DepartmentId);
            ViewData["EnrollmentId"] = new SelectList(_context.Enrollments, "EnrollmentId", "EnrollmentId", lecturer.EnrollmentId);
            ViewData["ProgramId"] = new SelectList(_context.ProgramTypes, "ProgramId", "ProgramId", lecturer.ProgramId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", lecturer.StatusId);
            return View(lecturer);
        }

        // GET: Lecturers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lecturers == null)
            {
                return NotFound();
            }

            var lecturer = await _context.Lecturers.FindAsync(id);
            if (lecturer == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Deparrtments, "DepartmentId", "DepartmentId", lecturer.DepartmentId);
            ViewData["EnrollmentId"] = new SelectList(_context.Enrollments, "EnrollmentId", "EnrollmentId", lecturer.EnrollmentId);
            ViewData["ProgramId"] = new SelectList(_context.ProgramTypes, "ProgramId", "ProgramId", lecturer.ProgramId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", lecturer.StatusId);
            return View(lecturer);
        }

        // POST: Lecturers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LecturerId,Name,Fname,Gfname,Uname,Gender,Password,Address,Email,ProgramId,DepartmentId,EnrollmentId,StatusId")] Lecturer lecturer)
        {
            if (id != lecturer.LecturerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lecturer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LecturerExists(lecturer.LecturerId))
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
            ViewData["DepartmentId"] = new SelectList(_context.Deparrtments, "DepartmentId", "DepartmentId", lecturer.DepartmentId);
            ViewData["EnrollmentId"] = new SelectList(_context.Enrollments, "EnrollmentId", "EnrollmentId", lecturer.EnrollmentId);
            ViewData["ProgramId"] = new SelectList(_context.ProgramTypes, "ProgramId", "ProgramId", lecturer.ProgramId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", lecturer.StatusId);
            return View(lecturer);
        }

        // GET: Lecturers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lecturers == null)
            {
                return NotFound();
            }

            var lecturer = await _context.Lecturers
                .Include(l => l.Department)
                .Include(l => l.Enrollment)
                .Include(l => l.Program)
                .Include(l => l.Status)
                .FirstOrDefaultAsync(m => m.LecturerId == id);
            if (lecturer == null)
            {
                return NotFound();
            }

            return View(lecturer);
        }

        // POST: Lecturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lecturers == null)
            {
                return Problem("Entity set 'ELearningContext.Lecturers'  is null.");
            }
            var lecturer = await _context.Lecturers.FindAsync(id);
            if (lecturer != null)
            {
                _context.Lecturers.Remove(lecturer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LecturerExists(int id)
        {
          return (_context.Lecturers?.Any(e => e.LecturerId == id)).GetValueOrDefault();
        }
    }
}
