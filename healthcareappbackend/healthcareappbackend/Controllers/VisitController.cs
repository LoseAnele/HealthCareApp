using healthcareappbackend.Data;
using healthcareappbackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace healthcareappbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly DataContext _context;

        public VisitController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Visit/getVisitByPatient/{patientId}
        [HttpGet("getVisitByPatient/{patientId}")]
        public async Task<ActionResult<IEnumerable<Visit>>> GetVisitsForPatient(int patientId)
        {
            var visits = await _context.Visits
                .Where(v => v.PatientId == patientId)
                .ToListAsync();

            if (visits == null || !visits.Any())
            {
                return NotFound("No visits found for this patient.");
            }

            return Ok(visits);
        }

        // GET: api/Visit/getVisitById/{id}
        [HttpGet("getVisitById/{id}")]
        public async Task<ActionResult<Visit>> GetVisitById(int id)
        {
            var visit = await _context.Visits.FindAsync(id);
            if (visit == null)
                return NotFound();
            return Ok(visit);
        }

        // POST: api/Visit/addVisit
        [HttpPost("addVisit")]
        public async Task<ActionResult<Visit>> CreateVisit([FromBody] Visit visit)
        {
            if (visit == null)
                return BadRequest();

            _context.Visits.Add(visit);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVisitById), new { id = visit.Id }, visit);
        }

        // PUT: api/Visit/updateVisit/{id}
        [HttpPut("updateVisit/{id}")]
        public async Task<IActionResult> UpdateVisit(int id, [FromBody] Visit visit)
        {
            if (visit == null || visit.Id != id)
                return BadRequest();

            var existingVisit = await _context.Visits.FindAsync(id);
            if (existingVisit == null)
                return NotFound();

            // Update properties
            existingVisit.VisitDate = visit.VisitDate;
            existingVisit.Notes = visit.Notes;
            existingVisit.Diagnosis = visit.Diagnosis;
            existingVisit.Treatment = visit.Treatment;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
