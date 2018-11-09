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
    public class CertsController : ControllerBase
    {
        private readonly ResumeContext _context;

        public CertsController(ResumeContext context)
        {
            _context = context;
        }

        // GET: api/Certs
        [HttpGet]
        public IEnumerable<Cert> GetCert()
        {
            return _context.Cert;
        }

        // GET: api/Certs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCert([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cert = await _context.Cert.FindAsync(id);

            if (cert == null)
            {
                return NotFound();
            }

            return Ok(cert);
        }

        // PUT: api/Certs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCert([FromRoute] int id, [FromBody] Cert cert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cert.Id)
            {
                return BadRequest();
            }

            _context.Entry(cert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CertExists(id))
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

        // POST: api/Certs
        [HttpPost]
        public async Task<IActionResult> PostCert([FromBody] Cert cert)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cert.Add(cert);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCert", new { id = cert.Id }, cert);
        }

        // DELETE: api/Certs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCert([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cert = await _context.Cert.FindAsync(id);
            if (cert == null)
            {
                return NotFound();
            }

            _context.Cert.Remove(cert);
            await _context.SaveChangesAsync();

            return Ok(cert);
        }

        private bool CertExists(int id)
        {
            return _context.Cert.Any(e => e.Id == id);
        }
    }
}