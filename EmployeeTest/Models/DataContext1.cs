using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeTest.Models
{
    public class DataContext1:DbContext
    {
        public DataContext1():base("con")
        {

        }
        public DbSet<Designation> DesignationMaster { get; set; }
        public DbSet<Employee> EmployeeMaster { get; set; }
        public DbSet<EmployeeAttendance> EmployeeAttendance { get; set; }
    }
}