using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{
    private static List<Teacher> teachers = new List<Teacher>
    {
        new Teacher { TeacherId = 1, FirstName = "Alice", LastName = "Smith", HireDate = DateTime.Now },
        new Teacher { TeacherId = 2, FirstName = "Bob", LastName = "Johnson", HireDate = DateTime.Now }
    };

    
    [HttpGet]
    [Produces("application/json")]
    public IActionResult GetTeachers()
    {
        return Ok(teachers);
    }

    
    [HttpGet("{id}")]
    public IActionResult GetTeacher(int id)
    {
        var teacher = teachers.Find(t => t.TeacherId == id);
        if (teacher == null)
        {
            return NotFound();
        }
        return Ok(teacher);
    }

  
    [HttpPost]
    public IActionResult AddTeacher([FromBody] Teacher newTeacher)
    {
        if (newTeacher == null)
        {
            return BadRequest();
        }
        newTeacher.TeacherId = teachers.Count + 1;
        teachers.Add(newTeacher);
        return CreatedAtAction(nameof(GetTeacher), new { id = newTeacher.TeacherId }, newTeacher);
    }

   
    [HttpPut("{id}")]
    public IActionResult UpdateTeacher(int id, [FromBody] Teacher updatedTeacher)
    {
        var teacher = teachers.Find(t => t.TeacherId == id);
        if (teacher == null)
        {
            return NotFound();
        }
        teacher.FirstName = updatedTeacher.FirstName;
        teacher.LastName = updatedTeacher.LastName;
        teacher.HireDate = updatedTeacher.HireDate;
        return NoContent();
    }

    
    [HttpDelete("{id}")]
    public IActionResult DeleteTeacher(int id)
    {
        var teacher = teachers.Find(t => t.TeacherId == id);
        if (teacher == null)
        {
            return NotFound();
        }
        teachers.Remove(teacher);
        return NoContent();
    }
}

