using BusinessLayer.Interface;
using CommanLayer;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System.Security.Claims;

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
                if (feedBack != null)
                {
                    return Ok(new ResponseModel<FeedBackEntity> { IsSucces = true, message = "succesfully added feedback", Data = feedBack });
                }
                return BadRequest(new ResponseModel<AppointmentEntity> { IsSucces = false, message = "unsuccesfull to add feedback" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("getFeedbacks")]
        public IActionResult GetFeedBackEntities()
        {
            try
            {
                int PatientId = Convert.ToInt32(User.FindFirstValue("UserID"));
                IEnumerable<FeedBackEntity> feedBacks = feedBackServicesBL.GetFeedBackEntities(PatientId);
                if (feedBacks != null)
                {
                    return Ok(new ResponseModel<IEnumerable<FeedBackEntity>> { IsSucces = true, message = "succesfully get feedbacks", Data = feedBacks });
                }
                return BadRequest(new ResponseModel<bool> { IsSucces = false, message = "unsuccesfully to get feedback" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
