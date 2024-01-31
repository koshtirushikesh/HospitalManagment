using CommanLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IDoctorServices
    {
        public string LoginDoctor(string Email, string Password);
        public IEnumerable<PatientEntity> ViewPatient(int DoctorID);
        public IEnumerable<AppointmentEntity> ViewAppointment(int DoctorID);
        public PatientModel ChangeStatusOfPatient(int patientId, int DoctorId, int doctorAction);
    }
}
