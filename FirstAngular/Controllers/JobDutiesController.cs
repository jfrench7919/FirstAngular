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
    public class JobDutiesController : ControllerBase
    {
        private readonly ResumeContext _context;

        public JobDutiesController(ResumeContext context)
        {
            _context = context;
        }

        // GET: api/JobDuties
        [HttpGet]
        public IEnumerable<JobDuty> GetJobDuty()
        {
            return _context.JobDuty;
        }

        // GET: api/JobDuties/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobDuty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobDuty = await _context.JobDuty.FindAsync(id);

            if (jobDuty == null)
            {
                return NotFound();
            }

            return Ok(jobDuty);
        }

        // PUT: api/JobDuties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobDuty([FromRoute] int id, [FromBody] JobDuty jobDuty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobDuty.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobDuty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobDutyExists(id))
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

        // POST: api/JobDuties
        [HttpPost]
        public async Task<IActionResult> PostJobDuty([FromBody] JobDuty jobDuty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.JobDuty.Add(jobDuty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobDuty", new { id = jobDuty.Id }, jobDuty);
        }

        // DELETE: api/JobDuties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobDuty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobDuty = await _context.JobDuty.FindAsync(id);
            if (jobDuty == null)
            {
                return NotFound();
            }

            _context.JobDuty.Remove(jobDuty);
            await _context.SaveChangesAsync();

            return Ok(jobDuty);
        }

        private bool JobDutyExists(int id)
        {
            return _context.JobDuty.Any(e => e.Id == id);
        }
    }
}