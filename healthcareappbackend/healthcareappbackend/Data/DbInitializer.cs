using healthcareappbackend.Models;
using Microsoft.EntityFrameworkCore;

namespace healthcareappbackend.Data
{
    public static class DbInitializer
    {
        public static void Seed(DataContext context)
        {
            context.Database.EnsureCreated();

            // Check if an Administrator exists
            if (context.Administrators.Any() || context.Doctors.Any() || context.Assistants.Any())
            {
                return; // Admin already exists, so do not seed
            }

            // Create a sample Administrator
            var admin = new Administrator
            {
                Username = "admin@email.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin@123"),
                FullName = "John Doe",
                Role = "Admin",
                Email = "admin@email.com"
            };

            // Create a sample Doctor
            var doctor = new Doctor
            {
                Name = "Jane",
                Surname = "Doe",
                Gender = "Female",
                Address = "123 Govan Mbeki",
                Role = "Doctor",
                Speciality = "Cardiology",
                Username = "doctor@email.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("doctor@123"),
                Email = "doctor@email.com"
            };

            // Create a sample Assistant
            var assistant = new Assistant
            {
                Name = "Alice",
                Surname = "Smith",
                Gender = "Female",
                Address = "123 Main Street",
                Role = "Assistant",
                Department = "Cardiology",
                Username = "assistant@email.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("assistant@123"),
                Email = "assistant@email.com"
            };

            // Add the entities to the context
            context.Administrators.Add(admin);
            context.Doctors.Add(doctor);
            context.Assistants.Add(assistant);
            context.SaveChanges();
        }
    }
}
