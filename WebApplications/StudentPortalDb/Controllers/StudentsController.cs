using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortalDb.DTO;
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

        private DateTime GetIndianTime()
        {
            TimeZoneInfo istZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Kolkata");
            return TimeZoneInfo.ConvertTime(DateTime.Now, istZone);
        }

        public async Task<IActionResult> Index(string q = null)
        {
            var students = await _service.SearchAsync(q);
            var items = students.Select(StudentDto.Map).ToList();
            ViewBag.Query = q ?? "";
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentListAsync(string q = null)
        {
            var students = await _service.SearchAsync(q);
            var response = students.Select(StudentDto.Map).ToList();
            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string q)
        {
            var students = await _service.SearchAsync(q);
            var response = students.Select(StudentDto.Map).ToList();
            return Json(response);
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
            return View(new CreateStudentDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStudentDto request)
        {
            if (!ModelState.IsValid)
                return View(request);

            if (await _service.EmailExistsAsync(request.Email))
            {
                ModelState.AddModelError(nameof(request.Email), "Email already exists.");
                return View(request);
            }

            var student = new Student
            {
                FullName = request.FullName,
                Email = request.Email,
                Phone = request.Phone,
                JoinDate = request.JoinDate,
                Status = "Active",
                CreatedAt = GetIndianTime()
            };

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

            var editDto = EditStudentDto.Map(student);
            return View(editDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditStudentDto request)
        {
            if (id != request.StudentId)
                return NotFound();

            if (!ModelState.IsValid)
                return View(request);

            try
            {
                // Get the tracked instance from database
                var existingStudent = await _service.GetByIdAsync(id);
                if (existingStudent == null)
                    return NotFound();

                // Update only the allowed fields on the tracked instance
                existingStudent.FullName = request.FullName;
                existingStudent.Email = request.Email;
                existingStudent.Phone = request.Phone;
                existingStudent.Status = request.Status;
                existingStudent.JoinDate = request.JoinDate;
                // CreatedAt is automatically preserved

                await _service.UpdateAsync(existingStudent);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _service.ExistsAsync(request.StudentId))
                    return NotFound();
                else
                    throw;
            }
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