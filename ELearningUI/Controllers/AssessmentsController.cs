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
    public class AssessmentsController : Controller
    {
        private readonly ELearningContext _context;

        public AssessmentsController(ELearningContext context)
        {
            _context = context;
        }

        // GET: Assessments
        public async Task<IActionResult> Index()
        {
            var eLearningContext = _context.Assessments.Include(a => a.Assignment).Include(a => a.Exam).Include(a => a.Lecturer).Include(a => a.Quiz);
            return View(await eLearningContext.ToListAsync());
        }

        // GET: Assessments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Assessments == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments
                .Include(a => a.Assignment)
                .Include(a => a.Exam)
                .Include(a => a.Lecturer)
                .Include(a => a.Quiz)
                .FirstOrDefaultAsync(m => m.AssessmentId == id);
            if (assessment == null)
            {
                return NotFound();
            }

            return View(assessment);
        }

        // GET: Assessments/Create
        public IActionResult Create()
        {
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "AssignmentId", "AssignmentId");
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId");
            ViewData["LecturerId"] = new SelectList(_context.Lecturers, "LecturerId", "LecturerId");
            ViewData["QuizId"] = new SelectList(_context.Quizzes, "QuizId", "QuizId");
            return View();
        }

        // POST: Assessments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssessmentId,AssessmentCode,Attendance,AssignmentId,QuizId,ExamId,LecturerId")] Assessment assessment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assessment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "AssignmentId", "AssignmentId", assessment.AssignmentId);
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId", assessment.ExamId);
            ViewData["LecturerId"] = new SelectList(_context.Lecturers, "LecturerId", "LecturerId", assessment.LecturerId);
            ViewData["QuizId"] = new SelectList(_context.Quizzes, "QuizId", "QuizId", assessment.QuizId);
            return View(assessment);
        }

        // GET: Assessments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Assessments == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments.FindAsync(id);
            if (assessment == null)
            {
                return NotFound();
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "AssignmentId", "AssignmentId", assessment.AssignmentId);
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId", assessment.ExamId);
            ViewData["LecturerId"] = new SelectList(_context.Lecturers, "LecturerId", "LecturerId", assessment.LecturerId);
            ViewData["QuizId"] = new SelectList(_context.Quizzes, "QuizId", "QuizId", assessment.QuizId);
            return View(assessment);
        }

        // POST: Assessments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssessmentId,AssessmentCode,Attendance,AssignmentId,QuizId,ExamId,LecturerId")] Assessment assessment)
        {
            if (id != assessment.AssessmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assessment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssessmentExists(assessment.AssessmentId))
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
            ViewData["AssignmentId"] = new SelectList(_context.Assignments, "AssignmentId", "AssignmentId", assessment.AssignmentId);
            ViewData["ExamId"] = new SelectList(_context.Exams, "ExamId", "ExamId", assessment.ExamId);
            ViewData["LecturerId"] = new SelectList(_context.Lecturers, "LecturerId", "LecturerId", assessment.LecturerId);
            ViewData["QuizId"] = new SelectList(_context.Quizzes, "QuizId", "QuizId", assessment.QuizId);
            return View(assessment);
        }

        // GET: Assessments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Assessments == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments
                .Include(a => a.Assignment)
                .Include(a => a.Exam)
                .Include(a => a.Lecturer)
                .Include(a => a.Quiz)
                .FirstOrDefaultAsync(m => m.AssessmentId == id);
            if (assessment == null)
            {
                return NotFound();
            }

            return View(assessment);
        }

        // POST: Assessments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Assessments == null)
            {
                return Problem("Entity set 'ELearningContext.Assessments'  is null.");
            }
            var assessment = await _context.Assessments.FindAsync(id);
            if (assessment != null)
            {
                _context.Assessments.Remove(assessment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssessmentExists(int id)
        {
          return (_context.Assessments?.Any(e => e.AssessmentId == id)).GetValueOrDefault();
        }
    }
}
