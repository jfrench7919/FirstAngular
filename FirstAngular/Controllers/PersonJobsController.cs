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
    public class PersonJobsController : ControllerBase
    {
        private readonly ResumeContext _context;

        public PersonJobsController(ResumeContext context)
        {
            _context = context;
        }

        // GET: api/PersonJobs
        [HttpGet]
        public IEnumerable<PersonJob> GetPersonJob()
        {
            return _context.PersonJob;
        }

        // GET: api/PersonJobs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonJob([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personJob = await _context.PersonJob.FindAsync(id);

            if (personJob == null)
            {
                return NotFound();
            }

            return Ok(personJob);
        }

        // PUT: api/PersonJobs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonJob([FromRoute] int id, [FromBody] PersonJob personJob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personJob.Id)
            {
                return BadRequest();
            }

            _context.Entry(personJob).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonJobExists(id))
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

        // POST: api/PersonJobs
        [HttpPost]
        public async Task<IActionResult> PostPersonJob([FromBody] PersonJob personJob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PersonJob.Add(personJob);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonJob", new { id = personJob.Id }, personJob);
        }

        // DELETE: api/PersonJobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonJob([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personJob = await _context.PersonJob.FindAsync(id);
            if (personJob == null)
            {
                return NotFound();
            }

            _context.PersonJob.Remove(personJob);
            await _context.SaveChangesAsync();

            return Ok(personJob);
        }

        private bool PersonJobExists(int id)
        {
            return _context.PersonJob.Any(e => e.Id == id);
        }
    }
}