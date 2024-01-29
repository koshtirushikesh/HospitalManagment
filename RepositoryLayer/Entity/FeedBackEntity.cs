﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class FeedBackEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedbakId { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public int AppointmentId { get; set; }
        [ForeignKey("Patients")]
        public int PatientID { get; set; }
    }
}
