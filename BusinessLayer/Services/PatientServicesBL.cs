using BusinessLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class PatientServicesBL : IPatientServicesBL
    {
        private readonly IPatientServices patientServices;
        public PatientServicesBL(IPatientServices patientServices)
        {
            this.patientServices = patientServices;
        }

        public AppointmentEntity AddAppointment(AppointmentEntity appointmentEntity)
        {
            return patientServices.AddAppointment(appointmentEntity);
        }

        public string LoginUser(string Email, string Password)
        {
            return patientServices.LoginUser(Email, Password);  
        }

        public AppointmentEntity ViewAppointment(int userId)
        {
            return patientServices.ViewAppointment(userId);
        }
    }
}
