using Hospital_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hospital_Management_System
{
    public class HospitalManagementSystemDBContex: DbContext
    {
        public HospitalManagementSystemDBContex(): base("name=HospitalManagementSystemDBConnection")
        {
            Database.SetInitializer<HospitalManagementSystemDBContex>(new CreateDatabaseIfNotExists<HospitalManagementSystemDBContex>());
        }
        public DbSet<Appoinment> Appoinments { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AssignTest> AssignTests { get; set; }

    }
}