using Microsoft.EntityFrameworkCore;
using webapi.health.clinic.Domains;

namespace webapi.health.clinic.Contexts
{
    public class HealthClinicContext : DbContext
    {
        // Tables
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<ClinicDoctor> ClinicDoctors { get; set; }
        public DbSet<ClinicPatient> ClinicPatients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorMedicalSpecialty> DoctorMedicalSpecialties { get; set; }
        public DbSet<MedicalSpecialty> MedicalSpecialties { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        // Connection String
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseSqlServer("Server = NOTE17-S14; Database = health_clinic_db; User Id = sa; Pwd = Senai@134; TrustServerCertificate = True");
    }
}

