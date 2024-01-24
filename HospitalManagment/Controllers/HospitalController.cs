using BusinessLayer.Interface;
using CommanLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using RepositoryLayer.JwtToken;
using System.Data;
using System.Security.Claims;

namespace HospitalManagment.Controllers
{
    public class HospitalController : Controller
    {
        private readonly IHospitalServicesBL hospitalServicesBL;
        public HospitalController(IHospitalServicesBL hospitalServicesBL)
        {
            this.hospitalServicesBL = hospitalServicesBL;
        }

        [Authorize(Roles = "Hospital")]
        [HttpPost("AddDoctor")]
        public IActionResult AddDoctor(DoctorEntity doctorEntity) 
        {
            DoctorEntity doctor = hospitalServicesBL.AddDoctors(doctorEntity);
            if (doctor != null)
            {
                return Ok(new ResponseModel<DoctorEntity> { IsSucces = true , message="Doctor added succesfully", Data=doctor});
            }
            return BadRequest(new ResponseModel<DoctorEntity> { IsSucces = false, message = "unable to add Doctor", Data = doctor });
        }

        [Authorize(Roles ="Hospital")]
        [HttpPost("AddHospital")]
        public IActionResult AddHospital(HospitalEntity hospitalEntity)
        {
            HospitalEntity hospital = hospitalServicesBL.AddHospital(hospitalEntity);
            if(hospital != null)
            {
                return Ok(new ResponseModel<HospitalEntity> { IsSucces = true, message = "Hospital added succesfully", Data = hospital });
            }
            return BadRequest(new ResponseModel<string> { IsSucces = false , message = "unable to add hospital"});
        }

        [Authorize(Roles = "Hospital")]
        [HttpDelete("RemoveDoctor")]
        public IActionResult RemoveDoctor(int DoctorId)
        {
            bool result = hospitalServicesBL.RemoveDoctor(DoctorId);
            if (result)
            {
                return Ok(new ResponseModel<bool> { IsSucces = true, message = "doctor deleted succesfully" });
            }
            return BadRequest(new ResponseModel<bool> { IsSucces = false, message = "unable to delete the doctor" });
        }

        [HttpGet("LoginHospital")]
        public IActionResult LoginHospital(string Email , string Password)
        {
            string token = hospitalServicesBL.LoginHospital(Email,Password);
            if(token != null)
            {
                return Ok(new ResponseModel<string> { IsSucces = true, message = "Login succesfull", Data = token });
            }
            return BadRequest(new ResponseModel<bool> { IsSucces = false, message = "Login unsuccesfull" });
        }

        [HttpGet("GetDoctors")]
        public IActionResult ViewDoctors()
        {
            int hospitalId = Convert.ToInt32(User.FindFirstValue("UserID"));
            IEnumerable<DoctorEntity> listOfDoctors = hospitalServicesBL.ViewDoctors(hospitalId);
            if (listOfDoctors  != null)
            {
                return Ok(new ResponseModel<IEnumerable<DoctorEntity>> { IsSucces = true, message = "succesfully get doctors", Data = listOfDoctors });
            }
            return BadRequest(new ResponseModel<string> { IsSucces = true, message = "unsuccesfully to get doctors" ,Data = null });
        }

        [HttpGet("GetHOspital")]
        public IActionResult ViewHospital(int hospitalId)
        {
            HospitalEntity hospitalEntity =hospitalServicesBL.ViewHOspital(hospitalId);
            if(hospitalEntity != null)
            {
                return Ok(new ResponseModel<HospitalEntity> { IsSucces = true, message = "succesfully get hospital data", Data = hospitalEntity });
            }
            return BadRequest(new ResponseModel<string> { IsSucces=true , message="can not get hospital data"});
        }
    }
}
