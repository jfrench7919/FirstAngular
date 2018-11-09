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
    public class PersonCertsController : ControllerBase
    {
        private readonly ResumeContext _context;

        public PersonCertsController(ResumeContext context)
        {
            _context = context;
        }

        // GET: api/PersonCerts
        [HttpGet]
        public IEnumerable<PersonCert> GetPersonCert()
        {
            return _context.PersonCert;
        }

        // GET: api/PersonCerts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonCert([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personCert = await _context.PersonCert.FindAsync(id);

            if (personCert == null)
            {
                return NotFound();
            }

            return Ok(personCert);
        }

        // PUT: api/PersonCerts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonCert([FromRoute] int id, [FromBody] PersonCert personCert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personCert.Id)
            {
                return BadRequest();
            }

            _context.Entry(personCert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonCertExists(id))
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

        // POST: api/PersonCerts
        [HttpPost]
        public async Task<IActionResult> PostPersonCert([FromBody] PersonCert personCert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PersonCert.Add(personCert);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonCert", new { id = personCert.Id }, personCert);
        }

        // DELETE: api/PersonCerts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonCert([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var personCert = await _context.PersonCert.FindAsync(id);
            if (personCert == null)
            {
                return NotFound();
            }

            _context.PersonCert.Remove(personCert);
            await _context.SaveChangesAsync();

            return Ok(personCert);
        }

        private bool PersonCertExists(int id)
        {
            return _context.PersonCert.Any(e => e.Id == id);
        }
    }
}