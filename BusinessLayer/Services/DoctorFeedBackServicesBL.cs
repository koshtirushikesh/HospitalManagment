using BusinessLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class DoctorFeedBackServicesBL : IDoctorFeedBackServicesBL
    {
        private readonly IDoctorFeedBackServices doctorFeedBackServices;
        public DoctorFeedBackServicesBL(IDoctorFeedBackServices doctorFeedBackServices)
        {
            this.doctorFeedBackServices = doctorFeedBackServices;
        }

        public DoctorFeedBack AddFeedback(DoctorFeedBack doctorFeedBack)
        {
            return doctorFeedBackServices.AddFeedback(doctorFeedBack);
        }

        public IEnumerable<DoctorFeedBack> GetFeedbacks(int patientId)
        {
            return doctorFeedBackServices.GetFeedbacks(patientId);
        }

        public DoctorFeedBack UpdateFeedback(int DoctorId, int PatientID, string Description, int Rating)
        {
            return doctorFeedBackServices.UpdateFeedback(DoctorId, PatientID, Description, Rating);
        }
    }
}
