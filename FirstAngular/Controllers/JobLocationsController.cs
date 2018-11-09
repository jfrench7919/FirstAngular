using FirstAngular.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobLocationsController : ControllerBase
    {
        private readonly ResumeContext _context;

        public JobLocationsController(ResumeContext context)
        {
            _context = context;
        }

        // GET: api/JobLocations
        [HttpGet]
        public IEnumerable<JobLocation> GetJobLocation()
        {
            return _context.JobLocation;
        }

        // GET: api/JobLocations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobLocation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobLocation = await _context.JobLocation.FindAsync(id);

            if (jobLocation == null)
            {
                return NotFound();
            }

            return Ok(jobLocation);
        }

        // PUT: api/JobLocations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobLocation([FromRoute] int id, [FromBody] JobLocation jobLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobLocation.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobLocationExists(id))
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

        // POST: api/JobLocations
        [HttpPost]
        public async Task<IActionResult> PostJobLocation([FromBody] JobLocation jobLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.JobLocation.Add(jobLocation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobLocationExists(jobLocation.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJobLocation", new { id = jobLocation.Id }, jobLocation);
        }

        // DELETE: api/JobLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobLocation([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobLocation = await _context.JobLocation.FindAsync(id);
            if (jobLocation == null)
            {
                return NotFound();
            }

            _context.JobLocation.Remove(jobLocation);
            await _context.SaveChangesAsync();

            return Ok(jobLocation);
        }

        private bool JobLocationExists(int id)
        {
            return _context.JobLocation.Any(e => e.Id == id);
        }
    }
}