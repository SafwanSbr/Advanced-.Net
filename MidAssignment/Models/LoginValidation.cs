using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MidAssignment.Models
{
    public class LoginValidation
    {
        [Required]
        public string Email {  get; set; }

        [Required]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email format")]
        public string Password { get; set; }
        [Required]
        public string UserType { get; set; }
    }
}