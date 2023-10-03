﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapi.health.clinic.Contexts;

#nullable disable

namespace webapi.health.clinic.Migrations
{
    [DbContext(typeof(HealthClinicContext))]
    partial class HealthClinicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webapi.health.clinic.Domains.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("CHAR(8)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("Complement")
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("VARCHAR(32)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("VARCHAR(5)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("CHAR(2)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.Clinic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("ClosingTime")
                        .HasColumnType("Time");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("FancyName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<TimeSpan>("OpeningTime")
                        .HasColumnType("Time");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.ClinicDoctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClinicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("DoctorId");

                    b.ToTable("ClinicDoctors");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.ClinicPatient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClinicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("PatientId");

                    b.ToTable("ClinicPatients");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConsultationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("Date");

                    b.Property<bool>("IsValidated")
                        .HasColumnType("BIT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("VARCHAR(300)");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.Consultation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClinicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConsultationStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("Date");

                    b.Property<Guid>("DoctorMedicalSpecialtyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MedicalRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("Time");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("ConsultationStatusId");

                    b.HasIndex("DoctorMedicalSpecialtyId");

                    b.HasIndex("MedicalRecordId");

                    b.HasIndex("PatientId");

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.ConsultationStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(32)");

                    b.HasKey("Id");

                    b.ToTable("ConsultationStatus");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("CHAR(8)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CRM")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.DoctorMedicalSpecialty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MedicalSpecialtyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("MedicalSpecialtyId");

                    b.ToTable("DoctorMedicalSpecialties");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.MedicalRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("MedicalRecords");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.MedicalSpecialty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(40)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("MedicalSpecialties");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("DATE");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("CHAR(60)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("CHAR(11)");

                    b.Property<string>("SomeonePhoneNumber")
                        .HasColumnType("CHAR(11)");

                    b.Property<Guid>("UserTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.UserType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(32)");

                    b.HasKey("Id");

                    b.HasIndex("TypeName")
                        .IsUnique();

                    b.ToTable("UserTypes");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.Clinic", b =>
                {
                    b.HasOne("webapi.health.clinic.Domains.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.ClinicDoctor", b =>
                {
                    b.HasOne("webapi.health.clinic.Domains.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health.clinic.Domains.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinic");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.ClinicPatient", b =>
                {
                    b.HasOne("webapi.health.clinic.Domains.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health.clinic.Domains.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinic");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.Comment", b =>
                {
                    b.HasOne("webapi.health.clinic.Domains.Consultation", "Consultation")
                        .WithMany()
                        .HasForeignKey("ConsultationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consultation");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.Consultation", b =>
                {
                    b.HasOne("webapi.health.clinic.Domains.Clinic", "Clinic")
                        .WithMany()
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health.clinic.Domains.ConsultationStatus", "ConsultationStatus")
                        .WithMany()
                        .HasForeignKey("ConsultationStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health.clinic.Domains.DoctorMedicalSpecialty", "DoctorMedicalSpecialty")
                        .WithMany()
                        .HasForeignKey("DoctorMedicalSpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health.clinic.Domains.MedicalRecord", "MedicalRecord")
                        .WithMany()
                        .HasForeignKey("MedicalRecordId");

                    b.HasOne("webapi.health.clinic.Domains.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinic");

                    b.Navigation("ConsultationStatus");

                    b.Navigation("DoctorMedicalSpecialty");

                    b.Navigation("MedicalRecord");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.Doctor", b =>
                {
                    b.HasOne("webapi.health.clinic.Domains.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.DoctorMedicalSpecialty", b =>
                {
                    b.HasOne("webapi.health.clinic.Domains.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health.clinic.Domains.MedicalSpecialty", "MedicalSpecialty")
                        .WithMany()
                        .HasForeignKey("MedicalSpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("MedicalSpecialty");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.Patient", b =>
                {
                    b.HasOne("webapi.health.clinic.Domains.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("webapi.health.clinic.Domains.User", b =>
                {
                    b.HasOne("webapi.health.clinic.Domains.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health.clinic.Domains.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("UserType");
                });
#pragma warning restore 612, 618
        }
    }
}
