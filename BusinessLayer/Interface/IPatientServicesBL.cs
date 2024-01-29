using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IPatientServicesBL
    {
        public AppointmentEntity AddAppointment(AppointmentEntity appointmentEntity);
        public string LoginUser(string Email, string Password);
        public AppointmentEntity ViewAppointment(int userId);
        public PatientEntity AddPatient(PatientEntity patientEntity);
    }
}
