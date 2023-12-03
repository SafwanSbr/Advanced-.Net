using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MidAssignment.Models
{
    public class EmployeeDTO
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}