using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IFeedBackServices
    {
        public FeedBackEntity AddFeedBack(FeedBackEntity feedBackEntity);
        public IEnumerable<FeedBackEntity> GetFeedBackEntities(int PatientId);
        public FeedBackEntity UpdateFeedback(int rating, string Discrpction, int AppointmentId,int patientId);
    }
}
