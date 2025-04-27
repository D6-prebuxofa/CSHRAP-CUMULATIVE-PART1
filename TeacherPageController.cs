using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement;
using SchoolManagement.Models; // Correct namespace for your models
using YourProjectNamespace.Data; // Wherever your DbContext is

namespace YourProjectNamespace.Controllers
{
    public class TeacherPageController : Controller
    {
        private readonly SchoolDbContext _context;

        public TeacherPageController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: /Teacher/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: /Teacher/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(teacher.FirstName) || string.IsNullOrWhiteSpace(teacher.LastName))
                {
                    ModelState.AddModelError("", "Teacher Name cannot be empty.");
                    return View(teacher);
                }
                if (teacher.HireDate > DateTime.Now)
                {
                    ModelState.AddModelError("", "Hire Date cannot be in the future.");
                    return View(teacher);
                }
                if (teacher.Salary < 0)
                {
                    ModelState.AddModelError("", "Salary cannot be negative.");
                    return View(teacher);
                }

                _context.Update(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // After updating, go back to the Index page
            }
            return View(teacher);
        }
    }
}







