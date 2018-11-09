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
    public class PersonLocationsController : ControllerBase
    {
        private readonly ResumeContext _context;

        public PersonLocationsController(ResumeContext context)
        {
            _context = context;
        }

        // GET: api/PersonLocations
        [HttpGet]
        public IEnumerable<PersonLocation> GetPersonLocation()
        {
            return _context.PersonLocation;
        }

        // GET: api/PersonLocations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonLocation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personLocation = await _context.PersonLocation.FindAsync(id);

            if (personLocation == null)
            {
                return NotFound();
            }

            return Ok(personLocation);
        }

        // PUT: api/PersonLocations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonLocation([FromRoute] int id, [FromBody] PersonLocation personLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personLocation.Id)
            {
                return BadRequest();
            }

            _context.Entry(personLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonLocationExists(id))
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

        // POST: api/PersonLocations
        [HttpPost]
        public async Task<IActionResult> PostPersonLocation([FromBody] PersonLocation personLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PersonLocation.Add(personLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonLocation", new { id = personLocation.Id }, personLocation);
        }

        // DELETE: api/PersonLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonLocation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personLocation = await _context.PersonLocation.FindAsync(id);
            if (personLocation == null)
            {
                return NotFound();
            }

            _context.PersonLocation.Remove(personLocation);
            await _context.SaveChangesAsync();

            return Ok(personLocation);
        }

        private bool PersonLocationExists(int id)
        {
            return _context.PersonLocation.Any(e => e.Id == id);
        }
    }
}