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
    public class PersonUrlsController : ControllerBase
    {
        private readonly ResumeContext _context;

        public PersonUrlsController(ResumeContext context)
        {
            _context = context;
        }

        // GET: api/PersonUrls
        [HttpGet]
        public IEnumerable<PersonUrl> GetPersonUrl()
        {
            return _context.PersonUrl;
        }

        // GET: api/PersonUrls/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonUrl([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personUrl = await _context.PersonUrl.FindAsync(id);

            if (personUrl == null)
            {
                return NotFound();
            }

            return Ok(personUrl);
        }

        // PUT: api/PersonUrls/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonUrl([FromRoute] int id, [FromBody] PersonUrl personUrl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personUrl.Id)
            {
                return BadRequest();
            }

            _context.Entry(personUrl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonUrlExists(id))
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

        // POST: api/PersonUrls
        [HttpPost]
        public async Task<IActionResult> PostPersonUrl([FromBody] PersonUrl personUrl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PersonUrl.Add(personUrl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonUrl", new { id = personUrl.Id }, personUrl);
        }

        // DELETE: api/PersonUrls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonUrl([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personUrl = await _context.PersonUrl.FindAsync(id);
            if (personUrl == null)
            {
                return NotFound();
            }

            _context.PersonUrl.Remove(personUrl);
            await _context.SaveChangesAsync();

            return Ok(personUrl);
        }

        private bool PersonUrlExists(int id)
        {
            return _context.PersonUrl.Any(e => e.Id == id);
        }
    }
}