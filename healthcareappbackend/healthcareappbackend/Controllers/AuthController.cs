using healthcareappbackend.Data;
using healthcareappbackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace healthcareappbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;

        public AuthController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto userLoginDto)
        {
            // Validate the input
            if (userLoginDto == null || string.IsNullOrEmpty(userLoginDto.Email) || string.IsNullOrEmpty(userLoginDto.Password))
            {
                return BadRequest(new { message = "Email and password are required." });
            }

            // Check for Administrator
            var admin = _context.Administrators.SingleOrDefault(u => u.Email == userLoginDto.Email);
            if (admin != null && BCrypt.Net.BCrypt.Verify(userLoginDto.Password, admin.PasswordHash))
            {
                return Ok(new { FullName = admin.FullName, Role = admin.Role, Email = admin.Email, AdminId = admin.Id});
            }

            // Check for Doctor
            var doctor = _context.Doctors.SingleOrDefault(u => u.Email == userLoginDto.Email);
            if (doctor != null && BCrypt.Net.BCrypt.Verify(userLoginDto.Password, doctor.PasswordHash))
            {
                return Ok(new { FullName = $"{doctor.Name} {doctor.Surname}", Role = doctor.Role, Email = doctor.Email, doctorId = doctor.Id });
            }

            // Check for Assistant
            var assistant = _context.Assistants.SingleOrDefault(u => u.Email == userLoginDto.Email);
            if (assistant != null && BCrypt.Net.BCrypt.Verify(userLoginDto.Password, assistant.PasswordHash))
            {
                return Ok(new { FullName = $"{assistant.Name} {assistant.Surname}", Role = assistant.Role, Email = assistant.Email, AssistantId = assistant.Id });
            }

            // If no match found
            return Unauthorized(new { message = "Invalid email or password." });
        }


        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword([FromBody] ForgotPasswordDto forgotDto)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == forgotDto.Email);
            if (user == null)
            {
                return NotFound("User not found");
            }

            // Logic to send a password reset email
            return Ok(new { Message = "Password reset email sent" });
        }
    }
}
