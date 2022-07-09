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
    public class StudentsController : Controller
    {
        private readonly ELearningContext _context;

        public StudentsController(ELearningContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var eLearningContext = _context.Students.Include(s => s.Assessment).Include(s => s.Department).Include(s => s.Enrollment).Include(s => s.Grade).Include(s => s.Status).Include(s => s.StatusNavigation);
            return View(await eLearningContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Assessment)
                .Include(s => s.Department)
                .Include(s => s.Enrollment)
                .Include(s => s.Grade)
                .Include(s => s.Status)
                .Include(s => s.StatusNavigation)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["AssessmentId"] = new SelectList(_context.Assessments, "AssessmentId", "AssessmentId");
            ViewData["DepartmentId"] = new SelectList(_context.Deparrtments, "DepartmentId", "DepartmentId");
            ViewData["EnrollmentId"] = new SelectList(_context.Enrollments, "EnrollmentId", "EnrollmentId");
            ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId");
            ViewData["StatusId"] = new SelectList(_context.ProgramTypes, "ProgramId", "ProgramId");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,Name,Fname,Gfname,Uname,Password,Address,Gender,Email,DateOfBirth,EnrollmentId,ProgramId,StatusId,DepartmentId,GradeId,AssessmentId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssessmentId"] = new SelectList(_context.Assessments, "AssessmentId", "AssessmentId", student.AssessmentId);
            ViewData["DepartmentId"] = new SelectList(_context.Deparrtments, "DepartmentId", "DepartmentId", student.DepartmentId);
            ViewData["EnrollmentId"] = new SelectList(_context.Enrollments, "EnrollmentId", "EnrollmentId", student.EnrollmentId);
            ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId", student.GradeId);
            ViewData["StatusId"] = new SelectList(_context.ProgramTypes, "ProgramId", "ProgramId", student.StatusId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", student.StatusId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["AssessmentId"] = new SelectList(_context.Assessments, "AssessmentId", "AssessmentId", student.AssessmentId);
            ViewData["DepartmentId"] = new SelectList(_context.Deparrtments, "DepartmentId", "DepartmentId", student.DepartmentId);
            ViewData["EnrollmentId"] = new SelectList(_context.Enrollments, "EnrollmentId", "EnrollmentId", student.EnrollmentId);
            ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId", student.GradeId);
            ViewData["StatusId"] = new SelectList(_context.ProgramTypes, "ProgramId", "ProgramId", student.StatusId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", student.StatusId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,Name,Fname,Gfname,Uname,Password,Address,Gender,Email,DateOfBirth,EnrollmentId,ProgramId,StatusId,DepartmentId,GradeId,AssessmentId")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            ViewData["AssessmentId"] = new SelectList(_context.Assessments, "AssessmentId", "AssessmentId", student.AssessmentId);
            ViewData["DepartmentId"] = new SelectList(_context.Deparrtments, "DepartmentId", "DepartmentId", student.DepartmentId);
            ViewData["EnrollmentId"] = new SelectList(_context.Enrollments, "EnrollmentId", "EnrollmentId", student.EnrollmentId);
            ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId", student.GradeId);
            ViewData["StatusId"] = new SelectList(_context.ProgramTypes, "ProgramId", "ProgramId", student.StatusId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "StatusId", student.StatusId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Assessment)
                .Include(s => s.Department)
                .Include(s => s.Enrollment)
                .Include(s => s.Grade)
                .Include(s => s.Status)
                .Include(s => s.StatusNavigation)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'ELearningContext.Students'  is null.");
            }
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
          return (_context.Students?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
