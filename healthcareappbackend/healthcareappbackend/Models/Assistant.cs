namespace healthcareappbackend.Models
{
    public class Assistant
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
        public string Department { get; set; }
        public ICollection<Patient>? Patients { get; set; }
    }
}
