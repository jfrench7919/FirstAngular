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
    public class PersonReferencesController : ControllerBase
    {
        private readonly ResumeContext _context;

        public PersonReferencesController(ResumeContext context)
        {
            _context = context;
        }

        // GET: api/PersonReferences
        [HttpGet]
        public IEnumerable<PersonReference> GetPersonReference()
        {
            return _context.PersonReference;
        }

        // GET: api/PersonReferences/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonReference([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personReference = await _context.PersonReference.FindAsync(id);

            if (personReference == null)
            {
                return NotFound();
            }

            return Ok(personReference);
        }

        // PUT: api/PersonReferences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonReference([FromRoute] int id, [FromBody] PersonReference personReference)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personReference.Id)
            {
                return BadRequest();
            }

            _context.Entry(personReference).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonReferenceExists(id))
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

        // POST: api/PersonReferences
        [HttpPost]
        public async Task<IActionResult> PostPersonReference([FromBody] PersonReference personReference)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PersonReference.Add(personReference);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonReference", new { id = personReference.Id }, personReference);
        }

        // DELETE: api/PersonReferences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonReference([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personReference = await _context.PersonReference.FindAsync(id);
            if (personReference == null)
            {
                return NotFound();
            }

            _context.PersonReference.Remove(personReference);
            await _context.SaveChangesAsync();

            return Ok(personReference);
        }

        private bool PersonReferenceExists(int id)
        {
            return _context.PersonReference.Any(e => e.Id == id);
        }
    }
}