﻿using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IDoctorServicesBL
    {
        public string LoginDoctor(string Email, string Password);
        public PatientEntity AddPatient(PatientEntity patientEntity);
        public IEnumerable<PatientEntity> ViewPatient(int DoctorID);
        public IEnumerable<AppointmentEntity> ViewAppointment(int DoctorID);
    }
}
