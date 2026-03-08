using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortalDb.Models;
using StudentPortalDb.Services;

namespace StudentPortalDb.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(string q = null)
        {
            var items = await _service.SearchAsync(q);
            ViewBag.Query = q ?? "";
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string q)
        {
            var students = await _service.SearchAsync(q);
            return Json(students);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _service.GetByIdAsync(id.Value);

            if (student == null)
                return NotFound();

            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("FullName,Email,Phone")] Student student,
            string JoinDate)
        {
            if (string.IsNullOrWhiteSpace(JoinDate))
            {
                ModelState.AddModelError("JoinDate", "Join Date is required.");
                return View(student);
            }

            if (await _service.EmailExistsAsync(student.Email))
            {
                return RedirectToAction("Index", "Students");
            }

            student.JoinDate = DateOnly.Parse(JoinDate);
            student.Status = "Active";
            student.CreatedAt = DateTime.Now;

            await _service.AddAsync(student);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _service.GetByIdAsync(id.Value);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("StudentId,FullName,Email,Phone,Status,JoinDate")] Student student)
        {
            if (id != student.StudentId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _service.ExistsAsync(student.StudentId))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _service.GetByIdAsync(id.Value);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}