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
    public class SchedulesController : Controller
    {
        private readonly ELearningContext _context;

        public SchedulesController(ELearningContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            var eLearningContext = _context.Schedules.Include(s => s.Admin).Include(s => s.Assessment).Include(s => s.Lecture).Include(s => s.Student);
            return View(await eLearningContext.ToListAsync());
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Schedules == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .Include(s => s.Admin)
                .Include(s => s.Assessment)
                .Include(s => s.Lecture)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.ScheduleId == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "AdminId");
            ViewData["AssessmentId"] = new SelectList(_context.Assessments, "AssessmentId", "AssessmentId");
            ViewData["LectureId"] = new SelectList(_context.Lecturers, "LecturerId", "LecturerId");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScheduleId,CourseStartDateTime,AdminId,LectureId,StudentId,AssessmentId")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", schedule.AdminId);
            ViewData["AssessmentId"] = new SelectList(_context.Assessments, "AssessmentId", "AssessmentId", schedule.AssessmentId);
            ViewData["LectureId"] = new SelectList(_context.Lecturers, "LecturerId", "LecturerId", schedule.LectureId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", schedule.StudentId);
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Schedules == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", schedule.AdminId);
            ViewData["AssessmentId"] = new SelectList(_context.Assessments, "AssessmentId", "AssessmentId", schedule.AssessmentId);
            ViewData["LectureId"] = new SelectList(_context.Lecturers, "LecturerId", "LecturerId", schedule.LectureId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", schedule.StudentId);
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScheduleId,CourseStartDateTime,AdminId,LectureId,StudentId,AssessmentId")] Schedule schedule)
        {
            if (id != schedule.ScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.ScheduleId))
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
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", schedule.AdminId);
            ViewData["AssessmentId"] = new SelectList(_context.Assessments, "AssessmentId", "AssessmentId", schedule.AssessmentId);
            ViewData["LectureId"] = new SelectList(_context.Lecturers, "LecturerId", "LecturerId", schedule.LectureId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", schedule.StudentId);
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Schedules == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .Include(s => s.Admin)
                .Include(s => s.Assessment)
                .Include(s => s.Lecture)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.ScheduleId == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Schedules == null)
            {
                return Problem("Entity set 'ELearningContext.Schedules'  is null.");
            }
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule != null)
            {
                _context.Schedules.Remove(schedule);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(int id)
        {
          return (_context.Schedules?.Any(e => e.ScheduleId == id)).GetValueOrDefault();
        }
    }
}
