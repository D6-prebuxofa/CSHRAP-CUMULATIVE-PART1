// PUT: api/TeacherAPI/Update/5
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SchoolManagement.models;

/// <summary>
/// Updates a teacher in the database.
/// </summary>
[HttpPut("Update/{id}")]
public async Task<IActionResult> UpdateTeacher(int id, [FromBody] Teacher updatedTeacher)
{
    var teacher = await _context.Teachers.FindAsync(id);
    if (teacher == null)
    {
        return NotFound();
    }

    if (string.IsNullOrWhiteSpace(updatedTeacher.FirstName) || string.IsNullOrWhiteSpace(updatedTeacher.LastName))
    {
        return BadRequest("Teacher Name cannot be empty.");
    }
    if (updatedTeacher.HireDate > DateTime.Now)
    {
        return BadRequest("Hire Date cannot be in the future.");
    }
    if (updatedTeacher.Salary < 0)
    {
        return BadRequest("Salary cannot be negative.");
    }

    teacher.FirstName = updatedTeacher.FirstName;
    teacher.LastName = updatedTeacher.LastName;
    teacher.HireDate = updatedTeacher.HireDate;
    teacher.Subject = updatedTeacher.Subject;
    teacher.Salary = updatedTeacher.Salary;

    await _context.SaveChangesAsync();

    return Ok(teacher);
}












