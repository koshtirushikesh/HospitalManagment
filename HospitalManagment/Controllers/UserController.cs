using BusinessLayer.Interface;
using CommanLayer;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;

namespace HospitalManagment.Controllers
{
    public class UserController : Controller
    {
        private readonly IPatientServicesBL patientServicesBL;
        public UserController(IPatientServicesBL patientServicesBL)
        {
            this.patientServicesBL = patientServicesBL;
        }


        [HttpPost("addAppointment")]
        public IActionResult AddAppointment(AppointmentEntity appointmentEntity)
        {
            AppointmentEntity appointment = patientServicesBL.AddAppointment(appointmentEntity);
            if(appointment != null)
            {
               return Ok(new ResponseModel<AppointmentEntity> { IsSucces = true, message = "succesfully get appointment", Data = appointment });
            }
            return BadRequest(new ResponseModel<AppointmentEntity> { IsSucces = false, message = "unsuccesfully get appointment" });
        }
    }
}
