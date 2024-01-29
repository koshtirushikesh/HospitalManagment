using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IFeedBackServicesBL
    {
        public FeedBackEntity AddFeedBack(FeedBackEntity feedBackEntity);
        public IEnumerable<FeedBackEntity> GetFeedBackEntities(int PatientId);
    }
}
