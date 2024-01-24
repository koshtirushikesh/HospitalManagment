using BusinessLayer.Interface;
using CommanLayer;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;

namespace HospitalManagment.Controllers
{
    public class HospitalController : Controller
    {
        private readonly IHospitalServicesBL hospitalServicesBL;
        public HospitalController(IHospitalServicesBL hospitalServicesBL)
        {
            this.hospitalServicesBL = hospitalServicesBL;
        }

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
    }
}
