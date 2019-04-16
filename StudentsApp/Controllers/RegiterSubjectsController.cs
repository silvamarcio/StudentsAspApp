using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentsApp.Models;

namespace StudentsApp.Controllers
{
    public class RegiterSubjectsController : Controller
    {
        private readonly StudentsAppContext _context;

        public RegiterSubjectsController(StudentsAppContext context)
        {
            _context = context;
        }

        // GET: RegiterSubjects
        public async Task<IActionResult> Index()
        {
            var studentsAppContext = _context.RegiterSubject.Include(r => r.Student).Include(r => r.Subject);
            return View(await studentsAppContext.ToListAsync());
        }

        // GET: RegiterSubjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiterSubject = await _context.RegiterSubject
                .Include(r => r.Student)
                .Include(r => r.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regiterSubject == null)
            {
                return NotFound();
            }

            return View(regiterSubject);
        }

        // GET: RegiterSubjects/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id");
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Id");
            return View();
        }

        // POST: RegiterSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,SubjectId")] RegiterSubject regiterSubject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regiterSubject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", regiterSubject.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Id", regiterSubject.SubjectId);
            return View(regiterSubject);
        }

        // GET: RegiterSubjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiterSubject = await _context.RegiterSubject.FindAsync(id);
            if (regiterSubject == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", regiterSubject.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Id", regiterSubject.SubjectId);
            return View(regiterSubject);
        }

        // POST: RegiterSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,SubjectId")] RegiterSubject regiterSubject)
        {
            if (id != regiterSubject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regiterSubject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegiterSubjectExists(regiterSubject.Id))
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
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Id", regiterSubject.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Id", regiterSubject.SubjectId);
            return View(regiterSubject);
        }

        // GET: RegiterSubjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiterSubject = await _context.RegiterSubject
                .Include(r => r.Student)
                .Include(r => r.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regiterSubject == null)
            {
                return NotFound();
            }

            return View(regiterSubject);
        }

        // POST: RegiterSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regiterSubject = await _context.RegiterSubject.FindAsync(id);
            _context.RegiterSubject.Remove(regiterSubject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegiterSubjectExists(int id)
        {
            return _context.RegiterSubject.Any(e => e.Id == id);
        }
    }
}
