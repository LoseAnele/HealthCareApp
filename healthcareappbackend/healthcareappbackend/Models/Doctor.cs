namespace healthcareappbackend.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string Speciality { get; set; }
        public ICollection<Visit>? Visits { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
