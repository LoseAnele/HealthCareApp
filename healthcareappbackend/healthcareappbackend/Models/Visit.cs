namespace healthcareappbackend.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime VisitDate { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public string Notes { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }
    }
}
