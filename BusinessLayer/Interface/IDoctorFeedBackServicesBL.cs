using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IDoctorFeedBackServicesBL
    {
        public DoctorFeedBack AddFeedback(DoctorFeedBack doctorFeedBack);
        public DoctorFeedBack UpdateFeedback(int DoctorId, int PatientID, string Description, int Rating);
        public IEnumerable<DoctorFeedBack> GetFeedbacks(int patientId);
    }
}
