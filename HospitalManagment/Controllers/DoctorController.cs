using BusinessLayer.Interface;
using CommanLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;

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
        public IActionResult LoginDoctor(string Email,string Password)
        {
            string token = doctorServicesBL.LoginDoctor(Email, Password);
            if(token != null)
            {
                return Ok(new ResponseModel<string> { IsSucces = true, message = "Login Succesfull", Data = token });
            };
            return BadRequest(new ResponseModel<string> { IsSucces = false, message = "Login Unsuccesfull" });
        }
    }
}
