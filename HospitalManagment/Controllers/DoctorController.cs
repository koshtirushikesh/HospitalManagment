using BusinessLayer.Interface;
using CommanLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using RepositoryLayer.JwtToken;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize(Roles = "Doctor")]
        [HttpPatch("changeStatusOfPatient")]
        public IActionResult ChangeStatusOfPatient(int patientId, int doctorAction)
        {
            try
            {
                int DoctorId = Convert.ToInt32(User.FindFirstValue("UserId"));
                PatientModel patientEntity = doctorServicesBL.ChangeStatusOfPatient(patientId, DoctorId, doctorAction);
                if (patientEntity != null)
                {
                    return Ok(new ResponseModel<PatientModel> { IsSucces = true, message = "change status Succesfull", Data = patientEntity });
                };
                return BadRequest(new ResponseModel<string> { IsSucces = false, message = "change status Unsuccesfull" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPatch("changeSatatusOfAppointment")]
        public IActionResult ChangeStatusOfAppointment(bool isExamined, int appointmentId)
        {
            try
            {
                int DoctorId = Convert.ToInt32(User.FindFirstValue("UserId"));
                AppointmentEntity appointmentEntity = doctorServicesBL.ChangeStatusOfAppointment(DoctorId, isExamined, appointmentId);
                if (appointmentEntity != null)
                {
                    return Ok(new ResponseModel<AppointmentEntity> { IsSucces = true, message = "change status Succesfull", Data = appointmentEntity });
                };
                return BadRequest(new ResponseModel<string> { IsSucces = false, message = "change status Unsuccesfull" });
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
                    return Ok(new ResponseModel<IEnumerable<PatientEntity>> { IsSucces = true, message = "succesfully get all patient", Data = listOfPatient });
                }
                return BadRequest(new ResponseModel<bool> { IsSucces = false, message = "unsuccesfull to get all patient" });
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("getActivePatient")]
        public IActionResult GetActivePatient()
        {
            try
            {
                int DoctorId = Convert.ToInt32(User.FindFirstValue("UserId"));
                IEnumerable<PatientEntity> patientEntities = doctorServicesBL.GetActivePatient(DoctorId);
                if (patientEntities != null)
                {
                    return Ok(new ResponseModel<IEnumerable<PatientEntity>> { IsSucces = true, message = "Succesfull get all active patient", Data = patientEntities });
                };
                return BadRequest(new ResponseModel<string> { IsSucces = false, message = "unsuccesfull to get all active appointment" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("getActiveAppointments")]
        public IActionResult getActiveAppointment()
        {
            try
            {
                int DoctorId = Convert.ToInt32(User.FindFirstValue("UserId"));
                IEnumerable<AppointmentEntity> patientEntities = doctorServicesBL.getActiveAppointment(DoctorId);
                if (patientEntities != null)
                {
                    return Ok(new ResponseModel<IEnumerable<AppointmentEntity>> { IsSucces = true, message = "Succesfull get all active appointment", Data = patientEntities });
                };
                return BadRequest(new ResponseModel<string> { IsSucces = false, message = "unsuccesfull to get all active appointment" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    } 
}
