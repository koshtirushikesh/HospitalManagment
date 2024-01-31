using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class PatientEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string PatientAddress { get; set; }
        [ForeignKey("Hospitals")]
        public int HospitalID { get; set; }
        [ForeignKey("Doctors")]
        public int DoctorID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int DoctorAction { get; set; } = 0;
    }
}
