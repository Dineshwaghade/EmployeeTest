using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeTest.Models
{
    public class ViewModel
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public Nullable< DateTime >Date { get; set; }
        public string Category { get; set; }
        public Nullable<int> Designation_Id { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public List<Employee> EmployeeList { get; set; }
        public List<EmployeeAttendance> EmployeeAttendanceList { get; set; }

    }
}