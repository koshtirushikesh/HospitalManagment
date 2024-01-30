using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorFeedBack = RepositoryLayer.Entity.DoctorFeedBack;

namespace RepositoryLayer.Services
{
    public class DoctorFeedBackServices : IDoctorFeedBackServices
    {
        private readonly HospitalManagmentContext hospitalManagmentContext;
        public DoctorFeedBackServices(HospitalManagmentContext hospitalManagmentContext)
        {
            this.hospitalManagmentContext = hospitalManagmentContext;
        }

        public DoctorFeedBack AddFeedback(DoctorFeedBack doctorFeedBack)
        {
            DoctorFeedBack doctorFeedBackServices = hospitalManagmentContext.DoctorFeedBack.FirstOrDefault(x=> x.DoctorID == doctorFeedBack.DoctorID);
            if(doctorFeedBackServices == null)
            {
                DoctorFeedBack doctor = new DoctorFeedBack();
                doctor.DoctorID = doctorFeedBack.DoctorID;
                doctor.PatientID = doctorFeedBack.PatientID;
                doctor.Description = doctorFeedBack.Description;
                doctor.Rating = doctorFeedBack.Rating;

                hospitalManagmentContext.DoctorFeedBack.Add(doctor);
                hospitalManagmentContext.SaveChanges();
                return doctor;
            }
            return null;
        }

        public DoctorFeedBack UpdateFeedback(int DoctorId,int PatientID,string Description,int Rating)
        {
            try
            {
                DoctorFeedBack doctorFeedBackServices = hospitalManagmentContext.DoctorFeedBack.FirstOrDefault(x => x.DoctorID == DoctorId && x.PatientID == PatientID);
                if (doctorFeedBackServices != null)
                {
                    doctorFeedBackServices.Description = Description;
                    doctorFeedBackServices.Rating = Rating;
                    hospitalManagmentContext.SaveChanges();
                    return doctorFeedBackServices;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<DoctorFeedBack> GetFeedbacks(int patientId)
        {
            try
            {
                IEnumerable<DoctorFeedBack> listOfDoctorFeedBack = hospitalManagmentContext.DoctorFeedBack.Where(x => x.PatientID == patientId);
                if (listOfDoctorFeedBack.Any())
                {
                    return listOfDoctorFeedBack;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
