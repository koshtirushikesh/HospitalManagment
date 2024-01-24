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
    public class HospitalServicesBL:IHospitalServicesBL
    {
        private readonly IHospitalServices hospitalServices;
        public HospitalServicesBL(IHospitalServices hospitalServices)
        {
            this.hospitalServices = hospitalServices;
        }

        public DoctorEntity AddDoctors(DoctorEntity doctorEntity)
        {
            return hospitalServices.AddDoctors(doctorEntity);
        }

        public HospitalEntity AddHospital(HospitalEntity hospitalEntity)
        {
            return hospitalServices.AddHospital(hospitalEntity);
        }

        public bool RemoveDoctor(int DoctorID)
        {
            return hospitalServices.RemoveDoctor(DoctorID);
        }
    }
}
