using BusinessLayer.Interface;
using CommanLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System.Security.Claims;

namespace HospitalManagment.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorServicesBL doctorServicesBL;
        public DoctorController(IDoctorServicesBL doctorServicesBL)
        {
            this.doctorServicesBL = doctorServicesBL;
        }

        [HttpGet("LoginDoctor")]
        public IActionResult LoginDoctor(string Email, string Password)
        {
            try
            {
                string token = doctorServicesBL.LoginDoctor(Email, Password);
                if (token != null)
                {
                    return Ok(new ResponseModel<string> { IsSucces = true, message = "Login Succesfull", Data = token });
                };
                return BadRequest(new ResponseModel<string> { IsSucces = false, message = "Login Unsuccesfull" });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [Authorize(Roles = "Doctor")]
        [HttpGet("getPatients")]
        public IActionResult ViewPatient()
        {
            try
            {
                int DoctorId = Convert.ToInt32(User.FindFirstValue("UserId"));
                IEnumerable<PatientEntity> listOfPatient = doctorServicesBL.ViewPatient(DoctorId);
                if (listOfPatient != null)
                {
                    return Ok(new ResponseModel<IEnumerable<PatientEntity>> { IsSucces = true, message = "succesfully get all patient" ,Data=listOfPatient });
                }
                return BadRequest(new ResponseModel<bool> { IsSucces = false, message = "unsuccesfull to get all patient" });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("getAppointments")]
        public IActionResult ViewAppointment()
        {
            try
            {
                int DoctorId = Convert.ToInt32(User.FindFirstValue("UserId"));
                IEnumerable<AppointmentEntity> listOfPatient = doctorServicesBL.ViewAppointment(DoctorId);
                if (listOfPatient.Any())
                {
                    return Ok(new ResponseModel<IEnumerable<AppointmentEntity>> { IsSucces = true, message = "succesfully get all appointment", Data = listOfPatient });
                }
                return BadRequest(new ResponseModel<bool> { IsSucces = false, message = "unsuccesfull to get all appointment" });
            }
            catch(Exception ex)
            {
                throw ex;   
            }
        }

    }
}
