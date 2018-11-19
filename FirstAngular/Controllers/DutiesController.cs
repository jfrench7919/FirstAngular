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
    public class DutiesController : ControllerBase
    {
        private readonly ResumeContext _context;

        public DutiesController(ResumeContext context)
        {
            _context = context;
        }

        // GET: api/Duties
        [HttpGet]
        public IEnumerable<Duty> GetDuty()
        {
            return _context.Duty;
        }

        // GET: api/Duties/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDuty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var duty = await _context.Duty.FindAsync(id);

            if (duty == null)
            {
                return NotFound();
            }

            return Ok(duty);
        }

        // GET: api/Duties/5
        [HttpGet("ByJob/{id}")]
        public async Task<IActionResult> GetDutyByJob([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var duties = _context.JobDuty.Include(x => x.Duty).Where(x => x.JobId == id);

            if (duties == null)
            {
                return NotFound();
            }

            return Ok(duties);
        }

        // PUT: api/Duties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDuty([FromRoute] int id, [FromBody] Duty duty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != duty.Id)
            {
                return BadRequest();
            }

            _context.Entry(duty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DutyExists(id))
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

        // POST: api/Duties
        [HttpPost]
        public async Task<IActionResult> PostDuty([FromBody] Duty duty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Duty.Add(duty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDuty", new { id = duty.Id }, duty);
        }

        // DELETE: api/Duties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDuty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var duty = await _context.Duty.FindAsync(id);
            if (duty == null)
            {
                return NotFound();
            }

            _context.Duty.Remove(duty);
            await _context.SaveChangesAsync();

            return Ok(duty);
        }

        private bool DutyExists(int id)
        {
            return _context.Duty.Any(e => e.Id == id);
        }
    }
}