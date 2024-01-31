using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanLayer
{
    public class PatientModel
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string PatientAddress { get; set; }
        public int HospitalID { get; set; }
        public int DoctorID { get; set; }
        public int DoctorAction { get; set; } = 0;
    }
}
