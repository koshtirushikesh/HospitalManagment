using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Services
{
    public class FeedBackServices:IFeedBackServices
    {
        private readonly HospitalManagmentContext hospitalManagmentContext;
        public FeedBackServices(HospitalManagmentContext hospitalManagmentContext)
        {
            this.hospitalManagmentContext = hospitalManagmentContext;
        }
        public FeedBackEntity AddFeedBack(FeedBackEntity feedBackEntity)
        {
            try
            {
                FeedBackEntity feedBack = new FeedBackEntity();
                if(!hospitalManagmentContext.FeedBack.Any(x => x.AppointmentId == feedBackEntity.AppointmentId))
                {
                    feedBack.AppointmentId = feedBackEntity.AppointmentId;
                    feedBack.Description = feedBackEntity.Description;
                    feedBack.Rating = feedBackEntity.Rating;
                    
                    hospitalManagmentContext.FeedBack.Add(feedBack);
                    hospitalManagmentContext.SaveChanges();

                    return feedBack;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<FeedBackEntity> GetFeedBackEntities(int PatientId)
        {
            IEnumerable<FeedBackEntity> entities = hospitalManagmentContext.FeedBack.Where(x=>x.PatientID == PatientId);
            if (entities.Any())
            {
                return entities;
            }
            return null;
        }


    }
}
