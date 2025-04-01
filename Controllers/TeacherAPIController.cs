using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models; 

namespace SchoolManagement.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherAPIController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        
        public TeacherAPIController(SchoolDbContext context)
        {
            _context = context;
        }

      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()  
        {
          
            return await _context.Teachers.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)  
        {
          
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }
    }
}


