using CommanLayer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.JwtToken;
using RepositoryLayer.Migrations;
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
            try
            {
                DoctorEntity doctorEntity = hospitalManagmentContext.Doctors.FirstOrDefault(x => x.Email == Email && x.Password == Password);

                if (doctorEntity != null)
                {
                    Token jwtToken = new Token(configuration);
                    string token = jwtToken.GenerateToken(doctorEntity.Email, doctorEntity.DoctorID, "Doctor");
                    return token;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<PatientEntity> ViewPatient(int DoctorID)
        {
            try
            {
                IEnumerable<PatientEntity> listOfPatient = hospitalManagmentContext.Patients.Where(x => x.DoctorID == DoctorID);

                if (listOfPatient != null)
                {
                    return listOfPatient;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<AppointmentEntity> ViewAppointment(int DoctorID)
        {
            try
            {
                IEnumerable<AppointmentEntity> listOfAppointment = hospitalManagmentContext.Appointment.Where(x => x.DoctorId == DoctorID);
                if (listOfAppointment != null)
                {
                    return listOfAppointment;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<PatientEntity> GetActivePatient(int doctorId)
        {
            IEnumerable<PatientEntity> patientEntity = hospitalManagmentContext.Patients.Where(x => x.DoctorID == doctorId && x.DoctorAction == 0);
            if (patientEntity != null)
            {
                return patientEntity;
            }
            return null;
        }

        public IEnumerable<AppointmentEntity> getActiveAppointment(int doctorId)
        {
            return hospitalManagmentContext.Appointment.Where(x => x.DoctorId == doctorId && x.isExamin == false);
        }

        public IEnumerable<PatientEntity> GetOpdPatient(int doctorId)
        {
            return hospitalManagmentContext.Patients.Where(x => x.DoctorID == doctorId && x.DoctorAction == (int)DoctorAction.opd);
        }

        public IEnumerable<PatientEntity> GetIpdPatient(int doctorId)
        {
            return hospitalManagmentContext.Patients.Where(x => x.DoctorID == doctorId && x.DoctorAction == (int)DoctorAction.ipd);
        }

        public PatientModel ChangeStatusOfPatient(int patientId, int DoctorId,int doctorAction)
        {
            PatientEntity patientEntity = hospitalManagmentContext.Patients.FirstOrDefault(x=> x.PatientID==patientId && x.DoctorID == DoctorId);
            PatientModel patient = new PatientModel();

            if (patientEntity != null)
            {
                if(doctorAction== 1)
                {
                    patientEntity.DoctorAction = (int)DoctorAction.opd;
                } 
                if(doctorAction== 2)
                {
                    patientEntity.DoctorAction = (int)DoctorAction.ipd;
                }
                hospitalManagmentContext.SaveChanges();
                patient.PatientID = patientEntity.PatientID;
                patient.PatientName = patientEntity.PatientName;
                patient.PatientAddress = patientEntity.PatientAddress;
                patient.HospitalID = patient.HospitalID;
                patient.DoctorID = patientEntity.DoctorID;
                patient.DoctorAction = patientEntity.DoctorAction;

                return patient;
            }
            return null;
        }
        
        public AppointmentEntity ChangeStatusOfAppointment(int doctorId,bool isExamined,int appointmentId)
        {
            AppointmentEntity appointment = hospitalManagmentContext.Appointment.FirstOrDefault(x => x.AppointmentId == appointmentId && x.DoctorId == doctorId);
            if(appointment != null)
            {
                appointment.isExamin = isExamined;
                hospitalManagmentContext.SaveChanges();
                return appointment;
            }
            return null;
        }
    }
}
