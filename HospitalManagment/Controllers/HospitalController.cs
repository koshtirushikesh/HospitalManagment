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

    }
}
