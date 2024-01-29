using BusinessLayer.Interface;
using CommanLayer;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using RepositoryLayer.Migrations;

namespace HospitalManagment.Controllers
{
    public class FeedBackController : Controller
    {
        private readonly IFeedBackServicesBL feedBackServicesBL;
        public FeedBackController(IFeedBackServicesBL feedBackServicesBL)
        {
            this.feedBackServicesBL = feedBackServicesBL;
        }

        [HttpPost("addFeedBack")]
        public IActionResult AddFeedBack(FeedBackEntity feedBackEntity)
        {
            try
            {
                FeedBackEntity feedBack = feedBackServicesBL.AddFeedBack(feedBackEntity);
                if(feedBack != null)
                {
                    return Ok(new ResponseModel<FeedBackEntity> { IsSucces = true, message = "succesfully added feedback", Data = feedBack });   
                }
                return BadRequest(new ResponseModel<AppointmentEntity> { IsSucces = true, message = "unsuccesfull to get appointment"});
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
