using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeTest.Models
{
    public class Designation
    {
        [Key]
        public int Designation_Id { get; set; }
        [Required]
        public string Designation_Desc { get; set; }

    }
}