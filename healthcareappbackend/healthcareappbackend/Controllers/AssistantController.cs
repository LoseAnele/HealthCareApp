using healthcareappbackend.Data;
using healthcareappbackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace healthcareappbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssistantController : ControllerBase
    {
        private readonly DataContext _context;

        public AssistantController(DataContext context)
        {
            _context = context;
        }


        // GET: api/assistant/getAssistants
        [HttpGet("getAssistants")]
        public async Task<ActionResult<IEnumerable<Assistant>>> GetAssistants()
        {
            var assistants = await _context.Assistants.ToListAsync();
            return Ok(assistants);
        }

        // GET: api/assistant/getAssistant/{id}
        [HttpGet("getAssistant/{id}")]
        public async Task<ActionResult<Assistant>> GetAssistant(int id)
        {
            var assistant = await _context.Assistants.FindAsync(id);
            if (assistant == null)
            {
                return NotFound();
            }
            return Ok(assistant);
        }

        // POST: api/assistant/addAssistant
        [HttpPost("addAssistant")]
        public async Task<ActionResult<Assistant>> PostAssistant(Assistant assistant)
        {
            if (assistant == null)
            {
                return BadRequest("Invalid assistant data.");
            }

            // Hash the assistant's password
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(assistant.PasswordHash);

            // Assign the hashed password to the assistant's password field
            assistant.PasswordHash = passwordHash;

            _context.Assistants.Add(assistant);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAssistant), new { id = assistant.Id }, assistant);
        }


        // PUT: api/assistant/updateAssistant/{id}
        [HttpPut("updateAssistant/{id}")]
        public async Task<IActionResult> PutAssistant(int id, Assistant assistant)
        {
            if (id != assistant.Id)
            {
                return BadRequest();
            }

            _context.Entry(assistant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssistantExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/assistant/deleteAssistant/{id}
        [HttpDelete("deleteAssistant/{id}")]
        public async Task<IActionResult> DeleteAssistant(int id)
        {
            var assistant = await _context.Assistants.FindAsync(id);
            if (assistant == null)
            {
                return NotFound();
            }

            _context.Assistants.Remove(assistant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssistantExists(int id)
        {
            return _context.Assistants.Any(e => e.Id == id);
        }
    }
}
