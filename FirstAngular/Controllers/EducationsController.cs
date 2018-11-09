using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstAngular.Models;

namespace FirstAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        private readonly ResumeContext _context;

        public EducationsController(ResumeContext context)
        {
            _context = context;
        }

        // GET: api/Educations
        [HttpGet]
        public IEnumerable<Education> GetEducation()
        {
            return _context.Education;
        }

        // GET: api/Educations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEducation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var education = await _context.Education.FindAsync(id);

            if (education == null)
            {
                return NotFound();
            }

            return Ok(education);
        }

        // PUT: api/Educations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducation([FromRoute] int id, [FromBody] Education education)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != education.Id)
            {
                return BadRequest();
            }

            _context.Entry(education).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationExists(id))
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

        // POST: api/Educations
        [HttpPost]
        public async Task<IActionResult> PostEducation([FromBody] Education education)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Education.Add(education);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEducation", new { id = education.Id }, education);
        }

        // DELETE: api/Educations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var education = await _context.Education.FindAsync(id);
            if (education == null)
            {
                return NotFound();
            }

            _context.Education.Remove(education);
            await _context.SaveChangesAsync();

            return Ok(education);
        }

        private bool EducationExists(int id)
        {
            return _context.Education.Any(e => e.Id == id);
        }
    }
}