using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class AppointmentEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentId { get; set; }
        public DateTime AppointmentTime { get; set; }
        [ForeignKey("Doctors")]
        public int DoctorId { get; set; }
        [ForeignKey("Patients")]
        public int PatientID { get; set; }
        [ForeignKey("Hospitals")]
        public int HospitalId { get; set; }
    }
}
