using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanLayer
{
    public class PatientEntityWithCount
    {
        public int count {  get; set; }
        public IEnumerable<object> patientEntities { get; set; }
    }
}
