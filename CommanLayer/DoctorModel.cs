using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommanLayer
{
    public class DoctorModel
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string Qualification { get; set; }
        public int salary { get; set; }
        public int HospitalId { get; set; }
    }
}
