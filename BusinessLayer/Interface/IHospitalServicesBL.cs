using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IHospitalServicesBL
    {
        public DoctorEntity AddDoctors(DoctorEntity doctorEntity);
        public HospitalEntity AddHospital(HospitalEntity hospitalEntity);
        public bool RemoveDoctor(int DoctorID);
        public string LoginHospital(string Email, string Password);
    }
}

