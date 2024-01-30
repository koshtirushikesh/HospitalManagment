using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
