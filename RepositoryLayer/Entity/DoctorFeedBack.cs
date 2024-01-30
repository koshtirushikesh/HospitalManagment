using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class DoctorFeedBack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorFeedbakId { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        [ForeignKey("Doctors")]
        public int DoctorID { get; set; }
        [ForeignKey("Patients")]
        public int PatientID { get; set; }
    }
}
