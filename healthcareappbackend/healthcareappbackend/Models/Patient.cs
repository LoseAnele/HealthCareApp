namespace healthcareappbackend.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsMedicalAid { get; set; }
        public string? MedicalAidCompany { get; set; }
        public int AssistantId { get; set; }

        // These fields should be optional now
        public List<Visit>? Visits { get; set; } = new List<Visit>(); // Make this optional
        public List<Appointment>? Appointments { get; set; } = new List<Appointment>(); // Make this optional
    }

}
