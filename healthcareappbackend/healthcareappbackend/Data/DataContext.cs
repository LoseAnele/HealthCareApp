using Microsoft.EntityFrameworkCore;
using healthcareappbackend.Models;

namespace healthcareappbackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Assistant> Assistants { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Example configuration for Administrator
            modelBuilder.Entity<Administrator>().ToTable("Administrators");
            modelBuilder.Entity<Administrator>()
                .Property(a => a.Username)
                .IsRequired();

            // Example configuration for Doctor
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<Doctor>()
                .Property(d => d.Name)
                .IsRequired();

            // Example configuration for Assistant
            modelBuilder.Entity<Assistant>().ToTable("Assistants");
            modelBuilder.Entity<Assistant>()
                .Property(a => a.Name)
                .IsRequired();

            // One-to-Many: Doctor -> Visits
            modelBuilder.Entity<Visit>()
                .HasOne<Doctor>() // Specify that Visit has one Doctor
                .WithMany() // No navigation property on Doctor
                .HasForeignKey(v => v.DoctorId);

            // One-to-Many: Patient -> Visits
            modelBuilder.Entity<Visit>()
                .HasOne<Patient>() // Specify that Visit has one Patient
                .WithMany() // No navigation property on Patient
                .HasForeignKey(v => v.PatientId)
                .OnDelete(DeleteBehavior.Cascade); // Optional: Configure delete behavior as needed

            // One-to-Many: Assistant -> Patients
            modelBuilder.Entity<Patient>()
                .HasOne<Assistant>() // Specify that Patient has one Assistant
                .WithMany() // No navigation property on Assistant
                .HasForeignKey(p => p.AssistantId)
                .OnDelete(DeleteBehavior.Cascade); // Optional: Configure delete behavior as needed

            modelBuilder.Entity<Appointment>()
          .HasOne<Patient>()  // Assuming Appointment has one Patient
          .WithMany()        // Assuming Patient can have many Appointments
          .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Appointment>()
                .HasOne<Doctor>()  // Assuming Appointment has one Doctor
                .WithMany()        // Assuming Doctor can have many Appointments
                .HasForeignKey(a => a.DoctorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
