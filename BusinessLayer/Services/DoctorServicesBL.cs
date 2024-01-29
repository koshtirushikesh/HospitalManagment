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
    public class DoctorServicesBL : IDoctorServicesBL
    {
        private readonly IDoctorServices doctorServices;
        public DoctorServicesBL(IDoctorServices doctorServices)
        {
            this.doctorServices = doctorServices;
        }

        public string LoginDoctor(string Email, string Password)
        {
            return doctorServices.LoginDoctor(Email, Password);
        }

        public IEnumerable<AppointmentEntity> ViewAppointment(int DoctorID)
        {
            return doctorServices.ViewAppointment(DoctorID);
        }

        public IEnumerable<PatientEntity> ViewPatient(int DoctorID)
        {
            return doctorServices.ViewPatient(DoctorID);
        }
    }
}
