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
    public class JobManagersController : ControllerBase
    {
        private readonly ResumeContext _context;

        public JobManagersController(ResumeContext context)
        {
            _context = context;
        }

        // GET: api/JobManagers
        [HttpGet]
        public IEnumerable<JobManager> GetJobManager()
        {
            return _context.JobManager;
        }

        // GET: api/JobManagers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobManager([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobManager = await _context.JobManager.FindAsync(id);

            if (jobManager == null)
            {
                return NotFound();
            }

            return Ok(jobManager);
        }

        // PUT: api/JobManagers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobManager([FromRoute] int id, [FromBody] JobManager jobManager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobManager.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobManager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobManagerExists(id))
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

        // POST: api/JobManagers
        [HttpPost]
        public async Task<IActionResult> PostJobManager([FromBody] JobManager jobManager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.JobManager.Add(jobManager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobManager", new { id = jobManager.Id }, jobManager);
        }

        // DELETE: api/JobManagers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobManager([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobManager = await _context.JobManager.FindAsync(id);
            if (jobManager == null)
            {
                return NotFound();
            }

            _context.JobManager.Remove(jobManager);
            await _context.SaveChangesAsync();

            return Ok(jobManager);
        }

        private bool JobManagerExists(int id)
        {
            return _context.JobManager.Any(e => e.Id == id);
        }
    }
}