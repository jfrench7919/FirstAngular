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
    public class PeopleController : ControllerBase
    {
        private readonly ResumeContext _context;
        
        public PeopleController(ResumeContext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public IEnumerable<object> GetPerson()
        {
            var people = _context.Person
                        .Include(x => x.PersonJob)
                        .Include(x => x.PersonCert)
                        .Include(x => x.PersonEducation)
                        .Include(x => x.PersonLocation)
                        .Include(x => x.PersonReferencePerson)
                        .Include(x => x.PersonSkill)
                        .Include(x => x.PersonUrl);

            return people;
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = _context.Person
                            .Include(x => x.PersonJob)
                            .Include(x => x.PersonCert)
                            .Include(x => x.PersonEducation)
                            .Include(x => x.PersonLocation)
                            .Include(x => x.PersonReferencePerson)
                            .Include(x => x.PersonSkill)
                            .Include(x => x.PersonUrl)
                            .Where(x => x.Id == id).FirstOrDefault();

            if (person == null)
            {
                return NotFound();
            }
            
            return Ok(person);
        }

        // PUT: api/People/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson([FromRoute] int id, [FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // POST: api/People
        [HttpPost]
        public async Task<IActionResult> PostPerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Person.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Person.Remove(person);
            await _context.SaveChangesAsync();

            return Ok(person);
        }

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.Id == id);
        }
    }
}