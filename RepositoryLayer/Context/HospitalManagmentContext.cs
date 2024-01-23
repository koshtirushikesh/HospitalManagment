using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Context
{
    public class HospitalManagmentContext:DbContext 
    {
        public HospitalManagmentContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<DoctorEntity> Doctors { get; set; }
    }
}
