using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentPortalDb.Models;

namespace StudentPortalDb.Controllers
{
    public class TblLogsController : Controller
    {
        private readonly StudentPortalDbContext _context;

        public TblLogsController(StudentPortalDbContext context)
        {
            _context = context;
        }

        // GET: TblLogs
        public async Task<IActionResult> Index()
        {
            var studentPortalDbContext = _context.TblLogs.Include(t => t.Student);
            return View(await studentPortalDbContext.ToListAsync());
        }

        // GET: TblLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLog = await _context.TblLogs
                .Include(t => t.Student)
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (tblLog == null)
            {
                return NotFound();
            }

            return View(tblLog);
        }

        // GET: TblLogs/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FullName");
            return View();
        }

        // POST: TblLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,Info")] TblLog tblLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FullName", tblLog.StudentId);
            return View(tblLog);
        }

        // GET: TblLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLog = await _context.TblLogs.FindAsync(id);
            if (tblLog == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FullName", tblLog.StudentId);
            return View(tblLog);
        }

        // POST: TblLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LogId,StudentId,Info")] TblLog tblLog)
        {
            if (id != tblLog.LogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblLogExists(tblLog.LogId))
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
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FullName", tblLog.StudentId);
            return View(tblLog);
        }

        // GET: TblLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblLog = await _context.TblLogs
                .Include(t => t.Student)
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (tblLog == null)
            {
                return NotFound();
            }

            return View(tblLog);
        }

        // POST: TblLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblLog = await _context.TblLogs.FindAsync(id);
            if (tblLog != null)
            {
                _context.TblLogs.Remove(tblLog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblLogExists(int id)
        {
            return _context.TblLogs.Any(e => e.LogId == id);
        }
    }
}
