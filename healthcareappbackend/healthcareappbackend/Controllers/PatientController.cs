using healthcareappbackend.Data;
using healthcareappbackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace healthcareappbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly DataContext _context;

        public PatientController(DataContext context)
        {
            _context = context;
        }

        // GET: api/patient/getPatients/{id}
        [HttpGet("getPatients/{id}")]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatientsByAssistant(int id)
        {
            int assistantId = id; // Get the current Assistant ID from the session

            var patients = _context.Patients.Where(p => p.AssistantId == assistantId).ToList();

            return Ok(patients);
        }

        [HttpGet("getAllPatients")]
        public List<Patient> GetAdministrators()
        {
            return _context.Patients.ToList(); //return a list of P...
        }


        // GET: api/patient/getPatient/{id}
        [HttpGet("getPatient/{id}")]
        public async Task<ActionResult<Patient>> GetPatientById(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
                return NotFound();
            return Ok(patient);
        }

        // POST: api/patient/addPatient
        [HttpPost("addPatient")]
        public async Task<ActionResult<Patient>> CreatePatient([FromBody] Patient patient)
        {
            if (patient.AssistantId == 0) // Check if AssistantId is set
            {
                return BadRequest("AssistantId is required.");
            }

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPatientsByAssistant), new { id = patient.PatientId }, patient);
        }

        // PUT: api/patient/updatePatient/{id}
        [HttpPut("updatePatient/{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] Patient patient)
        {
            if (patient == null || patient.PatientId != id)
                return BadRequest();

            var existingPatient = await _context.Patients.FindAsync(id);
            if (existingPatient == null)
                return NotFound();

            // Update the properties
            existingPatient.Name = patient.Name;
            existingPatient.Surname = patient.Surname;
            existingPatient.Username = patient.Username;
            existingPatient.Gender = patient.Gender;
            existingPatient.Address = patient.Address;
            existingPatient.Email = patient.Email;
            existingPatient.PhoneNumber = patient.PhoneNumber;
            existingPatient.IsMedicalAid = patient.IsMedicalAid;
            existingPatient.MedicalAidCompany = patient.MedicalAidCompany;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/patient/deletePatient/{id}
        [HttpDelete("deletePatient/{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
                return NotFound();

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
