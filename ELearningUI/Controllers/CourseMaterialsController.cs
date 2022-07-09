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
    public class CourseMaterialsController : Controller
    {
        private readonly ELearningContext _context;

        public CourseMaterialsController(ELearningContext context)
        {
            _context = context;
        }

        // GET: CourseMaterials
        public async Task<IActionResult> Index()
        {
            var eLearningContext = _context.CourseMaterials.Include(c => c.Course).Include(c => c.Lecture);
            return View(await eLearningContext.ToListAsync());
        }

        // GET: CourseMaterials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CourseMaterials == null)
            {
                return NotFound();
            }

            var courseMaterial = await _context.CourseMaterials
                .Include(c => c.Course)
                .Include(c => c.Lecture)
                .FirstOrDefaultAsync(m => m.CourseMaterialId == id);
            if (courseMaterial == null)
            {
                return NotFound();
            }

            return View(courseMaterial);
        }

        // GET: CourseMaterials/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");
            ViewData["LectureId"] = new SelectList(_context.Lecturers, "LecturerId", "LecturerId");
            return View();
        }

        // POST: CourseMaterials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseMaterialId,MaterialName,Description,File,LectureId,CourseId")] CourseMaterial courseMaterial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseMaterial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", courseMaterial.CourseId);
            ViewData["LectureId"] = new SelectList(_context.Lecturers, "LecturerId", "LecturerId", courseMaterial.LectureId);
            return View(courseMaterial);
        }

        // GET: CourseMaterials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CourseMaterials == null)
            {
                return NotFound();
            }

            var courseMaterial = await _context.CourseMaterials.FindAsync(id);
            if (courseMaterial == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", courseMaterial.CourseId);
            ViewData["LectureId"] = new SelectList(_context.Lecturers, "LecturerId", "LecturerId", courseMaterial.LectureId);
            return View(courseMaterial);
        }

        // POST: CourseMaterials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseMaterialId,MaterialName,Description,File,LectureId,CourseId")] CourseMaterial courseMaterial)
        {
            if (id != courseMaterial.CourseMaterialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseMaterial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseMaterialExists(courseMaterial.CourseMaterialId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", courseMaterial.CourseId);
            ViewData["LectureId"] = new SelectList(_context.Lecturers, "LecturerId", "LecturerId", courseMaterial.LectureId);
            return View(courseMaterial);
        }

        // GET: CourseMaterials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CourseMaterials == null)
            {
                return NotFound();
            }

            var courseMaterial = await _context.CourseMaterials
                .Include(c => c.Course)
                .Include(c => c.Lecture)
                .FirstOrDefaultAsync(m => m.CourseMaterialId == id);
            if (courseMaterial == null)
            {
                return NotFound();
            }

            return View(courseMaterial);
        }

        // POST: CourseMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CourseMaterials == null)
            {
                return Problem("Entity set 'ELearningContext.CourseMaterials'  is null.");
            }
            var courseMaterial = await _context.CourseMaterials.FindAsync(id);
            if (courseMaterial != null)
            {
                _context.CourseMaterials.Remove(courseMaterial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseMaterialExists(int id)
        {
          return (_context.CourseMaterials?.Any(e => e.CourseMaterialId == id)).GetValueOrDefault();
        }
    }
}
