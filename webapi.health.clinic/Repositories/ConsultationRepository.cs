using webapi.health.clinic.Contexts;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class ConsultationRepository : IConsultationRepository
    {
        private readonly HealthClinicContext _context;

        public ConsultationRepository()
        {
            _context = new HealthClinicContext();
        }

        public void Create(Consultation consultation)
        {
            _context.Consultations.Add(consultation);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Consultation findedConsultation = _context.Consultations.FirstOrDefault(consultation => consultation.Id == id)!;

            if (findedConsultation != null)
            {
                _context.Consultations.Remove(findedConsultation);
                _context.SaveChanges();
            }
        }

        public Consultation GetById(Guid id)
        {
            return _context.Consultations.Select(consultation => new Consultation
            {
                Id = consultation.Id,
                Date = consultation.Date.Date,
                Time = consultation.Time,
                Clinic = new Clinic
                {
                    Id = consultation.ClinicId,
                    FancyName = consultation.Clinic!.FancyName
                },
                Patient = new Patient
                {
                    Id = consultation.PatientId,
                    User = new User
                    {
                        Id = consultation.Patient!.UserId,
                        Name = consultation.Patient.User!.Name
                    }
                },
                DoctorMedicalSpecialty = new DoctorMedicalSpecialty
                {
                    Id = consultation.DoctorMedicalSpecialtyId,
                    MedicalSpecialty = new MedicalSpecialty
                    {
                        Id = consultation.DoctorMedicalSpecialty!.MedicalSpecialtyId,
                        Name = consultation.DoctorMedicalSpecialty.MedicalSpecialty!.Name
                    },
                    Doctor = new Doctor
                    {
                        Id = consultation.DoctorMedicalSpecialty.DoctorId,
                        CRM = consultation.DoctorMedicalSpecialty.Doctor!.CRM,
                        User = new User
                        {
                            Name = consultation.DoctorMedicalSpecialty.Doctor!.User!.Name
                        }
                    }
                },
                ConsultationStatus = new ConsultationStatus
                {
                    Id = consultation.ConsultationStatus!.Id,
                    StatusName = consultation.ConsultationStatus.StatusName
                }
            }).FirstOrDefault(consultation => consultation.Id == id)!;
        }

        public List<Consultation> GetConsultationByDoctor(Guid doctorId)
        {
            return _context.Consultations.Where(consultation => consultation.DoctorMedicalSpecialty!.DoctorId == doctorId).Select(consultation => new Consultation
            {
                Id = consultation.Id,
                Date = consultation.Date.Date,
                Time = consultation.Time,
                Clinic = new Clinic
                {
                    Id = consultation.ClinicId,
                    FancyName = consultation.Clinic!.FancyName
                },
                Patient = new Patient
                {
                    Id = consultation.PatientId,
                    User = new User
                    {
                        Id = consultation.Patient!.UserId,
                        Name = consultation.Patient.User!.Name
                    }
                },
                DoctorMedicalSpecialty = new DoctorMedicalSpecialty
                {
                    Id = consultation.DoctorMedicalSpecialtyId,
                    MedicalSpecialty = new MedicalSpecialty
                    {
                        Id = consultation.DoctorMedicalSpecialty!.MedicalSpecialtyId,
                        Name = consultation.DoctorMedicalSpecialty.MedicalSpecialty!.Name
                    },
                    Doctor = new Doctor
                    {
                        Id = consultation.DoctorMedicalSpecialty.DoctorId,
                        CRM = consultation.DoctorMedicalSpecialty.Doctor!.CRM,
                        User = new User
                        {
                            Name = consultation.DoctorMedicalSpecialty.Doctor!.User!.Name
                        }
                    }
                },
                ConsultationStatus = new ConsultationStatus
                {
                    Id = consultation.ConsultationStatus!.Id,
                    StatusName = consultation.ConsultationStatus.StatusName
                }
            }).ToList();
        }

        public List<Consultation> GetConsultationByPatient(Guid pacientId)
        {
            return _context.Consultations.Where(consultation => consultation.PatientId == pacientId).Select(consultation => new Consultation
            {
                Id = consultation.Id,
                Date = consultation.Date.Date,
                Time = consultation.Time,
                Clinic = new Clinic
                {
                    Id = consultation.ClinicId,
                    FancyName = consultation.Clinic!.FancyName
                },
                Patient = new Patient
                {
                    Id = consultation.PatientId,
                    User = new User
                    {
                        Id = consultation.Patient!.UserId,
                        Name = consultation.Patient.User!.Name
                    }
                },
                DoctorMedicalSpecialty = new DoctorMedicalSpecialty
                {
                    Id = consultation.DoctorMedicalSpecialtyId,
                    MedicalSpecialty = new MedicalSpecialty
                    {
                        Id = consultation.DoctorMedicalSpecialty!.MedicalSpecialtyId,
                        Name = consultation.DoctorMedicalSpecialty.MedicalSpecialty!.Name
                    },
                    Doctor = new Doctor
                    {
                        Id = consultation.DoctorMedicalSpecialty.DoctorId,
                        CRM = consultation.DoctorMedicalSpecialty.Doctor!.CRM,
                        User = new User
                        {
                            Name = consultation.DoctorMedicalSpecialty.Doctor!.User!.Name
                        }
                    }
                },
                ConsultationStatus = new ConsultationStatus
                {
                    Id = consultation.ConsultationStatus!.Id,
                    StatusName = consultation.ConsultationStatus.StatusName
                }
            }).ToList();
        }

        public List<Consultation> ListAll()
        {
            return _context.Consultations.Select(consultation => new Consultation
            {
                Id = consultation.Id,
                Date = consultation.Date.Date,
                Time = consultation.Time,
                Clinic = new Clinic
                {
                    Id = consultation.ClinicId,
                    FancyName = consultation.Clinic!.FancyName
                },
                Patient = new Patient
                {
                    Id = consultation.PatientId,
                    User = new User {
                        Id = consultation.Patient!.UserId,
                        Name = consultation.Patient.User!.Name
                    }
                },
                DoctorMedicalSpecialty = new DoctorMedicalSpecialty
                {
                    Id = consultation.DoctorMedicalSpecialtyId,
                    MedicalSpecialty = new MedicalSpecialty
                    {
                        Id = consultation.DoctorMedicalSpecialty!.MedicalSpecialtyId,
                        Name = consultation.DoctorMedicalSpecialty.MedicalSpecialty!.Name
                    },
                    Doctor = new Doctor
                    {
                        Id = consultation.DoctorMedicalSpecialty.DoctorId,
                        CRM =  consultation.DoctorMedicalSpecialty.Doctor!.CRM,
                        User = new User
                        {
                            Name = consultation.DoctorMedicalSpecialty.Doctor!.User!.Name
                        }
                    }
                },
                ConsultationStatus = new ConsultationStatus
                {
                    Id = consultation.ConsultationStatus!.Id,
                    StatusName = consultation.ConsultationStatus.StatusName
                }
            }).ToList();
        }

        public void Update(Consultation consultation)
        {
            Consultation findedConsultation = _context.Consultations.FirstOrDefault(c => c.Id == consultation.Id)!;

            if (findedConsultation != null)
            {
                findedConsultation.Date = consultation.Date;
                findedConsultation.Time = consultation.Time;
                findedConsultation.ClinicId = consultation.ClinicId;
                findedConsultation.PatientId = consultation.PatientId;
                findedConsultation.DoctorMedicalSpecialtyId = consultation.DoctorMedicalSpecialtyId;
                findedConsultation.MedicalRecordId = consultation.MedicalRecordId;
                findedConsultation.ConsultationStatusId = findedConsultation.ConsultationStatusId;

                _context.Consultations.Update(findedConsultation);
                _context.SaveChanges();
            }
        }
    }
}
