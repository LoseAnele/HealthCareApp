using healthcareappbackend.Data;
using healthcareappbackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace healthcareappbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly DataContext _context;

        public AppointmentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("getAppointment/{doctorId}")]
        public async Task<IActionResult> GetAppointmentsForDoctor(int doctorId)
        {
            // Fetch appointments for the specified doctor
            var appointments = await _context.Appointments
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();

            if (appointments == null || !appointments.Any())
            {
                return NotFound("No appointments found for this doctor.");
            }

            return Ok(appointments);
        }

        [HttpPost("addAppointment")]
        public async Task<IActionResult> AddAppointment([FromBody] Appointment appointment)
        {
            if (appointment == null)
            {
                return BadRequest("Invalid appointment data.");
            }

            // Add the new appointment to the database
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
