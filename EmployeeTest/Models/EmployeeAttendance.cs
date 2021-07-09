using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeTest.Models
{
    public class EmployeeAttendance
    {
        [Key]
        public int Attendance_Id { get; set; }
        public Nullable<int> Employee_Id { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Date { get; set; }
        public string Attendance_Status { get; set; }
        public Employee Employee { get; set; }

    }
}