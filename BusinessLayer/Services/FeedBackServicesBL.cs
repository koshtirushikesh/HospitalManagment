using BusinessLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class FeedBackServicesBL : IFeedBackServicesBL
    {
        public readonly IFeedBackServices feedBackServices;
        public FeedBackServicesBL(IFeedBackServices feedBackServices)
        {
            this.feedBackServices = feedBackServices;
        }

        public FeedBackEntity AddFeedBack(FeedBackEntity feedBackEntity)
        {
            return feedBackServices.AddFeedBack(feedBackEntity);
        }
    }
}
