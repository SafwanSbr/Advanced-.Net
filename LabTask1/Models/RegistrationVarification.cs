using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabTask1.Models
{
    public class RegistrationVarification
    {
        //3-50 character, only number, spcae, dash allowed
        [Required(ErrorMessage ="*Full Name Required*")]
        [RegularExpression(@"^[A-Za-z. \-]{3, 50}$", ErrorMessage = "Only letters, space, .(dot), -(dash) are allowed. Length must be within 3 to 50")]
        public string Name { get; set; }

        //5 to 7 character, only alphabet, number, dash, underscore allowed
        [Required(ErrorMessage ="*Username Required*")]
        [RegularExpression(@"^[a-zA-Z0-9_-]{5,7}$", ErrorMessage ="Only letters, numbers, _(undescore), -(dash) are allowed. length must within 3 to 7")]
        public string Username { get; set; }
        
        //xx-xxxxx-x@student.aiub.edu
        [Required(ErrorMessage ="*Email Required*")]
        [RegularExpression(@"^\d{2}-\d{5}-\d@student.aiub.edu$", ErrorMessage = "Only Student Mail Id required.")]
        public string Email { get; set; }
        
        //ID; xx-xxxxx-x
        [Required(ErrorMessage ="*Student ID Required*")]
        [RegularExpression(@"^\d{2}-\d{5}-\d{1}$", ErrorMessage = "Use Valid Student ID")]
        public string StudentId { get; set; }
        
        //At least 8 chareacters, 2 alphabet, 1 Number, 2 Special Character. No space allowed.
        [Required(ErrorMessage ="*Password Required*")]
        [RegularExpression(@"^(?=.*[A-Za-z].*[A-Za-z])(?=.*\d)(?=.*[!@#$%^&*()-_+=<>?]).{8,}$")]
        public string Password { get; set;}
        
        [Required(ErrorMessage ="Date Of Birth Required")]
        [Age18Check(ErrorMessage = "You must be at least 18 years old.")]
        public DateTime dob { get; set; }
    }
}