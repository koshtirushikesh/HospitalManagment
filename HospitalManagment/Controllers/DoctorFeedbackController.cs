using BusinessLayer.Interface;
using CommanLayer;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using RepositoryLayer.JwtToken;
using RepositoryLayer.Migrations;
using System.Security.Claims;
using DoctorFeedBack = RepositoryLayer.Entity.DoctorFeedBack;

namespace HospitalManagment.Controllers
{
    public class DoctorFeedbackController : Controller
    {
        private readonly IDoctorFeedBackServicesBL doctorFeedBackServicesBL;
        public DoctorFeedbackController(IDoctorFeedBackServicesBL doctorFeedBackServicesBL)
        {
            this.doctorFeedBackServicesBL = doctorFeedBackServicesBL;
        }

        [HttpPost("addDoctorFeedback")]
        public IActionResult AddFeedback(DoctorFeedBack doctorFeedBack)
        {
            doctorFeedBack.PatientID = Convert.ToInt32(User.FindFirstValue("UserID"));
            DoctorFeedBack doctor =  doctorFeedBackServicesBL.AddFeedback(doctorFeedBack);
            if(doctor != null)
            {
                return Ok(new ResponseModel<DoctorFeedBack> { IsSucces = true, message = "doctor feed back added succesfully", Data = doctor });
            }

            return BadRequest(new ResponseModel<string> { IsSucces = false, message = "unsuccesfull to add doctor feedback" });
        }

        [HttpPut("updateDoctorFeedback")]
        public IActionResult UpdateFeedback(int DoctorId, string Description, int Rating)
        {
            int patientID = Convert.ToInt32(User.FindFirstValue("UserID"));
            DoctorFeedBack doctor = doctorFeedBackServicesBL.UpdateFeedback(DoctorId,patientID,Description,Rating);
            if (doctor != null)
            {
                return Ok(new ResponseModel<DoctorFeedBack> { IsSucces = true, message = "succesfully update the rating or description", Data = doctor });
            }

            return BadRequest(new ResponseModel<string> { IsSucces = false, message = "succesfully update the rating or description" });
        }
    }
}
