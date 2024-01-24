using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Migrations;

namespace RepositoryLayer.Services
{
    public class HosptialServices : IHospitalServices
    {
        public readonly HospitalManagmentContext hospitalManagmentContext;
        public HosptialServices(HospitalManagmentContext hospitalManagmentContext)
        {
            this.hospitalManagmentContext = hospitalManagmentContext;
        }

        public DoctorEntity AddDoctors(DoctorEntity doctorEntity)
        {
            DoctorEntity doctor = hospitalManagmentContext.Doctors.Where(x => x.DoctorName == doctorEntity.DoctorName).FirstOrDefault();

            if (doctor == null)
            {
                DoctorEntity doc = new DoctorEntity
                {
                    DoctorName = doctorEntity.DoctorName,
                    Qualification = doctorEntity.Qualification,
                    salary = doctorEntity.salary,
                    HospitalId = doctorEntity.HospitalId
                };
                hospitalManagmentContext.Doctors.Add(doc);
                hospitalManagmentContext.SaveChanges();

                return doc;
            }

            return null;
        }

        public HospitalEntity AddHospital(HospitalEntity hospitalEntity)
        {
            HospitalEntity hospital = hospitalManagmentContext.Hospitals.Where(x => x.HospitalName == hospitalEntity.HospitalName && x.HospitalCity == hospitalEntity.HospitalCity).FirstOrDefault();
            if (hospital == null)
            {
                HospitalEntity hospitalRL = new HospitalEntity
                {
                    HospitalAddress = hospitalEntity.HospitalAddress,
                    HospitalCity = hospitalEntity.HospitalCity,
                    HospitalName = hospitalEntity.HospitalName
                };

                hospitalManagmentContext.Hospitals.Add(hospitalRL);
                hospitalManagmentContext.SaveChanges();

                return hospitalRL;
            }
            return null;
        }

        public bool RemoveDoctor(int DoctorID)
        {
            DoctorEntity doctorEntity = hospitalManagmentContext.Doctors.Where( x => x.DoctorID == DoctorID).FirstOrDefault();
            if (doctorEntity != null)
            {
                hospitalManagmentContext.Doctors.Remove(doctorEntity);
                hospitalManagmentContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
