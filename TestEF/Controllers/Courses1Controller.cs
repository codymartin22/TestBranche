using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestEF.DBContext;
using TestEF.Models;

namespace TestEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Courses1Controller : ControllerBase
    {
        private readonly AppsDBContext _context;

        public Courses1Controller(AppsDBContext context)
        {
            _context = context;
        }

        // GET: api/Courses1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Courses>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }
        //find 
        [HttpGet("{id}/Courses")]
        public async Task<ActionResult<IEnumerable<Courses>>> GetCoursebySTID(int id)
        {
            var Course = await _context.Students.Where(p => p.StudentId == id).SelectMany(p => p.CourseStudents).Select(p => p.Courses).ToListAsync();
            return Course;
        }
        [HttpGet("{id}/Students")]
        public async Task<ActionResult<IEnumerable<Students>>> GetStudentsbyCID(int id)
        {
            var students = await _context.Courses.Where(p => p.CourseId == id).SelectMany(p => p.CourseStudents).Select(p => p.Students).ToListAsync();
            return students;
        }

        // GET: api/Courses1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Courses>> GetCourses(int id)
        {
            var courses = await _context.Courses.FindAsync(id);

            if (courses == null)
            {
                return NotFound();
            }

            return courses;
        }
        // PUT: api/Courses1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourses(int id, Courses courses)
        {
            if (id != courses.CourseId)
            {
                return BadRequest();
            }

            _context.Entry(courses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Courses1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Courses>> PostCourses(Courses courses)
        {
            _context.Courses.Add(courses);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourses", new { id = courses.CourseId }, courses);
        }

        // DELETE: api/Courses1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Courses>> DeleteCourses(int id)
        {
            var courses = await _context.Courses.FindAsync(id);
            if (courses == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(courses);
            await _context.SaveChangesAsync();

            return courses;
        }

        private bool CoursesExists(int id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}
