using webapi.health.clinic.Contexts;
using webapi.health.clinic.Domains;
using webapi.health.clinic.Interfaces;

namespace webapi.health.clinic.Repositories
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly HealthClinicContext _context;

        public MedicalRecordRepository()
        {
            _context = new HealthClinicContext();
        }

        public void Create(MedicalRecord medicalRecord)
        {
            _context.MedicalRecords.Add(medicalRecord);
            _context.SaveChanges();
        }

        public MedicalRecord GetById(Guid id)
        {
            return _context.MedicalRecords.FirstOrDefault(record => record.Id == id)!;
        }

        public void Update(MedicalRecord medicalRecord)
        {
            MedicalRecord findedMedicalRecord = GetById(medicalRecord.Id);

            if (findedMedicalRecord != null)
            {
                findedMedicalRecord.Text = medicalRecord.Text;

                _context.MedicalRecords.Update(findedMedicalRecord);
                _context.SaveChanges();
            }
        }
    }
}
