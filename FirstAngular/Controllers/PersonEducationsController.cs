using FirstAngular.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonEducationsController : ControllerBase
    {
        private readonly ResumeContext _context;

        public PersonEducationsController(ResumeContext context)
        {
            _context = context;
        }

        // GET: api/PersonEducations
        [HttpGet]
        public IEnumerable<PersonEducation> GetPersonEducation()
        {
            return _context.PersonEducation;
        }

        // GET: api/PersonEducations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonEducation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personEducation = await _context.PersonEducation.FindAsync(id);

            if (personEducation == null)
            {
                return NotFound();
            }

            return Ok(personEducation);
        }

        // PUT: api/PersonEducations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonEducation([FromRoute] int id, [FromBody] PersonEducation personEducation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personEducation.Id)
            {
                return BadRequest();
            }

            _context.Entry(personEducation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonEducationExists(id))
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

        // POST: api/PersonEducations
        [HttpPost]
        public async Task<IActionResult> PostPersonEducation([FromBody] PersonEducation personEducation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PersonEducation.Add(personEducation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonEducation", new { id = personEducation.Id }, personEducation);
        }

        // DELETE: api/PersonEducations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonEducation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personEducation = await _context.PersonEducation.FindAsync(id);
            if (personEducation == null)
            {
                return NotFound();
            }

            _context.PersonEducation.Remove(personEducation);
            await _context.SaveChangesAsync();

            return Ok(personEducation);
        }

        private bool PersonEducationExists(int id)
        {
            return _context.PersonEducation.Any(e => e.Id == id);
        }
    }
}