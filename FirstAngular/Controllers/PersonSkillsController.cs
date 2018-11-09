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
    public class PersonSkillsController : ControllerBase
    {
        private readonly ResumeContext _context;

        public PersonSkillsController(ResumeContext context)
        {
            _context = context;
        }

        // GET: api/PersonSkills
        [HttpGet]
        public IEnumerable<PersonSkill> GetPersonSkill()
        {
            return _context.PersonSkill;
        }

        // GET: api/PersonSkills/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonSkill([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personSkill = await _context.PersonSkill.FindAsync(id);

            if (personSkill == null)
            {
                return NotFound();
            }

            return Ok(personSkill);
        }

        // PUT: api/PersonSkills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonSkill([FromRoute] int id, [FromBody] PersonSkill personSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personSkill.Id)
            {
                return BadRequest();
            }

            _context.Entry(personSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonSkillExists(id))
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

        // POST: api/PersonSkills
        [HttpPost]
        public async Task<IActionResult> PostPersonSkill([FromBody] PersonSkill personSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PersonSkill.Add(personSkill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonSkill", new { id = personSkill.Id }, personSkill);
        }

        // DELETE: api/PersonSkills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonSkill([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personSkill = await _context.PersonSkill.FindAsync(id);
            if (personSkill == null)
            {
                return NotFound();
            }

            _context.PersonSkill.Remove(personSkill);
            await _context.SaveChangesAsync();

            return Ok(personSkill);
        }

        private bool PersonSkillExists(int id)
        {
            return _context.PersonSkill.Any(e => e.Id == id);
        }
    }
}