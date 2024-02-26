using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly StudentDbContext context;

        public StudentApiController(StudentDbContext context)
        {
            this.context = context;

        }

        
        [HttpGet]
        [Route("GetAllStudent")]
        public async Task<ActionResult<List<Student>>> GetAllStudent()
        {
            var data = await context.Students.ToListAsync();
            return Ok(data);

        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<Student>> GetById(int id)
        {
            var std = await context.Students.FindAsync(id);
            if (std == null)
            {
                return NotFound();
            }
            return Ok(std);

        }

        [HttpPost]
        
        public async Task<ActionResult<Student>> AddStudent(Student std)
        {
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpPut("{id}")]
        
        public async Task<ActionResult<Student>> UpdateStd(int id, Student std)
        {
            if (id != std.Id)
            {
                return BadRequest();
            }
            context.Entry(std).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpDelete("{id}")]
        
        public async Task<ActionResult<Student>> deleteStudent(int id)
        {
            var std = await context.Students.FindAsync(id);
            if (std == null)
            {
                return BadRequest();
            }
            context.Students.Remove(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }
    }
}
