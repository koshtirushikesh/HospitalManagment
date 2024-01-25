using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Services
{
    public class PatientServices:IPatientServices
    {
        private readonly HospitalManagmentContext hospitalManagmentContext;
        public PatientServices(HospitalManagmentContext hospitalManagmentContext)
        {
            this.hospitalManagmentContext = hospitalManagmentContext;
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
    }
}
