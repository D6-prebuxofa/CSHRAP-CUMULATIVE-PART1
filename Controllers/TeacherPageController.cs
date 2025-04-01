using Microsoft.AspNetCore.Mvc;
using YourNamespace.Services;   
using YourNamespace.Models;    
public class TeacherPageController : Controller
{
    private readonly TeacherService _teacherService;

    
    public TeacherPageController(TeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var teacher = _teacherService.GetTeacherById(id);
        if (teacher == null)
        {
            return NotFound(); 
        }

        _teacherService.DeleteTeacher(id); 
        return NoContent(); 
    }
}



