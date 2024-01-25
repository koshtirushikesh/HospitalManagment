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
        public PatientEntity AddPatient(PatientEntity patientEntity);
    }
}
