using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.JwtToken;

namespace RepositoryLayer.Services
{
    public class PatientServices:IPatientServices
    {
        private readonly HospitalManagmentContext hospitalManagmentContext;
        public IConfiguration configuration;
        public PatientServices(HospitalManagmentContext hospitalManagmentContext,IConfiguration configuration)
        {
            this.hospitalManagmentContext = hospitalManagmentContext;
            this.configuration = configuration;
        }
        public AppointmentEntity AddAppointment(AppointmentEntity appointmentEntity)
        {
            AppointmentEntity appointment =  hospitalManagmentContext.Appointment.Where(x => x.PatientID == appointmentEntity.PatientID && x.AppointmentTime == appointmentEntity.AppointmentTime).FirstOrDefault();
            if (appointment == null)
            {
                AppointmentEntity entity = new AppointmentEntity()
                {
                    AppointmentTime = appointmentEntity.AppointmentTime,
                    DoctorId = appointmentEntity.DoctorId,
                    PatientID = appointmentEntity.PatientID,
                };
                hospitalManagmentContext.Appointment.Add(entity);
                hospitalManagmentContext.SaveChanges();

                return entity;
            }
            return null;
        }

        public string LoginUser(string Email, string Password)
        {
            PatientEntity patient = hospitalManagmentContext.Patients.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();
            if(patient != null)
            {
                Token jwtToken = new Token(configuration);
                return jwtToken.GenerateToken(patient.Email, patient.PatientID, "User");
            }
            return null;
        }

        public AppointmentEntity ViewAppointment(int userId)
        {
            AppointmentEntity appointment = hospitalManagmentContext.Appointment.Where(x => x.PatientID == userId).FirstOrDefault();
            if (appointment != null)
            {
                return appointment;
            }
            return null;
        }
    }
}
