using BusinessLayer.Interface;
using BusinessLayer.Services;
using CommanLayer;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using RepositoryLayer.Migrations;
using System.Security.Claims;

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
            try
            {
                AppointmentEntity appointment = patientServicesBL.AddAppointment(appointmentEntity);
                if (appointment != null)
                {
                    return Ok(new ResponseModel<AppointmentEntity> { IsSucces = true, message = "succesfully get appointment", Data = appointment });
                }
                return BadRequest(new ResponseModel<AppointmentEntity> { IsSucces = false, message = "unsuccesfully get appointment" });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("AddPatient")]
        public IActionResult AddPatient(PatientEntity patientEntity)
        {
            try
            {
                PatientEntity patient = patientServicesBL.AddPatient(patientEntity);
                if (patient != null)
                {
                    return Ok(new ResponseModel<PatientEntity> { IsSucces = true, message = "Succesfully added Patient", Data = patient });
                }
                return BadRequest(new ResponseModel<bool> { IsSucces = false, message = "unsuccesfull to add patient" });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("loginUser")]
        public IActionResult LoginUser(string Email,string Password)
        {
            try
            {
                string token = patientServicesBL.LoginUser(Email, Password);
                if (token != null)
                {
                    return Ok(new ResponseModel<string> { IsSucces = true, message = "succesfull login", Data = token });
                }
                return BadRequest(new ResponseModel<string> { IsSucces = false, message = "unsuccesfull to login" });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("viewAppointment")]
        public IActionResult ViewAppointment()
        {
            try
            {
                int userID = Convert.ToInt32(User.FindFirstValue("UserID"));
                AppointmentEntity appointment = patientServicesBL.ViewAppointment(userID);
                if (appointment != null)
                {
                    return Ok(new ResponseModel<AppointmentEntity> { IsSucces = true, message = "succesfully get the appointment", Data = appointment });
                }
                return BadRequest(new ResponseModel<bool> { IsSucces = false, message = "unsuccesfully to get appointment" });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
