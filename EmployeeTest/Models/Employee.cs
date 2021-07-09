using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeTest.Models
{
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }
        [Required]
        public string Employee_First_name { get; set; }
        public string Employee_Middle_name { get; set; }
        [Required]
        public string Employee_Last_Name { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DOB { get; set; }
        [Required]
        public string Employee_Address { get; set; }
        [Required]
        public string City { get; set; }
        public Nullable<int> Designation_Id { get; set; }
        [Required]
        public string Employee_category { get; set; }
        [Required]
        public Nullable<decimal> Employee_Salary { get; set; }
        public Designation Designation { get; set; }

    }
}