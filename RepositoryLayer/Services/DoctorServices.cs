﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.JwtToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class DoctorServices:IDoctorServices
    {
        private readonly HospitalManagmentContext hospitalManagmentContext;
        public IConfiguration configuration;
        public DoctorServices(HospitalManagmentContext hospitalManagmentContext, IConfiguration configuration)
        {
            this.hospitalManagmentContext = hospitalManagmentContext;
            this.configuration = configuration;
        }

        public string LoginDoctor(string Email, string Password)
        {
            DoctorEntity doctorEntity = hospitalManagmentContext.Doctors.FirstOrDefault(x => x.Email == Email && x.Password == Password);

            if(doctorEntity != null)
            {
                Token jwtToken = new Token(configuration);
                string token = jwtToken.GenerateToken(doctorEntity.Email, doctorEntity.DoctorID, "Doctor");
                return token;
            }
            return null;
        }

        public PatientEntity AddPatient(PatientEntity patientEntity)
        {
            PatientEntity patient = hospitalManagmentContext.Patients.FirstOrDefault(x=> x.PatientName == patientEntity.PatientName);
            if(patient == null)
            {
                PatientEntity patient1 = new PatientEntity()
                {
                    PatientName = patientEntity.PatientName,
                    PatientAddress = patientEntity.PatientAddress,
                    DoctorID = patientEntity.DoctorID,
                    HospitalID = patientEntity.HospitalID,
                    Email = patientEntity.Email,
                    Password=patientEntity.Password,
                };
                hospitalManagmentContext.Patients.Add(patient1);
                hospitalManagmentContext.SaveChanges();
                return patient1;
            }
            return null;
        }

        public IEnumerable<PatientEntity> ViewPatient(int DoctorID)
        {
            IEnumerable<PatientEntity> listOfPatient = hospitalManagmentContext.Patients.Where(x => x.DoctorID == DoctorID);

            if(listOfPatient != null)
            {
                return listOfPatient;
            }
            return null;
        }

        public IEnumerable<AppointmentEntity> ViewAppointment(int DoctorID)
        {
            IEnumerable<AppointmentEntity> listOfAppointment = hospitalManagmentContext.Appointment.Where(x => x.DoctorId == DoctorID);
            if(listOfAppointment != null)
            {
                return listOfAppointment;
            }
            return null;
        }
    }
}
