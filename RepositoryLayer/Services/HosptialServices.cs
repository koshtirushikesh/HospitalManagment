using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class HosptialServices
    {
        public readonly HospitalManagmentContext hospitalManagmentContext;
        public HosptialServices(HospitalManagmentContext hospitalManagmentContext)
        {
            this.hospitalManagmentContext = hospitalManagmentContext;
        }

        public DoctorEntity AddDoctors(DoctorEntity doctorEntity)
        {
            DoctorEntity doctor = hospitalManagmentContext.Doctors.Where( x => x.DoctorName == doctorEntity.DoctorName).FirstOrDefault();

            if (doctor == null)
            {
                DoctorEntity doc = new DoctorEntity
                {
                    DoctorName = doctorEntity.DoctorName,
                    Qualification = doctorEntity.Qualification,
                    salary = doctorEntity.salary
                };
                hospitalManagmentContext.Doctors.Add(doc);
                hospitalManagmentContext.SaveChanges();

                return doc;
            }

            return null;
        }
    }
}
