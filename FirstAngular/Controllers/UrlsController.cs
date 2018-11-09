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
    public class UrlsController : ControllerBase
    {
        private readonly ResumeContext _context;

        public UrlsController(ResumeContext context)
        {
            _context = context;
        }

        // GET: api/Urls
        [HttpGet]
        public IEnumerable<Url> GetUrl()
        {
            return _context.Url;
        }

        // GET: api/Urls/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUrl([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var url = await _context.Url.FindAsync(id);

            if (url == null)
            {
                return NotFound();
            }

            return Ok(url);
        }

        // PUT: api/Urls/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUrl([FromRoute] int id, [FromBody] Url url)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != url.Id)
            {
                return BadRequest();
            }

            _context.Entry(url).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrlExists(id))
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

        // POST: api/Urls
        [HttpPost]
        public async Task<IActionResult> PostUrl([FromBody] Url url)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Url.Add(url);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUrl", new { id = url.Id }, url);
        }

        // DELETE: api/Urls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUrl([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var url = await _context.Url.FindAsync(id);
            if (url == null)
            {
                return NotFound();
            }

            _context.Url.Remove(url);
            await _context.SaveChangesAsync();

            return Ok(url);
        }

        private bool UrlExists(int id)
        {
            return _context.Url.Any(e => e.Id == id);
        }
    }
}